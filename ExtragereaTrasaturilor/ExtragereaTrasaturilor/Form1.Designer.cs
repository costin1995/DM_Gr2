namespace ExtragereaTrasaturilor
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
            this.btnExtTras = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnExtTras
            // 
            this.btnExtTras.Location = new System.Drawing.Point(269, 143);
            this.btnExtTras.Name = "btnExtTras";
            this.btnExtTras.Size = new System.Drawing.Size(75, 48);
            this.btnExtTras.TabIndex = 0;
            this.btnExtTras.Text = "Extragere Trasaturi";
            this.btnExtTras.UseVisualStyleBackColor = true;
            this.btnExtTras.Click += new System.EventHandler(this.btnExtTras_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 366);
            this.Controls.Add(this.btnExtTras);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnExtTras;
    }
}

