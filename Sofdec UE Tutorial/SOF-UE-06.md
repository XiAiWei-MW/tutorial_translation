## 入门篇06：播放带字幕的视频
本节将介绍如何播放带有字幕的Sofdec视频。

### 播放带有字幕的视频
可以把视频附在关卡中的一个物体上播放，如下图所示。<br/>
具体步骤如下。

![](images/ue4_sofdec_06_01.png)

#### 1.导入sofdec视频并准备Mana资产
按照[“CRI Sofdec入门篇01”](SOF-UE-01.md)中的说明，将视频导入虚幻引擎中进行字幕制作。

![](images/sofdec_ue_0602.png)

#### 2.将视频附在关卡中的一个平面上，并将其播放出来
创建一个StaticMesh来容纳ManaTexture。这次我们使用了一个平面。<br/>
将其设置在可见位置上，比例为16:9。
* 位置: (100.0, 0.0, 110.0)
* 旋转: (90.0, 0.0, 90.0)
* 放大/缩小: (1.777, 1.0, 1.0)

![](images/sofdec_ue_0603.png)

在名为“Plane”的Actor的详细面板上点击“添加蓝图/脚本”。

![](images/sofdec_ue_0604.png)

打开创建的蓝图，在“StaticMeshComponent”详细面板中把视频材料设置为“Materials > Element 0”。

![](images/sofdec_ue_0605.png)

从“添加组件”的下拉列表中，选择“Mana Component”。

![](images/sofdec_ue_0606.png)

在Mana Component的详细面板中将视频纹理设置为“Rendering > Movie”。

![](images/sofdec_ue_0607.png)

创建一个蓝图图表，在游戏开始时开始播放，如下图所示。<br/>
通过上述操作，视频就在平面上播放了。

![](images/sofdec_ue_0608.png)

#### 3.在视频播放中添加字幕
从“添加组件”下拉列表中，选择“TextRender”。

![](images/sofdec_ue_0609.png)

将TextRender放在视口中，使其在平面上可见。

![](images/sofdec_ue_0610.png)

在Component列表中选择Mana。

![](images/sofdec_ue_0611.png)