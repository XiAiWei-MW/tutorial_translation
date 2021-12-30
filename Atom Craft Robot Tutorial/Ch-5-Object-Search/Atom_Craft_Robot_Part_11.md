## Robot教程篇 Part 11：来尝试使用find_object吧（下）
到目前为止，我们已经介绍了各种操作CRI AtomCraft的函数，但所有这些都是在一次调用中获得一个对象的函数。<br/>
find_objects函数是一个非常有用的函数，它允许我们在一次调用中获取多个对象。<br/>
本教程将介绍如何使用find_objects函数一次检索多个对象。

让我们写一个脚本，为一个工作单元中的所有波形区域批量设置Voice限数组。

本教程将使用在教程<a href="../Ch-2-Project-Module/Atom_Craft_Robot_Part_06.md" target="_blank">“创建一个项目并注册波形文件”</a>中创建的项目。

### 准备脚本文件
在脚本菜单中，选择“脚本列表”。<br/>
在脚本列表窗口中按下 "新建 "按钮，创建一个脚本文件，名称如下：

| 脚本保存地址     | 脚本文件名                                |
|:-----------------|:------------------------------------------|
| tutorials [CRI]  | tutorial05-2_use_find_object.py           |

### 脚本文件说明
双击刚刚创建的脚本，在脚本编辑器中打开它，并写上如下的描述语句：

```python
# --Description:[教程]使用find_object函数&批量设置波形区域的Voice限数组
```

### 导入模块
接下来我们导入以下模块：

```python
import sys
import cri.atomcraft.debug as acdebug
import cri.atomcraft.project as acproject
```

导入用于项目操作的project模块，以及用于日志输出的debug模块。

### 获取要设置的Voice限数组
我们先获取要为波形区域设置的Voice限数组。
要获得Voice限数组，可以使用以下函数，方法与 <a href="../Ch-4-Build_Binary/Atom_Craft_Robot_Part_08.md" target="_blank">“游戏数据（ACF，ACB）的输出”</a>教程中获得目标配置相同。

| 函数名            | 说明                |
|:------------------|:--------------------|
| get_global_folder | 获取选择器文件夹等总体设置下方的文件夹 |
| get_child_object  | 搜索并获取指定的父对象正下方的对象 |

使用这些函数来获取Voice限数组的脚本如下所示：

```python
# 获取Voice限数组文件夹
voicelimit_group_folder  = acproject.get_global_folder("VoiceLimitGroupFolder")["data"]

# 获取Voice限数组“VoiceLimitGroup_0”
voicelimit_group = acproject.get_child_object(voicelimit_group_folder, "VoiceLimitGroup", "VoiceLimitGroup_0")["data"]
```

管理同时发声数量的Voice限数组可以使用get_global_folder函数从全局设置中的Voice限数组文件夹中获得。
在得到Voice限数组文件夹后，我们使用get_child_object获取Voice限数组文件夹下的Voice限数组“VoiceLimitGroup_0”，并将其存储在变量voicelimit_group中。

### 获取设置Voice限数组的波形区域