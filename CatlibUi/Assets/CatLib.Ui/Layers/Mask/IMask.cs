using System;

namespace CatLib.Ui
{
    public interface IMask
    {
        /// <summary>
        /// 展示遮罩
        /// 如果未找到指定名称，则展示默认遮罩
        /// 提供遮罩队列功能
        /// </summary>
        /// <param name="maskName">遮罩名称</param>
        /// <param name="maskGuid">指定maskId,如果不传,则系统随机一个</param>
        /// <exception cref="Exception">mask is active</exception>
        Guid ShowMask(string maskName,Guid? maskGuid=null);


        /// <summary>
        /// 取消指定遮罩
        /// </summary>
        /// <param name="maskId"></param>
        void HideMask(Guid maskId);


        /// <summary>
        /// 取消所有遮罩
        /// </summary>
        /// <exception cref="Exception">no mask now</exception>
        void HideAllMask();
    }
}