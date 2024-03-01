using ConverterLib;

namespace ConverterApp
{
    public partial class Form1 : Form
    {
        ConverterLib.ConverterManager cm;
        public Form1()
        {
            InitializeComponent();
            cm = new ConverterLib.ConverterManager();
            comboBox1.Items.AddRange(cm.GetPhysValuesList().ToArray());
            comboBox1.SelectedIndex = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                double num = Convert.ToDouble(textBox1.Text);
                string phValue = comboBox1.Text;
                string from = comboBox2.Text;
                string to = comboBox3.Text;

                textBox2.Text = cm.GetConvertedValue(num, from, to, phValue).ToString();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox2.Items.Clear();
            comboBox2.Items.AddRange(cm.GetMeasureList(comboBox1.Text).ToArray());
            comboBox2.SelectedIndex = 0;

            comboBox3.Items.Clear();
            comboBox3.Items.AddRange(cm.GetMeasureList(comboBox1.Text).ToArray());
            comboBox3.SelectedIndex = 0;
        }
    }
}