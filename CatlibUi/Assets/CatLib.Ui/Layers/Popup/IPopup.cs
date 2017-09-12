using System;

namespace CatLib.Ui
{
    public interface IPopup
    {
        /// <summary>
        /// 弹出一个窗口
        /// </summary>
        /// <param name="windowName"></param>
        /// <param name="messageBody"></param>
        /// <param name="onConfirmHandler"></param>
        /// <param name="onSelectionHandler"></param>
        /// <param name="messageTitle"></param>
        /// <exception cref="Exception">window existed</exception>>
        /// <exception cref="Exception">can't get window</exception>>
        void PopupWindow(string windowName, string messageTitle, object messageBody, Action<bool> onConfirmHandler,Action<object> onSelectionHandler=null);

        /// <summary>
        /// 弹出一个窗口
        /// </summary>
        /// <param name="windowName"></param>
        /// <param name="messageBody"></param>
        /// <param name="onConfirmHandler"></param>
        /// <param name="onSelectionHandler"></param>
        /// <param name="messageTitle"></param>
        /// <exception cref="Exception">window existed</exception>>
        /// <exception cref="Exception">can't get window</exception>>
        void PopupWindow(string windowName, string messageTitle, Action<bool> onConfirmHandler,Action<object> onSelectionHandler=null);
 

    }
}