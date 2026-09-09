using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace day8
{
    //专门负责“商品业务规则”的类
    internal class ProductService //internal只能在当前程序集（项目）内部访问，外部项目无法使用，实际还是要看这个类是否需要被其他程序集访问
    {
        //把一个功能封装成方法
        //给我一个商品列表和商品编号，我返回一个 Product
        public Product FindProduct(List<Product> products, int productID)
        {
            foreach (Product product in products)
            {
                if (product.ProductID==productID)
                    return product;
            }
            return null;//遍历结束之后没找到就null
        }

        //给我一个商品对象和购买数量
        public string ReduceStock(Product product, int quantity)
        {
            if (quantity <= 0)
            {
                return "INVALID_QUANTITY";
            }
            else if(quantity > product.stock)
            {
                //库存不足
                return "INSUFFICIENT_STOCK";
            }
            else
            {
                product.stock=product.stock-quantity;
                return "SUCCESS";
            }
        }
        public string AddProduct(List<Product> products, Product product)
        {
            Product foundProduct = FindProduct(products, product.ProductID);
            //没找到 → 才能添加
            if (foundProduct == null)
            {
                products.Add(product);
                return "SUCCESS";
            }
            else { return "DUPLICATE"; }//商品编号重复//找到相同编号 → 不能添加

        }
        public string DeleteProduct(List<Product> products, int productID)
        {
            // 1. 找商品
            Product foundProduct = FindProduct(products,productID);

            // 2. 判断有没有找到
            if (foundProduct!=null)
            {
                // 3. 删除商品,foundProduct本身就已经找到product对象，同理productID也是一样的道理
                products.Remove(foundProduct);

                return "SUCCESS";
            }
            else
            {
                return "NOT_FOUND";
            }
        }
    }

}
