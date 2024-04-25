using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OrderFood
{
    public class CSDL
    {
        private DataTable _data;
        public static CSDL _Instance;
        public DataTable data
        {
            get { return _data; }
            private set { }
        }
      
        public static CSDL Instance
        {
            get
            {
                if(_Instance == null)
                {
                    _Instance=new CSDL();
                }
                return _Instance;
            }
            private set { }
        }

        private CSDL()
        {
            _data = new DataTable();
            _data.Columns.AddRange(new DataColumn[] { 
                new DataColumn{ColumnName="TenBan",DataType=typeof(string)},
                new DataColumn{ColumnName="Món ăn",DataType=typeof(string)},
                new DataColumn{ColumnName="Số lượng",DataType = typeof(int)},
            });
            _data.Rows.Add("1", "Tôm viên", 2);
            _data.Rows.Add("1", "Cá viên", 1);
            _data.Rows.Add("2", "Tôm viên", 1);
            _data.Rows.Add("3", "Tôm viên", 1);
            _data.Rows.Add("4", "Tôm viên", 1);
            _data.Rows.Add("5", "Tôm viên", 1);
        }
        public List<Order> getOrdersByTableName(string TableName)
        {
            List<Order> orders = new List<Order>();
            foreach(DataRow dr in data.Rows)
            {
                if (dr["TenBan"].ToString() == TableName)
                {
                    orders.Add(new Order
                    {
                        TableName = dr["TenBan"].ToString(),
                        FoodName = dr["Món ăn"].ToString(),
                        Quantity = Convert.ToInt32(dr["Số lượng"].ToString()),
                    });
                }
            }
            return orders;
        }
        public void AddOrder(Order order)
        {
            data.Rows.Add(order.TableName,order.FoodName,order.Quantity);
        }
        public void SaveOrder(Order order)
        {
            foreach(DataRow dr in data.Rows)
            {
                if(dr["TenBan"].ToString() == order.TableName && dr["Món ăn"].ToString() == order.FoodName)
                {
                    dr["Số lượng"]=order.Quantity;
                }
            }
        }
        public void DeleteOrder(Order order)
        {
            foreach(DataRow dr in data.Rows)
            {
                if (dr["TenBan"].ToString() == order.TableName && dr["Món ăn"].ToString() == order.FoodName)
                {
                    data.Rows.Remove(dr);
                    break;
                }
            }
        }
    }
}
