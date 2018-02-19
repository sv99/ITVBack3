using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace VideoBack
{
    public partial class fmCams : Form
    {
        public string Cams { get; set; }

        public fmCams(string sCams)
        {
            InitializeComponent();
            this.Cams = sCams;
            InitChecBoxes();
        }

        private void buOk_Click(object sender, EventArgs e)
        {
            UpdateCams();
            Close();
        }

        private void InitChecBoxes()
        {
            if (Cams.IndexOf(',') <= 0)
            {
                //одна камера
                CheckBox cb = (CheckBox)this.Controls.Find("chb" + Cams.Trim(), false)[0];
                cb.Checked = true;
            }
            else
            {
                foreach ( var cam in Cams.Split(','))
                {
                    CheckBox cb = (CheckBox)this.Controls.Find("chb" + cam.Trim(), false)[0];
                    cb.Checked = true;
                }
            }
        }

        private void UpdateCams()
        {
            string res = "";
            bool not_first = false;
            for (int i = 1; i <= 32; i++)
            {
                CheckBox cb = (CheckBox)this.Controls.Find(
                    "chb" + i.ToString(CultureInfo.InvariantCulture), false)[0];
                
                if (cb.Checked)
                {
                    if (not_first) res += ',';
                    res += i.ToString(CultureInfo.InvariantCulture);
                    not_first = true;
                }
            }
            Cams = res;
        }
    }
}
