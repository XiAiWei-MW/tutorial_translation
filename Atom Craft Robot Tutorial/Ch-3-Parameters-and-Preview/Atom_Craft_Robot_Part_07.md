### Robot教程篇 Part 7：参数值的变更与预览
在上一章<a href="../Ch-2-Project-Module/Atom_Craft_Robot_Part_06.md" target="_blank">“创建一个项目并注册波形文件”</a>中，我们用AtomCraft Robot创建了一系列数据，例如项目和Cue。

本节我们将编写一个脚本来改变我们创建的Cue的音量，并预览该Cue。<br/>
我们将会用到上一章<a href="../Ch-2-Project-Module/Atom_Craft_Robot_Part_06.md" target="_blank">“创建一个项目并注册波形文件”</a>中创建的项目。

### 准备脚本文件
在脚本菜单中，选择“脚本列表”。<br/>
在脚本列表窗口中按下 "新建 "按钮，创建一个脚本文件，名称如下：

| 脚本保存地址     | 脚本文件名                                |
|:-----------------|:------------------------------------------|
| tutorials [CRI]  | tutorial03-1_edit_and_preview.py          |

### 脚本文件说明
双击刚刚创建的脚本，在脚本编辑器中打开它，并写上如下的描述语句：

```python
# --Description:[教程]参数值的变更和Cue预览
```

### 导入模块
接下来我们导入以下模块：

```python
import cri.atomcraft.project as acproject
import cri.atomcraft.preview as acpreview
```

其中project模块用于处理AtomCraft的项目数据，preview模块用于预览。

### 获取编辑的Cue

![](https://game.criware.jp/wp-content/uploads/2020/11/robot_06_01.png)

为了编辑一个Cue的参数，我们需要将该Cue作为一个对象获取。
有两种获取对象的主要方式：
* 通过搜索进行获取
* 通过遍历层次结构进行获取

作为对层次结构的复习，我们将使用以下函数来逐级遍历工作单位对象，以获取Cue。<br/>
如果我们知道将要获取的Cue的层次结构，那么遍历层次结构进行获取就很有用。<br/>
通过搜索进行获取的方法将在之后<a href="../Ch-5-Object-Search/Atom_Craft_Robot_Part_09.md" target="_blank">“对象检索函数的类型”</a>的教程中解释。<br/>
以下函数依次用于获取工作单元、CueSheet文件夹、CueSheet和Cue：

| 函数名                  | 说明                |
|:------------------------|:--------------------|
| get_workunit            | 获取工作单元        |
| get_cuesheet_rootfolder | 获取CueSheet根文件夹    |
| get_child_object        | 搜索并获取指定的父对象正下方的对象 |

脚本如下所示：

```python
# 获取工作单元
workunit = acproject.get_workunit("WorkUnit_Tutorial")["data"]

# 获取CueSheet根文件夹
cuesheet_rootfolder = acproject.get_cuesheet_rootfolder(workunit)["data"]

# 获取CueSheet文件夹“WorkUnit_Tutorial”
cuesheet_folder = acproject.get_child_object(cuesheet_rootfolder, "CueSheetFolder", "WorkUnit_Tutorial")["data"]

# 获取CueSheet
cue_sheet = acproject.get_child_object(cuesheet_folder, "CueSheet", "Tutorial")["data"]

# 获取Cue
cue = acproject.get_child_object(cue_sheet, "Cue", "gun1_High")["data"]
```

#### 获取Cue的说明
为了检索分层结构中的一个对象，我们首先需要获取根对象，即起始对象。<br/>
包含Cue对象的对象结构的根对象是工作单元对象。<br/>
工作单元对象可以通过在get_workunit函数中指定“工作单元名称”获得。<br/>
在这个例子中，我们通过指定“WorkUnit_Tutorial”作为工作单元名称来检索该工作单元。

接下来，我们使用get_cuesheet_rootfolder函数从工作单元中检索出工作单元的CueSheet根文件夹。<br/>
从CueSheet根文件夹中，我们可以使用get_child_object函数来从CueSheet文件夹、CueSheet、Cue等层次结构中获取对象。

### 变更Cue的参数值

![](https://game.criware.jp/wp-content/uploads/2020/11/robot_06_02.png)

获取了Cue之后，接下来是变更Cue的参数值。<br/>
我们将使用以下函数来改变Cue的音量参数：

| 函数名    | 说明      |
|:----------|:----------|
| set_value | 设置对象的参数 |

使用该函数将Cue的音量变更为0.5的脚本如下所示：

```python
# 变更Cue的音量
acproject.set_value(cue, "Volume", 0.5)
```

#### 说明
set_value函数是一个用于改变参数的通用函数，需要指定“目标对象信息”、“参数名称”和 “参数值”。

在执行脚本之前，确认Cue“gun1_High”的音量为1.0。<br/>
确认完成后，按“运行”按钮来运行该脚本。<br/>
可以看到，提示音“gun1_High”的音量已经变成了0.5。

![](https://game.criware.jp/wp-content/uploads/2020/11/robot_06_03.png)

### Cue的预览
最后，我们将在导入的preview模块中使用以下函数预览Cue：

| 函数名             | 说明      |
|:-------------------|:----------|
| start_playback_cue | 播放所指定的Cue |

start_playback_cue函数是一个简单的预览函数，能让我们指定一个Cue来预览和播放。<br/>
刚才改变了音量的Cue“gun1_High”，通过以下的脚本，可以预览出来：

```python
# 播放Cue
acpreview.start_playback_cue(cue)
```

### 脚本的保存与运行
保存并运行该脚本，如果脚本运行成功，名为“gun1_High”的Cue的音量会变为0.5，并且会进行预览播放。
