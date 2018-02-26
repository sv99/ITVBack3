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
    public partial class fmProfile : Form
    {
        public Profile Profile { get; private set; }

        public fmProfile(Profile profile)
        {
            InitializeComponent();
            this.Profile = profile;
            InitCams();
            this.tbSourceUrl.Text = this.Profile.SourceUrl;
            this.tbDestFolder.Text = this.Profile.DestFolder;
            this.tbUserName.Text = this.Profile.Username;
            this.tbPassword.Text = this.Profile.Password;
            this.rbIntellect.Checked = this.Profile.IsIntellect;
            this.rbGeovision.Checked = !this.Profile.IsIntellect;
        }

        public fmProfile()
        {
            InitializeComponent();
        }

        private void InitCams()
        {
            if (String.IsNullOrEmpty(this.Profile.Cams))
                return;
            if (this.Profile.Cams.IndexOf(',') <= 0)
            {
                //одна камера
                CheckBox cb = (CheckBox)this.gbCams.Controls.Find("chb" + this.Profile.Cams.Trim(), false)[0];
                cb.Checked = true;
            }
            else
            {
                foreach (var cam in this.Profile.Cams.Split(','))
                {
                    CheckBox cb = (CheckBox)this.gbCams.Controls.Find("chb" + cam.Trim(), false)[0];
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
                CheckBox cb = (CheckBox)this.gbCams.Controls.Find(
                    "chb" + i.ToString(CultureInfo.InvariantCulture), false)[0];

                if (cb.Checked)
                {
                    if (not_first) res += ',';
                    res += i.ToString(CultureInfo.InvariantCulture);
                    not_first = true;
                }
            }
            this.Profile.Cams = res;
        }

        private void buOk_Click(object sender, EventArgs e)
        {
            UpdateCams();
            if (Profile.Cams == "")
            {
                MessageBox.Show("Нужно выделить хотя бы одну камеру!", "Внимание",
                               MessageBoxButtons.OK,
                               MessageBoxIcon.Exclamation);
                return;
            }
            //this.laCamsArray.Text = fm.Cams;
            this.Profile.SourceUrl = this.tbSourceUrl.Text;
            this.Profile.DestFolder = this.tbDestFolder.Text;
            this.Profile.Username = this.tbUserName.Text;
            this.Profile.Password = this.tbPassword.Text;
            this.Profile.IsIntellect = this.rbIntellect.Checked;
            this.DialogResult = DialogResult.OK;
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.folderBrowserDialog1.SelectedPath = this.tbDestFolder.Text;
            if (this.folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                this.tbDestFolder.Text = this.folderBrowserDialog1.SelectedPath;
            }
        }
    }
}
