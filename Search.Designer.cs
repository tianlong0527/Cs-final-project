namespace personal_note
{
    partial class Search
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
            this.tp = new System.Windows.Forms.TabControl();
            this.tpDay = new System.Windows.Forms.TabPage();
            this.lblAlarm = new System.Windows.Forms.Label();
            this.btnDay = new System.Windows.Forms.Button();
            this.lblMonth = new System.Windows.Forms.Label();
            this.lblDay = new System.Windows.Forms.Label();
            this.rtbDay = new System.Windows.Forms.RichTextBox();
            this.rtbMonth = new System.Windows.Forms.RichTextBox();
            this.lblYear = new System.Windows.Forms.Label();
            this.rtbYear = new System.Windows.Forms.RichTextBox();
            this.tpStar = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.btnStar = new System.Windows.Forms.Button();
            this.lblStar = new System.Windows.Forms.Label();
            this.rtbStar = new System.Windows.Forms.RichTextBox();
            this.tpTag = new System.Windows.Forms.TabPage();
            this.label2 = new System.Windows.Forms.Label();
            this.btnTag = new System.Windows.Forms.Button();
            this.lblTag = new System.Windows.Forms.Label();
            this.rtbTag = new System.Windows.Forms.RichTextBox();
            this.tp.SuspendLayout();
            this.tpDay.SuspendLayout();
            this.tpStar.SuspendLayout();
            this.tpTag.SuspendLayout();
            this.SuspendLayout();
            // 
            // tp
            // 
            this.tp.Controls.Add(this.tpDay);
            this.tp.Controls.Add(this.tpStar);
            this.tp.Controls.Add(this.tpTag);
            this.tp.Location = new System.Drawing.Point(0, -1);
            this.tp.Name = "tp";
            this.tp.SelectedIndex = 0;
            this.tp.Size = new System.Drawing.Size(535, 317);
            this.tp.TabIndex = 0;
            // 
            // tpDay
            // 
            this.tpDay.Controls.Add(this.lblAlarm);
            this.tpDay.Controls.Add(this.btnDay);
            this.tpDay.Controls.Add(this.lblMonth);
            this.tpDay.Controls.Add(this.lblDay);
            this.tpDay.Controls.Add(this.rtbDay);
            this.tpDay.Controls.Add(this.rtbMonth);
            this.tpDay.Controls.Add(this.lblYear);
            this.tpDay.Controls.Add(this.rtbYear);
            this.tpDay.Location = new System.Drawing.Point(4, 28);
            this.tpDay.Name = "tpDay";
            this.tpDay.Padding = new System.Windows.Forms.Padding(3);
            this.tpDay.Size = new System.Drawing.Size(527, 285);
            this.tpDay.TabIndex = 0;
            this.tpDay.Text = "Day";
            this.tpDay.UseVisualStyleBackColor = true;
            // 
            // lblAlarm
            // 
            this.lblAlarm.AutoSize = true;
            this.lblAlarm.Font = new System.Drawing.Font("新細明體", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblAlarm.Location = new System.Drawing.Point(145, 0);
            this.lblAlarm.Name = "lblAlarm";
            this.lblAlarm.Size = new System.Drawing.Size(217, 40);
            this.lblAlarm.TabIndex = 7;
            this.lblAlarm.Text = "請輸入數字";
            // 
            // btnDay
            // 
            this.btnDay.Location = new System.Drawing.Point(197, 215);
            this.btnDay.Name = "btnDay";
            this.btnDay.Size = new System.Drawing.Size(125, 46);
            this.btnDay.TabIndex = 6;
            this.btnDay.Text = "Search";
            this.btnDay.UseVisualStyleBackColor = true;
            this.btnDay.Click += new System.EventHandler(this.btnDay_Click);
            // 
            // lblMonth
            // 
            this.lblMonth.AutoSize = true;
            this.lblMonth.Font = new System.Drawing.Font("新細明體", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblMonth.Location = new System.Drawing.Point(279, 104);
            this.lblMonth.Name = "lblMonth";
            this.lblMonth.Size = new System.Drawing.Size(113, 40);
            this.lblMonth.TabIndex = 5;
            this.lblMonth.Text = "month";
            // 
            // lblDay
            // 
            this.lblDay.AutoSize = true;
            this.lblDay.Font = new System.Drawing.Font("新細明體", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblDay.Location = new System.Drawing.Point(279, 169);
            this.lblDay.Name = "lblDay";
            this.lblDay.Size = new System.Drawing.Size(72, 40);
            this.lblDay.TabIndex = 4;
            this.lblDay.Text = "day";
            // 
            // rtbDay
            // 
            this.rtbDay.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.rtbDay.Location = new System.Drawing.Point(147, 169);
            this.rtbDay.Name = "rtbDay";
            this.rtbDay.Size = new System.Drawing.Size(126, 40);
            this.rtbDay.TabIndex = 3;
            this.rtbDay.Text = "";
            // 
            // rtbMonth
            // 
            this.rtbMonth.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.rtbMonth.Location = new System.Drawing.Point(147, 104);
            this.rtbMonth.Name = "rtbMonth";
            this.rtbMonth.Size = new System.Drawing.Size(126, 40);
            this.rtbMonth.TabIndex = 2;
            this.rtbMonth.Text = "";
            // 
            // lblYear
            // 
            this.lblYear.AutoSize = true;
            this.lblYear.Font = new System.Drawing.Font("新細明體", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblYear.Location = new System.Drawing.Point(279, 47);
            this.lblYear.Name = "lblYear";
            this.lblYear.Size = new System.Drawing.Size(83, 40);
            this.lblYear.TabIndex = 1;
            this.lblYear.Text = "year";
            // 
            // rtbYear
            // 
            this.rtbYear.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.rtbYear.Location = new System.Drawing.Point(147, 47);
            this.rtbYear.Name = "rtbYear";
            this.rtbYear.Size = new System.Drawing.Size(126, 40);
            this.rtbYear.TabIndex = 0;
            this.rtbYear.Text = "";
            // 
            // tpStar
            // 
            this.tpStar.Controls.Add(this.label1);
            this.tpStar.Controls.Add(this.btnStar);
            this.tpStar.Controls.Add(this.lblStar);
            this.tpStar.Controls.Add(this.rtbStar);
            this.tpStar.Location = new System.Drawing.Point(4, 28);
            this.tpStar.Name = "tpStar";
            this.tpStar.Padding = new System.Windows.Forms.Padding(3);
            this.tpStar.Size = new System.Drawing.Size(527, 285);
            this.tpStar.TabIndex = 1;
            this.tpStar.Text = "Star";
            this.tpStar.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("新細明體", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label1.Location = new System.Drawing.Point(153, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(217, 40);
            this.label1.TabIndex = 8;
            this.label1.Text = "請輸入數字";
            // 
            // btnStar
            // 
            this.btnStar.Location = new System.Drawing.Point(195, 157);
            this.btnStar.Name = "btnStar";
            this.btnStar.Size = new System.Drawing.Size(125, 46);
            this.btnStar.TabIndex = 7;
            this.btnStar.Text = "Search";
            this.btnStar.UseVisualStyleBackColor = true;
            this.btnStar.Click += new System.EventHandler(this.btnStar_Click);
            // 
            // lblStar
            // 
            this.lblStar.AutoSize = true;
            this.lblStar.Font = new System.Drawing.Font("新細明體", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblStar.Location = new System.Drawing.Point(298, 81);
            this.lblStar.Name = "lblStar";
            this.lblStar.Size = new System.Drawing.Size(72, 40);
            this.lblStar.TabIndex = 3;
            this.lblStar.Text = "star";
            // 
            // rtbStar
            // 
            this.rtbStar.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.rtbStar.Location = new System.Drawing.Point(166, 81);
            this.rtbStar.Name = "rtbStar";
            this.rtbStar.Size = new System.Drawing.Size(126, 40);
            this.rtbStar.TabIndex = 2;
            this.rtbStar.Text = "";
            // 
            // tpTag
            // 
            this.tpTag.Controls.Add(this.label2);
            this.tpTag.Controls.Add(this.btnTag);
            this.tpTag.Controls.Add(this.lblTag);
            this.tpTag.Controls.Add(this.rtbTag);
            this.tpTag.Location = new System.Drawing.Point(4, 28);
            this.tpTag.Name = "tpTag";
            this.tpTag.Padding = new System.Windows.Forms.Padding(3);
            this.tpTag.Size = new System.Drawing.Size(527, 285);
            this.tpTag.TabIndex = 2;
            this.tpTag.Text = "Tag";
            this.tpTag.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("新細明體", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label2.Location = new System.Drawing.Point(154, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(217, 40);
            this.label2.TabIndex = 11;
            this.label2.Text = "請輸入文字";
            // 
            // btnTag
            // 
            this.btnTag.Location = new System.Drawing.Point(196, 161);
            this.btnTag.Name = "btnTag";
            this.btnTag.Size = new System.Drawing.Size(125, 46);
            this.btnTag.TabIndex = 10;
            this.btnTag.Text = "Search";
            this.btnTag.UseVisualStyleBackColor = true;
            this.btnTag.Click += new System.EventHandler(this.btnTag_Click);
            // 
            // lblTag
            // 
            this.lblTag.AutoSize = true;
            this.lblTag.Font = new System.Drawing.Font("新細明體", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblTag.Location = new System.Drawing.Point(293, 78);
            this.lblTag.Name = "lblTag";
            this.lblTag.Size = new System.Drawing.Size(63, 40);
            this.lblTag.TabIndex = 9;
            this.lblTag.Text = "tag";
            // 
            // rtbTag
            // 
            this.rtbTag.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.rtbTag.Location = new System.Drawing.Point(161, 78);
            this.rtbTag.Name = "rtbTag";
            this.rtbTag.Size = new System.Drawing.Size(126, 40);
            this.rtbTag.TabIndex = 8;
            this.rtbTag.Text = "";
            // 
            // Search
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(530, 313);
            this.Controls.Add(this.tp);
            this.Name = "Search";
            this.Text = "Search";
            this.tp.ResumeLayout(false);
            this.tpDay.ResumeLayout(false);
            this.tpDay.PerformLayout();
            this.tpStar.ResumeLayout(false);
            this.tpStar.PerformLayout();
            this.tpTag.ResumeLayout(false);
            this.tpTag.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tp;
        private System.Windows.Forms.TabPage tpDay;
        private System.Windows.Forms.TabPage tpStar;
        private System.Windows.Forms.TabPage tpTag;
        private System.Windows.Forms.Label lblYear;
        private System.Windows.Forms.RichTextBox rtbYear;
        private System.Windows.Forms.Label lblMonth;
        private System.Windows.Forms.Label lblDay;
        private System.Windows.Forms.RichTextBox rtbDay;
        private System.Windows.Forms.RichTextBox rtbMonth;
        private System.Windows.Forms.Button btnDay;
        private System.Windows.Forms.Button btnStar;
        private System.Windows.Forms.Label lblStar;
        private System.Windows.Forms.RichTextBox rtbStar;
        private System.Windows.Forms.Button btnTag;
        private System.Windows.Forms.Label lblTag;
        private System.Windows.Forms.RichTextBox rtbTag;
        private System.Windows.Forms.Label lblAlarm;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}