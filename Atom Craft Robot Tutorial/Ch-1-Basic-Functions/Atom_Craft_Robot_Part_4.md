## Robot教程篇 Part 4：对象名称和参数域名称

### 用于访问对象的对象类型名称
每个对象都有一个对象类型名称来表示其类型。<br/>
脚本会使用这些对象类型名称来创建和检索各种类型的对象。<br/>
例如，在一个叫做create_object的通用对象创建函数中，第一个参数是要创建的父对象，第二个参数是要创建的对象类型，第三个参数是要创建的对象的名称。<br/>
如果我们想在CueSheet上创建一个名为“footstep”的Cue，需要指定“Cue”作为对象类型名称。<br/>
代码如下：

```python
cue = acproject.create_object(cuesheet, "Cue", "footstep")["data"]
```

**cue**：新创建的Cue对象变量<br/>
**cuesheet**：名为“footstep”的Cue的上级CueSheet变量

### 访问一个对象的参数
对象有各种各样的参数，例如名称和注释。<br/>
可以通过指定参数名对一个对象的各种参数进行访问。<br/>
例如，通用函数get_value将对象作为其第一个参数，参数名作为其第二个参数。<br/>
如果我们想获得某个Cue对象的名称，参数名称应指定为 "Name"。<br/>
代码如下：

```python
cue_name = acproject.get_value(cue, "Name")["data"]
```
