using System;
using System.Collections.Generic;//存储List<T>
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace day9
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

            ProductService p = new ProductService();

            while (true)
            {
                Console.WriteLine("======商品管理系统======");
                Console.WriteLine("1. 查询商品");
                Console.WriteLine("2. 添加商品");
                Console.WriteLine("3. 删除商品");
                Console.WriteLine("4. 扣减库存");
                Console.WriteLine("5. 退出");

                Console.WriteLine("请选择：");

                string input2 = Console.ReadLine();
                int choice = int.Parse(input2);
                if (choice==1)
                {
                    Console.WriteLine("请输入商品编号：");
                    string input = Console.ReadLine();
                    int productID = int.Parse(input);
                    Product result = p.FindProduct(products, productID);
                    if (result!=null)
                    {
                        Console.WriteLine("商品已找到");
                        Console.WriteLine($"商品编码:{result.ProductID}");
                        Console.WriteLine($"商品名称：{result.ProductName}");
                        Console.WriteLine($"商品价格：{result.Price}");
                        Console.WriteLine($"商品库存：{result.stock}");

                    }

                    else { Console.WriteLine($"未找到编号为 {productID} 的商品！"); }
                }
                else if (choice==2)
                {
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
                }
                else if (choice==3)
                {
                    Console.WriteLine("请输入商品编号: ");
                    string input = Console.ReadLine();
                    int productID = int.Parse(input);
                    string result = p.DeleteProduct(products, productID);

                    // 根据业务结果显示信息
                    if (result == "SUCCESS")
                    {
                        Console.WriteLine("商品删除成功");
                    }
                    else if (result == "NOT_FOUND")
                    {
                        Console.WriteLine("该商品不存在");
                    }
                    
                }
                else if (choice==4)
                {
                    Console.WriteLine("请输入商品编号: ");//WriteLine自动换行，Write不会
                                                   // 读取用户输入（ReadLine() 不加参数），不读取就没办法转化
                    string input = Console.ReadLine();
                    //将输入的字符串转化为整数
                    int productID = int.Parse(input);
                    //调用FindProduct 方法查找商品
               
                    Product foundProduct = p.FindProduct(products, productID);
                    if (foundProduct != null)
                    {
                        Console.WriteLine("请输入购买数量: ");
                        string input3 = Console.ReadLine();
                        int quantity = int.Parse(input3);
                        string result = p.ReduceStock(foundProduct, quantity);
                        //if (result) 表示“当 result 为 true 时执行”
                        if (result == "SUCCESS")
                        {
                            Console.WriteLine($"商品名称: {foundProduct.ProductName}");
                            Console.WriteLine($"购买数量: {quantity}");
                            Console.WriteLine($"剩余库存: {foundProduct.stock}");
                        }
                        else if (result == "INVALID_QUANTITY")
                        {
                            Console.WriteLine("数量不合法，请重试！");
                        }
                        else if (result == "INSUFFICIENT_STOCK")
                        {
                            Console.WriteLine("该商品库存不足");
                            Console.WriteLine($"库存量: {foundProduct.stock}");
                        }

                    }
                    else
                    {
                        Console.WriteLine($"未找到编号为 {productID} 的商品！");
                    }

                   

                }
                    else if (choice==5)
                {
                    break;
                }
                else { Console.WriteLine("无效选项，请重新输入"); }
                
            }
            
            Console.ReadKey();
        }
    }
}
