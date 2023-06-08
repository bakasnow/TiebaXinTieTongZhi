using SqlSugar;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using TiebaApi.TiebaJieGou;
using TiebaApi.TiebaWebApi;
using static TiebaXinTieTongZhi.SQLite;

namespace TiebaXinTieTongZhi
{
    public partial class TiebaXinTieTongZhiForm : Form
    {
        public TiebaXinTieTongZhiForm()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
        }

        /// <summary>
        /// 是否更新订阅列表
        /// </summary>
        public static bool IsGengXinDingYue = true;

        /// <summary>
        /// 是否更新设置
        /// </summary>
        public static bool IsGengXinSheZhi = true;

        /// <summary>
        /// WAV文件播放
        /// </summary>
        public static SoundPlayer soundPlayer = new SoundPlayer(Properties.Resources.TiShiYin);

        #region 事件

        /// <summary>
        /// 窗口 创建
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TiebaXinTieTongZhiForm_Load(object sender, EventArgs e)
        {
            //如果勾选开机启动，跳过版本验证
            if (KaiJiQiDong.IsZhuCe() == false)
            {
                //版本验证
                if (!BanBen.GetVersion())
                {
                    Dispose();
                }
            }

            //数据库
            ChuangJianShuJuKu();

            //创建表
            ChuangJianBiao();

            //托盘图标
            notifyIcon1.Icon = Icon;
            notifyIcon1.Visible = true;
            notifyIcon1.BalloonTipIcon = ToolTipIcon.None;

            //标题
            Text = $"贴吧新帖通知 v{BanBen.Version}";

            //启动线程
            MainThread = new Thread(ZhuXianCheng)
            {
                IsBackground = true
            };
            MainThread.Start();
        }

