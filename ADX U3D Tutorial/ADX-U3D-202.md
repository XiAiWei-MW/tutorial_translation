## 初级篇02：停止播放声音的方法
这里还有一些关于如何停止声音的说明。

### 停止CriAtomSource
正如上一篇所解释的，简单地调用CriAtomSource.Stop()就可以停止声音的播放。

如果CriAtomSource.Play()被连续执行，会同时播放多个声音。<br/>
如果在有多个声音在播放时调用CriAtomSource.Stop()，所有在该CriAtomSource中播放的声音将停止。

#### Tips
一个CriAtomSource的播放状态可以用CriAtomSource.status来检查。

### 在播放过程中停止个别声音
如何控制单个声音的播放，例如，“保持背景音乐的播放，但只停止角色的对话”？<br/>
可以为每个声音使用单独的CriAtomSource，但这里有一个更简单、更有效的方法。

```csharp
CriAtomSource atomSrc = gameObject.GetComponent<CriAtomSource>();

/* 连续播放3个Cue */
CriAtomExPlayback playback1 = atomSrc.Play("Cue1");
CriAtomExPlayback playback2 = atomSrc.Play("Cue2");
CriAtomExPlayback playback3 = atomSrc.Play("Cue3");

/* 只停止播放Cue2 */
playback2.Stop();
```

#### Tips
各个音频的播放状态可以在CriAtomExPlayback.status中查看。
