# C- 学习仓库

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

## 第二天与第一天的主要差异

- 第一天直接遍历 `List<Product>` 并打印所有商品名称。
- 第二天把“按编号查找商品”封装成独立方法 `FindProduct(List<Product>, int)`，返回 `Product` 或 `null`。
- 第二天通过 `Console.ReadLine()` 接收用户输入，并按编号输出完整商品信息。
