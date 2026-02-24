namespace MagicHoroscope
{
    partial class MagicHoroscope
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MagicHoroscope));
            this.panelHead = new System.Windows.Forms.Panel();
            this.txtHead = new System.Windows.Forms.Label();
            this.dateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.calcButton = new System.Windows.Forms.Button();
            this.pictureSign = new System.Windows.Forms.PictureBox();
            this.pictureElement = new System.Windows.Forms.PictureBox();
            this.txtBoxRes = new System.Windows.Forms.TextBox();
            this.outputGroup = new System.Windows.Forms.GroupBox();
            this.helloLabel = new System.Windows.Forms.Label();
            this.panelHead.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureSign)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureElement)).BeginInit();
            this.outputGroup.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelHead
            // 
            this.panelHead.BackColor = System.Drawing.Color.Transparent;
            this.panelHead.Controls.Add(this.txtHead);
            this.panelHead.Location = new System.Drawing.Point(12, 12);
            this.panelHead.Name = "panelHead";
            this.panelHead.Size = new System.Drawing.Size(776, 88);
            this.panelHead.TabIndex = 0;
            // 
            // txtHead
            // 
            this.txtHead.AutoSize = true;
            this.txtHead.BackColor = System.Drawing.Color.Transparent;
            this.txtHead.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtHead.ForeColor = System.Drawing.Color.White;
            this.txtHead.Location = new System.Drawing.Point(169, 13);
            this.txtHead.Name = "txtHead";
            this.txtHead.Size = new System.Drawing.Size(399, 55);
            this.txtHead.TabIndex = 0;
            this.txtHead.Text = "Magic Horoscope";
            // 
            // dateTimePicker
            // 
            this.dateTimePicker.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.dateTimePicker.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker.CalendarMonthBackground = System.Drawing.Color.White;
            this.dateTimePicker.CalendarTitleBackColor = System.Drawing.Color.White;
            this.dateTimePicker.Cursor = System.Windows.Forms.Cursors.Default;
            this.dateTimePicker.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.dateTimePicker.Location = new System.Drawing.Point(12, 208);
            this.dateTimePicker.MaxDate = new System.DateTime(2026, 1, 18, 18, 45, 10, 0);
            this.dateTimePicker.MinDate = new System.DateTime(1926, 1, 1, 0, 0, 0, 0);
            this.dateTimePicker.Name = "dateTimePicker";
            this.dateTimePicker.Size = new System.Drawing.Size(286, 29);
            this.dateTimePicker.TabIndex = 0;
            this.dateTimePicker.Value = new System.DateTime(2026, 1, 18, 0, 0, 0, 0);
            // 
            // calcButton
            // 
            this.calcButton.BackColor = System.Drawing.Color.White;
            this.calcButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.calcButton.ForeColor = System.Drawing.Color.Black;
            this.calcButton.Location = new System.Drawing.Point(12, 261);
            this.calcButton.Name = "calcButton";
            this.calcButton.Size = new System.Drawing.Size(286, 105);
            this.calcButton.TabIndex = 1;
            this.calcButton.Text = "Calculate";
            this.calcButton.UseVisualStyleBackColor = false;
            this.calcButton.Click += new System.EventHandler(this.calcButton_Click);
            // 
            // pictureSign
            // 
            this.pictureSign.BackColor = System.Drawing.Color.White;
            this.pictureSign.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureSign.Location = new System.Drawing.Point(305, 19);
            this.pictureSign.Name = "pictureSign";
            this.pictureSign.Size = new System.Drawing.Size(128, 128);
            this.pictureSign.TabIndex = 2;
            this.pictureSign.TabStop = false;
            // 
            // pictureElement
            // 
            this.pictureElement.BackColor = System.Drawing.Color.White;
            this.pictureElement.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureElement.Location = new System.Drawing.Point(305, 156);
            this.pictureElement.Name = "pictureElement";
            this.pictureElement.Size = new System.Drawing.Size(128, 128);
            this.pictureElement.TabIndex = 3;
            this.pictureElement.TabStop = false;
            // 
            // txtBoxRes
            // 
            this.txtBoxRes.BackColor = System.Drawing.Color.White;
            this.txtBoxRes.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtBoxRes.Location = new System.Drawing.Point(6, 19);
            this.txtBoxRes.Multiline = true;
            this.txtBoxRes.Name = "txtBoxRes";
            this.txtBoxRes.ReadOnly = true;
            this.txtBoxRes.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtBoxRes.Size = new System.Drawing.Size(276, 309);
            this.txtBoxRes.TabIndex = 4;
            // 
            // outputGroup
            // 
            this.outputGroup.BackColor = System.Drawing.Color.Transparent;
            this.outputGroup.Controls.Add(this.pictureSign);
            this.outputGroup.Controls.Add(this.txtBoxRes);
            this.outputGroup.Controls.Add(this.pictureElement);
            this.outputGroup.Location = new System.Drawing.Point(325, 104);
            this.outputGroup.Name = "outputGroup";
            this.outputGroup.Size = new System.Drawing.Size(451, 334);
            this.outputGroup.TabIndex = 5;
            this.outputGroup.TabStop = false;
            // 
            // helloLabel
            // 
            this.helloLabel.AutoSize = true;
            this.helloLabel.BackColor = System.Drawing.Color.Transparent;
            this.helloLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.helloLabel.ForeColor = System.Drawing.Color.White;
            this.helloLabel.Location = new System.Drawing.Point(4, 171);
            this.helloLabel.Name = "helloLabel";
            this.helloLabel.Size = new System.Drawing.Size(319, 16);
            this.helloLabel.TabIndex = 6;
            this.helloLabel.Text = "Choose your birthday in calendar and click on button ";
            // 
            // MagicHoroscope
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = global::MagicHoroscope.Properties.Resources.sky;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.helloLabel);
            this.Controls.Add(this.dateTimePicker);
            this.Controls.Add(this.outputGroup);
            this.Controls.Add(this.calcButton);
            this.Controls.Add(this.panelHead);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MagicHoroscope";
            this.Text = "Magic Horoscope";
            this.panelHead.ResumeLayout(false);
            this.panelHead.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureSign)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureElement)).EndInit();
            this.outputGroup.ResumeLayout(false);
            this.outputGroup.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panelHead;
        private System.Windows.Forms.DateTimePicker dateTimePicker;
        private System.Windows.Forms.Button calcButton;
        private System.Windows.Forms.PictureBox pictureSign;
        private System.Windows.Forms.PictureBox pictureElement;
        private System.Windows.Forms.TextBox txtBoxRes;
        private System.Windows.Forms.GroupBox outputGroup;
        private System.Windows.Forms.Label txtHead;
        private System.Windows.Forms.Label helloLabel;
    }
}

