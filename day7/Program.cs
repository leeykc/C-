using System;
using System.Collections.Generic;//存储List<T>
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace day7
{

    //前台/入口
    internal class Program
    {

        static void Main(string[] args)
        {
            List<Product> products = new List<Product>();

            Console.WriteLine("请输入商品编号: ");
            string input = Console.ReadLine();
            int productID = int.Parse(input);

            Console.WriteLine("请输入商品名称: ");
            string productName = Console.ReadLine();

            Console.WriteLine("请输入商品价格: ");
            string inputPrice = Console.ReadLine();
            decimal price = decimal.Parse(inputPrice);

            Console.WriteLine("请输入商品库存: ");
            string inputStock = Console.ReadLine();
            int stock = int.Parse(inputStock);

            // 创建商品对象
            Product product = new Product();

            // 给商品对象赋值
            product.ProductID = productID;
            product.ProductName = productName;
            product.Price = price;
            product.stock = stock;

            // 创建商品业务类
            ProductService p = new ProductService();

            // 调用添加商品业务
            string result = p.AddProduct(products, product);

            // 根据业务结果显示信息
            if (result == "SUCCESS")
            {
                Console.WriteLine("商品添加成功");
            }
            else if (result == "DUPLICATE")
            {
                Console.WriteLine("商品添加失败，商品编号已经存在");
            }

            Console.ReadKey();
        }
    }
}
