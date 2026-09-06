using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Product 是在告诉 C#：“商品这种东西应该具有什么数据结构
namespace day4
{
    public class Product
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }

        public decimal Price { get; set; }

        public int stock {  get; set; }

    }

}
