namespace TiebaXinTieTongZhi
{
	partial class DingYueGuanLiForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DingYueGuanLiForm));
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.button_XinZeng = new System.Windows.Forms.Button();
            this.button_ShanChu = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.listView1.FullRowSelect = true;
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(9, 9);
            this.listView1.Margin = new System.Windows.Forms.Padding(0);
            this.listView1.MultiSelect = false;
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(226, 254);
            this.listView1.TabIndex = 6;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "贴吧名";
            this.columnHeader1.Width = 130;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "扫描间隔";
            this.columnHeader2.Width = 70;
            // 
            // button_XinZeng
            // 
            this.button_XinZeng.Location = new System.Drawing.Point(9, 272);
            this.button_XinZeng.Margin = new System.Windows.Forms.Padding(0);
            this.button_XinZeng.Name = "button_XinZeng";
            this.button_XinZeng.Size = new System.Drawing.Size(110, 30);
            this.button_XinZeng.TabIndex = 7;
            this.button_XinZeng.Text = "新 增";
            this.button_XinZeng.UseVisualStyleBackColor = true;
            this.button_XinZeng.Click += new System.EventHandler(this.Button_XinZeng_Click);
            // 
            // button_ShanChu
            // 
            this.button_ShanChu.ForeColor = System.Drawing.Color.Red;
            this.button_ShanChu.Location = new System.Drawing.Point(125, 272);
            this.button_ShanChu.Margin = new System.Windows.Forms.Padding(0);
            this.button_ShanChu.Name = "button_ShanChu";
            this.button_ShanChu.Size = new System.Drawing.Size(110, 30);
            this.button_ShanChu.TabIndex = 8;
            this.button_ShanChu.Text = "删 除";
            this.button_ShanChu.UseVisualStyleBackColor = true;
            this.button_ShanChu.Click += new System.EventHandler(this.Button_ShanChu_Click);
            // 
            // DingYueGuanLiForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(244, 311);
            this.Controls.Add(this.button_ShanChu);
            this.Controls.Add(this.button_XinZeng);
            this.Controls.Add(this.listView1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(260, 350);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(260, 350);
            this.Name = "DingYueGuanLiForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DingYueGuanLiForm";
            this.Load += new System.EventHandler(this.DingYueGuanLiForm_Load);
            this.ResumeLayout(false);

		}

		#endregion
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.Button button_XinZeng;
        private System.Windows.Forms.Button button_ShanChu;
    }
}