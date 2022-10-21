## ADX教程篇 Part 25 ：Block播放
### 它能做什么？
我们可以轻松地创建一个状态变化的音效，或者一个音乐随状态变化的演出。

### 它是什么？
这是一种根据游戏情况改变乐曲和声音的演出方法。

时间轴（时间线）被划分为多个区块，声音基本上在区块内持续循环播放，并根据游戏情况的变化，在指定的精确时间内过渡到另一个区块。

### 视频演示
#### 改变音效的示例
(*音效的示例来自于旧版本的工具，与新版本看起来略有不同)

* <a href="https://www.youtube.com/embed/bPQeYh8waf8" target="_blank">８．ブロック再生機能を使ってみよう（１）</a>
* <a href="https://www.youtube.com/embed/jtLFhoQdRFg" target="_blank">９．ブロック再生機能を使ってみよう（２）</a>

#### 变化的乐曲的示例
也可以像在作曲软件中那样，按乐器分开波形数据并将它们并列展开。

<a href="https://www.youtube.com/embed/gFCLlMWVHYM" target="_blank">CRI ADX2 / ブロック再生デモ</a>

视频中是按照Intro→Intro2→A→A→B→A→C→Intro2的顺序迁移的。
    
如果在每个Block的播放过程中指定了要过渡到下一个区块，那么过渡目的地就会闪烁，当现在正在播放的Block到达终点时就会跳到下一个Block。

也可以创建只在过渡时间或只在第一段循环播放的声音（音轨）。