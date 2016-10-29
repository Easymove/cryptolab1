using System.ComponentModel;
using System.Windows.Forms;

namespace cryptolab1
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

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
            this.components = new System.ComponentModel.Container();
            this.probabilityTable = new System.Windows.Forms.DataGridView();
            this.choiseLabel = new System.Windows.Forms.Label();
            this.tableDropdown = new System.Windows.Forms.ComboBox();
            this.tableNames = new System.Windows.Forms.BindingSource(this.components);
            this.tableData = new System.Windows.Forms.BindingSource(this.components);
            this.renderButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.mCountBox = new System.Windows.Forms.NumericUpDown();
            this.kCountBox = new System.Windows.Forms.NumericUpDown();
            this.eCountBox = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.randomDropdown = new System.Windows.Forms.ComboBox();
            this.randomMode = new System.Windows.Forms.BindingSource(this.components);
            this.computeButton = new System.Windows.Forms.Button();
            this.saveButton = new System.Windows.Forms.Button();
            this.genButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.probabilityTable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tableNames)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tableData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mCountBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kCountBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.eCountBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.randomMode)).BeginInit();
            this.SuspendLayout();
            // 
            // probabilityTable
            // 
            this.probabilityTable.AllowUserToAddRows = false;
            this.probabilityTable.AllowUserToDeleteRows = false;
            this.probabilityTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.probabilityTable.Location = new System.Drawing.Point(17, 58);
            this.probabilityTable.Name = "probabilityTable";
            this.probabilityTable.Size = new System.Drawing.Size(737, 417);
            this.probabilityTable.TabIndex = 0;
            // 
            // choiseLabel
            // 
            this.choiseLabel.AutoSize = true;
            this.choiseLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.choiseLabel.Location = new System.Drawing.Point(12, 9);
            this.choiseLabel.Name = "choiseLabel";
            this.choiseLabel.Size = new System.Drawing.Size(72, 25);
            this.choiseLabel.TabIndex = 1;
            this.choiseLabel.Text = "Table:";
            // 
            // tableDropdown
            // 
            this.tableDropdown.DataSource = this.tableNames;
            this.tableDropdown.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tableDropdown.FormattingEnabled = true;
            this.tableDropdown.Location = new System.Drawing.Point(90, 12);
            this.tableDropdown.Name = "tableDropdown";
            this.tableDropdown.Size = new System.Drawing.Size(249, 24);
            this.tableDropdown.TabIndex = 2;
            // 
            // renderButton
            // 
            this.renderButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.renderButton.Location = new System.Drawing.Point(760, 58);
            this.renderButton.Name = "renderButton";
            this.renderButton.Size = new System.Drawing.Size(112, 43);
            this.renderButton.TabIndex = 3;
            this.renderButton.Text = "render";
            this.renderButton.UseVisualStyleBackColor = true;
            this.renderButton.Click += new System.EventHandler(this.renderButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(464, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 25);
            this.label1.TabIndex = 4;
            this.label1.Text = "|M|:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(569, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 25);
            this.label2.TabIndex = 6;
            this.label2.Text = "|K|:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(662, 11);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 25);
            this.label3.TabIndex = 8;
            this.label3.Text = "|E|:";
            // 
            // mCountBox
            // 
            this.mCountBox.Location = new System.Drawing.Point(516, 16);
            this.mCountBox.Name = "mCountBox";
            this.mCountBox.Size = new System.Drawing.Size(44, 20);
            this.mCountBox.TabIndex = 10;
            this.mCountBox.Value = new decimal(new int[] {
            6,
            0,
            0,
            0});
            // 
            // kCountBox
            // 
            this.kCountBox.Location = new System.Drawing.Point(612, 16);
            this.kCountBox.Name = "kCountBox";
            this.kCountBox.Size = new System.Drawing.Size(44, 20);
            this.kCountBox.TabIndex = 11;
            this.kCountBox.Value = new decimal(new int[] {
            6,
            0,
            0,
            0});
            // 
            // eCountBox
            // 
            this.eCountBox.Location = new System.Drawing.Point(710, 16);
            this.eCountBox.Name = "eCountBox";
            this.eCountBox.Size = new System.Drawing.Size(44, 20);
            this.eCountBox.TabIndex = 12;
            this.eCountBox.Value = new decimal(new int[] {
            6,
            0,
            0,
            0});
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(345, 11);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(32, 25);
            this.label4.TabIndex = 13;
            this.label4.Text = "P:";
            // 
            // randomDropdown
            // 
            this.randomDropdown.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.randomDropdown.FormattingEnabled = true;
            this.randomDropdown.Location = new System.Drawing.Point(374, 13);
            this.randomDropdown.Name = "randomDropdown";
            this.randomDropdown.Size = new System.Drawing.Size(75, 24);
            this.randomDropdown.TabIndex = 14;
            // 
            // computeButton
            // 
            this.computeButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.computeButton.Location = new System.Drawing.Point(760, 156);
            this.computeButton.Name = "computeButton";
            this.computeButton.Size = new System.Drawing.Size(112, 43);
            this.computeButton.TabIndex = 15;
            this.computeButton.Text = "compute";
            this.computeButton.UseVisualStyleBackColor = true;
            this.computeButton.Click += new System.EventHandler(this.computeButton_Click);
            // 
            // saveButton
            // 
            this.saveButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.saveButton.Location = new System.Drawing.Point(760, 276);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(112, 43);
            this.saveButton.TabIndex = 16;
            this.saveButton.Text = "save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // genButton
            // 
            this.genButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.genButton.Location = new System.Drawing.Point(760, 107);
            this.genButton.Name = "genButton";
            this.genButton.Size = new System.Drawing.Size(112, 43);
            this.genButton.TabIndex = 17;
            this.genButton.Text = "generate";
            this.genButton.UseVisualStyleBackColor = true;
            this.genButton.Click += new System.EventHandler(this.genButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(879, 485);
            this.Controls.Add(this.genButton);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.computeButton);
            this.Controls.Add(this.randomDropdown);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.eCountBox);
            this.Controls.Add(this.kCountBox);
            this.Controls.Add(this.mCountBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.renderButton);
            this.Controls.Add(this.tableDropdown);
            this.Controls.Add(this.choiseLabel);
            this.Controls.Add(this.probabilityTable);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(895, 524);
            this.MinimumSize = new System.Drawing.Size(895, 524);
            this.Name = "MainForm";
            this.ShowIcon = false;
            this.Text = "cryptolab";
            ((System.ComponentModel.ISupportInitialize)(this.probabilityTable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tableNames)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tableData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mCountBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kCountBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.eCountBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.randomMode)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DataGridView probabilityTable;
        private Label choiseLabel;
        private ComboBox tableDropdown;
        private BindingSource tableData;
        private BindingSource tableNames;
        private Button renderButton;
        private Label label1;
        private Label label2;
        private Label label3;
        private NumericUpDown mCountBox;
        private NumericUpDown kCountBox;
        private NumericUpDown eCountBox;
        private Label label4;
        private ComboBox randomDropdown;
        private BindingSource randomMode;
        private Button computeButton;
        private Button saveButton;
        private Button genButton;
    }
}

