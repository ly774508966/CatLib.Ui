# CatLib.Ui
CatLib.Ui是建立在CatLib框架基础上的简易Ui框架。

依赖：
* CatLib V1.0
* Unity > 5.3
* UGui 

## 定义
* Ui元素： 挂载了RectTransform的GameObject物体
* 层级： 包含Ui元素的容器

## Ui元素
Ui元素由UiFactory产出，目前版本提供了简单的实现 `SimpleUiFactory`,只需要将场景中的Ui元素拖拽到工厂对应的层级，就可以使用。

## 层级
本框架定义了5个页面层级（您也可以自己添加）
1. 背景: Background
2. 页面: Browser
3. 浮层: Overlay
4. 提示: Popup
5. 遮罩: Mask

级别越大的层级越靠近使用者。

### 背景
背景层监听页面层的页面变化事件，自动更改背景。
**您无法主动更改背景Ui元素**

### 页面
页面层提供跳转到指定页面的方法，您可以使用
`Browser.Instance.EnterPage(string pageName)`

**页面锁定**
您可以主动为页面上锁，防止其他路由更改页面。

### 浮层
类似背景，浮层由页面变更事件触发，您无法主动更改。

### 提示
提示窗口创建后，用户对于窗口内的操作将触发回调，接口为
`void PopupWindow(string windowName, string messageTitle, object messageBody, Action<bool> onConfirmHandler,Action<object> onSelectionHandler=null);`

### 遮罩
对于用户IO操作，需要进行遮罩，当操作完成后，取消。接口如下：

`void ShowMask(string maskName);`

`void HideMask();`

## 项目结构
- CatLib: CatLib核心
- CatLib.Ui: Ui核心
- DevelopHelper: 开发时的帮助类，不应包含在正式项目中
- Example: 演示场景

### CatLib.Ui
- Helper: 帮助类
- Layer: 层级管理
- Layers: 上述5个层级的实现类
- UiFactory: Ui元素工厂类



