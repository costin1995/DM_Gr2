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
			this.radioBtbBinara = new System.Windows.Forms.RadioButton();
			this.radioBtnNominala = new System.Windows.Forms.RadioButton();
			this.radioBtnSuma1 = new System.Windows.Forms.RadioButton();
			this.radioBtnCornellSmart = new System.Windows.Forms.RadioButton();
			this.label1 = new System.Windows.Forms.Label();
			this.btnSelect = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.pragForm)).BeginInit();
			this.SuspendLayout();
			// 
			// btnExtTras
			// 
			this.btnExtTras.Location = new System.Drawing.Point(76, 84);
			this.btnExtTras.Margin = new System.Windows.Forms.Padding(4);
			this.btnExtTras.Name = "btnExtTras";
			this.btnExtTras.Size = new System.Drawing.Size(147, 59);
			this.btnExtTras.TabIndex = 0;
			this.btnExtTras.Text = "Extragere Trasaturi";
			this.btnExtTras.UseVisualStyleBackColor = true;
			this.btnExtTras.Click += new System.EventHandler(this.btnExtTras_Click);
			// 
			// selectieTrasaturiBtn
			// 
			this.selectieTrasaturiBtn.Location = new System.Drawing.Point(286, 84);
			this.selectieTrasaturiBtn.Name = "selectieTrasaturiBtn";
			this.selectieTrasaturiBtn.Size = new System.Drawing.Size(140, 59);
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
			this.pragForm.Location = new System.Drawing.Point(295, 168);
			this.pragForm.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.pragForm.Name = "pragForm";
			this.pragForm.Size = new System.Drawing.Size(120, 22);
			this.pragForm.TabIndex = 2;
			// 
			// radioBtbBinara
			// 
			this.radioBtbBinara.AutoSize = true;
			this.radioBtbBinara.Location = new System.Drawing.Point(583, 106);
			this.radioBtbBinara.Name = "radioBtbBinara";
			this.radioBtbBinara.Size = new System.Drawing.Size(158, 21);
			this.radioBtbBinara.TabIndex = 3;
			this.radioBtbBinara.TabStop = true;
			this.radioBtbBinara.Text = "Normalizarea Binara";
			this.radioBtbBinara.UseVisualStyleBackColor = true;
			// 
			// radioBtnNominala
			// 
			this.radioBtnNominala.AutoSize = true;
			this.radioBtnNominala.Location = new System.Drawing.Point(583, 133);
			this.radioBtnNominala.Name = "radioBtnNominala";
			this.radioBtnNominala.Size = new System.Drawing.Size(176, 21);
			this.radioBtnNominala.TabIndex = 4;
			this.radioBtnNominala.TabStop = true;
			this.radioBtnNominala.Text = "Normalizarea Nominala";
			this.radioBtnNominala.UseVisualStyleBackColor = true;
			// 
			// radioBtnSuma1
			// 
			this.radioBtnSuma1.AutoSize = true;
			this.radioBtnSuma1.Location = new System.Drawing.Point(583, 160);
			this.radioBtnSuma1.Name = "radioBtnSuma1";
			this.radioBtnSuma1.Size = new System.Drawing.Size(165, 21);
			this.radioBtnSuma1.TabIndex = 5;
			this.radioBtnSuma1.TabStop = true;
			this.radioBtnSuma1.Text = "Normalizarea Suma 1";
			this.radioBtnSuma1.UseVisualStyleBackColor = true;
			// 
			// radioBtnCornellSmart
			// 
			this.radioBtnCornellSmart.AutoSize = true;
			this.radioBtnCornellSmart.Location = new System.Drawing.Point(583, 187);
			this.radioBtnCornellSmart.Name = "radioBtnCornellSmart";
			this.radioBtnCornellSmart.Size = new System.Drawing.Size(202, 21);
			this.radioBtnCornellSmart.TabIndex = 6;
			this.radioBtnCornellSmart.TabStop = true;
			this.radioBtnCornellSmart.Text = "Normalizarea Cornell Smart";
			this.radioBtnCornellSmart.UseVisualStyleBackColor = true;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(559, 72);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(242, 20);
			this.label1.TabIndex = 7;
			this.label1.Text = "Alegeti normalizarea dorita:";
			// 
			// btnSelect
			// 
			this.btnSelect.Location = new System.Drawing.Point(632, 231);
			this.btnSelect.Name = "btnSelect";
			this.btnSelect.Size = new System.Drawing.Size(75, 23);
			this.btnSelect.TabIndex = 8;
			this.btnSelect.Text = "Select";
			this.btnSelect.UseVisualStyleBackColor = true;
			this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.Controls.Add(this.btnSelect);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.radioBtnCornellSmart);
			this.Controls.Add(this.radioBtnSuma1);
			this.Controls.Add(this.radioBtnNominala);
			this.Controls.Add(this.radioBtbBinara);
			this.Controls.Add(this.pragForm);
			this.Controls.Add(this.selectieTrasaturiBtn);
			this.Controls.Add(this.btnExtTras);
			this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.Name = "Form1";
			this.Text = "Form1";
			((System.ComponentModel.ISupportInitialize)(this.pragForm)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnExtTras;
        private System.Windows.Forms.Button selectieTrasaturiBtn;
        private System.Windows.Forms.NumericUpDown pragForm;
		private System.Windows.Forms.RadioButton radioBtbBinara;
		private System.Windows.Forms.RadioButton radioBtnNominala;
		private System.Windows.Forms.RadioButton radioBtnSuma1;
		private System.Windows.Forms.RadioButton radioBtnCornellSmart;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button btnSelect;
	}
}

