# C- 学习仓库（库存管理系统练习）

用代码记录 C# 与 Java 的学习过程。

## day1：C# List\<T\> 与对象入门

- 创建三个 `Product` 对象，并保存到 `List<Product>`。
- 使用 `foreach` 遍历商品列表，输出全部商品名称。
- 运行方式：使用 Visual Studio 打开 `day1.sln`，按 F5 运行。

```text
机械键盘
鼠标
显示器
```

## day2：方法与商品查询

- 在第一天商品列表的基础上新增 `FindProduct` 方法。
- 输入商品编号后，方法会在列表中查找对应商品并返回。
- 找到时输出商品名称、价格、库存；找不到时提示“未找到”。
- 运行方式：使用 Visual Studio 打开 `day2.sln`，按 F5 运行。

```text
请输入商品编号: 1002
找到商品！
商品名称: 鼠标
价格: 99 元
库存: 100 件
```

## day3：库存扣减练习

- 在 `day2` 商品查询的基础上新增 `ReduceStock` 库存扣减方法。
- 输入商品编号和购买数量后，对找到的商品执行库存扣减。
- 购买数量大于当前库存时提示“库存不足”，否则扣减库存并显示剩余数量。
- 运行方式：使用 Visual Studio 打开 `day3.sln`，按 F5 运行。

```text
请输入商品编号: 1001
请输入购买数量: 5
商品名称: 机械键盘
购买数量: 5
剩余库存: 45
```

## day4：库存扣减结果判断

- 将 `day3` 的 `ReduceStock` 方法改为返回 `bool`。
- 库存足够时扣减成功并返回 `true`，库存不足时返回 `false` 且不扣减库存。
- 调用后由主程序输出商品名称、购买数量、剩余库存和结果。
- 运行方式：使用 Visual Studio 打开 `day4.sln`，按 F5 运行。

```text
请输入商品编号: 1001
请输入购买数量: 5
商品名称: 机械键盘
购买数量: 5
剩余库存: 45
True
```

## day5+day6：ProductService 与前台调用

- 把商品查找和库存扣减的业务规则移动到独立的 `ProductService` 类中。
- `ProductService.FindProduct` 负责按编号查找商品。
- `ProductService.ReduceStock` 返回状态字符串，区分“数量不合法”“库存不足”和“扣减成功”。
- `Program` 作为前台入口接收输入，并根据返回状态输出对应结果。
- 运行方式：使用 Visual Studio 打开 `day5+day6.sln`，按 F5 运行。

```text
请输入商品编号: 1002
请输入购买数量: 1000
该商品库存不足
库存量: 100
```

## day7：商品添加业务

- 在 `day5+day6` 的 `ProductService` 基础上新增 `AddProduct` 商品添加方法。
- 通过控制台输入商品编号、名称、价格和库存，创建新的 `Product` 对象。
- `AddProduct` 会先检查商品编号是否已存在，编号重复时返回 `DUPLICATE`，否则添加成功并返回 `SUCCESS`。
- 运行方式：使用 Visual Studio 打开 `day7.sln`，按 F5 运行。

```text
请输入商品编号: 1004
请输入商品名称: 耳机
请输入商品价格: 199
请输入商品库存: 80
商品添加成功
```

## 第二天与第一天的主要差异

- 第一天直接遍历 `List<Product>` 并打印所有商品名称。
- 第二天把“按编号查找商品”封装成独立方法 `FindProduct(List<Product>, int)`，返回 `Product` 或 `null`。
- 第二天通过 `Console.ReadLine()` 接收用户输入，并按编号输出完整商品信息。

## 第三天与第二天的主要差异

- 第二天只负责查找商品并输出信息，不改变库存。
- 第三天新增 `ReduceStock(Product, int)`，根据购买数量直接修改商品的 `stock`。
- 第三天在购买数量超过现有库存时输出“库存不足”，否则输出扣减后的剩余库存。

## 第四天与第三天的主要差异

- 第三天的 `ReduceStock` 没有返回值，库存不足时直接输出“库存不足”。
- 第四天把 `ReduceStock` 改为返回 `bool`：扣减成功返回 `true`，库存不足返回 `false`。
- 第四天由主程序接收返回值，并输出扣减后的剩余库存和成功结果。

## day5+day6 与 day4 的主要差异

- day4 的查找和库存扣减逻辑都写在 `Program` 中。
- day5+day6 将业务规则封装到 `ProductService` 类中，让 `Program` 只负责前台输入和输出。
- `ReduceStock` 由返回 `bool` 改为返回状态字符串，并额外检查购买数量是否为不合法数值。

## day7 与 day5+day6 的主要差异

- day5+day6 只在前台查找商品并执行库存扣减，不向列表中添加新商品。
- day7 新增 `AddProduct(List<Product>, Product)`，先通过 `FindProduct` 检查编号重复，再决定是否把商品加入列表。
- day7 由 `Program` 输入完整商品信息并调用 `AddProduct`，分别处理 `SUCCESS` 和 `DUPLICATE` 两种结果。
