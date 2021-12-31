## Robot教程篇 Part 12：get_child_objects的使用
本教程中将会介绍如何使用get_child_objects函数一次获取多个对象。<br/>
我们将编写一个脚本，直接获取CueSheet下的所有Cue，并根据命名规则设置类别。

本教程将使用[“来尝试使用find_object吧（上）”](Atom_Craft_Robot_Part_10.md)教程中创建的项目。

### 准备脚本文件
在脚本菜单中，选择“脚本列表”。<br/>
在脚本列表窗口中按下 "新建 "按钮，创建一个脚本文件，名称如下：

| 脚本保存地址     | 脚本文件名                                |
|:-----------------|:------------------------------------------|
| tutorials [CRI]  | tutorial05-3_use_get_child_objects.py     |

### 脚本文件说明
双击刚刚创建的脚本，在脚本编辑器中打开它，并写上如下的描述语句：

```python
# --Description:[教程]使用get_child_objects函数来获取Cue，并根据命名规则设置类别
```

### 导入模块
接下来我们导入以下模块：

```python
import sys
import cri.atomcraft.debug as acdebug
import cri.atomcraft.project as acproject
```

导入用于项目操作的project模块，以及用于日志输出的debug模块。

### 准备设定的类别
在<a href="Atom_Craft_Robot_Part_10.md" target="_blank">“来尝试使用find_object吧（上）”</a>教程中，我们创建了几个名字以 "sfx_"开头的Cue。
我们现在将为这些以“sfx”开头的Cue的类别设置为“sfx”。<br/>
使用以下函数将CRI AtomCraft项目树中的类别由默认的“Category_0”改为“sfx”。
