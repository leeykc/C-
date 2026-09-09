using System;
using System.Collections.Generic;//存储List<T>
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace day8
{

    //前台/入口
    internal class Program
    {

        static void Main(string[] args)
        {
            List<Product> products = new List<Product>();//不加东西相当于空的数据库，相当于临时内存数据库，每次重启都会把东西加回去，后面设置成SQL Server Product表
            Product p1 = new Product();
            p1.ProductID = 1001;
            p1.ProductName = "机械键盘";
            p1.Price = 299;
            p1.stock = 50;

            Product p2 = new Product();
            p2.ProductID = 1002;
            p2.ProductName = "鼠标";
            p2.Price = 99;
            p2.stock = 100;

            products.Add(p1);
            products.Add(p2);

            Console.WriteLine("请输入商品编号: ");
            string input = Console.ReadLine();
            int productID = int.Parse(input);

            // 创建商品业务类
            ProductService p = new ProductService();

            string result2 = p.DeleteProduct(products, productID);

            // 根据业务结果显示信息
            if (result2 == "SUCCESS")
            {
                Console.WriteLine("商品删除成功");
            }
            else if (result2 == "NOT_FOUND")
            {
                Console.WriteLine("该商品不存在");
            }

            //下面注释的代码是验证，删除是否能进行，而不是一直删除，因为这里是临时数据库，每次重新测试都会重新加入对象
            //string result = p.DeleteProduct(products, productID);

            //if (result == "SUCCESS")
            //{
            //    Console.WriteLine("第一次删除成功");
            //}
            //else
            //{
            //    Console.WriteLine("第一次删除失败");
            //}

            //// 再删除一次
            //string result2 = p.DeleteProduct(products, productID);

            //if (result2 == "SUCCESS")
            //{
            //    Console.WriteLine("第二次删除成功");
            //}
            //else
            //{
            //    Console.WriteLine("第二次删除失败，商品不存在");
            //}
            Console.ReadKey();
        }
    }
}
