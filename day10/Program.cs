using System;
using System.Collections.Generic;

namespace day10
{
    // 前台 / 程序入口
    internal class Program
    {
        static void Main(string[] args)
        {
            // 创建临时内存数据库
            List<Product> products = new List<Product>();

            // 初始化商品
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

            // 创建商品业务类
            ProductService p = new ProductService();

            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("======商品管理系统======");
                Console.WriteLine("1. 查询商品");
                Console.WriteLine("2. 添加商品");
                Console.WriteLine("3. 删除商品");
                Console.WriteLine("4. 扣减库存");
                Console.WriteLine("5. 退出");
                Console.WriteLine("========================");
                Console.WriteLine("请选择（输入q退出菜单）：");

                string input2 = Console.ReadLine();

                // 主菜单输入 q，直接退出程序
                if (p.IsCancel(input2))
                {
                    break;
                }

                int choice;

                bool choiceSuccess = int.TryParse(input2, out choice);

                if (!choiceSuccess)
                {
                    Console.WriteLine("请输入正确的数字！");
                    continue;
                }

                // ========================
                // 1. 查询商品
                // ========================
                if (choice == 1)
                {
                    Console.WriteLine("请输入商品编号（输入q取消）：");
                    string input = Console.ReadLine();

                    if (p.IsCancel(input))
                    {
                        Console.WriteLine("已取消查询");
                        continue;
                    }

                    int productID;
                    bool success = int.TryParse(input, out productID);

                    if (success)
                    {
                        Product result = p.FindProduct(products, productID);

                        if (result != null)
                        {
                            Console.WriteLine("商品已找到");
                            Console.WriteLine($"商品编码：{result.ProductID}");
                            Console.WriteLine($"商品名称：{result.ProductName}");
                            Console.WriteLine($"商品价格：{result.Price}");
                            Console.WriteLine($"商品库存：{result.stock}");
                        }
                        else
                        {
                            Console.WriteLine($"未找到编号为 {productID} 的商品！");
                        }
                    }
                    else
                    {
                        Console.WriteLine("请输入正确的数字！");
                    }
                }

                // ========================
                // 2. 添加商品
                // ========================
                else if (choice == 2)
                {
                    Console.WriteLine("请输入商品编号（输入q取消）：");
                    string input = Console.ReadLine();

                    if (p.IsCancel(input))
                    {
                        Console.WriteLine("已取消添加商品");
                        continue;
                    }

                    int productID;
                    bool success = int.TryParse(input, out productID);

                    if (success)
                    {
                        Console.WriteLine("请输入商品名称（输入q取消）：");
                        string productName = Console.ReadLine();

                        if (p.IsCancel(productName))
                        {
                            Console.WriteLine("已取消添加商品");
                            continue;
                        }

                        Console.WriteLine("请输入商品价格（输入q取消）：");
                        string inputPrice = Console.ReadLine();

                        if (p.IsCancel(inputPrice))
                        {
                            Console.WriteLine("已取消添加商品");
                            continue;
                        }

                        decimal price;
                        bool priceSuccess = decimal.TryParse(inputPrice, out price);

                        if (!priceSuccess)
                        {
                            Console.WriteLine("请输入正确的价格！");
                            continue;
                        }

                        Console.WriteLine("请输入商品库存（输入q取消）：");
                        string inputStock = Console.ReadLine();

                        if (p.IsCancel(inputStock))
                        {
                            Console.WriteLine("已取消添加商品");
                            continue;
                        }

                        int stock;
                        bool stockSuccess = int.TryParse(inputStock, out stock);

                        if (!stockSuccess)
                        {
                            Console.WriteLine("请输入正确的库存！");
                            continue;
                        }

                        // 创建商品对象
                        Product product = new Product();

                        product.ProductID = productID;
                        product.ProductName = productName;
                        product.Price = price;
                        product.stock = stock;

                        // 调用添加商品业务
                        string result = p.AddProduct(products, product);

                        if (result == "SUCCESS")
                        {
                            Console.WriteLine("商品添加成功");
                        }
                        else if (result == "DUPLICATE")
                        {
                            Console.WriteLine("商品添加失败，商品编号已经存在");
                        }
                    }
                    else
                    {
                        Console.WriteLine("请输入正确的数字！");
                    }
                }

                // ========================
                // 3. 删除商品
                // ========================
                else if (choice == 3)
                {
                    Console.WriteLine("请输入商品编号（输入q取消）：");
                    string input = Console.ReadLine();

                    if (p.IsCancel(input))
                    {
                        Console.WriteLine("已取消删除");
                        continue;
                    }

                    int productID;
                    bool success = int.TryParse(input, out productID);

                    if (success)
                    {
                        string result = p.DeleteProduct(products, productID);

                        if (result == "SUCCESS")
                        {
                            Console.WriteLine("商品删除成功");
                        }
                        else if (result == "NOT_FOUND")
                        {
                            Console.WriteLine("该商品不存在");
                        }
                    }
                    else
                    {
                        Console.WriteLine("请输入正确的数字！");
                    }
                }

                // ========================
                // 4. 扣减库存
                // ========================
                else if (choice == 4)
                {
                    Console.WriteLine("请输入商品编号（输入q取消）：");
                    string input = Console.ReadLine();

                    if (p.IsCancel(input))
                    {
                        Console.WriteLine("已取消扣减库存");
                        continue;
                    }

                    int productID;
                    bool success = int.TryParse(input, out productID);

                    if (success)
                    {
                        Product foundProduct = p.FindProduct(products, productID);

                        if (foundProduct != null)
                        {
                            Console.WriteLine("请输入购买数量（输入q取消）：");
                            string input3 = Console.ReadLine();

                            if (p.IsCancel(input3))
                            {
                                Console.WriteLine("已取消扣减库存");
                                continue;
                            }

                            int quantity;
                            bool quantitySuccess = int.TryParse(input3, out quantity);

                            if (!quantitySuccess)
                            {
                                Console.WriteLine("请输入正确的购买数量！");
                                continue;
                            }

                            string result = p.ReduceStock(foundProduct, quantity);

                            if (result == "SUCCESS")
                            {
                                Console.WriteLine($"商品名称：{foundProduct.ProductName}");
                                Console.WriteLine($"购买数量：{quantity}");
                                Console.WriteLine($"剩余库存：{foundProduct.stock}");
                            }
                            else if (result == "INVALID_QUANTITY")
                            {
                                Console.WriteLine("数量不合法，请重试！");
                            }
                            else if (result == "INSUFFICIENT_STOCK")
                            {
                                Console.WriteLine("该商品库存不足");
                                Console.WriteLine($"库存量：{foundProduct.stock}");
                            }
                        }
                        else
                        {
                            Console.WriteLine($"未找到编号为 {productID} 的商品！");
                        }
                    }
                    else
                    {
                        Console.WriteLine("请输入正确的数字！");
                    }
                }

                // ========================
                // 5. 退出程序
                // ========================
                else if (choice == 5)
                {
                    break;
                }

                else
                {
                    Console.WriteLine("无效选项，请重新输入");
                }
            }

            Console.WriteLine("程序结束");
            Console.ReadKey();
        }
    }
}
