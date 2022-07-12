using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace How_to_create_HMI_Control_Real_Time
{
    public partial class FormMain : Form
    {
        private ModbusRTUProtocol ModbusRTUProtocol = new ModbusRTUProtocol(10);
        public FormMain()
        {
            InitializeComponent();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            displayControl1.DataBindings.Add("Text", ModbusRTUProtocol.Registers[0], "Address", true, DataSourceUpdateMode.OnPropertyChanged);
            displayControl2.DataBindings.Add("Text", ModbusRTUProtocol.Registers[1], "Address", true, DataSourceUpdateMode.OnPropertyChanged);
            displayControl3.DataBindings.Add("Text", ModbusRTUProtocol.Registers[2], "Address", true, DataSourceUpdateMode.OnPropertyChanged);
            displayControl4.DataBindings.Add("Text", ModbusRTUProtocol.Registers[3], "Address", true, DataSourceUpdateMode.OnPropertyChanged);
            displayControl5.DataBindings.Add("Text", ModbusRTUProtocol.Registers[4], "Address", true, DataSourceUpdateMode.OnPropertyChanged);
            displayControl6.DataBindings.Add("Text", ModbusRTUProtocol.Registers[5], "Address", true, DataSourceUpdateMode.OnPropertyChanged);
            displayControl7.DataBindings.Add("Text", ModbusRTUProtocol.Registers[6], "Address", true, DataSourceUpdateMode.OnPropertyChanged);
            displayControl8.DataBindings.Add("Text", ModbusRTUProtocol.Registers[7], "Address", true, DataSourceUpdateMode.OnPropertyChanged);
            displayControl9.DataBindings.Add("Text", ModbusRTUProtocol.Registers[8], "Address", true, DataSourceUpdateMode.OnPropertyChanged);
            displayControl10.DataBindings.Add("Text", ModbusRTUProtocol.Registers[9], "Address", true, DataSourceUpdateMode.OnPropertyChanged);

            editorControl1.DataBindings.Add("Text", ModbusRTUProtocol.Registers[0], "Value", true, DataSourceUpdateMode.OnPropertyChanged);
            editorControl2.DataBindings.Add("Text", ModbusRTUProtocol.Registers[1], "Value", true, DataSourceUpdateMode.OnPropertyChanged);
            editorControl3.DataBindings.Add("Text", ModbusRTUProtocol.Registers[2], "Value", true, DataSourceUpdateMode.OnPropertyChanged);
            editorControl4.DataBindings.Add("Text", ModbusRTUProtocol.Registers[3], "Value", true, DataSourceUpdateMode.OnPropertyChanged);
            editorControl5.DataBindings.Add("Text", ModbusRTUProtocol.Registers[4], "Value", true, DataSourceUpdateMode.OnPropertyChanged);
            editorControl6.DataBindings.Add("Text", ModbusRTUProtocol.Registers[5], "Value", true, DataSourceUpdateMode.OnPropertyChanged);
            editorControl7.DataBindings.Add("Text", ModbusRTUProtocol.Registers[6], "Value", true, DataSourceUpdateMode.OnPropertyChanged);
            editorControl8.DataBindings.Add("Text", ModbusRTUProtocol.Registers[7], "Value", true, DataSourceUpdateMode.OnPropertyChanged);
            editorControl9.DataBindings.Add("Text", ModbusRTUProtocol.Registers[8], "Value", true, DataSourceUpdateMode.OnPropertyChanged);
            editorControl10.DataBindings.Add("Text", ModbusRTUProtocol.Registers[9], "Value", true, DataSourceUpdateMode.OnPropertyChanged);

            refreshList();
        }

        private void refreshList()
        {
            comboBox1.Items.Clear();
            foreach (var port in ModbusRTUProtocol.getPorts())
            {
                comboBox1.Items.Add(port);
            }
            comboBox1.SelectedIndex = 0;
        }

        private void mbusCheck(int adr, KeyEventArgs e,string val)
        {
            if (e.KeyCode == Keys.Enter && val != "")
            {
                ModbusRTUProtocol.WriteSingleRegister(Convert.ToUInt16(adr), Convert.ToUInt16(val));
            }
        }

        private void editorControl15_KeyDown(object sender, KeyEventArgs e)
        {
            mbusCheck(0, e, editorControl15.Text);
        }

        private void editorControl14_KeyDown(object sender, KeyEventArgs e)
        {
            mbusCheck(1, e, editorControl14.Text);
        }

        private void editorControl13_KeyDown(object sender, KeyEventArgs e)
        {
            mbusCheck(2, e, editorControl13.Text);
        }

        private void editorControl12_KeyDown(object sender, KeyEventArgs e)
        {
            mbusCheck(3, e, editorControl12.Text);
        }

        private void editorControl11_KeyDown(object sender, KeyEventArgs e)
        {
            mbusCheck(4, e, editorControl11.Text);
        }

        private void editorControl20_KeyDown(object sender, KeyEventArgs e)
        {
            mbusCheck(5, e, editorControl20.Text);
        }

        private void editorControl19_KeyDown(object sender, KeyEventArgs e)
        {
            mbusCheck(6, e, editorControl19.Text);
        }

        private void editorControl18_KeyDown(object sender, KeyEventArgs e)
        {
            mbusCheck(7, e, editorControl18.Text);
        }

        private void editorControl17_KeyDown(object sender, KeyEventArgs e)
        {
            mbusCheck(8, e, editorControl17.Text);
        }

        private void editorControl16_KeyDown(object sender, KeyEventArgs e)
        {
            mbusCheck(9, e, editorControl16.Text);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            ModbusRTUProtocol.scan = true;
            ModbusRTUProtocol.Start(comboBox1.Text);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ModbusRTUProtocol.scan = true;
            if (ModbusRTUProtocol.Start("COM5"))
            {
                button1.Enabled = false;
                comboBox1.Enabled = false;
                button2.Enabled = false;
                button1.Text = "Connected";
                timer1.Start();
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            refreshList();
        }

        
    }
}
