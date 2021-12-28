## Robot教程篇 Part 1：Python3环境配置

本教程将使用Python3作为脚本语言。已经将Python环境在AtomCraft中配置好的读者可以跳过这一节。

### 安装Python3
CRI Atom Robot兼容Python3.7（64bit）和Python 3.8（64bit）。<br/>
操作测试使用CPython 3.7.8（64bit）和CPython 3.8.6（64bit）。<br/>
Python3可以从Python官网获得。

<a href="https://www.python.org/" target="_blank">https://www.python.org/</a><br/>
Mac用户可从Homebrew等包管理器获得。

### 本地运行的环境配置
接下来是本地的环境配置。
远程运行脚本的话可以跳到[“远程运行的环境配置”](#远程运行的环境配置)部分。

> 关于本地和远程运行 <br/>
本地运行是指从Atom Craft内部，例如菜单中，运行Atom Craft Robot。<br/>
远程运行是指从外部系统，如DAW或游戏引擎，运行Atom Craft Robot。

#### OS通用设定
从“脚本”菜单中打开“脚本设置”对话框。<br/>
接着在“插件”选项卡中指定插件类型（Python版本）。

![](https://game.criware.jp/wp-content/uploads/2020/11/robot_01_01.png)

请按照本地Python的版本选择正确的插件。<br/>
已安装的Python的版本可以用以下命令行语句查看。

Windows系统在CMD中输入：

```shell
python --version
```

Mac在Terminal中输入：

```shell
python3 --version
```

#### Windows的具体配置
在环境变量PYTHONHOME和PATH中加入Python（64bit）的安装路径。

例如：<br/>
> C:\Users\(user name)\AppData\Local\Programs\Python\Python37\ <br/>
C:\Users\(user name)\Anaconda3\

可以用以下命令行语句确认环境变量：
```shell
where python
```

如果无法设置环境变量，请尝试登出和重新登入用户。

#### Mac的具体配置
使用Homebrew等方式安装了Python3的情况下，则需要通过Terminal更改AtomCraft中记录的，本地运行时所需要的Python3的路径。

##### <u>（1）在“脚本”菜单中的“脚本设定”里选择“MAC PYTHON库”</u>
“CRI AtomCraft中正在使用的Python库”区域会自动填充。

![](https://game.criware.jp/wp-content/uploads/2020/11/robot_01_02.png)

##### <u>（2）变更后的Python库路径</u>
使用Homebrew安装Python3的情况（Ver.3.7.8）
> /usr/local/Cellar/python/3.7.8/Frameworks/Python.framework/Versions/3.7/Python

使用Anaconda的情况
> /Users/(user name)/anaconda3/lib/libpython3.7m.dylib

##### <u>（3）按下“在Terminal中运行”并更新Python插件信息</u>
将对话框中的命令行语句在Terminal中运行，CRI Atom Craft插件的信息将会更新。

##### <u>不使用CRI AtomCraft，而是直接在Terminal中变更路径的话，请运行下列语句：</u>
使用Homebrew安装Python3的情况（Ver.3.7.8）

```shell
sudo install_name_tool -change /Library/Frameworks/Python.framework/Versions/3.7/Python /usr/local/Cellar/python/3.7.8/Frameworks/Python.framework/Versions/3.7/Python /Applications/CRIWARE/CRI\ ADX2/Tools\ Ver.3.44/CriAtomCraft.app/Contents/PlugIns/libCriAcApiPython3.dylib
```

使用Anaconda的情况
```shell
sudo install_name_tool -change /Library/Frameworks/Python.framework/Versions/3.7/Python /Users/(user name)/anaconda3/lib/libpython3.7m.dylib /Applications/CRIWARE/CRI\ ADX2/Tools\ Ver.3.44/CriAtomCraft.app/Contents/PlugIns/libCriAcApiPython3.dylib
```

#### 添加用户脚本检索路径
在创建新的脚本路径之前，我们需要指定脚本文件的检索文件夹。<br/>
在“脚本设置”对话框的“用户脚本”选项卡上，点击“添加”按钮，新增文件夹路径。<br/>
在这里设定好的文件夹路径内的文件，之后会在脚本列表和脚本菜单中显示出来，并且可以在CRI AtomCraft中运行。

![](https://game.criware.jp/wp-content/uploads/2020/11/robot_01_03.png)

### 远程运行的环境配置

#### 检查远程运行的插件包
CRI AtomCraft中包含一个用于远程执行的插件包。<br/>
在与CriAtomCraft.exe（或Mac上的CriAtomCraft.app）同文件夹内有一个robot文件夹。<br/>
里面的remote/Python文件夹内有一个cri文件夹，它是Python插件的根文件夹。<br/>
文件结构如下：
```
CriAtomCraft.exe (CriAtomCraft.app)
robot文件夹
  - remote文件夹
    - Python文件夹：Python版插件的根文件夹
      - cri文件夹
        - atomcraft文件夹
          - build.py：插件脚本
          - common.py：（同上）
          - debug.py：（同上）
          - project.py：（同上）
          - preview.py：（同上）
          - error.py：（同上）
```

#### 将Python版插件的根文件夹添加到PYTHONPATH中

##### <u>Windows系统</u>
如果CRI Atom Craft（CRI ADX2 SDK）的路径在C盘下，CriAtomCraft.exe的路径应该为：
```shell
C:\cri\tools\ADX2\ver.3\CriAtomCraft.exe
```

此时，应将以下文件夹路径追加到PYTHONPATH中：
```shell
C:\cri\tools\ADX2\ver.3\robot\remote\Python
```

##### <u>Mac系统</u>
如果工具版本为Ver.3.44，CriAtomCraft.exe的路径应该为：
```shell
/Applications/CRIWARE/CRI ADX2/Tools Ver.3.44/CriAtomCraft.app
```

此时，应将以下文件夹路径追加到PYTHONPATH中：
```shell
/Applications/CRIWARE/CRI ADX2/Tools Ver.3.44/robot/remote/Python
```
