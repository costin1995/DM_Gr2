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
            this.knnBtn = new System.Windows.Forms.Button();
            this.RBEuclidiana = new System.Windows.Forms.RadioButton();
            this.RBManhattan = new System.Windows.Forms.RadioButton();
            this.kVal = new System.Windows.Forms.NumericUpDown();
            this.castigInformatioalBtn = new System.Windows.Forms.Button();
            this.ImpartireDateBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pragForm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kVal)).BeginInit();
            this.SuspendLayout();
            // 
            // btnExtTras
            // 
            this.btnExtTras.Location = new System.Drawing.Point(13, 367);
            this.btnExtTras.Margin = new System.Windows.Forms.Padding(4);
            this.btnExtTras.Name = "btnExtTras";
            this.btnExtTras.Size = new System.Drawing.Size(159, 57);
            this.btnExtTras.TabIndex = 0;
            this.btnExtTras.Text = "Extragere Trasaturi";
            this.btnExtTras.UseVisualStyleBackColor = true;
            this.btnExtTras.Click += new System.EventHandler(this.btnExtTras_Click);
            // 
            // selectieTrasaturiBtn
            // 
            this.selectieTrasaturiBtn.Location = new System.Drawing.Point(289, 65);
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
            this.pragForm.Location = new System.Drawing.Point(302, 137);
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
            this.radioBtbBinara.Location = new System.Drawing.Point(572, 57);
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
            this.radioBtnNominala.Location = new System.Drawing.Point(572, 84);
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
            this.radioBtnSuma1.Location = new System.Drawing.Point(572, 111);
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
            this.radioBtnCornellSmart.Location = new System.Drawing.Point(572, 138);
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
            this.label1.Location = new System.Drawing.Point(532, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(242, 20);
            this.label1.TabIndex = 7;
            this.label1.Text = "Alegeti normalizarea dorita:";
            // 
            // btnSelect
            // 
            this.btnSelect.Location = new System.Drawing.Point(613, 165);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(75, 23);
            this.btnSelect.TabIndex = 8;
            this.btnSelect.Text = "Select";
            this.btnSelect.UseVisualStyleBackColor = true;
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // knnBtn
            // 
            this.knnBtn.Location = new System.Drawing.Point(381, 352);
            this.knnBtn.Name = "knnBtn";
            this.knnBtn.Size = new System.Drawing.Size(117, 44);
            this.knnBtn.TabIndex = 9;
            this.knnBtn.Text = "KNN";
            this.knnBtn.UseVisualStyleBackColor = true;
            this.knnBtn.Click += new System.EventHandler(this.knnBtn_Click);
            // 
            // RBEuclidiana
            // 
            this.RBEuclidiana.AutoSize = true;
            this.RBEuclidiana.Location = new System.Drawing.Point(369, 282);
            this.RBEuclidiana.Name = "RBEuclidiana";
            this.RBEuclidiana.Size = new System.Drawing.Size(148, 21);
            this.RBEuclidiana.TabIndex = 10;
            this.RBEuclidiana.TabStop = true;
            this.RBEuclidiana.Text = "distanta Euclidiana";
            this.RBEuclidiana.UseVisualStyleBackColor = true;
            // 
            // RBManhattan
            // 
            this.RBManhattan.AutoSize = true;
            this.RBManhattan.Location = new System.Drawing.Point(367, 318);
            this.RBManhattan.Name = "RBManhattan";
            this.RBManhattan.Size = new System.Drawing.Size(150, 21);
            this.RBManhattan.TabIndex = 11;
            this.RBManhattan.TabStop = true;
            this.RBManhattan.Text = "distanta Manhatten";
            this.RBManhattan.UseVisualStyleBackColor = true;
            // 
            // kVal
            // 
            this.kVal.Location = new System.Drawing.Point(381, 402);
            this.kVal.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.kVal.Name = "kVal";
            this.kVal.Size = new System.Drawing.Size(120, 22);
            this.kVal.TabIndex = 12;
            // 
            // castigInformatioalBtn
            // 
            this.castigInformatioalBtn.Location = new System.Drawing.Point(12, 75);
            this.castigInformatioalBtn.Name = "castigInformatioalBtn";
            this.castigInformatioalBtn.Size = new System.Drawing.Size(141, 57);
            this.castigInformatioalBtn.TabIndex = 13;
            this.castigInformatioalBtn.Text = "Castig Informational";
            this.castigInformatioalBtn.UseVisualStyleBackColor = true;
            this.castigInformatioalBtn.Click += new System.EventHandler(this.castigInformatioalBtn_Click);
            // 
            // ImpartireDateBtn
            // 
            this.ImpartireDateBtn.Location = new System.Drawing.Point(586, 220);
            this.ImpartireDateBtn.Name = "ImpartireDateBtn";
            this.ImpartireDateBtn.Size = new System.Drawing.Size(151, 61);
            this.ImpartireDateBtn.TabIndex = 14;
            this.ImpartireDateBtn.Text = "Impartirea datelor";
            this.ImpartireDateBtn.UseVisualStyleBackColor = true;
            this.ImpartireDateBtn.Click += new System.EventHandler(this.ImpartireDateBtn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.ImpartireDateBtn);
            this.Controls.Add(this.castigInformatioalBtn);
            this.Controls.Add(this.kVal);
            this.Controls.Add(this.RBManhattan);
            this.Controls.Add(this.RBEuclidiana);
            this.Controls.Add(this.knnBtn);
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
            ((System.ComponentModel.ISupportInitialize)(this.kVal)).EndInit();
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
        private System.Windows.Forms.Button knnBtn;
        private System.Windows.Forms.RadioButton RBEuclidiana;
        private System.Windows.Forms.RadioButton RBManhattan;
        private System.Windows.Forms.NumericUpDown kVal;
        private System.Windows.Forms.Button castigInformatioalBtn;
        private System.Windows.Forms.Button ImpartireDateBtn;
    }
}

