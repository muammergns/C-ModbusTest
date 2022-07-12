using System.Windows.Forms;

namespace How_to_create_HMI_Control_Real_Time
{
    public class EditorControl : TextBox
    {
        private Register _Register = null;

        public EditorControl()
        {
            this.BackColor = System.Drawing.Color.Black;
            this.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 32F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.Lime;
            this.TextAlign = HorizontalAlignment.Center;
            this.Text = "0";
            Label.CheckForIllegalCrossThreadCalls = false;
        }

        protected override void InitLayout()
        {
            this.AutoSize = false;
            base.InitLayout();
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);
            if (e.KeyCode == Keys.Enter && _Register != null)
            {
               // ModbusRTUProtocol.WriteSingleRegister(_Register.Address, _Register.Value);
            }
        }

        public Register Register
        {
            get { return _Register; }
            set
            {
                _Register = value;
                if (_Register == null) return;
                if (this.DataBindings.Count > 0)
                    this.DataBindings.Clear();
                this.DataBindings.Add("Text", _Register, "Value", true, DataSourceUpdateMode.OnPropertyChanged);
            }
        }
    }
}