        /// <summary>
        /// 窗口 关闭前
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TiebaXinTieTongZhiForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MainThread == null)
            {
                //这个必须要加，不然关闭程序的时候会被拒绝
                e.Cancel = false;
            }
            else
            {
                WindowState = FormWindowState.Minimized;
                e.Cancel = true;
            }
        }

        /// <summary>
        /// 窗口 状态
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TiebaXinTieTongZhiForm_Resize(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
            {
                ShowInTaskbar = false;
            }
            else
            {
                ShowInTaskbar = true;
            }
        }

        /// <summary>
        /// 列表框 鼠标双击
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ListView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (listView1.SelectedItems.Count == 1)
            {
                int index = listView1.SelectedItems[0].Index; //取当前选中项的index,SelectedItems[0]这必须为0

                if (long.TryParse(listView1.Items[index].SubItems[0].Text, out long tid))
                {
                    Process.Start($"https://tieba.baidu.com/p/{tid}");
                }
            }
        }

        /// <summary>
        /// 托盘图标 气泡被单击
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NotifyIcon1_BalloonTipClicked(object sender, EventArgs e)
        {
            Process.Start(
                new Regex("https://tieba.baidu.com/p/([0-9]*)")
                .Match(notifyIcon1.BalloonTipText).Value
                );
        }

        /// <summary>
        /// 托盘图标 被双击
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NotifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            WindowState = FormWindowState.Normal;
        }

        /// <summary>
        /// 菜单 订阅管理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 订阅管理ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            DingYueGuanLiForm dingYueGuanLiForm = new DingYueGuanLiForm();
            IsGengXinDingYue = false;
            dingYueGuanLiForm.ShowDialog();
            IsGengXinDingYue = true;
        }

        /// <summary>
        /// 菜单 设置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 设置toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            SheZhiForm sheZhiForm = new SheZhiForm();
            IsGengXinSheZhi = false;
            sheZhiForm.ShowDialog();
            IsGengXinSheZhi = true;
        }

        /// <summary>
        /// 菜单 关闭程序
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 关闭程序ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(text: "确定要关闭程序吗？", caption: "笨蛋雪说：", buttons: MessageBoxButtons.YesNo, icon: MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {
                MainThread.Abort();
                MainThread = null;

                Close();
            }
        }

        #endregion

        #region 主线程

        /// <summary>
        /// 主线程
        /// </summary>
        public static Thread MainThread;

        /// <summary>
        /// 主线程
        /// </summary>
        private void ZhuXianCheng()
        {
            //订阅列表
            List<DingYueJieGou> dingYueLieBiao = new List<DingYueJieGou>();

            //设置参数
            SheZhiBiaoJieGou sheZhiCanShu = new SheZhiBiaoJieGou();

            while (true)
            {
                //是否需要更新贴吧列表
                if (IsGengXinDingYue)
                {
                    //从数据库获取订阅列表
                    List<DingYueJieGou> tempDingYueLieBiao = new List<DingYueJieGou>();
                    foreach (var dylb in sqlSugarClient.Queryable<DingYueLieBiaoJieGou>().ToList())
                    {
                        tempDingYueLieBiao.Add(new DingYueJieGou
                        {
                            TiebaName = dylb.TiebaName,
                            SaoMiaoJianGe = dylb.SaoMiaoJianGe,
                            XiaCiHuoQuShiJian = DateTime.Now,
                            IsShanChu = false
                        });
                    }

                    //更新订阅列表
                    foreach (var dingYue in dingYueLieBiao)
                    {
                        //删除
                        dingYue.IsShanChu = true;

                        //如果老列表的贴吧在临时列表中存在
                        if (tempDingYueLieBiao.Count(tdy => tdy.TiebaName == dingYue.TiebaName) > 0)
                        {
                            //保留
                            dingYue.IsShanChu = false;
                        }
                    }

                    //更新订阅列表
                    foreach (var tempDingYue in tempDingYueLieBiao)
                    {
                        //如果临时列表中的贴吧在老列表中存在
                        if (dingYueLieBiao.Any(dy => dy.TiebaName == tempDingYue.TiebaName))
                        {
                            continue;
                        }

                        //新增
                        dingYueLieBiao.Add(tempDingYue);

                        //初始化缓存
                        TiebaWebZhuTi tiebaZhuTi = new TiebaWebZhuTi(tempDingYue.TiebaName);
                        for (int pn = 1; pn <= 3; pn++)
                        {
                            foreach (TiebaWebZhuTiJieGou zhuTi in tiebaZhuTi.Get(pn: pn, isFaBuPaiXu: true))
                            {
                                //跳过置顶、会员置顶、话题
                                if (zhuTi.IsZhiDing || zhuTi.IsHuiYuanZhiDing || zhuTi.IsHuaTi)
                                {
                                    continue;
                                }

                                //添加Tid缓存
                                if (TidHuanCun.IsCunZai(zhuTi.Tid) == false)
                                {
                                    TidHuanCun.TianJia(new TidHuanCunBiaoJieGou
                                    {
                                        Tid = zhuTi.Tid,
                                        TiebaName = tempDingYue.TiebaName,
                                        TianJiaShiJian = DateTime.Now
                                    });
                                }
                            }
                        }
                    }

                    //删除被标记的贴吧
                    dingYueLieBiao.RemoveAll(dy => dy.IsShanChu);

                    IsGengXinDingYue = false;
                }

                //是否更新设置
                if (IsGengXinSheZhi)
                {
                    sheZhiCanShu = sqlSugarClient.Queryable<SheZhiBiaoJieGou>().First(sz => sz.SheZhiID == 1);

                    IsGengXinSheZhi = false;
                }

                //遍历订阅列表
                for (int i = 0; i < dingYueLieBiao.Count; i++)
                {
                    //扫描间隔
                    if (DateTime.Now < dingYueLieBiao[i].XiaCiHuoQuShiJian)
                    {
                        Thread.Sleep(100);
                        continue;
                    }

                    List<TiebaWebZhuTiJieGou> tiebaZhuTiLieBiao = new TiebaWebZhuTi(dingYueLieBiao[i].TiebaName).Get(isFaBuPaiXu: true);
                    foreach (var zhuTi in tiebaZhuTiLieBiao)
                    {
                        //跳过置顶、会员置顶、话题
                        if (zhuTi.IsZhiDing || zhuTi.IsHuiYuanZhiDing || zhuTi.IsHuaTi)
                        {
                            continue;
                        }

                        //帖子在缓存中存在
                        if (TidHuanCun.IsCunZai(zhuTi.Tid))
                        {
                            continue;
                        }

                        ListViewItem listViewItem = new ListViewItem
                        {
                            Text = Convert.ToString(zhuTi.Tid)
                        };
                        listViewItem.SubItems.Add(dingYueLieBiao[i].TiebaName);
                        listViewItem.SubItems.Add(zhuTi.BiaoTi);
                        listViewItem.SubItems.Add(zhuTi.NiCheng);
                        listViewItem.SubItems.Add(zhuTi.FaTieShiJian.ToString("MM/dd HH:mm:ss"));

                        //插到第一行
                        listView1.Items.Insert(0, listViewItem);

                        //提示音
                        soundPlayer.Play();

                        //通知弹窗
                        TongZhiForm tongZhiForm = new TongZhiForm
                        {
                            TiebaName = dingYueLieBiao[i].TiebaName,
                            Tid = zhuTi.Tid,
                            BiaoTi = zhuTi.BiaoTi,
                            LouZhu = zhuTi.NiCheng,
                            XuHao = 1,
                            TongZhiZiDongGuanBiShiJian = Convert.ToInt32(sheZhiCanShu.TongZhiZiDongGuanBiShiJian)
                        };
                        SetShowChartForm(tongZhiForm);

                        //添加Tid缓存
                        if (TidHuanCun.IsCunZai(zhuTi.Tid) == false)
                        {
                            TidHuanCun.TianJia(new TidHuanCunBiaoJieGou
                            {
                                Tid = zhuTi.Tid,
                                TiebaName = dingYueLieBiao[i].TiebaName,
                                TianJiaShiJian = DateTime.Now
                            });
                        }
                    }

                    //更新下次获取时间
                    dingYueLieBiao[i].XiaCiHuoQuShiJian = DateTime.Now.AddSeconds(dingYueLieBiao[i].SaoMiaoJianGe);
                }

                Thread.Sleep(100);
            }
        }

        #endregion

        #region 函数

        public delegate void SetShowChartFormInvoke(Form myform);

        public void SetShowChartForm(Form myform)
        {
            if (this.InvokeRequired)
            {
                SetShowChartFormInvoke _setShowChartFormInvoke = new SetShowChartFormInvoke(SetShowChartForm);
                this.Invoke(_setShowChartFormInvoke, new object[] { myform });
            }
            else
            {
                myform.Show();
            }
        }

        #endregion

        #region 结构

        /// <summary>
        /// 订阅结构
        /// </summary>
        public class DingYueJieGou
        {
            /// <summary>
            /// 贴吧名
            /// </summary>
            public string TiebaName;

            /// <summary>
            /// 扫描间隔
            /// </summary>
            public long SaoMiaoJianGe;

            /// <summary>
            /// 下次获取时间
            /// </summary>
            public DateTime XiaCiHuoQuShiJian;

            /// <summary>
            /// 是否删除
            /// </summary>
            public bool IsShanChu;
        }

        /// <summary>
        /// 缓存结构
        /// </summary>
        public class HuanCunJieGou
        {
            /// <summary>
            /// 帖号
            /// </summary>
            public long Tid;

            /// <summary>
            /// 发帖时间
            /// </summary>
            public DateTime FaTieShiJian;

            /// <summary>
            /// 添加时间
            /// </summary>
            public DateTime TianJiaShiJian;
        }

        #endregion

    }
}
