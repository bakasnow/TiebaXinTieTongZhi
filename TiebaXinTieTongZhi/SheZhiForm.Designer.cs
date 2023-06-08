namespace TiebaXinTieTongZhi
{
    partial class SheZhiForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_TongZhiZiDongGuanBiShiJian = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.button_BaoCun = new System.Windows.Forms.Button();
            this.label_TidHuanCunShu = new System.Windows.Forms.Label();
            this.button_QingChuTidHuanCun = new System.Windows.Forms.Button();
            this.checkBox_KaiJiQiDong = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "通知自动关闭时间";
            // 
            // textBox_TongZhiZiDongGuanBiShiJian
            // 
            this.textBox_TongZhiZiDongGuanBiShiJian.Location = new System.Drawing.Point(124, 17);
            this.textBox_TongZhiZiDongGuanBiShiJian.Margin = new System.Windows.Forms.Padding(0);
            this.textBox_TongZhiZiDongGuanBiShiJian.Name = "textBox_TongZhiZiDongGuanBiShiJian";
            this.textBox_TongZhiZiDongGuanBiShiJian.Size = new System.Drawing.Size(30, 21);
            this.textBox_TongZhiZiDongGuanBiShiJian.TabIndex = 1;
            this.textBox_TongZhiZiDongGuanBiShiJian.Text = "15";
            this.textBox_TongZhiZiDongGuanBiShiJian.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(157, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(17, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "秒";
            // 
            // button_BaoCun
            // 
            this.button_BaoCun.Location = new System.Drawing.Point(195, 122);
            this.button_BaoCun.Margin = new System.Windows.Forms.Padding(0);
            this.button_BaoCun.Name = "button_BaoCun";
            this.button_BaoCun.Size = new System.Drawing.Size(80, 30);
            this.button_BaoCun.TabIndex = 4;
            this.button_BaoCun.Text = "保存并应用";
            this.button_BaoCun.UseVisualStyleBackColor = true;
            this.button_BaoCun.Click += new System.EventHandler(this.Button_BaoCun_Click);
            // 
            // label_TidHuanCunShu
            // 
            this.label_TidHuanCunShu.AutoSize = true;
            this.label_TidHuanCunShu.Location = new System.Drawing.Point(20, 50);
            this.label_TidHuanCunShu.Name = "label_TidHuanCunShu";
            this.label_TidHuanCunShu.Size = new System.Drawing.Size(107, 12);
            this.label_TidHuanCunShu.TabIndex = 5;
            this.label_TidHuanCunShu.Text = "帖号缓存总数 0 条";
            // 
            // button_QingChuTidHuanCun
            // 
            this.button_QingChuTidHuanCun.Location = new System.Drawing.Point(185, 44);
            this.button_QingChuTidHuanCun.Margin = new System.Windows.Forms.Padding(0);
            this.button_QingChuTidHuanCun.Name = "button_QingChuTidHuanCun";
            this.button_QingChuTidHuanCun.Size = new System.Drawing.Size(90, 25);
            this.button_QingChuTidHuanCun.TabIndex = 6;
            this.button_QingChuTidHuanCun.Text = "清除帖号缓存";
            this.button_QingChuTidHuanCun.UseVisualStyleBackColor = true;
            this.button_QingChuTidHuanCun.Click += new System.EventHandler(this.Button_QingChuTidHuanCun_Click);
            // 
            // checkBox_KaiJiQiDong
            // 
            this.checkBox_KaiJiQiDong.AutoSize = true;
            this.checkBox_KaiJiQiDong.Location = new System.Drawing.Point(22, 130);
            this.checkBox_KaiJiQiDong.Name = "checkBox_KaiJiQiDong";
            this.checkBox_KaiJiQiDong.Size = new System.Drawing.Size(72, 16);
            this.checkBox_KaiJiQiDong.TabIndex = 7;
            this.checkBox_KaiJiQiDong.Text = "开机启动";
            this.checkBox_KaiJiQiDong.UseVisualStyleBackColor = true;
            this.checkBox_KaiJiQiDong.CheckedChanged += new System.EventHandler(this.CheckBox_KaiJiQiDong_CheckedChanged);
            // 
            // SheZhiForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(284, 161);
            this.Controls.Add(this.checkBox_KaiJiQiDong);
            this.Controls.Add(this.button_QingChuTidHuanCun);
            this.Controls.Add(this.label_TidHuanCunShu);
            this.Controls.Add(this.button_BaoCun);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox_TongZhiZiDongGuanBiShiJian);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(300, 200);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(300, 200);
            this.Name = "SheZhiForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SheZhiForm";
            this.Load += new System.EventHandler(this.SheZhiForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_TongZhiZiDongGuanBiShiJian;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button_BaoCun;
        private System.Windows.Forms.Label label_TidHuanCunShu;
        private System.Windows.Forms.Button button_QingChuTidHuanCun;
        private System.Windows.Forms.CheckBox checkBox_KaiJiQiDong;
    }
}