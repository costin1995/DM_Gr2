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
            this.btnEvKNN = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.pragForm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kVal)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnExtTras
            // 
            this.btnExtTras.Location = new System.Drawing.Point(76, 183);
            this.btnExtTras.Name = "btnExtTras";
            this.btnExtTras.Size = new System.Drawing.Size(119, 46);
            this.btnExtTras.TabIndex = 0;
            this.btnExtTras.Text = "Extragere Trasaturi";
            this.btnExtTras.UseVisualStyleBackColor = true;
            this.btnExtTras.Click += new System.EventHandler(this.btnExtTras_Click);
            // 
            // selectieTrasaturiBtn
            // 
            this.selectieTrasaturiBtn.Location = new System.Drawing.Point(5, 18);
            this.selectieTrasaturiBtn.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.selectieTrasaturiBtn.Name = "selectieTrasaturiBtn";
            this.selectieTrasaturiBtn.Size = new System.Drawing.Size(105, 48);
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
            this.pragForm.Location = new System.Drawing.Point(12, 81);
            this.pragForm.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pragForm.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.pragForm.Name = "pragForm";
            this.pragForm.Size = new System.Drawing.Size(90, 20);
            this.pragForm.TabIndex = 2;
            // 
            // radioBtbBinara
            // 
            this.radioBtbBinara.AutoSize = true;
            this.radioBtbBinara.Location = new System.Drawing.Point(34, 56);
            this.radioBtbBinara.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.radioBtbBinara.Name = "radioBtbBinara";
            this.radioBtbBinara.Size = new System.Drawing.Size(119, 17);
            this.radioBtbBinara.TabIndex = 3;
            this.radioBtbBinara.TabStop = true;
            this.radioBtbBinara.Text = "Normalizarea Binara";
            this.radioBtbBinara.UseVisualStyleBackColor = true;
            // 
            // radioBtnNominala
            // 
            this.radioBtnNominala.AutoSize = true;
            this.radioBtnNominala.Location = new System.Drawing.Point(34, 78);
            this.radioBtnNominala.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.radioBtnNominala.Name = "radioBtnNominala";
            this.radioBtnNominala.Size = new System.Drawing.Size(133, 17);
            this.radioBtnNominala.TabIndex = 4;
            this.radioBtnNominala.TabStop = true;
            this.radioBtnNominala.Text = "Normalizarea Nominala";
            this.radioBtnNominala.UseVisualStyleBackColor = true;
            // 
            // radioBtnSuma1
            // 
            this.radioBtnSuma1.AutoSize = true;
            this.radioBtnSuma1.Location = new System.Drawing.Point(34, 100);
            this.radioBtnSuma1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.radioBtnSuma1.Name = "radioBtnSuma1";
            this.radioBtnSuma1.Size = new System.Drawing.Size(125, 17);
            this.radioBtnSuma1.TabIndex = 5;
            this.radioBtnSuma1.TabStop = true;
            this.radioBtnSuma1.Text = "Normalizarea Suma 1";
            this.radioBtnSuma1.UseVisualStyleBackColor = true;
            // 
            // radioBtnCornellSmart
            // 
            this.radioBtnCornellSmart.AutoSize = true;
            this.radioBtnCornellSmart.Location = new System.Drawing.Point(34, 122);
            this.radioBtnCornellSmart.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.radioBtnCornellSmart.Name = "radioBtnCornellSmart";
            this.radioBtnCornellSmart.Size = new System.Drawing.Size(151, 17);
            this.radioBtnCornellSmart.TabIndex = 6;
            this.radioBtnCornellSmart.TabStop = true;
            this.radioBtnCornellSmart.Text = "Normalizarea Cornell Smart";
            this.radioBtnCornellSmart.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(4, 30);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(209, 17);
            this.label1.TabIndex = 7;
            this.label1.Text = "Alegeti normalizarea dorita:";
            // 
            // btnSelect
            // 
            this.btnSelect.Location = new System.Drawing.Point(65, 144);
            this.btnSelect.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(56, 19);
            this.btnSelect.TabIndex = 8;
            this.btnSelect.Text = "Select";
            this.btnSelect.UseVisualStyleBackColor = true;
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // knnBtn
            // 
            this.knnBtn.Location = new System.Drawing.Point(7, 18);
            this.knnBtn.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.knnBtn.Name = "knnBtn";
            this.knnBtn.Size = new System.Drawing.Size(88, 36);
            this.knnBtn.TabIndex = 9;
            this.knnBtn.Text = "KNN";
            this.knnBtn.UseVisualStyleBackColor = true;
            this.knnBtn.Click += new System.EventHandler(this.knnBtn_Click);
            // 
            // RBEuclidiana
            // 
            this.RBEuclidiana.AutoSize = true;
            this.RBEuclidiana.Location = new System.Drawing.Point(10, 18);
            this.RBEuclidiana.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.RBEuclidiana.Name = "RBEuclidiana";
            this.RBEuclidiana.Size = new System.Drawing.Size(114, 17);
            this.RBEuclidiana.TabIndex = 10;
            this.RBEuclidiana.TabStop = true;
            this.RBEuclidiana.Text = "distanta Euclidiana";
            this.RBEuclidiana.UseVisualStyleBackColor = true;
            // 
            // RBManhattan
            // 
            this.RBManhattan.AutoSize = true;
            this.RBManhattan.Location = new System.Drawing.Point(10, 39);
            this.RBManhattan.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.RBManhattan.Name = "RBManhattan";
            this.RBManhattan.Size = new System.Drawing.Size(116, 17);
            this.RBManhattan.TabIndex = 11;
            this.RBManhattan.TabStop = true;
            this.RBManhattan.Text = "distanta Manhatten";
            this.RBManhattan.UseVisualStyleBackColor = true;
            // 
            // kVal
            // 
            this.kVal.Location = new System.Drawing.Point(19, 60);
            this.kVal.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.kVal.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.kVal.Name = "kVal";
            this.kVal.Size = new System.Drawing.Size(90, 20);
            this.kVal.TabIndex = 12;
            // 
            // castigInformatioalBtn
            // 
            this.castigInformatioalBtn.Location = new System.Drawing.Point(11, 16);
            this.castigInformatioalBtn.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.castigInformatioalBtn.Name = "castigInformatioalBtn";
            this.castigInformatioalBtn.Size = new System.Drawing.Size(106, 46);
            this.castigInformatioalBtn.TabIndex = 13;
            this.castigInformatioalBtn.Text = "Castig Informational";
            this.castigInformatioalBtn.UseVisualStyleBackColor = true;
            this.castigInformatioalBtn.Click += new System.EventHandler(this.castigInformatioalBtn_Click);
            // 
            // ImpartireDateBtn
            // 
            this.ImpartireDateBtn.Location = new System.Drawing.Point(11, 15);
            this.ImpartireDateBtn.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.ImpartireDateBtn.Name = "ImpartireDateBtn";
            this.ImpartireDateBtn.Size = new System.Drawing.Size(113, 50);
            this.ImpartireDateBtn.TabIndex = 14;
            this.ImpartireDateBtn.Text = "Impartirea datelor";
            this.ImpartireDateBtn.UseVisualStyleBackColor = true;
            this.ImpartireDateBtn.Click += new System.EventHandler(this.ImpartireDateBtn_Click);
            // 
            // btnEvKNN
            // 
            this.btnEvKNN.Location = new System.Drawing.Point(97, 128);
            this.btnEvKNN.Name = "btnEvKNN";
            this.btnEvKNN.Size = new System.Drawing.Size(124, 45);
            this.btnEvKNN.TabIndex = 15;
            this.btnEvKNN.Text = "Evaluare KNN";
            this.btnEvKNN.UseVisualStyleBackColor = true;
            this.btnEvKNN.Click += new System.EventHandler(this.btnEvKNN_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.castigInformatioalBtn);
            this.groupBox1.Location = new System.Drawing.Point(28, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(129, 70);
            this.groupBox1.TabIndex = 16;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Pas1";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.selectieTrasaturiBtn);
            this.groupBox2.Controls.Add(this.pragForm);
            this.groupBox2.Location = new System.Drawing.Point(198, 17);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(118, 115);
            this.groupBox2.TabIndex = 17;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Pas2";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.radioBtnNominala);
            this.groupBox3.Controls.Add(this.radioBtbBinara);
            this.groupBox3.Controls.Add(this.radioBtnSuma1);
            this.groupBox3.Controls.Add(this.radioBtnCornellSmart);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.btnSelect);
            this.groupBox3.Location = new System.Drawing.Point(345, 17);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(218, 183);
            this.groupBox3.TabIndex = 18;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Pas3";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.ImpartireDateBtn);
            this.groupBox4.Location = new System.Drawing.Point(375, 222);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(129, 70);
            this.groupBox4.TabIndex = 19;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Pas4";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.RBEuclidiana);
            this.groupBox5.Controls.Add(this.RBManhattan);
            this.groupBox5.Controls.Add(this.kVal);
            this.groupBox5.Location = new System.Drawing.Point(375, 298);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(129, 87);
            this.groupBox5.TabIndex = 20;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Pas5";
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.knnBtn);
            this.groupBox6.Location = new System.Drawing.Point(375, 403);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(102, 63);
            this.groupBox6.TabIndex = 21;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Pas6";
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(11, 19);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(288, 103);
            this.textBox1.TabIndex = 22;
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.textBox1);
            this.groupBox7.Controls.Add(this.btnEvKNN);
            this.groupBox7.Location = new System.Drawing.Point(28, 298);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(305, 183);
            this.groupBox7.TabIndex = 23;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Partea de Evaluare";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 615);
            this.Controls.Add(this.groupBox7);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnExtTras);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pragForm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kVal)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.ResumeLayout(false);

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
        private System.Windows.Forms.Button btnEvKNN;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.GroupBox groupBox7;
    }
}

