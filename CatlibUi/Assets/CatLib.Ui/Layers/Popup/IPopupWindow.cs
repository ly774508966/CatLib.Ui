using System;
using UnityEngine;

namespace CatLib.Ui
{
    public interface IPopupWindow
    {
        string WindowName { get; }

        /// <summary>
        /// 当确认或者取消时，通知回调并关闭窗口
        /// </summary>
        /// <param name="onConfirmHandler"></param>
        void RegisterConfirmHandler(Action<bool> onConfirmHandler);

        /// <summary>
        /// 当窗口中有物体被选择时，通知回调并关闭窗口
        /// </summary>
        /// <param name="onSelectHandler"></param>
        void RegisterSelectHandler(Action<object> onSelectHandler);

        /// <summary>
        /// 该Ui对应的RectTransform
        /// </summary>
        RectTransform RectTransform { get; }
    }
}