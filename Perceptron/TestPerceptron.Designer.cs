namespace Perceptron
{
    partial class TestPerceptron
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
            this.trainingDataGridView = new System.Windows.Forms.DataGridView();
            this.x0 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.x1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.y = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.addInputColumnBtn = new System.Windows.Forms.Button();
            this.RemoveInputColumnBtn = new System.Windows.Forms.Button();
            this.perceptronParametersGridView = new System.Windows.Forms.DataGridView();
            this.trainBtn = new System.Windows.Forms.Button();
            this.addDataBtn = new System.Windows.Forms.Button();
            this.deleteDataBtn = new System.Windows.Forms.Button();
            this.testDataGridView = new System.Windows.Forms.DataGridView();
            this.testBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.trainingDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.perceptronParametersGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.testDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // trainingDataGridView
            // 
            this.trainingDataGridView.AllowUserToAddRows = false;
            this.trainingDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.trainingDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.x0,
            this.x1,
            this.y});
            this.trainingDataGridView.Location = new System.Drawing.Point(29, 153);
            this.trainingDataGridView.Name = "trainingDataGridView";
            this.trainingDataGridView.RowTemplate.Height = 33;
            this.trainingDataGridView.Size = new System.Drawing.Size(1220, 322);
            this.trainingDataGridView.TabIndex = 0;
            // 
            // x0
            // 
            this.x0.HeaderText = "x0";
            this.x0.Name = "x0";
            // 
            // x1
            // 
            this.x1.HeaderText = "x1";
            this.x1.Name = "x1";
            // 
            // y
            // 
            this.y.HeaderText = "y";
            this.y.Name = "y";
            // 
            // addInputColumnBtn
            // 
            this.addInputColumnBtn.Location = new System.Drawing.Point(29, 40);
            this.addInputColumnBtn.Name = "addInputColumnBtn";
            this.addInputColumnBtn.Size = new System.Drawing.Size(204, 60);
            this.addInputColumnBtn.TabIndex = 2;
            this.addInputColumnBtn.Text = "Add input column";
            this.addInputColumnBtn.UseVisualStyleBackColor = true;
            this.addInputColumnBtn.Click += new System.EventHandler(this.AddInputColumnBtn_Click);
            // 
            // RemoveInputColumnBtn
            // 
            this.RemoveInputColumnBtn.BackColor = System.Drawing.SystemColors.Menu;
            this.RemoveInputColumnBtn.Location = new System.Drawing.Point(239, 40);
            this.RemoveInputColumnBtn.Name = "RemoveInputColumnBtn";
            this.RemoveInputColumnBtn.Size = new System.Drawing.Size(254, 60);
            this.RemoveInputColumnBtn.TabIndex = 3;
            this.RemoveInputColumnBtn.Text = "Remove input column";
            this.RemoveInputColumnBtn.UseVisualStyleBackColor = false;
            this.RemoveInputColumnBtn.Click += new System.EventHandler(this.RemoveInputColumnBtn_Click);
            // 
            // perceptronParametersGridView
            // 
            this.perceptronParametersGridView.AllowUserToAddRows = false;
            this.perceptronParametersGridView.AllowUserToDeleteRows = false;
            this.perceptronParametersGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.perceptronParametersGridView.Location = new System.Drawing.Point(29, 541);
            this.perceptronParametersGridView.Name = "perceptronParametersGridView";
            this.perceptronParametersGridView.ReadOnly = true;
            this.perceptronParametersGridView.RowTemplate.Height = 33;
            this.perceptronParametersGridView.Size = new System.Drawing.Size(1220, 322);
            this.perceptronParametersGridView.TabIndex = 4;
            // 
            // trainBtn
            // 
            this.trainBtn.Location = new System.Drawing.Point(1046, 40);
            this.trainBtn.Name = "trainBtn";
            this.trainBtn.Size = new System.Drawing.Size(203, 60);
            this.trainBtn.TabIndex = 5;
            this.trainBtn.Text = "Train";
            this.trainBtn.UseVisualStyleBackColor = true;
            this.trainBtn.Click += new System.EventHandler(this.TrainBtn_Click);
            // 
            // addDataBtn
            // 
            this.addDataBtn.Location = new System.Drawing.Point(557, 40);
            this.addDataBtn.Name = "addDataBtn";
            this.addDataBtn.Size = new System.Drawing.Size(215, 60);
            this.addDataBtn.TabIndex = 6;
            this.addDataBtn.Text = "Add Data";
            this.addDataBtn.UseVisualStyleBackColor = true;
            this.addDataBtn.Click += new System.EventHandler(this.AddDataBtn_Click);
            // 
            // deleteDataBtn
            // 
            this.deleteDataBtn.Location = new System.Drawing.Point(778, 40);
            this.deleteDataBtn.Name = "deleteDataBtn";
            this.deleteDataBtn.Size = new System.Drawing.Size(215, 60);
            this.deleteDataBtn.TabIndex = 7;
            this.deleteDataBtn.Text = "Delete Data";
            this.deleteDataBtn.UseVisualStyleBackColor = true;
            this.deleteDataBtn.Click += new System.EventHandler(this.DeleteDataBtn_Click);
            // 
            // testDataGridView
            // 
            this.testDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.testDataGridView.Location = new System.Drawing.Point(29, 927);
            this.testDataGridView.Name = "testDataGridView";
            this.testDataGridView.RowTemplate.Height = 33;
            this.testDataGridView.Size = new System.Drawing.Size(1029, 283);
            this.testDataGridView.TabIndex = 8;
            // 
            // testBtn
            // 
            this.testBtn.Enabled = false;
            this.testBtn.Location = new System.Drawing.Point(1084, 927);
            this.testBtn.Name = "testBtn";
            this.testBtn.Size = new System.Drawing.Size(165, 68);
            this.testBtn.TabIndex = 9;
            this.testBtn.Text = "Test";
            this.testBtn.UseVisualStyleBackColor = true;
            this.testBtn.Click += new System.EventHandler(this.TestBtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(27, 902);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(146, 25);
            this.label1.TabIndex = 10;
            this.label1.Text = "Testing Data";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(27, 516);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(252, 25);
            this.label2.TabIndex = 11;
            this.label2.Text = "Perceptron parameters";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(27, 128);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(151, 25);
            this.label3.TabIndex = 12;
            this.label3.Text = "Training data";
            // 
            // TestPerceptron
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1280, 1226);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.testBtn);
            this.Controls.Add(this.testDataGridView);
            this.Controls.Add(this.deleteDataBtn);
            this.Controls.Add(this.addDataBtn);
            this.Controls.Add(this.trainBtn);
            this.Controls.Add(this.perceptronParametersGridView);
            this.Controls.Add(this.RemoveInputColumnBtn);
            this.Controls.Add(this.addInputColumnBtn);
            this.Controls.Add(this.trainingDataGridView);
            this.Name = "TestPerceptron";
            this.Padding = new System.Windows.Forms.Padding(3);
            this.Text = "Perceptron";
            ((System.ComponentModel.ISupportInitialize)(this.trainingDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.perceptronParametersGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.testDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView trainingDataGridView;
        private System.Windows.Forms.Button addInputColumnBtn;
        private System.Windows.Forms.Button RemoveInputColumnBtn;
        private System.Windows.Forms.DataGridView perceptronParametersGridView;
        private System.Windows.Forms.Button trainBtn;
        private System.Windows.Forms.Button addDataBtn;
        private System.Windows.Forms.Button deleteDataBtn;
        private System.Windows.Forms.DataGridViewTextBoxColumn x0;
        private System.Windows.Forms.DataGridViewTextBoxColumn x1;
        private System.Windows.Forms.DataGridViewTextBoxColumn y;
        private System.Windows.Forms.DataGridView testDataGridView;
        private System.Windows.Forms.Button testBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}

