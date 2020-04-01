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
    public partial class FormMain : Form
    {
        private DataTable dtShouhin = new DataTable();

        public FormMain()
        {
            InitializeComponent();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            var con = new HanbaiConnection();
            var dao = new ShouhinDAO(con);

            con.Open();
            dao.Fill(dtShouhin);
            con.Close();

            dataGridView1.DataSource = dtShouhin;

            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[1].HeaderText = "商品名";
            dataGridView1.Columns[2].HeaderText = "単価";
            
        }


        private void buttonAdd_Click(object sender, EventArgs e)
        {
            var frm = new FormEdit();

            if( frm.ShowDialog() == DialogResult.OK)
            {
                var con = new HanbaiConnection();
                var dao = new ShouhinDAO(con);

                con.Open();
                dao.Insert(frm.shouhin);
                dao.Fill(dtShouhin);
                con.Close();
            }
        }
        private Shouhin GetCurrentShouhin()
        {
            int rowIndex = dataGridView1.CurrentCell.RowIndex;
            DataRow row = dtShouhin.Rows[rowIndex];
            
            int sid = (int)row["sid"];
            string sname = (string)row["sname"];
            int tanka = (int)row["tanka"];

            return new Shouhin(sid, sname, tanka);
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            var frm = new FormEdit();

            frm.shouhin = GetCurrentShouhin();

            if (frm.ShowDialog() == DialogResult.OK)
            {
                var con = new HanbaiConnection();
                var dao = new ShouhinDAO(con);

                con.Open();
                dao.Update(frm.shouhin);
                dao.Fill(dtShouhin);
                con.Close();
            }

        }

        private void buttonDel_Click(object sender, EventArgs e)
        {
            Shouhin shouhin = GetCurrentShouhin();

            if(MessageBox.Show(shouhin.Sname+"を削除しますか？", "削除", 
                MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                var con = new HanbaiConnection();
                var dao = new ShouhinDAO(con);

                con.Open();
                dao.Delete(shouhin.Sid);
                dao.Fill(dtShouhin);
                con.Close();

            }
        }
    }
}
