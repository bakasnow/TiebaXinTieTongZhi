namespace TiebaXinTieTongZhi
{
	partial class TongZhiForm
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
            this.components = new System.ComponentModel.Container();
            this.label_biaoTi = new System.Windows.Forms.Label();
            this.label_tiebaName = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label_GuanBi = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label_biaoTi
            // 
            this.label_biaoTi.Font = new System.Drawing.Font("宋体", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_biaoTi.ForeColor = System.Drawing.Color.Black;
            this.label_biaoTi.Location = new System.Drawing.Point(10, 40);
            this.label_biaoTi.Margin = new System.Windows.Forms.Padding(0);
            this.label_biaoTi.Name = "label_biaoTi";
            this.label_biaoTi.Size = new System.Drawing.Size(280, 40);
            this.label_biaoTi.TabIndex = 0;
            this.label_biaoTi.Text = "有人喜欢茫茫的大雪,有喜欢如丝的细雨,可是我喜欢那迷人的雾。";
            this.label_biaoTi.Click += new System.EventHandler(this.Label_BiaoTi_Click);
            // 
            // label_tiebaName
            // 
            this.label_tiebaName.Font = new System.Drawing.Font("宋体", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_tiebaName.ForeColor = System.Drawing.Color.Black;
            this.label_tiebaName.Location = new System.Drawing.Point(10, 10);
            this.label_tiebaName.Margin = new System.Windows.Forms.Padding(0);
            this.label_tiebaName.Name = "label_tiebaName";
            this.label_tiebaName.Size = new System.Drawing.Size(280, 16);
            this.label_tiebaName.TabIndex = 1;
            this.label_tiebaName.Text = "贴吧名吧 - 用户名";
            this.label_tiebaName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.Timer1_Tick);
            // 
            // label_GuanBi
            // 
            this.label_GuanBi.Location = new System.Drawing.Point(210, 79);
            this.label_GuanBi.Margin = new System.Windows.Forms.Padding(0);
            this.label_GuanBi.Name = "label_GuanBi";
            this.label_GuanBi.Size = new System.Drawing.Size(80, 12);
            this.label_GuanBi.TabIndex = 2;
            this.label_GuanBi.Text = "关闭";
            this.label_GuanBi.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label_GuanBi.Click += new System.EventHandler(this.Label_GuanBi_Click);
            // 
            // TongZhiForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(300, 100);
            this.ControlBox = false;
            this.Controls.Add(this.label_GuanBi);
            this.Controls.Add(this.label_tiebaName);
            this.Controls.Add(this.label_biaoTi);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximumSize = new System.Drawing.Size(300, 100);
            this.MinimumSize = new System.Drawing.Size(300, 100);
            this.Name = "TongZhiForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TongZhiForm";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TongZhiForm_FormClosing);
            this.Load += new System.EventHandler(this.TongZhiForm_Load);
            this.ResumeLayout(false);

		}

		#endregion
		private System.Windows.Forms.Label label_biaoTi;
		private System.Windows.Forms.Label label_tiebaName;
		private System.Windows.Forms.Timer timer1;
		private System.Windows.Forms.Label label_GuanBi;
	}
}