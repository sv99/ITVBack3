using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ITVBack
{
    public partial class fmSourceEdit : Form
    {
        public string Source {
            get { return this.tbSource.Text;  }
            set { this.tbSource.Text = value; }
        }

        public fmSourceEdit(string sSource)
        {
            InitializeComponent();
            this.Source = sSource;
        }

    }
}
