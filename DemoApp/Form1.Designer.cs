namespace DemoApp
{
    partial class Form1
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
            this.sourcePictureBox = new System.Windows.Forms.PictureBox();
            this.destinationPictureBox = new System.Windows.Forms.PictureBox();
            this.loadBtn = new System.Windows.Forms.Button();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.night1Btn = new System.Windows.Forms.Button();
            this.night2Btn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.sourcePictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.destinationPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // sourcePictureBox
            // 
            this.sourcePictureBox.Location = new System.Drawing.Point(12, 12);
            this.sourcePictureBox.Name = "sourcePictureBox";
            this.sourcePictureBox.Size = new System.Drawing.Size(499, 502);
            this.sourcePictureBox.TabIndex = 0;
            this.sourcePictureBox.TabStop = false;
            // 
            // destinationPictureBox
            // 
            this.destinationPictureBox.Location = new System.Drawing.Point(758, 12);
            this.destinationPictureBox.Name = "destinationPictureBox";
            this.destinationPictureBox.Size = new System.Drawing.Size(499, 502);
            this.destinationPictureBox.TabIndex = 1;
            this.destinationPictureBox.TabStop = false;
            // 
            // loadBtn
            // 
            this.loadBtn.Location = new System.Drawing.Point(533, 12);
            this.loadBtn.Name = "loadBtn";
            this.loadBtn.Size = new System.Drawing.Size(207, 23);
            this.loadBtn.TabIndex = 2;
            this.loadBtn.Text = "Load";
            this.loadBtn.UseVisualStyleBackColor = true;
            this.loadBtn.Click += new System.EventHandler(this.loadBtn_Click);
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog1";
            // 
            // night1Btn
            // 
            this.night1Btn.Location = new System.Drawing.Point(533, 184);
            this.night1Btn.Name = "night1Btn";
            this.night1Btn.Size = new System.Drawing.Size(207, 23);
            this.night1Btn.TabIndex = 3;
            this.night1Btn.Text = "Night1";
            this.night1Btn.UseVisualStyleBackColor = true;
            this.night1Btn.Click += new System.EventHandler(this.night1Btn_Click);
            // 
            // night2Btn
            // 
            this.night2Btn.Location = new System.Drawing.Point(533, 222);
            this.night2Btn.Name = "night2Btn";
            this.night2Btn.Size = new System.Drawing.Size(207, 23);
            this.night2Btn.TabIndex = 4;
            this.night2Btn.Text = "Night2";
            this.night2Btn.UseVisualStyleBackColor = true;
            this.night2Btn.Click += new System.EventHandler(this.night2Btn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1269, 526);
            this.Controls.Add(this.night2Btn);
            this.Controls.Add(this.night1Btn);
            this.Controls.Add(this.loadBtn);
            this.Controls.Add(this.destinationPictureBox);
            this.Controls.Add(this.sourcePictureBox);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.sourcePictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.destinationPictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox sourcePictureBox;
        private System.Windows.Forms.PictureBox destinationPictureBox;
        private System.Windows.Forms.Button loadBtn;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.Button night1Btn;
        private System.Windows.Forms.Button night2Btn;
    }
}

