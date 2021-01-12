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
			this.selectieTrasaturiBtn = new System.Windows.Forms.Button();
			this.pragForm = new System.Windows.Forms.NumericUpDown();
			this.button1 = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.pragForm)).BeginInit();
			this.SuspendLayout();
			// 
			// btnExtTras
			// 
			this.btnExtTras.Location = new System.Drawing.Point(222, 198);
			this.btnExtTras.Margin = new System.Windows.Forms.Padding(4);
			this.btnExtTras.Name = "btnExtTras";
			this.btnExtTras.Size = new System.Drawing.Size(100, 59);
			this.btnExtTras.TabIndex = 0;
			this.btnExtTras.Text = "Extragere Trasaturi";
			this.btnExtTras.UseVisualStyleBackColor = true;
			this.btnExtTras.Click += new System.EventHandler(this.btnExtTras_Click);
			// 
			// selectieTrasaturiBtn
			// 
			this.selectieTrasaturiBtn.Location = new System.Drawing.Point(621, 283);
			this.selectieTrasaturiBtn.Name = "selectieTrasaturiBtn";
			this.selectieTrasaturiBtn.Size = new System.Drawing.Size(140, 50);
			this.selectieTrasaturiBtn.TabIndex = 1;
			this.selectieTrasaturiBtn.Text = "Selectie Trasaturi";
			this.selectieTrasaturiBtn.UseVisualStyleBackColor = true;
			this.selectieTrasaturiBtn.Click += new System.EventHandler(this.selectieTrasaturiBtn_Click);
			// 
			// pragForm
			// 
			this.pragForm.DecimalPlaces = 1;
			this.pragForm.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
			this.pragForm.Location = new System.Drawing.Point(621, 235);
			this.pragForm.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.pragForm.Name = "pragForm";
			this.pragForm.Size = new System.Drawing.Size(120, 22);
			this.pragForm.TabIndex = 2;
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(247, 297);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(75, 23);
			this.button1.TabIndex = 3;
			this.button1.Text = "button1";
			this.button1.UseVisualStyleBackColor = true;
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.pragForm);
			this.Controls.Add(this.selectieTrasaturiBtn);
			this.Controls.Add(this.btnExtTras);
			this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.Name = "Form1";
			this.Text = "Form1";
			this.Load += new System.EventHandler(this.Form1_Load);
			((System.ComponentModel.ISupportInitialize)(this.pragForm)).EndInit();
			this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnExtTras;
        private System.Windows.Forms.Button selectieTrasaturiBtn;
        private System.Windows.Forms.NumericUpDown pragForm;
		private System.Windows.Forms.Button button1;
	}
}

