using System;

namespace CatLib.Ui
{
    public interface IPopup
    {
        /// <summary>
        /// 弹出一个窗口
        /// </summary>
        /// <param name="windowName">窗口名称,对应Ui名称</param>
        /// <param name="messageTitle">窗口标题</param>
        /// <param name="messageBody">窗口内容</param>
        /// <param name="isShowMask">是否同时显示遮罩</param>
        /// <param name="onConfirmHandler">确认回调</param>
        /// <param name="onSelectionHandler">选择回调</param>
        /// <exception cref="Exception">window existed</exception>>
        /// <exception cref="Exception">can't get window</exception>>
        void PopupWindow(string windowName, string messageTitle=null, object messageBody=null,bool isShowMask=true, Action<bool> onConfirmHandler = null,Action<object> onSelectionHandler=null);

        /// <summary>
        /// 关闭当前弹窗
        /// </summary>
        /// <exception cref="Exception">current window is null</exception>>
        void CloseCurrentWindow();

    }
}