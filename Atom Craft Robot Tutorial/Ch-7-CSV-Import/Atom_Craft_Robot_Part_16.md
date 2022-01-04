## Robot教程篇 Part 16：使用CSV检查未注册的Cue
在之前的<a href="Atom_Craft_Robot_Part_15.md" target="_blank">“使用CSV文件创建CueSheet”</a>教程中，我们通过CSV文件注册了波形文件，并创建了CueSheet和Cue。<br/>
在本教程中，我们将使用<a href="Atom_Craft_Robot_Part_15.md" target="_blank">“使用CSV文件创建CueSheet”</a>中的CSV文件来写一个脚本，以检查在CRI Atom Craft中创建的CueSheet是否包含与CSV文件中的Cue名称相一致的Cue。

同样的，我们也会使用之前<a href="Atom_Craft_Robot_Part_15.md" target="_blank">“使用CSV文件创建CueSheet”</a>中创建的工程。

### 准备脚本文件
在脚本菜单中，选择“脚本列表”。<br/>
在脚本列表窗口中按下 "新建 "按钮，创建一个脚本文件，名称如下：

| 脚本保存地址     | 脚本文件名                                |
|:-----------------|:------------------------------------------|
| tutorials [CRI]  | tutorial07-2_check_cuesheet_from_csv.py   |

### 脚本文件说明
双击刚刚创建的脚本，在脚本编辑器中打开它，并写上如下的描述语句：

```python
# --Description:[教程]使用CSV检查未注册的Cue
```

### 导入模块
完成脚本描述之后，请导入以下模块：

```python
import sys
import os
import csv
import cri.atomcraft.debug as acdebug
import cri.atomcraft.project as acproject
```

为了读取CSV文件，我们从Python标准库中导入csv模块。此外，导入用于工程操作的project模块和用于日志输出的debug模块。

### 设置CSV文件的路径
设置用于检查的CSV文件的路径。脚本如下所示：

```python
# CSV文件地址
csv_path = os.path.dirname(os.path.dirname(__file__)) + '/tutorial_data/tutorial_data03/tutorial_data3.csv'

# 检查CSV文件是否存在
if os.path.isfile(csv_path) == False:
    acdebug.warning("无法找到CSV文件: " + csv_path)
    sys.exit()
```

使用os.path.isfile函数可以检查文件是否存在。
如果文件不存在，脚本将会中止。

### 检查并比较CueSheet内和CSV文件内的Cue名称

以下函数可用于读取CSV文件和检索信息，以便在检查中使用。

| 函数名                  | 说明                                         |
|-------------------------|----------------------------------------------|
| get_workunit            | 获取Work Unit                                |
| get_cuesheet_rootfolder | 获取Cue Sheet根文件夹                        |
| get_child_object        | 搜索并获取指定的父对象正下方的对象           |
| find_objects            | 以递归方式搜索对象并获取所有符合条件的对象   |
| get_value               | 获取对象的参数                               |

为了检查是否有匹配的Cue名称，我们需要获取CueSheet里面的Cue列表，并获取其中的Cue名称信息。<br/>
接下来我们检查Cue列表中是否包含从CSV中获取的Cue名称信息。<br/>
如果CueSheet中有尚未创建的Cue，Cue名称将显示在脚本日志中。<br/>
脚本如下：

```python
# 打开CSV文件并检查CueSheet中的Cue
acdebug.log("正在使用tutorial_data3.csv检查Cue")
unregistered_cue_name_list = []
with open(csv_path) as f:
    reader = csv.reader(f)
    for row in reader:
        # 获取CSV的Cue列表
        cue_name = row[1]
        # 检查CSV中记录的Cue是否已经被注册完毕
        if not cue_name in registered_cue_name_list:
            # 如果没有被注册的话
            unregistered_cue_name_list.append(cue_name)
# 检查
if len(unregistered_cue_name_list) > 0:
    acdebug.warning(cuesheet_name + "中有未注册的Cue")
    for cue_name in unregistered_cue_name_list:
        acdebug.warning("Cue " + cue_name + "未找到")
else:
    acdebug.log("检查完毕，没有异常")
acdebug.log("[教程]Cue的注册情况检查完毕")
```

### 脚本的保存与运行
脚本的编写到此结束。<br/>
保存并运行该脚本，如果脚本运行成功，日志中会输出所有CSV中不存在的Cue名称。<br/>
这时我们对CRI Atom Craft进行直接操作，如添加或删除Cue，或是重命名Cue，日志中输出的内容将会有所变化。
