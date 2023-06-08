using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TiebaApi.TiebaAppApi;
using static TiebaXinTieTongZhi.SQLite;

namespace TiebaXinTieTongZhi
{
    public partial class DingYueGuanLiForm : Form
    {
        public DingYueGuanLiForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 窗口 创建
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DingYueGuanLiForm_Load(object sender, EventArgs e)
        {
            Text = "订阅管理";

            List<DingYueLieBiaoJieGou> dingYueLieBiao = sqlSugarClient.Queryable<DingYueLieBiaoJieGou>().ToList();
            foreach (var dingYue in dingYueLieBiao)
            {
                ListViewItem listViewItem = new ListViewItem
                {
                    Text = Convert.ToString(dingYue.TiebaName)
                };
                listViewItem.SubItems.Add(dingYue.SaoMiaoJianGe == 0 ? "自动" : $"{dingYue.SaoMiaoJianGe}秒");
                listView1.Items.Add(listViewItem);
            }
        }

        /// <summary>
        /// 按钮 新增 被单击
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_XinZeng_Click(object sender, EventArgs e)
        {
            //弹框
            string tiebaName = Interaction.InputBox("请输入贴吧名，不带结尾的“吧”字。\n\n例：地下城与勇士吧，填写“地下城与勇士”", "添加贴吧", "地下城与勇士");
            if (string.IsNullOrEmpty(tiebaName))
            {
                return;
            }

            if (long.TryParse(Interaction.InputBox("请输入扫描间隔（秒）\n\n注：建议不要低于15秒", "扫描间隔", "60"), out long saoMiaoJianGe) == false)
            {
                saoMiaoJianGe = 60;
            }

            DingYueLieBiaoJieGou dingYueLieBiaoJieGou = new DingYueLieBiaoJieGou
            {
                TiebaName = tiebaName,
                SaoMiaoJianGe = saoMiaoJianGe
            };

            if (sqlSugarClient.Queryable<DingYueLieBiaoJieGou>().Count(dy => dy.TiebaName == tiebaName) > 0)
            {
                //更新
                if (sqlSugarClient.Updateable(dingYueLieBiaoJieGou).ExecuteCommand() <= 0)
                {
                    MessageBox.Show("订阅更新失败", "笨蛋雪说：", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                for (int i = 0; i < listView1.Items.Count; i++)
                {
                    if (listView1.Items[i].Text == tiebaName)
                    {
                        listView1.Items[i].SubItems[1].Text = $"{saoMiaoJianGe}秒";
                    }
                }
            }
            else
            {
                //新增
                if (sqlSugarClient.Insertable(dingYueLieBiaoJieGou).ExecuteCommand() <= 0)
                {
                    MessageBox.Show("订阅新增失败", "笨蛋雪说：", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                //新增
                ListViewItem listViewItem = new ListViewItem
                {
                    Text = Convert.ToString(tiebaName)
                };
                listViewItem.SubItems.Add($"{saoMiaoJianGe}秒");
                listView1.Items.Insert(0, listViewItem);//直接加到最前面
            }
        }

        /// <summary>
        /// 按钮 删除 被单击
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_ShanChu_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count <= 0) return;

            string tiebaName = listView1.SelectedItems[0].SubItems[0].Text;

            if (MessageBox.Show($"确定要删除{tiebaName}吧吗？", "笨蛋雪说：", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.No)
            {
                return;
            }

            if (sqlSugarClient.Deleteable<DingYueLieBiaoJieGou>().Where(dy => dy.TiebaName == tiebaName).ExecuteCommand() <= 0)
            {
                MessageBox.Show("账号删除失败", "笨蛋雪说：", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            listView1.SelectedItems[0].Remove();
        }
    }
}
