using UnityEngine;

namespace CatLib.Ui
{
    public interface IPage:IUi
    {
        /// <summary>
        /// 是否被锁定，锁定后无法切换其他Module
        /// </summary>
        bool IsLocked { get; }

        /// <summary>
        /// 页面名称
        /// </summary>
        string PageName { get; }

    }
}