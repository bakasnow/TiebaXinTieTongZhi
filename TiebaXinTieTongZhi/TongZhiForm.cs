using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TiebaXinTieTongZhi
{
    public partial class TongZhiForm : Form
    {
        public TongZhiForm()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
        }

        [DllImport("user32")]
        private static extern bool AnimateWindow(IntPtr hwnd, int dwTime, int dwFlags);

        //下面是可用的常量，根据不同的动画效果声明自己需要的
        //private const int AW_HOR_POSITIVE = 0x0001;//自左向右显示窗口，该标志可以在滚动动画和滑动动画中使用。使用AW_CENTER标志时忽略该标志
        //private const int AW_HOR_NEGATIVE = 0x0002;//自右向左显示窗口，该标志可以在滚动动画和滑动动画中使用。使用AW_CENTER标志时忽略该标志
        //private const int AW_VER_POSITIVE = 0x0004;//自顶向下显示窗口，该标志可以在滚动动画和滑动动画中使用。使用AW_CENTER标志时忽略该标志
        private const int AW_VER_NEGATIVE = 0x0008;//自下向上显示窗口，该标志可以在滚动动画和滑动动画中使用。使用AW_CENTER标志时忽略该标志该标志
                                                   //private const int AW_CENTER = 0x0010;//若使用了AW_HIDE标志，则使窗口向内重叠；否则向外扩展
        private const int AW_HIDE = 0x10000;//隐藏窗口
        private const int AW_ACTIVE = 0x20000;//激活窗口，在使用了AW_HIDE标志后不要使用这个标志
        private const int AW_SLIDE = 0x40000;//使用滑动类型动画效果，默认为滚动动画类型，当使用AW_CENTER标志时，这个标志就被忽略
        private const int AW_BLEND = 0x80000;//使用淡入淡出效果

        /// <summary>
        /// 序号
        /// </summary>
        public int XuHao;

        /// <summary>
        /// 贴吧名
        /// </summary>
        public string TiebaName;

        /// <summary>
        /// 帖号
        /// </summary>
        public long Tid;

        /// <summary>
        /// 标题
        /// </summary>
        public string BiaoTi;

        /// <summary>
        /// 楼主
        /// </summary>
        public string LouZhu;

        /// <summary>
        /// 通知自动关闭时间
        /// </summary>
        public int TongZhiZiDongGuanBiShiJian;

        /// <summary>
        /// 通知持续时间
        /// </summary>
        private int TongZhiChiXuShiJian = 0;

        /// <summary>
        /// 动画持续时间
        /// </summary>
        private const int DongHuaChiXuShiJian = 500;

        /// <summary>
        /// 窗口 创建
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TongZhiForm_Load(object sender, EventArgs e)
        {
            label_tiebaName.Text = $"{TiebaName}吧 - {LouZhu}";
            label_biaoTi.Text = BiaoTi;

            int x = Screen.PrimaryScreen.WorkingArea.Right - Width;
            int y = Screen.PrimaryScreen.WorkingArea.Bottom - Height * XuHao;
            Location = new Point(x, y);//设置窗体在屏幕右下角显示
            AnimateWindow(Handle, DongHuaChiXuShiJian, AW_SLIDE | AW_ACTIVE | AW_VER_NEGATIVE);

            if (TongZhiZiDongGuanBiShiJian != 0)
            {
                timer1.Interval = 1000;
                timer1.Start();
            }
        }

        /// <summary>
        /// 窗口 关闭前
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TongZhiForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            AnimateWindow(Handle, DongHuaChiXuShiJian, AW_BLEND | AW_HIDE);
        }

        /// <summary>
        /// 标签 标题 被单击
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Label_BiaoTi_Click(object sender, EventArgs e)
        {
            Process.Start($"https://tieba.baidu.com/p/{Tid}");
            AnimateWindow(Handle, DongHuaChiXuShiJian, AW_BLEND | AW_HIDE);
        }

        /// <summary>
        /// 标签 关闭 被单击
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Label_GuanBi_Click(object sender, EventArgs e)
        {
            AnimateWindow(Handle, DongHuaChiXuShiJian, AW_BLEND | AW_HIDE);
        }

        /// <summary>
        /// 时钟 滴答
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Timer1_Tick(object sender, EventArgs e)
        {
            label_GuanBi.Text = $"关闭({TongZhiZiDongGuanBiShiJian - TongZhiChiXuShiJian})";

            //如果通知持续时间 小于 通知自动关闭时间
            if (TongZhiChiXuShiJian < TongZhiZiDongGuanBiShiJian)
            {
                TongZhiChiXuShiJian++;
            }
            else
            {
                AnimateWindow(Handle, DongHuaChiXuShiJian, AW_BLEND | AW_HIDE);
            }
        }
    }
}
