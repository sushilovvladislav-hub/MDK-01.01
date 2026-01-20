using System;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace MagicHoroscope
{
    public partial class MagicHoroscope : Form
    {
        private readonly ZodiacCalculator _calculator;
        public MagicHoroscope()
        {
            InitializeComponent();
            
            dateTimePicker.MinDate = new DateTime(1900, 1, 1);
            dateTimePicker.MaxDate = DateTime.Today;
            dateTimePicker.Value = DateTime.Today;
            
            _calculator = new ZodiacCalculator();
            pictureElement.SizeMode = PictureBoxSizeMode.Zoom;
            pictureSign.SizeMode = PictureBoxSizeMode.Zoom;
        }

        private void calcButton_Click(object sender, EventArgs e)
        {
            DateTime selectedDate = dateTimePicker.Value;
            ZodiacSign sign = _calculator.GetSignByDate(selectedDate);

            if (sign == null) 
            {
                MessageBox.Show("Не удалось определить знак зодиака для выбранной даты.", "Ошибка", MessageBoxButtons .OK, MessageBoxIcon.Error);
            }

            txtBoxRes.Text = $"Знак: {sign.Name}\r\n";
            txtBoxRes.AppendText($"Стихия: {sign.Element}\r\n");
            txtBoxRes.AppendText($"{sign.Description}\r\n");
            txtBoxRes.AppendText($"{_calculator.GetElementDescription(sign.Element)}\r\n");
            pictureSign.Image = (Image)Properties.Resources.ResourceManager.GetObject(sign.Name);
            pictureElement.Image = (Image)Properties.Resources.ResourceManager.GetObject(sign.Element);
        }
    }
}
