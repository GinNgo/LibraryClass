using ClassLibraryDTO.QuanLyBanHangDTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryDAL.QuanLyBanHangDAL
{
    public class CongNoDAL : DbConnection
    {
        public List<CongNoDTO> ReadCustomer()
        {
            SqlConnection conn = CreateConnection();
            conn.Open();
            // SqlCommand cmd = new SqlCommand("select * from CongNo", conn);
            //lấy dl = procedure
            SqlCommand cmd = new SqlCommand("SelectAllCongNo", conn)
            {
                CommandType = CommandType.StoredProcedure
            };

            SqlDataReader reader = cmd.ExecuteReader();
            List<CongNoDTO> lstCus = new List<CongNoDTO>();
            while (reader.Read())
            {
                CongNoDTO cus = new CongNoDTO();
                cus.MaKhachHang = reader["makhachhang"].ToString();
                cus.TenKhachHang = reader["tenkhachhang"].ToString();
                cus.SoDienThoai = reader["sodienthoai"].ToString();
                cus.SoTienNo = decimal.Parse(reader["sotienno"].ToString());
                lstCus.Add(cus);
            }
            conn.Close();
            return lstCus;
        }
        public void DeleteCustomer(CongNoDTO cus)
        {
            SqlConnection conn = CreateConnection();
            try
            {
                conn.Open();
                //SqlCommand cmd = new SqlCommand("delete from CongNo where makhachhang  =@makhachhang ", conn);
                //cmd.Parameters.Add(new SqlParameter("@makhachhang", cus.MaKhachHang));
                //xoa bang proc
                SqlCommand cmd = new SqlCommand("DeleteCongNo", conn)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.Add("@makhachhang", SqlDbType.NVarChar).Value = cus.MaKhachHang;
                cmd.ExecuteNonQuery();
                conn.Close();
                Console.WriteLine("Xoa thanh cong !!!");
            }
            catch (Exception e)
            {
                Console.WriteLine("Co loi xay ra !!!" + e);
            }
            // dóng chuỗi kết nối
            finally
            {
                conn.Close();
            }
        }
        
        public void NewCustomer(CongNoDTO cus)
        {
            SqlConnection conn = CreateConnection();

            try { 
            conn.Open();
            //SqlCommand cmd = new SqlCommand("insert into CongNo values(@makhachhang ,@tenkhachhang,@sodienthoai,@sotienno)", conn);
            //cmd.Parameters.Add(new SqlParameter("@makhachhang", cus.MaKhachHang));
            //cmd.Parameters.Add(new SqlParameter("@tenkhachhang", cus.TenKhachHang));
            //cmd.Parameters.Add(new SqlParameter("@sodienthoai", cus.SoDienThoai));
            //cmd.Parameters.Add(new SqlParameter("@sotienno", cus.SoTienNo));
            //them moi bang proc
            SqlCommand cmd = new SqlCommand("InsertCongNo", conn)
            {
                CommandType = CommandType.StoredProcedure
            };
            cmd.Parameters.Add("@makhachhang", SqlDbType.NVarChar).Value = cus.MaKhachHang;
            cmd.Parameters.Add("@tenkhachhang", SqlDbType.NVarChar).Value = cus.TenKhachHang;
            cmd.Parameters.Add("@sodienthoai", SqlDbType.NVarChar).Value = cus.SoDienThoai;
            cmd.Parameters.Add("@sotienno", SqlDbType.Decimal).Value = cus.SoTienNo;
            cmd.ExecuteNonQuery();
            conn.Close();
                Console.WriteLine("Them thanh cong !!!");

            }
            catch (Exception e)
            {
                Console.WriteLine("Co loi xay ra !!!" + e);
            }
            // dóng chuỗi kết nối
            finally
            {
                conn.Close();
            }
        }
        public void EditCustomer(CongNoDTO cus)
        {
            SqlConnection conn = CreateConnection();
            try { 
            conn.Open();

                //SqlCommand cmd = new SqlCommand("update CongNo set tenkhachhang= @tenkhachhang,sodienthoai=@sodienthoai,sotienno=@sotienno where makhachhang = @makhachhang ", conn);
                //cmd.Parameters.Add(new SqlParameter("@makhachhang ", cus.MaKhachHang));
                //cmd.Parameters.Add(new SqlParameter("@tenkhachhang", cus.TenKhachHang));
                //cmd.Parameters.Add(new SqlParameter("@sodienthoai", cus.SoDienThoai));
                //cmd.Parameters.Add(new SqlParameter("@sotienno", cus.SoTienNo));
                //sua bang proc
                SqlCommand cmd = new SqlCommand("UpdateCongNo", conn)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.Add("@makhachhang", SqlDbType.NVarChar).Value = cus.MaKhachHang;
                cmd.Parameters.Add("@tenkhachhang", SqlDbType.NVarChar).Value = cus.TenKhachHang;
                cmd.Parameters.Add("@sodienthoai", SqlDbType.NVarChar).Value = cus.SoDienThoai;
                cmd.Parameters.Add("@sotienno", SqlDbType.Decimal).Value = cus.SoTienNo;
                cmd.ExecuteNonQuery();
            conn.Close();

                Console.WriteLine("Sua thanh cong !!!");

            }
            catch (Exception e)
            {
                Console.WriteLine("Co loi xay ra !!!" + e);
            }
            // dóng chuỗi kết nối
            finally
            {
                conn.Close();
            }

        }
    }
}
