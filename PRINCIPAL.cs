using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _CYD_ASIENTOS_CONTABLES_2019
{
    public partial class PRINCIPAL : Form
    {
        public PRINCIPAL()
        {
            InitializeComponent();
        }

        private void formularioRecaudacionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lFRM_RECAUDACION frm = new lFRM_RECAUDACION();
            frm.Show();
        }

        private void formularioColocacionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FRM_COLOCACION frm = new FRM_COLOCACION();
            frm.Show();
        }
    }
}
