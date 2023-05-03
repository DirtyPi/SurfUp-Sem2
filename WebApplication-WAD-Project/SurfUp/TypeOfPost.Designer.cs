
namespace SurfUp
{
    partial class TypeOfPost
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
            this.rbAnnoucement = new System.Windows.Forms.RadioButton();
            this.rbMedia = new System.Windows.Forms.RadioButton();
            this.rbImage = new System.Windows.Forms.RadioButton();
            this.btnSelect = new System.Windows.Forms.Button();
            this.btnCalncel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // rbAnnoucement
            // 
            this.rbAnnoucement.AutoSize = true;
            this.rbAnnoucement.Location = new System.Drawing.Point(26, 58);
            this.rbAnnoucement.Name = "rbAnnoucement";
            this.rbAnnoucement.Size = new System.Drawing.Size(122, 24);
            this.rbAnnoucement.TabIndex = 0;
            this.rbAnnoucement.TabStop = true;
            this.rbAnnoucement.Text = "Annoucement";
            this.rbAnnoucement.UseVisualStyleBackColor = true;
            // 
            // rbMedia
            // 
            this.rbMedia.AutoSize = true;
            this.rbMedia.Location = new System.Drawing.Point(170, 58);
            this.rbMedia.Name = "rbMedia";
            this.rbMedia.Size = new System.Drawing.Size(72, 24);
            this.rbMedia.TabIndex = 1;
            this.rbMedia.TabStop = true;
            this.rbMedia.Text = "Media";
            this.rbMedia.UseVisualStyleBackColor = true;
            // 
            // rbImage
            // 
            this.rbImage.AutoSize = true;
            this.rbImage.Location = new System.Drawing.Point(272, 58);
            this.rbImage.Name = "rbImage";
            this.rbImage.Size = new System.Drawing.Size(72, 24);
            this.rbImage.TabIndex = 2;
            this.rbImage.TabStop = true;
            this.rbImage.Text = "Image";
            this.rbImage.UseVisualStyleBackColor = true;
            // 
            // btnSelect
            // 
            this.btnSelect.Location = new System.Drawing.Point(12, 111);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(131, 58);
            this.btnSelect.TabIndex = 3;
            this.btnSelect.Text = "Select";
            this.btnSelect.UseVisualStyleBackColor = true;
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // btnCalncel
            // 
            this.btnCalncel.Location = new System.Drawing.Point(323, 140);
            this.btnCalncel.Name = "btnCalncel";
            this.btnCalncel.Size = new System.Drawing.Size(94, 29);
            this.btnCalncel.TabIndex = 4;
            this.btnCalncel.Text = "Cancel";
            this.btnCalncel.UseVisualStyleBackColor = true;
            // 
            // TypeOfPost
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(429, 181);
            this.Controls.Add(this.btnCalncel);
            this.Controls.Add(this.btnSelect);
            this.Controls.Add(this.rbImage);
            this.Controls.Add(this.rbMedia);
            this.Controls.Add(this.rbAnnoucement);
            this.Name = "TypeOfPost";
            this.Text = "TypeOfPost";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton rbAnnoucement;
        private System.Windows.Forms.RadioButton rbMedia;
        private System.Windows.Forms.RadioButton rbImage;
        private System.Windows.Forms.Button btnSelect;
        private System.Windows.Forms.Button btnCalncel;
    }
}