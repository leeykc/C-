using System;
using System.Collections.Generic;//存储List<T>
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace day1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Product p1 = new Product();
            p1.ProductID=1001;
            p1.ProductName="机械键盘";
            p1.Price=299;
            p1.stock=50;
          
            Product p2 = new Product();
            p2.ProductID=1002;
            p2.ProductName="鼠标";
            p2.Price=99;
            p2.stock=100;

            Product p3 = new Product();
            p3.ProductID=1003;
            p3.ProductName="显示器";
            p3.Price=1299;
            p3.stock=20;


            List<Product>    products = new List<Product>();
 //              ↓                    ↓              ↓
//只能保存 Product 类型的对象的列表   名字        新的商品列表
           

            products.Add(p1);
            products.Add(p2);//放进products
            products.Add (p3);

            foreach(Product product in products)
            {
                Console.WriteLine(product.ProductName);
            }//把三个商品全部打印出来,从 products 里面，一个一个拿出 Product
            Console.ReadKey();//让窗口停下,等于按一下键到下一步
        }
    }
}
