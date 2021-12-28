## Robot教程篇 Part 6：创建一个项目并注册波形文件
在本教程中，我们将编写一个包含从创建项目到在队列中注册波形文件的过程的脚本：
* 准备脚本文件
* 导入模块
* 设置项目名称和保存位置
* 创建项目和工作单元
* 注册素材
* 保存项目

### 准备脚本文件
在脚本菜单中，选择“脚本列表”，此时会出现一个脚本列表窗口，我们可以从中选择将要运行的脚本。<br/>
在脚本列表窗口中按下”新建“按钮，创建一个脚本文件，名称如下：

| 脚本保存地址    | 脚本文件名                               |
|:----------------|:-----------------------------------------|
| tutorials [CRI] | tutorial02-1_new_basic_project.py        |

### 脚本文件说明
双击创建的脚本，在脚本编辑器中打开它。<br/>
为了能够在“脚本列表”的窗口中显示脚本的内容，我们应当写一个脚本的描述，如下所示：

```python
# --Description:[教程]基本回放数据的创建和存储
```

### 导入模块
完成脚本描述之后，请导入以下模块，以便在你的脚本中操作CRI AtomCraft。

```python
import sys
import os
import cri.atomcraft.debug as acdebug
import cri.atomcraft.project as acproject
```

除了标准的Python模块sys和os之外，我们还导入了两个CRI AtomCraft操作模块。<br/>
一个是在<a href="file:///D:\Github\blog_translation\Atom%20Craft%20Robot%20Tutorial\Ch-1-Basic-Functions\Atom_Craft_Robot_Part_05.md" target="_blank">“在脚本日志中输出‘Hello World’”</a>教程中介绍过的debug模块，另一个是用于操作CRI AtomCraf的项目数据的project模块。

### 项目名称和保存路径的设定
接下来把项目名称，项目保存位置，教程中使用到的波形的位置记录在脚本里：

| 项目     | 内容                                        |
|:---------|:------------------------------------------|
| 项目名称 | Project_Tutorial                          |
| 项目保存位置 | “Documents/CRIWARE/CriAtomCraft/projects” |
| 波形文件位置 | “tutorials/robot/local/tutorial_data”     |

脚本如下所示：

```python
# 项目名称
project_name = "Project_Tutorial"

# 项目保存位置
projects_dir = os.path.expanduser('~/Documents/CRIWARE/CriAtomCraft/projects')
if not os.path.isdir(projects_dir):
    os.makedirs(projects_dir)

# 教程用声音素材的位置
data_dir = os.path.dirname(os.path.dirname(__file__)) + '/tutorial_data'
```

os.path.expanduser函数是Python的os模块中的一个函数，它将“\~”扩展到用户的主目录中以创建一个路径。<br/>
“\~”将会被用户的主目录代替。<br/>
os.path.isdir函数用来检查目录是否存在，如果不存在，就用os.makdirs函数来创建一个。

os.path.dirname函数被用来获取路径的目录。<br/>
在Python中，\_\_file\_\_包含可执行文件的路径。<br/>
教程中使用的波形文件位于“tutorial_data”文件夹中，该文件夹在可执行脚本文件的上方两个目录。<br/>
我们运行两次os.path.dirname，得到上方两个目录，并指定“tutorial_data”作为教程波形文件的位置。

#### 变量
变量是等号连接的左边的值，如`project_name = "Project_Tutorial"`中的“project_name”。<br/>
变量是一种用于临时存储程序中使用的数据的容器，它可以包含各种数据，如数字和文字。<br/>
数据一旦存储在一个变量中，该数据可以在后续的处理中自由获取。

### 工程和工作单元的创建
我们已经完成了模块导入、项目名称和保存项目的位置的设置。<br/>
现在我们准备开始处理CRI AtomCraft中的数据。<br/>
刚才导入的project模块，包含以下函数，用于创建项目和工作单元。

| 函数名          | 说明     |
|:----------------|:---------|
| create_project  | 创建对象   |
| create_workunit | 创建工作单元 |

脚本如下所示：
```python
# 创建项目
result = acproject.create_project(projects_dir, project_name, True)
if not result["succeed"]:
    acdebug.warning("Failed Create Project")
    sys.exit()

# 创建工作单元
result = acproject.create_workunit("WorkUnit_Tutorial", True, None)
if not result["succeed"]:
    acdebug.warning("Failed Create WorkUnit")
    sys.exit()

# 取得工作单元的信息
workunit = result["data"]
```

运行该脚本时，在“Documents/CRIWARE/CriAtomCraft/projects”下将创建一个包含工作单元 “WorkUnit_Tutorial”的“Project_Tutorial”项目。

