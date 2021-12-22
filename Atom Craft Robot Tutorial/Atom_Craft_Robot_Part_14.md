## Robot教程篇 Part 14：来尝试一下脚本编辑器的一些便利功能

在我们迄今为止创建的脚本中，要操作的对象的名称，如WorkUnit和CueSheet，都是直接写在脚本中的。<br/>
然而，这意味着如果我们想对不同的对象应用相同的操作时，只能直接编辑代码，既费时费力而且可能会导致错字。<br/>
为了避免这种情况，CRI Atom Craft Robot为脚本编辑提供了扩展功能。<br/>
这个功能允许我们在脚本列表和菜单中显示脚本注释，并使用编辑器GUI轻松更新脚本中定义的变量。<br/>
脚本编辑器的扩展功能将大幅降低修改脚本所需的时间和错误。

在本教程中，我们将创建一个脚本，使用脚本编辑器扩展功能中的用户变量功能，在GUI操作中改变一个Cue的“音高”参数。

![](https://game.criware.jp/wp-content/uploads/2020/11/robot_13_01.png)

本教程将使用之前在教程<a href="https://game.criware.jp/learn/tutorial/atomcraft/atomcraft_robot_06/" target="_blank">“创建项目和添加波形文件”（日文）</a>中创建的工程。

### 准备脚本文件
在脚本菜单中，选择“脚本列表”。
在脚本列表窗口中按下 "新建 "按钮，创建一个脚本文件，名称如下：

| 脚本保存地址     | 脚本文件名                                |
|:-----------------|:------------------------------------------|
| tutorials [CRI]  | tutorial06-1_user_variable.py             |

### 脚本文件说明
双击刚刚创建的脚本，在脚本编辑器中打开它，并写上如下的描述语句：

```
# --Description:[教程]使用用户变量来改变Cue的“音高”参数
```

### 导入模块
完成脚本描述之后，请导入以下模块，以便在你的脚本中操作CRI Atom Craft。

```
import cri.atomcraft.project
import cri.atomcraft.project as acproject
import cri.atomcraft.debug as acdebug
```

导入用于工程操作的project模块和用于日志输出的debug模块。<br/>
如果我们定义了一个用于处理对象的用户变量，则需要导入 cri.atomcraft.project，而不替换导入名称。

### 定义用户变量
首先我们通过`# --BeginUserVariable`和`# --EndUserVariable`来定义用户变量的范围。<br/>
在该范围内定义的变量，在脚本编辑器中会被当作用户变量处理。<br/>
为了改变Cue的音高，我们在`# --BeginUserVariable`到`# --EndUserVariable`之间写下变量：
* 改变参数的Cue
* 要改变的参数的字段名
* 要设定的参数的值

如下所示：

```
# --BeginUserVariable
VARIABLE_CUE = None
VARIABLE_PARAMETER_NAME = ""
VARIABLE_PARAMETER_VALUE = 0
# --EndUserVariable
```

我们应当为声明的变量设定一个初始值。

### 定义用户变量设置中显示的信息
为了让之前定义的用户变量显示在用户变量窗口中，我们需要使用三个双引号（"）描述一个docstring区域，将变量的名称、类型和描述写在变量的定义语句之前。

```
"""
变量名:
  type: 变量类别
  comment: 参数的说明
"""
```

在type中，我们可以根据变量的内容来指定三种不同的类型：

| type的种类 | 说明         |
|:-----------|:-------------|
| object     | 使用对象作为变量  |
| string     | 使用字符串作为变量 |
| number     | 使用数值作为变量  |

脚本整体如下所示：

```
# --BeginUserVariable
"""
VARIABLE_CUE:
  type: object
  comment: 将要改变参数的Cue
VARIABLE_PARAMETER_NAME:
  type: string
  comment: 参数名
VARIABLE_PARAMETER_VALUE:
  type: number
  comment: 参数值
"""
VARIABLE_CUE = None
VARIABLE_PARAMETER_NAME = ""
VARIABLE_PARAMETER_VALUE = 0
# --EndUserVariable
```

现在，点击脚本编辑器工具栏中的“更新”按钮，在脚本编辑器的右侧的“用户变量”区域将会显示我们刚才在脚本编辑器中编写的用户变量信息。

![](https://game.criware.jp/wp-content/uploads/2020/11/robot_13_02.png)

### 为用户变量设定参数
现在，脚本编辑器的“用户变量”部分中已经显示出了变量信息。<br/>
我们可以通过从CRI Atom Craft的WorkUnit Tree上拖放Cue来设置VARIABLE_CUE变量的对象。<br/>
接下来将VARIABLE_PARAMETER_NAME和VARIABLE_PARAMETER_VALUE设定为如下值：

| 变量名                   | 值    |
|:-------------------------|:------|
| VARIABLE_PARAMETER_NAME  | Pitch |
| VARIABLE_PARAMETER_VALUE | 100   |

![](https://game.criware.jp/wp-content/uploads/2020/11/robot_13_03.png)

点击应用之后，脚本将显示出脚本编辑器中“用户变量”部分的内容。

![](https://game.criware.jp/wp-content/uploads/2020/11/robot_13_04.png)

### 使用“用户变量”更新Cue参数
通过使用用户变量功能，我们已经为用户变量设置了对应的值。<br/>
我们现在将使用用户变量来Cue参数。<br/>
更新队列参数的脚本如下所示：  

```
acproject.set_value(VARIABLE_CUE, VARIABLE_PARAMETER_NAME, VARIABLE_PARAMETER_VALUE)

acdebug.log("音高参数的更改已结束")
```

### 脚本的保存与运行
脚本的编写到此结束。<br/>
保存并运行该脚本，如果脚本运行成功，Cue的音高值将被更新为用户变量区域中所设置的值，如下所示：

![](https://game.criware.jp/wp-content/uploads/2020/11/robot_13_05.png)

在这篇文章中，我们介绍了一个使用用户变量功能来改变Cue的音高的脚本。
这个脚本不仅可以用于Cue，也可以用于音轨。
除此之外，也可以指定音高以外的其他参数名称。
各位读者可以自行尝试编辑一下脚本。