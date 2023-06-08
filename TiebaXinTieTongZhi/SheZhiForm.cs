using Microsoft.Win32;
using SqlSugar;
using System;
using System.Windows.Forms;
using static TiebaXinTieTongZhi.SQLite;

namespace TiebaXinTieTongZhi
{
    public partial class SheZhiForm : Form
    {
        public SheZhiForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 窗口 创建
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SheZhiForm_Load(object sender, EventArgs e)
        {
            Text = "设置";

            SheZhiBiaoJieGou sheZhi = sqlSugarClient.Queryable<SheZhiBiaoJieGou>().First(sz => sz.SheZhiID == 1);

            textBox_TongZhiZiDongGuanBiShiJian.Text = sheZhi.TongZhiZiDongGuanBiShiJian;

            label_TidHuanCunShu.Text = $"帖号缓存总数 {sqlSugarClient.Queryable<TidHuanCunBiaoJieGou>().Count()} 条";

            // 是否注册开机启动
            checkBox_KaiJiQiDong.Checked = KaiJiQiDong.IsZhuCe();
        }

        /// <summary>
        /// 按钮 清除Tid缓存 被单击
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_QingChuTidHuanCun_Click(object sender, EventArgs e)
        {
            bool jieGuo = sqlSugarClient.DbMaintenance.TruncateTable<TidHuanCunBiaoJieGou>();
            if (jieGuo == false)
            {
                MessageBox.Show(text: "清除失败，请联系作者。", caption: "笨蛋雪说：", buttons: MessageBoxButtons.OK, icon: MessageBoxIcon.Error);
            }

            label_TidHuanCunShu.Text = $"帖号缓存总数 {sqlSugarClient.Queryable<TidHuanCunBiaoJieGou>().Count()} 条";
        }

        /// <summary>
        /// 多选框 开机启动 被选中
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CheckBox_KaiJiQiDong_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_KaiJiQiDong.Checked)
            {
                if (KaiJiQiDong.ZhuCe() == false)
                {
                    MessageBox.Show(text: "开机启动注册失败，请联系作者。", caption: "笨蛋雪说：", buttons: MessageBoxButtons.OK, icon: MessageBoxIcon.Error);
                }
            }
            else
            {
                if (KaiJiQiDong.ShanChu() == false)
                {
                    MessageBox.Show(text: "取消开机启动失败，请联系作者。", caption: "笨蛋雪说：", buttons: MessageBoxButtons.OK, icon: MessageBoxIcon.Error);
                }
            }
        }

        /// <summary>
        /// 按钮 保存 被单击
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_BaoCun_Click(object sender, EventArgs e)
        {
            SheZhiBiaoJieGou sheZhiBiaoJieGou = new SheZhiBiaoJieGou
            {
                SheZhiID = 1,
                TongZhiZiDongGuanBiShiJian = textBox_TongZhiZiDongGuanBiShiJian.Text
            };

            //更新
            sqlSugarClient.Updateable(sheZhiBiaoJieGou).ExecuteCommand();

            Close();
        }
    }
}
