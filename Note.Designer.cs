namespace personal_note
{
    partial class Note
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Note));
            this.rtbTitle = new System.Windows.Forms.RichTextBox();
            this.rtbDate = new System.Windows.Forms.RichTextBox();
            this.rtbTag = new System.Windows.Forms.RichTextBox();
            this.lblDate = new System.Windows.Forms.RichTextBox();
            this.lblTag = new System.Windows.Forms.RichTextBox();
            this.rtbNote = new System.Windows.Forms.RichTextBox();
            this.rtbAdd = new System.Windows.Forms.RichTextBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.pBox1 = new System.Windows.Forms.PictureBox();
            this.pBox2 = new System.Windows.Forms.PictureBox();
            this.pBox3 = new System.Windows.Forms.PictureBox();
            this.pBox4 = new System.Windows.Forms.PictureBox();
            this.pBox5 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pBox5)).BeginInit();
            this.SuspendLayout();
            // 
            // rtbTitle
            // 
            this.rtbTitle.AutoWordSelection = true;
            this.rtbTitle.BackColor = System.Drawing.SystemColors.MenuText;
            this.rtbTitle.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtbTitle.Cursor = System.Windows.Forms.Cursors.Default;
            this.rtbTitle.Font = new System.Drawing.Font("新細明體", 28F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.rtbTitle.ForeColor = System.Drawing.Color.Gray;
            this.rtbTitle.Location = new System.Drawing.Point(54, 69);
            this.rtbTitle.Name = "rtbTitle";
            this.rtbTitle.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.rtbTitle.Size = new System.Drawing.Size(755, 83);
            this.rtbTitle.TabIndex = 1;
            this.rtbTitle.Text = "Title";
            this.rtbTitle.TextChanged += new System.EventHandler(this.rtbTitle_TextChanged);
            this.rtbTitle.KeyDown += new System.Windows.Forms.KeyEventHandler(this.rtbTitle_KeyDown);
            // 
            // rtbDate
            // 
            this.rtbDate.BackColor = System.Drawing.SystemColors.WindowText;
            this.rtbDate.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtbDate.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.rtbDate.ForeColor = System.Drawing.SystemColors.Window;
            this.rtbDate.Location = new System.Drawing.Point(136, 178);
            this.rtbDate.Name = "rtbDate";
            this.rtbDate.Size = new System.Drawing.Size(656, 32);
            this.rtbDate.TabIndex = 4;
            this.rtbDate.Text = "";
            // 
            // rtbTag
            // 
            this.rtbTag.BackColor = System.Drawing.SystemColors.WindowText;
            this.rtbTag.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtbTag.Cursor = System.Windows.Forms.Cursors.Default;
            this.rtbTag.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.rtbTag.ForeColor = System.Drawing.SystemColors.Window;
            this.rtbTag.Location = new System.Drawing.Point(136, 236);
            this.rtbTag.Name = "rtbTag";
            this.rtbTag.Size = new System.Drawing.Size(586, 32);
            this.rtbTag.TabIndex = 5;
            this.rtbTag.Text = "";
            // 
            // lblDate
            // 
            this.lblDate.BackColor = System.Drawing.SystemColors.WindowText;
            this.lblDate.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lblDate.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblDate.ForeColor = System.Drawing.SystemColors.Window;
            this.lblDate.Location = new System.Drawing.Point(54, 178);
            this.lblDate.Name = "lblDate";
            this.lblDate.ReadOnly = true;
            this.lblDate.Size = new System.Drawing.Size(61, 32);
            this.lblDate.TabIndex = 6;
            this.lblDate.Text = "Dates";
            // 
            // lblTag
            // 
            this.lblTag.BackColor = System.Drawing.SystemColors.WindowText;
            this.lblTag.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lblTag.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblTag.ForeColor = System.Drawing.SystemColors.Window;
            this.lblTag.Location = new System.Drawing.Point(54, 236);
            this.lblTag.Name = "lblTag";
            this.lblTag.Size = new System.Drawing.Size(50, 32);
            this.lblTag.TabIndex = 7;
            this.lblTag.Text = "Tags";
            // 
            // rtbNote
            // 
            this.rtbNote.BackColor = System.Drawing.SystemColors.WindowText;
            this.rtbNote.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtbNote.Cursor = System.Windows.Forms.Cursors.Default;
            this.rtbNote.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.rtbNote.ForeColor = System.Drawing.Color.Gray;
            this.rtbNote.Location = new System.Drawing.Point(46, 299);
            this.rtbNote.Name = "rtbNote";
            this.rtbNote.Size = new System.Drawing.Size(745, 555);
            this.rtbNote.TabIndex = 8;
            this.rtbNote.Text = "早安，平安健康";
            this.rtbNote.TextChanged += new System.EventHandler(this.rtbNote_TextChanged);
            this.rtbNote.KeyDown += new System.Windows.Forms.KeyEventHandler(this.richTextBox1_KeyDown);
            // 
            // rtbAdd
            // 
            this.rtbAdd.BackColor = System.Drawing.SystemColors.Window;
            this.rtbAdd.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtbAdd.Cursor = System.Windows.Forms.Cursors.Default;
            this.rtbAdd.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.rtbAdd.ForeColor = System.Drawing.SystemColors.MenuText;
            this.rtbAdd.Location = new System.Drawing.Point(136, 236);
            this.rtbAdd.Name = "rtbAdd";
            this.rtbAdd.Size = new System.Drawing.Size(586, 32);
            this.rtbAdd.TabIndex = 9;
            this.rtbAdd.Text = "";
            this.rtbAdd.Visible = false;
            // 
            // btnAdd
            // 
            this.btnAdd.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnAdd.Location = new System.Drawing.Point(732, 236);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(77, 32);
            this.btnAdd.TabIndex = 10;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // pBox1
            // 
            this.pBox1.Image = ((System.Drawing.Image)(resources.GetObject("pBox1.Image")));
            this.pBox1.Location = new System.Drawing.Point(531, 6);
            this.pBox1.Name = "pBox1";
            this.pBox1.Size = new System.Drawing.Size(61, 57);
            this.pBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pBox1.TabIndex = 11;
            this.pBox1.TabStop = false;
            this.pBox1.Click += new System.EventHandler(this.pBox_Click);
            // 
            // pBox2
            // 
            this.pBox2.Image = ((System.Drawing.Image)(resources.GetObject("pBox2.Image")));
            this.pBox2.Location = new System.Drawing.Point(589, 6);
            this.pBox2.Name = "pBox2";
            this.pBox2.Size = new System.Drawing.Size(61, 57);
            this.pBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pBox2.TabIndex = 12;
            this.pBox2.TabStop = false;
            this.pBox2.Click += new System.EventHandler(this.pBox_Click);
            // 
            // pBox3
            // 
            this.pBox3.Image = ((System.Drawing.Image)(resources.GetObject("pBox3.Image")));
            this.pBox3.Location = new System.Drawing.Point(647, 6);
            this.pBox3.Name = "pBox3";
            this.pBox3.Size = new System.Drawing.Size(61, 57);
            this.pBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pBox3.TabIndex = 13;
            this.pBox3.TabStop = false;
            this.pBox3.Click += new System.EventHandler(this.pBox_Click);
            // 
            // pBox4
            // 
            this.pBox4.Image = ((System.Drawing.Image)(resources.GetObject("pBox4.Image")));
            this.pBox4.Location = new System.Drawing.Point(705, 6);
            this.pBox4.Name = "pBox4";
            this.pBox4.Size = new System.Drawing.Size(61, 57);
            this.pBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pBox4.TabIndex = 14;
            this.pBox4.TabStop = false;
            this.pBox4.Click += new System.EventHandler(this.pBox_Click);
            // 
            // pBox5
            // 
            this.pBox5.Image = ((System.Drawing.Image)(resources.GetObject("pBox5.Image")));
            this.pBox5.Location = new System.Drawing.Point(762, 6);
            this.pBox5.Name = "pBox5";
            this.pBox5.Size = new System.Drawing.Size(61, 57);
            this.pBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pBox5.TabIndex = 15;
            this.pBox5.TabStop = false;
            this.pBox5.Click += new System.EventHandler(this.pBox_Click);
            // 
            // Note
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlText;
            this.ClientSize = new System.Drawing.Size(821, 882);
            this.Controls.Add(this.pBox5);
            this.Controls.Add(this.pBox4);
            this.Controls.Add(this.pBox3);
            this.Controls.Add(this.pBox2);
            this.Controls.Add(this.pBox1);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.rtbAdd);
            this.Controls.Add(this.rtbNote);
            this.Controls.Add(this.lblTag);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.rtbTag);
            this.Controls.Add(this.rtbDate);
            this.Controls.Add(this.rtbTitle);
            this.ForeColor = System.Drawing.SystemColors.Control;
            this.Name = "Note";
            this.Text = "Note";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Note_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.pBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pBox5)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox rtbTitle;
        private System.Windows.Forms.RichTextBox rtbDate;
        private System.Windows.Forms.RichTextBox rtbTag;
        private System.Windows.Forms.RichTextBox lblDate;
        private System.Windows.Forms.RichTextBox lblTag;
        private System.Windows.Forms.RichTextBox rtbNote;
        private System.Windows.Forms.RichTextBox rtbAdd;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.PictureBox pBox1;
        private System.Windows.Forms.PictureBox pBox2;
        private System.Windows.Forms.PictureBox pBox3;
        private System.Windows.Forms.PictureBox pBox4;
        private System.Windows.Forms.PictureBox pBox5;
    }
}