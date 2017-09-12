using System;

namespace CatLib.Ui
{
    [Serializable]
    public class OverlayConfig
    {
        /// <summary>
        /// 监听的Page名称
        /// </summary>
        public string TriggerPageName;
        
        /// <summary>
        /// 需要展示的背景名称
        /// </summary>
        public string UiToShow;
    }
}