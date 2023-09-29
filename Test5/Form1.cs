using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Test5
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        //SqlConnection cnn = null;
        //string strcnn = "Server - DESKTOP-DTFBKP2\\SQLEXPRESS; Database =QLSV; User id =sa; pwd =123";
        //private void button_Click(object sender, EventArgs e)
        //{
        //    if (cnn == null)
        //        cnn = new SqlConnection(strcnn);
        //    if (cnn.State == ConnectionState.Closed)
        //       cnn.Open();
        //    SqlCommand cmd = new SqlCommand();
        //    cmd.CommandType = CommandType.Text;
        //    cmd.CommandText = "Select * from Student";
        //    cmd.Connection = cnn;
        //    SqlDataAdapter reader = cmd.ExecuteReader();
        //    while(reader.Read())
        //    {
        //        string ma = reader.Getstring(0);
        //        string ten = reader.GetString(1);
        //        double diem = reader.GetDouble(2);
        //        ListViewItem lvi = new ListViewItem(ma);
        //        lvi.SubItems.Add(ten);
        //        lvi.SubItems.Add(diem.ToString());
        //        ListView1.Items.Add(lvi);
        //    }
        //    reader.Close();
        //    cmn.Close();
        //}

        //DataSet ds = null;
        //SqlDataAdapter adt = null;
        private void button1_Click(object sender, EventArgs e)
        {
        //    if(cnn == null)
        //    {
        //        cnn = new SqlConnection(strcnn);
        //    }
        //    SqlDataAdapter adt = new SqlDataAdapter("Select * from Student",cnn);
        //    DataSet ds = new DataSet();
        //    adt.Fill(ds, "Student");
        //    dataGridView1.DataSource = ds.Tables["Student"];
        }

        private void button2_Click(object sender, EventArgs e)
        {
        //    DataRow row = ds.Tables["Student"].NewRow();
        //    row["StudentID"] = txtMa.Text;
        //    row["FullName"] = txtTen.Text;
        //    row["AverageScore"] = txtDiem.Text;
        //    row["FacultyID"] = txtMaKhoa.Text;
        //    ds.Tables["Student"].Rows.Add(row);
        //    int kq = adt.Update(ds.Tables["Student"]);
        //    if(kq > 0)
        //    {
        //        button1.PerformClick();
        //    }
        //    else
        //    {
        //        MessageBox.Show("That bai!");
        //    }
        }
    }
}
