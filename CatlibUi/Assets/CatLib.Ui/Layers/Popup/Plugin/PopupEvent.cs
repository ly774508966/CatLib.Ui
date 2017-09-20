using System;

namespace CatLib.Ui
{
    public class PopupEvent
    {
        public string WindowName;
        public string MessageName;
        public object MessageBody;
        public bool IsShowMask;
        public Action<bool> OnConfirmHandler;
        public Action<object> OnSelectHandler;

    }
}