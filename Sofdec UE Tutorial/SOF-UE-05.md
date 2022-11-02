## 入门篇05：全屏播放&在UI中播放视频

本节将告诉你如何在全屏和UI下播放Sofdec视频。

### 以全屏播放视频
使用UMG（Unreal Motion Graphics），一个覆盖整个屏幕的图像可以被添加到UI层。
具体步骤如下。

#### 1.导入一个Sofdec视频并准备Mana资产
按照[“CRI Sofdec入门篇01”](SOF-UE-01.md)中的步骤将一个需要全屏播放的视频导入虚幻引擎。

![](images/sofdec_ue_0501.png)

在编辑材料中，选择材料的“Result Node”。<br/>
在细节面板中，将“Material Domain”改为“User Interface”。<br/>
这将使“视频材料”在UMG组件中可以使用。

![](images/sofdec_ue_0502.png)

注意：ManaColourSpaceConverter的输出必须重新链接到结果节点的Final color（如果使用Alpha视频的话，也需要链接不透明度）。

#### 2.在场景中添加一个新的UserWidget蓝图
在内容浏览器中创建一个新的蓝图类。

![](images/sofdec_ue_0503.png)

展开“所有类”并选择“Visual/Widget/UserWidget”。

![](images/sofdec_ue_0504.png)

将创建的资产命名为“FullScreenWidget”。

![](images/sofdec_ue_0505.png)

#### 3.编辑组件
在“调色板”面板中找到“Image”组件，并将其拖放到设计器中。

![](images/sofdec_ue_0506.png)

在设计器中选择Image组件，在详细面板中展开“Appearance/Brush”，并在“Image”栏中设置视频素材。

![](images/sofdec_ue_0507.png)

#### 4.编辑关卡蓝图
打开关卡蓝图。（“蓝图”按钮->“打开关卡蓝图...”）。<br/>
添加如下所示的蓝图代码。

![](images/sofdec_ue_0508.png)

可以从这里复制蓝图代码：<a href="https://blueprintue.com/blueprint/8zvvholj/" target="_blank">https://blueprintue.com/blueprint/8zvvholj/</a>

创建两个变量。

| 对象类型                          | 描述                           |
|-----------------------------------|--------------------------------|
| Mana（参考Mana Player对象）       | 拥有用于播放视频的Mana播放器。 |
| Widget（参考FullScreenWidget对象）| 拥有显示视频的组件。           |

![](images/sofdec_ue_0509.png)

在“Mana Player”节点的详细面板中配置“Mana”。

![](images/sofdec_ue_0510.png)

在“Set Texture”节点中设置“In Mana Texture”。<br/>
在“Open Movie Source”节点中设置“In Mana Movie”。

![](images/sofdec_ue_0511.png)

当视频播放结束时，“OnEndReached”事件被触发，此时FullScreenWidget被隐藏。

![](images/sofdec_ue_0512.png)

该蓝图还增加了以下新的变量：
* Is Playing（Boolean）：保持播放状态。

### 在UI中播放视频
可以按照上述“全屏播放视频”的程序来创建一个用户界面。<br/>
之后可以在UMG中添加必要的UI对象并链接动作。<br/>
下面是一个带有播放和停止按钮的UI的例子。

#### 如何在UI中播放视频
在UI上添加一个按钮。

**组件设计器**<br/>
在蓝图中，为“Mana Player”引用添加一个变量，并为点击按钮时的事件添加代码。
“Stop”按钮调用Mana Pause，“Play”按钮调用Mana ReWind。
在内容浏览器中，选择“添加”->“用户界面”->“组件蓝图”。

![](images/sofdec_ue_0513.png)

命名为“UiPlayerWidget”。

![](images/sofdec_ue_0514.png)

将“面板”->“Canvas Panel”拖放到画面中。

![](images/sofdec_ue_0515.png)

然后是“常用”->“Image”。

![](images/sofdec_ue_0516.png)

同样地，拖放“常用”->“Button”到画面中。<br/>
这次我们将有两个按钮，“Stop”和“Play”，控制视频的播放和停止。

![](images/sofdec_ue_0517.png)

接下来，给按钮添加文本。
将“常用”->“文本”拖到放置的按钮上。

![](images/sofdec_ue_0518.png)

接下来，将层级中的“Button”重新命名。名称可以是“Stop”或“Play”，只要你知道它是哪个按钮。<br/>
(在这种情况下，我们使用“Button_Stop”和“Button_Play”）。

![](images/sofdec_ue_0519.png)

设置控制模式，使用户能够控制UI。<br/>
在当前打开的“组件设计器”的右上角选择“图表”。

![](images/sofdec_ue_0520.png)

**关卡蓝图**<br/>
可以从这里复制蓝图代码：
<a href="https://blueprintue.com/blueprint/j_bfoawd/" target="_blank">https://blueprintue.com/blueprint/j_bfoawd/</a>

![](images/sofdec_ue_0521.png)

### 虚幻引擎手册参考
关于UMG和actor组件的更多信息，请参考虚幻引擎文档：
* UMG：<a href="https://docs.unrealengine.com/5.0/zh-CN/umg-ui-designer-for-unreal-engine/" target="_blank">https://docs.unrealengine.com/5.0/zh-CN/umg-ui-designer-for-unreal-engine/</a>
* Actor Component：<a href="https://docs.unrealengine.com/5.0/zh-CN/components-in-unreal-engine/" target="_blank">https://docs.unrealengine.com/5.0/zh-CN/components-in-unreal-engine/</a>
