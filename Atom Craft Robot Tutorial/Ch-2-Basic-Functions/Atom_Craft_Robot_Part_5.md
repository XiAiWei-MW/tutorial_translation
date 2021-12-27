## Robot教程篇 Part 5：在脚本日志中输出“Hello World”

在本教程中，我们将以两种方式在“脚本日志”窗口中显示“Hello, World”字符：
* 使用Python自带的print函数输出日志
* 使用CRI AtomCraft API的debug模块输出日志

日志输出功能能让我们更加直观地检查一个脚本的执行情况。让我们了解一下这两种输出方法以及它们之间的区别。

### 准备脚本文件
首先我们准备一个Python脚本文件。<br/>
启动CRI AtomCraft，从“脚本”菜单中选择“脚本列表”。<br/>
从脚本列表中选择“tutorials[CRI]”，然后点击脚本文件的“新建”按钮。

![](https://game.criware.jp/wp-content/uploads/2020/11/robot_04_01.png)

点击“新建”按钮，打开文件创建对话框。<br/>
输入文件名“tutorial01-1_helloworld.py”，然后点击 "保存 "按钮，保存该文件。<br/>
保存好的脚本文件“tutorial01-1_helloworld”将出现在脚本列表中。

![](https://game.criware.jp/wp-content/uploads/2020/11/robot_04_02.png)

### 脚本说明
我们现在已经创建了一个脚本文件。<br/>
检查一下脚本列表的“samples[CRI]”部分，我们会发现一些脚本示例。<br/>
除了之前创建的“tutorial01-1_helloworld”，所有的脚本文件在脚本列表中都有一个说明栏。<br/>
脚本列表能够读取以下列格式写在脚本中的注释，并将其显示在脚本列表的“说明”栏中。

```python
# --Description: 说明
```

双击脚本列表中的“tutorial01-1_helloworld”，从脚本编辑器打开脚本文件，并添加如下注释：

```python
# --Description:[教程] 在日志中输出Hello World
```

添加注释后，点击脚本编辑器工具栏上的“保存”按钮，保存脚本。<br/>
返回脚本列表时，可以看到脚本“tutorial01-1_helloworld”的说明已经显示出来。

![](https://game.criware.jp/wp-content/uploads/2020/11/robot_04_03.png)

### 使用Python标准字符串输出“Hello, World”
添加了脚本说明之后，让我们使用Python标准输出的print函数将“Hello, World”打印到脚本日志中。<br/>
让我们回到脚本的运行，输入以下内容：

```python
print("Hello, World")
```

在脚本编辑器的工具栏上，点击“保存”按钮保存脚本。

![](https://game.criware.jp/wp-content/uploads/2020/11/robot_04_04.png)

#### 运行脚本
运行刚才创建的脚本，脚本日志窗口中显示“Hello, World”。<br/>
回到脚本列表，点击“显示日志”按钮，显示脚本日志窗口。<br/>
按工具栏上的“运行”按钮来运行脚本，“Hello, World”会出现在脚本日志窗口。

![](https://game.criware.jp/wp-content/uploads/2020/11/robot_04_05.png)

### 使用cri.atomcraft.debug模块显示“Hello, World”
使用Python的打印函数，我们能够在脚本日志中输出“Hello, World”。<br/>
接下来，让我们尝试使用CRI AtomCraft API的调试模块在脚本日志中输出“Hello, World”。

#### 导入CRI AtomCraft的Debug模组
在CRI AtomCraft中，有一个能够控制CRI AtomCraft的Python模块。<br/>
如果要在Python中使用外部模块，请使用 import 语句。<br/>
如果我们想使用CRI AtomCraft API的debug模块，可以使用以下语句：

```python
import cri.atomcraft.debug
```

![](https://game.criware.jp/wp-content/uploads/2020/11/robot_04_06.png)

#### 使用debug模块的log函数显示“Hello, World”
有了import，我们现在就可以使用CRI AtomCraft API的debug模块了。

那么，让我们试着用调试模块来显示“Hello, World”。<br/>
在debug模块中，有多个字符串输出函数，但我们将使用log函数来显示“Hello, World”。

在声明了`import cri.atomcraft.debug`之后，让我们写一个脚本：

```python
cri.atomcraft.debug.log("Hello, World")
```

保存脚本后，在运行前，按脚本日志窗口中的“清除”按钮，清除日志窗口。<br/>
运行该脚本时，我们会看到两行“Hello, World”，分别是print函数和log函数的输出结果。

![](https://game.criware.jp/wp-content/uploads/2020/11/robot_04_07.png)

#### Python标准print函数和debug模块log函数之间的区别
当我们在本地的脚本编辑器中使用print和log函数时，脚本日志的输出并没有真正的区别。<br/>
然而，当使用print函数远程执行Python脚本时，结果不会显示在CRI AtomCraft脚本日志中，而是输出到运行的应用程序内。<br/>
这种差异是因为print函数是由运行脚本的程序处理的。另一方面，log函数只在远程执行时输出到脚本日志。

如果我们通过从外部应用程序远程执行脚本来使用CRI AtomCraft，我们可能更希望将日志数据输出到外部应用程序。<br/>
因此，print函数和log函数能让我们把结果输出到不同的地方。

[远程执行的示例：通过terminal远程连接到CRI AtomCraft并运行print函数]

![](https://game.criware.jp/wp-content/uploads/2020/11/robot_04_08.png)

#### Debug模块中其它的输出函数
在本教程中，我们使用了log函数来打印“Hello World”。<br/>
实际场景中，当我们写一个脚本来操作CRI AtomCraft时，日志输出主要用于调试目的。<br/>
除了log函数外，在debug模块中还有一个warning函数。
