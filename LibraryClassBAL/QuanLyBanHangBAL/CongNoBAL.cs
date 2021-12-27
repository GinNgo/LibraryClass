using ClassLibraryDAL.QuanLyBanHangDAL;
using ClassLibraryDTO.QuanLyBanHangDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryClassBAL.QuanLyBanHangBAL
{
    public class CongNoBAL
    {
#pragma warning disable IDE0090 // Use 'new(...)'
        CongNoDAL dal = new CongNoDAL();
#pragma warning restore IDE0090 // Use 'new(...)'
        public List<CongNoDTO> ReadCustomer()
        {
            List<CongNoDTO> lstCus = dal.ReadCustomer();
            return lstCus;
        }
        public void NewCustomer(CongNoDTO cus)
        {
            dal.NewCustomer(cus);
        }
        public void DeleteCustomer(CongNoDTO cus)
        {
            dal.DeleteCustomer(cus);
        }
        public void EditCustomer(CongNoDTO cus)
        {
            dal.EditCustomer(cus);
        }

    }
}

