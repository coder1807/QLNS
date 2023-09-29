using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Migrations;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Test5.Models2; // khai bao CSDL

namespace Test5
{
    public partial class Form3 : Form
    {
        // khoi tao doi tuong CSDL
        StudentContextDB dbNhanSu = new StudentContextDB();
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            // goi csdl - ds phong ban, ds nhan vien
            List<Phongban> listPhongban = dbNhanSu.Phongbans.ToList();
            List<Nhanvien> listNhanvien = dbNhanSu.Nhanviens.ToList();
            FillFacultyCombobox(listPhongban);
            BindGrid(listNhanvien);
        }

        private void BindGrid(List<Nhanvien> listNhanvien)
        {
            // muon dua du lieu vao dataGridView thi phai lam sach dgv truoc
            dgvNhanSu.Rows.Clear();
            foreach(var item in listNhanvien)
            {
                int index = dgvNhanSu.Rows.Add();
                dgvNhanSu.Rows[index].Cells[0].Value = item.MaNV;
                dgvNhanSu.Rows[index].Cells[1].Value = item.TenNV;
                dgvNhanSu.Rows[index].Cells[2].Value = item.Ngaysinh.Value;
                dgvNhanSu.Rows[index].Cells[3].Value = item.Phongban.TenPB;
            }
        }

        private void FillFacultyCombobox(List<Phongban> listPhongban)
        {
            this.cmbPhongban.DataSource = listPhongban;
            this.cmbPhongban.DisplayMember = "TenPB";
            this.cmbPhongban.ValueMember = "MaPB";
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private int GetSelectedrow (string MaNV)
        {
            int length = dgvNhanSu.Rows.Count;
            for (int i = 0; i < length; i++)
            {
                if (dgvNhanSu.Rows[i].Cells[0].Value != null)
                {
                    if (dgvNhanSu.Rows[i].Cells[0].Value.ToString() == MaNV)
                    {
                        return i;
                    }
                }
            }
            return -1;
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(txtMaNV.Text) || string.IsNullOrEmpty(txtTenNV.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin nhân viên !","Thông báo",
                    MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
            else
            {
                int selectedRow = GetSelectedrow(txtMaNV.Text);
                if (selectedRow == -1)
                {
                    //selectedRow = dgvNhanSu.Rows.Add();
                    //dgvNhanSu.Rows[selectedRow].Cells[0].Value = txtMaNV.Text;
                    //dgvNhanSu.Rows[selectedRow].Cells[1].Value = txtTenNV.Text;
                    //dgvNhanSu.Rows[selectedRow].Cells[2].Value = dateTimePicker1.Value;
                    //dgvNhanSu.Rows[selectedRow].Cells[3].Value = cmbPhongban.Text;

                    Nhanvien nv = new Nhanvien();
                    nv.MaNV = txtMaNV.Text;
                    nv.TenNV = txtTenNV.Text;
                    nv.Ngaysinh = datetime.Value;
                    nv.MaPB = cmbPhongban.SelectedValue.ToString();

                    dbNhanSu.Nhanviens.AddOrUpdate(nv);
                    dbNhanSu.SaveChanges();

                    loadNV();
                }
                else
                {
                    MessageBox.Show("Thông tin mã số nhân viên đã tồn tại trong danh sách !","Thông báo",
                        MessageBoxButtons.OK,MessageBoxIcon.Warning);
                }
            }
        }

        private void loadNV()
        {
            List<Nhanvien> newListNhanVien = dbNhanSu.Nhanviens.ToList();
            BindGrid(newListNhanVien);
            txtMaNV.Clear();
            txtTenNV.Clear();
            txtMaNV.Focus();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            Nhanvien updateNhanVien = dbNhanSu.Nhanviens.FirstOrDefault(
                p => p.MaNV == txtMaNV.Text );
            if(updateNhanVien != null)
            {
                updateNhanVien.MaNV = txtMaNV.Text;
                updateNhanVien.TenNV = txtTenNV.Text;
                updateNhanVien.Ngaysinh = datetime.Value;
                updateNhanVien.MaPB = cmbPhongban.SelectedValue.ToString();

                dbNhanSu.Nhanviens.AddOrUpdate(updateNhanVien);
                dbNhanSu.SaveChanges();
                loadNV();
                MessageBox.Show($"Chỉnh sửa dữ liệu nhân viên {updateNhanVien.TenNV} thành công !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult rs = MessageBox.Show("Bạn có muốn thoát không ?","Thoát",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if(rs == DialogResult.OK)
            {
                this.Close();
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            Nhanvien deleteNhanvien = dbNhanSu.Nhanviens.FirstOrDefault(
                p => p.MaNV == txtMaNV.Text );
            if(deleteNhanvien != null )
            {
                DialogResult rs = MessageBox.Show($"Bạn có đồng ý xóa nhân viên {deleteNhanvien.TenNV} này ?", "Thông báo",
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                if(rs == DialogResult.OK)
                {
                    dbNhanSu.Nhanviens.Remove( deleteNhanvien );
                    dbNhanSu.SaveChanges();
                    loadNV();
                    MessageBox.Show($"Xóa nhân viên {deleteNhanvien.TenNV} thành công", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void dgvNhanSu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvNhanSu.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
                {
                    dgvNhanSu.CurrentRow.Selected = true;

                    txtMaNV.Text = dgvNhanSu.Rows[e.RowIndex].Cells[0].FormattedValue.ToString();
                    txtTenNV.Text = dgvNhanSu.Rows[e.RowIndex].Cells[1].FormattedValue.ToString();
                    datetime.Value = DateTime.Parse(dgvNhanSu.Rows[e.RowIndex].Cells[2].FormattedValue.ToString());
                    cmbPhongban.Text = dgvNhanSu.Rows[e.RowIndex].Cells[3].FormattedValue.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,"Lỗi !",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }
    }
}
