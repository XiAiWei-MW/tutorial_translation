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

| 函数名            | 说明                |
|:------------------|:--------------------|
| get_global_folder | 获取选择器文件夹等总体设置下方的文件夹 |
| find_object       | 以递归方式搜索并获取对象        |
| set_value         | 设置对象的参数             |

使用这些函数获取类别，然后将类别重命名的脚本如下所示：

```python
# 为Cue准备将要设定的类别
# 获取类别文件夹
category_folder = acproject.get_global_folder("CategoryFolder")["data"]

# 获取类别
category = acproject.find_object(category_folder, "Category", "Category_0")["data"]

# 变更类别名
acproject.set_value(category, "Name", "sfx")
```

#### 说明
使用get_global_folder函数获取类别文件夹。<br/>
然后使用find_object函数从category文件夹下获得名为“Category_0”的类别，并使用set_value函数将category名称改为“sfx”。

### 直接在CueSheet下获取将要设置类别的Cue
我们获取工作单元、CueSheet，并获取CueSheet中的Cue列表，以设置类别。<br/>
这次我们将使用get_child_objects函数来获取同一层次结构中类似对象的列表。

| 函数名            | 说明                        |
|:------------------|:----------------------------|
| get_workunit      | 获取工作单元                |
| find_object       | 以递归方式搜索并获取对象    |
| get_child_objects | 搜索指定的父对象正下方的对象，并获取所有符合条件的对象 |

使用这些函数来获取在CueSheet正下方的Cue列表的脚本如下所示：

```python
# 获取工作单元
workunit = acproject.get_workunit("WorkUnit_Tutorial")["data"]

# 获取CueSheet
cuesheet = acproject.find_object(workunit, "CueSheet", "Tutorial")["data"]
# 获取CueSheet正下方的多个Cue
cues = acproject.get_child_objects(cuesheet, "Cue")["data"]
```

#### 说明
get_child_objects函数用于以列表形式获取CueSheet正下方的Cue。<br/>
get_child_objects函数需要指定“父对象”和“要获取的对象类型”。<br/>
示例中指定的变量cuesheet和“Cue”（Cue对象的类型）用于获取CueSheet正下方的所有Cue，并将其存储在变量cues中。

### 获取符合条件的Cue
从使用get_child_objects函数获取的Cue列表中，创建一个名称以“sfx”开头的线索列表。<br/>
要获得Cue的名称，请使用以下函数：

| 函数名            | 说明                        |
|:------------------|:----------------------------|
| get_value         | 获取对象的参数              |

脚本如下所示：

```python
# 需要设定类别的Cue列表

# 包含了名称以 "sfx "开头的Cue的列表
cues_for_set_categories = []

## 检查对象的Cue
for cue in cues:
    # 获取Cue名称
    cue_name = acproject.get_value(cue, "Name")["data"]
    # 使用字符串函数startswith来检查字符串的开头是否包含sfx字符
    if cue_name.startswith('sfx') == True:  # Cue名称包含“sfx”
        # 添加到列表中
        cues_for_set_categories.append(cue)
```

### 为Cue设定类别
将存储在cues_for_set_categories列表中，且名称以sfx开头的Cue的类别进行设定。<br/>
这里我们使用以下函数，它允许我们在一次调用中为多个Cue设置类别。

| 函数名               | 说明                        |
|:---------------------|:----------------------------|
| add_category_to_cues | 针对多个Cue添加类别         |

脚本如下所示：

```python
# 设定类别
# 批量更改类别的情况下使用add_category_to_cues
acproject.add_category_to_cues(cues_for_set_categories, category)

acdebug.log("[教程]使用get_child_objects函数获得Cue，并根据命名规则设定了类别")
```

#### 说明
add_category_to_cues函数用于将到多个队列设置为同一类别。<br/>
add_category_to_cues函数指定一个Cue的列表和一个类别。

作为add_category_to_cues函数的替代品，还有set_categories函数，它可以一次为一个Cue设置多个类别。<br/>
根据不同目的来使用不同的类别设置函数，我们可以有效地为Cue设置类别。

### 保存和运行脚本
保存并运行该脚本，如果脚本运行成功，CategoryGroup_0下的“Category_0”将被改为“sfx”，名称以“sfx ”开头的Cue将会被归为“sfx”类别，如下所示：

![](https://game.criware.jp/wp-content/uploads/2020/11/robot_11_01.png)
