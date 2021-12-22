## Robot教程篇 Part 15：使用CSV文件创建CueSheet

在之前的教程中，我们已经把操作数据所需的所有信息直接写在脚本内。<br/>
在为游戏创建声音数据时，我们或许会使用一个电子表格，如Excel来记录需要创建的声音。<br/>
在下面的教程中，我们将学习如何将CSV格式的声音列表导入脚本，以及如何创建和检查数据。<br/>

这次，我们将编写一个脚本，使用以下格式的CSV文件，来进行一些操作：
* 用CSV文件名创建CueSheet
* 注册波形文件
* 新建Cue

| 波形文件名           | Cue名                   | Cue ID | 备注 |
|:---------------------|:------------------------|:-------|:-----|
| Alert.wav            | SE1000_Alert            | 1000   | 警报 |
| Attack_03.wav        | SE1001_Attack           | 1001   | 攻击 |
| ObjectAppearance.wav | SE1002_ObjectAppearance | 1002   | 出现 |
| ~                    | ~                       | ~      | ~    |

![](https://game.criware.jp/wp-content/uploads/2020/11/robot_14_01.png)

本教程将使用在教程<a href="https://game.criware.jp/learn/tutorial/atomcraft/atomcraft_robot_06/" target="_blank">“创建项目和排定波形文件”（日文）</a>中创建的工程。

### 准备脚本文件
在脚本菜单中，选择“脚本列表”。<br/>
在脚本列表窗口中按下 "新建 "按钮，创建一个脚本文件，名称如下：

| 脚本保存地址     | 脚本文件名                                |
|:-----------------|:------------------------------------------|
| tutorials [CRI]  | tutorial07-1_importcsv.py                 |

### 脚本文件说明
双击刚刚创建的脚本，在脚本编辑器中打开它，并写上如下的描述语句：

```
# --Description:[教程]使用CSV创建CueSheet
```

完成脚本描述之后，请导入以下模块。

```
import sys
import os
import csv
import cri.atomcraft.debug as acdebug
import cri.atomcraft.project as acproject
```

为了导入CSV文件，我们从Python标准库中导入csv模块。<br/>
此外，导入用于工程操作的project模块和用于日志输出的debug模块。

### 设置波形文件和CSV文件的路径
首先设置要导入的CSV的路径。<br/>
这次我们将使用工作区“tutorial_data/tutorial_data03”文件夹下的tutorial_data3.csv。

可以使用如下的脚本：

```
# 设置音频数据文件夹和要导入的CSV文件的路径
# 音频数据文件夹路径
data_dir = os.path.dirname(os.path.dirname(__file__)) + '/tutorial_data/tutorial_data03'

# CSV文件路径
csv_path = data_dir + "/tutorial_data3.csv"

# CSV文件路径检查
if os.path.isfile(csv_path) == False:
    acdebug.log("CSVファイルが見つかりません: " + csv_path)
    sys.exit()
```

#### 说明
要加载的CSV文件只包含波形文件的名称，而不是其完整路径。<br/>
我们需要指定完整的路径，以使用register_material函数注册一个波形文件。<br/>
为了之后创建波形文件的完整路径，波形文件的文件夹“waveform_dir”和CSV路径“csv_path”被定义为独立变量。<br/>
为了能够在文件不存在时中止脚本，我们使用os.path.isfile函数来检查文件是否存在。

### 获取素材文件夹并创建CueSheet
导入的CSV信息包含波形文件的名称和要创建的Cue的信息。<br/>
接下来我们将使用以下函数：

| 函数名                  | 说明              |
|:------------------------|:------------------|
| get_workunit            | 获取工作单元          |
| get_material_rootfolder | 获取工作单元的素材根文件夹   |
| get_cuesheet_rootfolder | 获取Cue Sheet根文件夹 |
| create_object           | 创建对象            |

要创建的CueSheet的名称是CSV文件的名称（没有扩展名）。<br/>
脚本如下所示：

```
# 获取Work Unit
workunit = acproject.get_workunit("WorkUnit_Tutorial")["data"]
material_root_folder = acproject.get_material_rootfolder(workunit)["data"]

# CueSheet根目录文件夹
cuesheet_rootfolder = acproject.get_cuesheet_rootfolder(workunit)["data"]

# 创建CueSheet
cuesheet_name = os.path.splitext(os.path.basename(csv_path))[0]
cuesheet = acproject.create_object(cuesheet_rootfolder, "CueSheet", cuesheet_name)["data"]
```

#### 说明
要从CSV路径中提取不带扩展名的文件名，我们可以使用os模块的os.path.splitext和os.path.basename函数。<br/>
os.path.basename 函数可以从一个路径字符串中提取文件名。<br/>
os.path.splitext函数在最末端（最右边）的“.”处分割字符串。<br/>
通过这两个函数，我们可以提取出一个没有扩展名的文件名。

### 打开CSV文件
现在我们介绍CSV文件的读取，素材文件的注册，和Cue的创建。<br/>
要读取一个CSV文件，可以使用csv模块中的csv.reader函数。<br/>
用open函数打开文件，获取文件对象并将其作为参数传递给csv.reader函数。

```
# 打开并读取CSV文件
with open(csv_path) as f:
    reader = csv.reader(f)
```

### 从CSV文件创建数据（注册波形文件、CueSheet和Cue的创建）
以下函数用于逐行读取CSV文件的内容，注册素材，以及新建Cue。

| 函数名            | 说明        |
|:------------------|:------------|
| register_material | 注册波形文件    |
| create_simple_cue | 创建Cue     |
| set_values        | 批量设置对象的参数 |

脚本作成如下：

```
# 打开并读取CSV文件
with open(csv_path) as f:
    reader = csv.reader(f)
    for row in reader:
        wave_file_path = "" # 储存波形文件路径
        row_params = {}     # 储存Cue的参数信息

        # 获取CSV的列
        wave_file_path = data_dir + "/" + row[0]  # 波形文件名
        row_params["Name"] = row[1]               # Cue名
        row_params["CueID"] = row[2]              # Cue ID
        row_params["Comment"] = row[3]            # 备注

        # 注册波形文件并新建素材
        material = acproject.register_material(material_root_folder, wave_file_path)["data"]
        # 生成Cue
        cue = acproject.create_simple_cue(cuesheet, material)["data"]
        # 设定Cue的Cue名，Cue ID和备注
        acproject.set_values(cue, row_params)
acdebug.log("[教程]CueSheet生成结束")
```
