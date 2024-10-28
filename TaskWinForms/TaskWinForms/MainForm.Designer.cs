namespace TaskWinForms
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            LoadData = new Button();
            district = new ComboBox();
            firstDeliveryTime = new DateTimePicker();
            Filter = new Button();
            Orders = new DataGridView();
            SaveData = new Button();
            statusStrip = new StatusStrip();
            statusLabel = new ToolStripStatusLabel();
            openFileDialog = new OpenFileDialog();
            saveFileDialog = new SaveFileDialog();
            ((System.ComponentModel.ISupportInitialize)Orders).BeginInit();
            statusStrip.SuspendLayout();
            SuspendLayout();
            // 
            // LoadData
            // 
            LoadData.AutoSize = true;
            LoadData.Location = new Point(82, 194);
            LoadData.MinimumSize = new Size(177, 40);
            LoadData.Name = "LoadData";
            LoadData.Size = new Size(177, 40);
            LoadData.TabIndex = 0;
            LoadData.Text = "Загрузить данные";
            LoadData.UseVisualStyleBackColor = true;
            LoadData.Click += LoadData_Click;
            // 
            // district
            // 
            district.Anchor = AnchorStyles.Top;
            district.FormattingEnabled = true;
            district.Location = new Point(516, 201);
            district.MinimumSize = new Size(121, 0);
            district.Name = "district";
            district.Size = new Size(121, 23);
            district.TabIndex = 1;
            // 
            // firstDeliveryTime
            // 
            firstDeliveryTime.Anchor = AnchorStyles.Top;
            firstDeliveryTime.Format = DateTimePickerFormat.Time;
            firstDeliveryTime.Location = new Point(280, 201);
            firstDeliveryTime.MinimumSize = new Size(200, 23);
            firstDeliveryTime.Name = "firstDeliveryTime";
            firstDeliveryTime.Size = new Size(200, 23);
            firstDeliveryTime.TabIndex = 2;
            // 
            // Filter
            // 
            Filter.Anchor = AnchorStyles.Top;
            Filter.Location = new Point(310, 230);
            Filter.MinimumSize = new Size(137, 42);
            Filter.Name = "Filter";
            Filter.Size = new Size(137, 42);
            Filter.TabIndex = 3;
            Filter.Text = "Фильтровать";
            Filter.UseVisualStyleBackColor = true;
            Filter.Click += Filter_Click;
            // 
            // Orders
            // 
            Orders.Anchor = AnchorStyles.Top;
            Orders.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            Orders.Location = new Point(82, 32);
            Orders.MinimumSize = new Size(648, 152);
            Orders.Name = "Orders";
            Orders.Size = new Size(648, 152);
            Orders.TabIndex = 4;
            // 
            // SaveData
            // 
            SaveData.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            SaveData.Location = new Point(665, 354);
            SaveData.MinimumSize = new Size(112, 51);
            SaveData.Name = "SaveData";
            SaveData.Size = new Size(112, 51);
            SaveData.TabIndex = 5;
            SaveData.Text = "Сохранить результаты";
            SaveData.UseVisualStyleBackColor = true;
            SaveData.Click += SaveData_Click;
            // 
            // statusStrip
            // 
            statusStrip.Items.AddRange(new ToolStripItem[] { statusLabel });
            statusStrip.Location = new Point(0, 428);
            statusStrip.Name = "statusStrip";
            statusStrip.Size = new Size(800, 22);
            statusStrip.TabIndex = 6;
            statusStrip.Text = "statusStrip1";
            // 
            // statusLabel
            // 
            statusLabel.Name = "statusLabel";
            statusLabel.Size = new Size(45, 17);
            statusLabel.Text = "Готово";
            // 
            // openFileDialog
            // 
            openFileDialog.FileName = "openFileDialog1";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(statusStrip);
            Controls.Add(SaveData);
            Controls.Add(Orders);
            Controls.Add(Filter);
            Controls.Add(firstDeliveryTime);
            Controls.Add(district);
            Controls.Add(LoadData);
            Name = "MainForm";
            Text = "Приложение для фильтрации";
            ((System.ComponentModel.ISupportInitialize)Orders).EndInit();
            statusStrip.ResumeLayout(false);
            statusStrip.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button LoadData;
        private ComboBox district;
        private DateTimePicker firstDeliveryTime;
        private Button Filter;
        private DataGridView Orders;
        private Button SaveData;
        private StatusStrip statusStrip;
        private OpenFileDialog openFileDialog;
        private SaveFileDialog saveFileDialog;
        private ToolStripStatusLabel statusLabel;
    }
}