![](https://game.criware.jp/wp-content/uploads/2020/11/robot_05_01.png)

#### 创建项目的说明
create_project函数用于创建一个项目，它指定了三个信息：项目名称、项目保存位置以及是否应该覆盖已存在项目。<br/>
如果第三个选项“覆盖已存在项目”被设置为 “True”，即使存在一个相同名称的项目文件，重名的项目将被覆盖，并创建一个新的项目。<br/>
执行函数时，执行的结果被作为返回值返回。 这里我们将返回的结果存储在一个叫做result的变量中。

result包含关于函数执行结果的各种信息，可以使用key来检索。<br/>
我们可以使用“succeed”检查该函数是否被成功执行，以及项目是否创建成功。<br/>
如果项目创建失败，日志窗口中会记录下结果。

#### 创建工作单元的说明
创建工作单元的函数create_workunit指定了以下信息：工作单元的名称，素材是否由工作单元管理，以及创建Cue时要设置的总线图。<br/>
执行create_workunit函数时，结果将作为返回值存储在变量result中，就像create_project函数一样。<br/>
result包含“succeed”键的信息，表明函数是否被成功执行，以及“data ”键的信息，表明被创建的工作单元。

在成功创建工作单元后，我们将`result["data"]`存储在workunit变量中，供后续处理使用。

### 注册素材
我们现在已经创建了项目和工作单元。
接下来我们将通过把波形文件注册到工作单元内的素材信息内来创建一个素材。
以下函数用于在素材根目录中注册一个波形文件：

| 函数名                  | 说明            |
|:------------------------|:----------------|
| get_material_rootfolder | 获取工作单元的素材根目录 |
| register_material       | 注册波形文件        |

脚本如下所示：

```python
# 获取素材根目录
material_root_folder = acproject.get_material_rootfolder(workunit)["data"]

# 将波形文件注册到素材根目录中
material = acproject.register_material(material_root_folder, data_dir+"/tutorial_data01/gun1_High.wav")["data"]
```

#### 注册素材的说明
注册素材所使用的register_material函数需要两个信息：目标文件夹和要注册的波形文件。<br/>
因此，我们首先使用get_material_rootfolder函数来获取工作单元的素材根目录。<br/>
接下来，我们使用register_material函数在素材根目录下注册波形文件，并创建素材。

执行脚本后，我们可以看到工作单元的素材根目录下创建了一个名为“gun1_High.wav ”素材。

![](https://game.criware.jp/wp-content/uploads/2020/11/robot_05_02.png)

### CueSheet，Cue和波形区域的创建
我们已经在工作单元的素材信息中注册了波形文件。<br/>
接下来我们使用以下函数来创建一个CueSheet，在里面创建一个Cue，将素材注册到该Cue上，并创建一个波形区域。

| 函数名                  | 说明                |
|:------------------------|:--------------------|
| get_cuesheet_rootfolder | 获取Cue Sheet根目录    |
| get_child_object        | 搜索并获取指定的父对象正下方的对象 |
| create_object           | 创建对象              |
| create_waveform_region  | 创建波形区域            |

脚本如下所示：

```python
# ----- CueSheet，Cue的创建 -----
# 获取CueSheet文件夹
cuesheet_rootfolder = acproject.get_cuesheet_rootfolder(workunit)["data"]

# 获取CueSheet文件夹“WorkUnit_Tutorial”
cuesheet_folder = acproject.get_child_object(cuesheet_rootfolder, "CueSheetFolder", "WorkUnit_Tutorial")["data"]

# 在CueSheet文件夹中创建CueSheet
cuesheet = acproject.create_object(cuesheet_folder, "CueSheet", "Tutorial")["data"]

# ----- Cue，音轨和波形区域的创建 -----
# 创建Cue
cue = acproject.create_object(cuesheet, "Cue", "gun1_High")["data"]
# 创建音轨
track = acproject.create_object(cue, "Track", "Track")["data"]
# 用指定素材创建波形区域
waveform_region = acproject.create_waveform_region(track, material)["data"]
```

#### CueSheet创建的说明
为了获得创建CueSheet的文件夹，我们使用get_cuesheet_rootfolder函数来获得工作单元的CueSheet根目录。<br/>
然后，使用get_child_object函数来检索CueSheet根文件夹下面的“WorkUnit_Tutorial ”文件夹。<br/>
get_child_object函数需要指定对象信息、需要检索的对象类型和需要检索的对象的名称。

“WorkUnit_Tutorial”是在创建工作单元时自动创建的，并与工作单元的名称相同的文件夹。<br/>
通过在这个文件夹中创建CueSheet，我们可以为每个工作单元分开指定ACB（游戏数据）的输出文件夹。

通过指定目标CueSheet文件夹，CueSheet对象类型（“CueSheet”），提示表名称（“Tutorial”），我们可以使用create_object这个通用的对象创建函数来创建一个CueSheet。<br/>
create_object函数需要指定（1）源对象信息，（2）要创建的对象类型以及（3）要创建的对象的名称。

#### Cue，音轨和波形区域创建的说明
