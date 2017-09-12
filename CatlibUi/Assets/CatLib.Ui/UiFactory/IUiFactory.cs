using System;
using UnityEngine;

namespace CatLib.Ui
{
    public interface IUiFactory
    {
        /// <summary>
        /// 获取Ui
        /// </summary>
        /// <param name="uiType">类型</param>
        /// <param name="uiName">名称</param>
        /// <returns></returns>
        /// <exception cref="Exception">can't find ui type</exception>
        /// <exception cref="Exception">can't get ui by name</exception>
        RectTransform GetUi(string uiType, string uiName);

        /// <summary>
        /// 添加ui
        /// 如果类型中已经存在同名ui，则忽略
        /// </summary>
        /// <param name="uiType"></param>
        /// <param name="rectTransform"></param>
        void AddUi(string uiType, RectTransform rectTransform);

    }
}