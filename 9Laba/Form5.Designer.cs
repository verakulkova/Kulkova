namespace _9Laba
{
    partial class Form5
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.Label date_salesLabel;
            this.label1 = new System.Windows.Forms.Label();
            this.bOOKSDataSet = new _9Laba.BOOKSDataSet();
            this.publishBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.publishTableAdapter = new _9Laba.BOOKSDataSetTableAdapters.publishTableAdapter();
            this.tableAdapterManager = new _9Laba.BOOKSDataSetTableAdapters.TableAdapterManager();
            this.salesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.salesTableAdapter = new _9Laba.BOOKSDataSetTableAdapters.salesTableAdapter();
            this.date_salesDateTimePicker = new System.Windows.Forms.DateTimePicker();
            date_salesLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.bOOKSDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.publishBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.salesBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label1.Location = new System.Drawing.Point(113, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(161, 23);
            this.label1.TabIndex = 1;
            this.label1.Text = "Таблица Заказы";
            // 
            // bOOKSDataSet
            // 
            this.bOOKSDataSet.DataSetName = "BOOKSDataSet";
            this.bOOKSDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // publishBindingSource
            // 
            this.publishBindingSource.DataMember = "publish";
            this.publishBindingSource.DataSource = this.bOOKSDataSet;
            // 
            // publishTableAdapter
            // 
            this.publishTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.authorsTableAdapter = null;
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.booksTableAdapter = null;
            this.tableAdapterManager.composition_salesTableAdapter = null;
            this.tableAdapterManager.publisherTableAdapter = null;
            this.tableAdapterManager.publishTableAdapter = this.publishTableAdapter;
            this.tableAdapterManager.salesTableAdapter = this.salesTableAdapter;
            this.tableAdapterManager.UpdateOrder = _9Laba.BOOKSDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // salesBindingSource
            // 
            this.salesBindingSource.DataMember = "sales";
            this.salesBindingSource.DataSource = this.bOOKSDataSet;
            // 
            // salesTableAdapter
            // 
            this.salesTableAdapter.ClearBeforeFill = true;
            // 
            // date_salesLabel
            // 
            date_salesLabel.AutoSize = true;
            date_salesLabel.Location = new System.Drawing.Point(85, 138);
            date_salesLabel.Name = "date_salesLabel";
            date_salesLabel.Size = new System.Drawing.Size(58, 13);
            date_salesLabel.TabIndex = 1;
            date_salesLabel.Text = "date sales:";
            // 
            // date_salesDateTimePicker
            // 
            this.date_salesDateTimePicker.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.salesBindingSource, "date_sales", true));
            this.date_salesDateTimePicker.Location = new System.Drawing.Point(149, 134);
            this.date_salesDateTimePicker.Name = "date_salesDateTimePicker";
            this.date_salesDateTimePicker.Size = new System.Drawing.Size(200, 20);
            this.date_salesDateTimePicker.TabIndex = 2;
            // 
            // Form5
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(435, 348);
            this.Controls.Add(date_salesLabel);
            this.Controls.Add(this.date_salesDateTimePicker);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form5";
            this.Text = "Таблица Заказы";
            this.Load += new System.EventHandler(this.Form5_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bOOKSDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.publishBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.salesBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private BOOKSDataSet bOOKSDataSet;
        private System.Windows.Forms.BindingSource publishBindingSource;
        private BOOKSDataSetTableAdapters.publishTableAdapter publishTableAdapter;
        private BOOKSDataSetTableAdapters.TableAdapterManager tableAdapterManager;
        private BOOKSDataSetTableAdapters.salesTableAdapter salesTableAdapter;
        private System.Windows.Forms.BindingSource salesBindingSource;
        private System.Windows.Forms.DateTimePicker date_salesDateTimePicker;
    }
}