using System;

namespace CatLib.Ui
{
    public interface IMask
    {
        /// <summary>
        /// 展示遮罩
        /// 如果未找到指定名称，则展示默认遮罩
        /// 提供遮罩队列功能
        /// 返回maskId,32位guid,唯一
        /// </summary>
        /// <param name="maskName">遮罩名称</param>
        /// <exception cref="Exception">mask is active</exception>
        string ShowMask(string maskName);


        /// <summary>
        /// 取消指定遮罩
        /// </summary>
        /// <param name="maskId"></param>
        void HideMask(string maskId);


        /// <summary>
        /// 取消所有遮罩
        /// </summary>
        /// <exception cref="Exception">no mask now</exception>
        void HideAllMask();
    }
}