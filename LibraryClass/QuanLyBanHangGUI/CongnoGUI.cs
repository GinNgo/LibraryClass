using ClassLibraryDTO.QuanLyBanHangDTO;
using LibraryClassBAL.QuanLyBanHangBAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibraryClass
{
    public partial class CongnoGUI : Form
    {
         CongNoBAL cusBAL = new CongNoBAL();
        public CongnoGUI()
        {
            InitializeComponent();
        }

        private void CongnoGUI_Load(object sender, EventArgs e)
        {
            List<CongNoDTO> lstCus = cusBAL.ReadCustomer();
            foreach (CongNoDTO cus in lstCus)
            {
              
                dgvCongNo.Rows.Add(cus.MaKhachHang, cus.TenKhachHang, cus.SoDienThoai, cus.SoTienNo);
            }
        }
        private void BtNew_Click(object sender, EventArgs e)
        {
            tbMaKhachHang.Enabled = true;
            List<CongNoDTO> lstCus = cusBAL.ReadCustomer();
            if (lstCus.Any(item => item.MaKhachHang.ToString() == tbMaKhachHang.Text) == true)
            {
                tbMaKhachHang.Text = "";
                tbTenKhachHang.Text = "";
                tbSoDienThoai.Text = "";
                tbSoTienNo.Text = "";
            }
            else
            {
                if(tbMaKhachHang.Text == ""& tbMaKhachHang.Text == ""& tbSoDienThoai.Text == ""& tbSoTienNo.Text == ""){
                    MessageBox.Show("Bạn cần điền đầy đủ thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else { 
                if (tbMaKhachHang.Text == "")
                {
                    MessageBox.Show("Bạn cần nhập mã", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                if (tbMaKhachHang.Text == "")
                {
                    MessageBox.Show("Bạn cần nhập Tên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                if (tbSoDienThoai.Text == "")
                {
                    MessageBox.Show("Bạn cần nhập Số diện thoại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                if (tbSoTienNo.Text == "")
                {
                    MessageBox.Show("Bạn cần nhập Số tiền nợ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                if (tbMaKhachHang.Text != "" & tbMaKhachHang.Text != "" & tbSoDienThoai.Text != "" & tbSoTienNo.Text != "")
                {
                        CongNoDTO cus = new CongNoDTO
                        {
                            MaKhachHang = tbMaKhachHang.Text.ToString(),
                            TenKhachHang = tbTenKhachHang.Text,
                            SoDienThoai = tbSoDienThoai.Text,
                            SoTienNo = decimal.Parse(tbSoTienNo.Text)
                        };
                        cusBAL.NewCustomer(cus);
                    dgvCongNo.Rows.Add(cus.MaKhachHang, cus.TenKhachHang, cus.SoDienThoai, cus.SoTienNo);
                    MessageBox.Show("Thêm thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.None);
                }
                }
            }
        }
        private void BtDelete_Click(object sender, EventArgs e)
        {
            if (tbMaKhachHang.Text == "")
            {
                MessageBox.Show("Không có đối tượng để xóa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            if (MessageBox.Show("Bạn có muốn xóa hay không", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                CongNoDTO cus = new CongNoDTO();
                cus.MaKhachHang = tbMaKhachHang.Text;
                cusBAL.DeleteCustomer(cus);
                int idx = dgvCongNo.CurrentCell.RowIndex;
                dgvCongNo.Rows.RemoveAt(idx);
                tbMaKhachHang.Text = "";
                tbTenKhachHang.Text = "";
                tbSoDienThoai.Text = "";
                tbSoTienNo.Text = "";
                tbMaKhachHang.Enabled = true;
                MessageBox.Show("Xóa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.None);
            }

        }
        private void BtEdit_Click(object sender, EventArgs e)
        {
            if (tbTenKhachHang.Text == "")
            {
                MessageBox.Show("Bạn cần nhập Tên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            if (tbSoDienThoai.Text == "")
            {
                MessageBox.Show("Bạn cần nhập Số diện thoại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            if (tbSoTienNo.Text == "")
            {
                MessageBox.Show("Bạn cần nhập Số tiền nợ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            if (tbMaKhachHang.Text != "" & tbSoDienThoai.Text != "" & tbSoTienNo.Text != "")
            {
                CongNoDTO cus = new CongNoDTO();
                cus.MaKhachHang = tbMaKhachHang.Text.ToString();
                cus.TenKhachHang = tbTenKhachHang.Text;
                cus.SoDienThoai = tbSoDienThoai.Text;
                cus.SoTienNo = decimal.Parse(tbSoTienNo.Text);
                cusBAL.EditCustomer(cus);
                DataGridViewRow row = dgvCongNo.CurrentRow;
                row.Cells[0].Value = cus.MaKhachHang;
                row.Cells[1].Value = cus.TenKhachHang;
                row.Cells[2].Value = cus.SoDienThoai;
                row.Cells[3].Value = cus.SoTienNo;
                MessageBox.Show("Sửa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.None);
        
            }

        }

        private void DgvCustomer_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            int idx = e.RowIndex;
            tbMaKhachHang.Text = dgvCongNo.Rows[idx].Cells[0].Value.ToString();
            tbTenKhachHang.Text = dgvCongNo.Rows[idx].Cells[1].Value.ToString();
            tbSoDienThoai.Text = dgvCongNo.Rows[idx].Cells[2].Value.ToString();
            tbSoTienNo.Text = dgvCongNo.Rows[idx].Cells[3].Value.ToString();
            tbMaKhachHang.Enabled = false;
        }

        private void BtClose_Click(object sender, EventArgs e)
        {
           if( MessageBox.Show("Bạn muốn thoát", "Close", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                this.Close();
            }
        }
    }
}
