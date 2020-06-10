using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HanbaiCS
{
    public partial class FormEdit : Form
    {
        internal Shouhin shouhin;
        public FormEdit()
        {
            InitializeComponent();
        }

        private void FormEdit_Load(object sender, EventArgs e)
        {
            if( shouhin != null)
            {
                textBoxSname.Text = shouhin.Sname;
                textBoxTanka.Text = shouhin.Tanka.ToString();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String sname = textBoxSname.Text;
            int tanka = int.Parse(textBoxTanka.Text);

            if (shouhin == null)
            {
                shouhin = new Shouhin(0, sname, tanka);
            }
            else
            {
                shouhin.Sname = sname;
                shouhin.Tanka = tanka;
            }
        }
    }
}
