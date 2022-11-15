## 中级篇01：CriAtomSource和CriAtomExPlayer
前面的教程介绍了如何用C#脚本控制CriAtomSource的播放。<br/>
除了CriAtomSource，CRIWARE Unity Plugin还定义了一个名为CriAtomExPlayer的类。<br/>
CriAtomSource和CriAtomExPlayer都可以用来播放CRI声音数据。<br/>
那么，它们之间的关系是什么，应该如何使用它们？

### CriAtomSource vs CriAtomExPlayer
#### CriAtomSource
* 一个继承自MonoBehaviour的类，可以附加到GameObject上。
* 如果放在场景中，可以在编辑器中设置声音播放参数。
* 很容易使用3D定位。
  * 只要在检视器中勾选一个方框，就可以播放3D声音。
  * 与CriAtomListener一起，可以轻松地控制3D声音的聆听方式。

#### CriAtomExPlayer
* 原生播放器类，汇集了各种声音播放功能。
  * CriAtomSource也使用内部持有的CriAtomExPlayer的实例来播放声音。
* 需要通过脚本来控制这个类，但可以进行更高级的参数调整。

### 使用CriAtomSource和CriAtomExPlayer
那么，什么时候应该使用CriAtomSource，什么时候应该使用CriAtomExPlayer？

#### CriAtomSource
* 当你想使用3D定位，或者是实现简单的音频播放时，CriAtomSource更加合适。
* CriAtomExPlayer的参数也可以通过访问CriAtomSource的player属性来设置。