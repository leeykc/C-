using System;
using System.Collections.Generic;//存储List<T>
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace day5_6
{

    //前台/入口
    internal class Program
    {

        static void Main(string[] args)//Main方法
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


            List<Product> products = new List<Product>();
            //              ↓                    ↓              ↓
            //只能保存 Product 类型的对象的列表   名字        新的商品列表


            products.Add(p1);
            products.Add(p2);//放进products
            products.Add(p3);


            Console.WriteLine("请输入商品编号: ");//WriteLine自动换行，Write不会
            // 读取用户输入（ReadLine() 不加参数），不读取就没办法转化
            string input = Console.ReadLine();
            //将输入的字符串转化为整数
            int productID = int.Parse(input);
            //调用FindProduct 方法查找商品
            ProductService p = new ProductService();
            Product foundProduct= p.FindProduct(products, productID);
            if (foundProduct != null)
            {
                Console.WriteLine("请输入购买数量: ");
                string input2 = Console.ReadLine();
                int quantity = int.Parse(input2);
                string result = p.ReduceStock(foundProduct, quantity);
                //if (result) 表示“当 result 为 true 时执行”
                if (result== "INVALID_QUANTITY")
                { 
                    Console.WriteLine("数量不合法，请重试！");
                 
                }
                else if (result=="INSUFFICIENT_STOCK")
                {
                    Console.WriteLine("该商品库存不足");
                    Console.WriteLine($"库存量: {foundProduct.stock}");
                }
                else
                {
                    Console.WriteLine($"商品名称: {foundProduct.ProductName}");
                    Console.WriteLine($"购买数量: {quantity}");
                    Console.WriteLine($"剩余库存: {foundProduct.stock}");
                }
           
            }
            else
            {
                Console.WriteLine($"未找到编号为 {productID} 的商品！");
            }


            Console.ReadKey();//让窗口停下,等于按一下键到下一步
        }
    }
}
