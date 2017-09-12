using System;

namespace CatLib.Ui
{
    public interface IMask
    {
        /// <summary>
        /// 展示遮罩
        /// 如果未找到指定名称，则展示默认遮罩
        /// </summary>
        /// <param name="maskName">遮罩名称</param>
        /// <exception cref="Exception">mask is active</exception>
        void ShowMask(string maskName);

        /// <summary>
        /// 取消当前遮罩
        /// </summary>
        /// <exception cref="Exception">no mask now</exception>
        void HideMask();
    }
}