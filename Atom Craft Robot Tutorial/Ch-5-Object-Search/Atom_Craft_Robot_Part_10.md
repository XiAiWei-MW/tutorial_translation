## Robot教程篇 Part 10：来尝试使用find_object吧

在本教程中，我们将使用find_object函数在一个工作单元中通过递归的方式检索一个CueSheet，连续处理多个波形文件并将它们注册到素材中，之后创建引用它们的Cue。<br/>
在<a href="../Ch-2-Project-Module/Atom_Craft_Robot_Part_06.md" target="_blank">“创建一个项目并注册波形文件”</a>教程中，我们尝试了逐一创建一个Cue和一个素材。<br/>
实际情况下，我们并不会一次只注册一个声音数据，而是一次注册一组声音数据。

本教程将使用在教程<a href="../Ch-2-Project-Module/Atom_Craft_Robot_Part_06.md" target="_blank">“创建一个项目并注册波形文件”</a>中创建的项目。

### 准备脚本文件
在脚本菜单中，选择“脚本列表”。<br/>
在脚本列表窗口中按下 "新建 "按钮，创建一个脚本文件，名称如下：

| 脚本保存地址     | 脚本文件名                                |
|:-----------------|:------------------------------------------|
| tutorials [CRI]  | tutorial05-1_use_find_object.py           |

### 脚本文件说明
双击刚刚创建的脚本，在脚本编辑器中打开它，并写上如下的描述语句：

```python
# --Description:[教程]使用find_object函数＆批量注册复数波形文件
```

### 导入模块
接下来我们导入以下模块：

```python
import os
import glob
import cri.atomcraft.debug as acdebug
import cri.atomcraft.project as acproject
```

为了得到文件夹中包含的音频文件的路径，我们导入了一个叫做glob的Python模块。<br/>
glob模块可以用来检索符合指定格式的文件路径。<br/>
此外我们导入用于项目操作的project模块，以及用于日志输出的debug模块。

### 获取教程波形素材文件夹中的波形文件列表
使用glob模块来获取教程工作文件夹“/tutorial_data/tutorial_data02”中的音频文件。<br/>
脚本如下所示：

```python
# 获取波形文件列表
# 获取教程波形素材文件夹'tutorial_data/tutorial_data02'的路径
data_dir = os.path.dirname(os.path.dirname(__file__)) + '/tutorial_data/tutorial_data02'

# 使用glob获取data_dir内的文件
files = glob.glob(data_dir + '/*')
if len(files) == 0:
    acdebug.warning(data_dir + "内没有文件")
    sys.exit()
```

#### 说明
我们把glob.glob函数获得的文件路径列表存储在变量files中。<br/>
接下来，我们使用len函数来检查存储在files变量中的文件路径的数量，如果没有，就输出日志并退出脚本。

在glob.glob函数中指定的路径末尾的“\*”是一个被用于通配符匹配搜索的特殊字符。<br/>
如果指定“\*”（星号），则获取文件夹中的所有文件。

### 素材文件夹和CueSheet的获取
以下函数用于获取工作单元，用于注册音频文件的素材文件夹，以及用于创建Cue的CueSheet:

| 函数名                  | 说明          |
|:------------------------|:--------------|
| get_workunit            | 获取工作单元  |
| get_material_rootfolder | 获取工作单元的素材根文件夹 |
| find_object             | 以递归方式搜索并获取对象  |

使用find_object函数获取CueSheet的脚本如下所示：

```python
# 获取注册了音频文件的工作单元
workunit = acproject.get_workunit("WorkUnit_Tutorial")["data"]

# 获取注册了音频文件的素材文件夹
material_root_folder = acproject.get_material_rootfolder(workunit)["data"]

# 获取创建了Cue的CueSheet
cuesheet = acproject.find_object(workunit, "CueSheet", "Tutorial")["data"]
```

#### 说明
我们用find_object函数来获取CueSheet。<br/>
find_object函数需要指定“作为搜索根的对象”、“要获取的对象类型”和“要获取的对象名称”作为参数。<br/>
find_object函数将根据指定的值遍历对象结构，并返回第一个符合标准的对象。<br/>
因此，我们可以在一次调用中检索所需的对象，而不必在脚本中遍历对象的层次结构。

### 从波形文件列表中创建一个Cue
我们将使用以下的函数，从刚刚检索到的文件路径列表中逐个取出文件路径，来创建一个素材和一个Cue。

| 函数名            | 说明   |
|:------------------|:-------|
| register_material | 注册波形文件 |
| create_simple_cue | 创建Cue  |

这里，我们使用create_simple_cue函数来创建一个Cue。<br/>
这里的for语句被用来连续处理由glob.glob函数获得的文件路径列表中的元素。脚本如下所示：

```python
for file in files:
    # 在素材根目录下注册波形文件，并创建一个素材
    material = acproject.register_material(material_root_folder, file)["data"]
    # 从素材信息中创建一个Cue
    acproject.create_simple_cue(cuesheet, material)
```

#### 说明
create_simple_cue函数会创建一个具有基本结构的Cue。<br/>
create_simple_cue函数需要指定CueSheet和Cue所引用的素材。<br/>
创建的Cue的名称为素材名称（无扩展名）。

### 保存项目
最后一步是项目的保存：

```python
# 保存项目
result = acproject.save_project_all()
if not result["succeed"]:
    acdebug.warning("项目文件保存失败。")

acdebug.log("[教程]使用find_object函数完成了文件夹中多个音频文件的批量注册。")
```

### 脚本的保存与运行
保存并运行该脚本，如果脚本运行成功，就会像下图一样，将“tutorial_data02”中的音频文件注册为素材，并创建一个Cue来引用它们。

![](https://game.criware.jp/wp-content/uploads/2020/11/robot_09_01.png)
