using System;

namespace CatLib.Ui
{
    public class PopupEventListener
    {
        public PopupEventListener()
        {
            App.Listen("popup", (payload) =>
            {
                var popupEvent = _createEvent(payload);
                Popup.Instance.PopupWindow(popupEvent.WindowName,
                    popupEvent.MessageName,
                    popupEvent.MessageBody,
                    popupEvent.IsShowMask,
                    popupEvent.OnConfirmHandler,
                    popupEvent.OnSelectHandler
                    );
                return false; // 终止事件继续传递
            });
        }
        
        private PopupEvent _createEvent(object payload)
        {
            try
            {
                var objArray = payload as object[];
                var popupEvent = new PopupEvent();
                popupEvent.WindowName = (string)objArray[0];
                popupEvent.MessageName =  objArray[1] as string;             // 可以传入null
                popupEvent.MessageBody =  objArray[2];                       // 可以传入null
                popupEvent.IsShowMask =  (bool)objArray[3];                  // 必须为bool类型
                popupEvent.OnConfirmHandler = objArray[4] as Action<bool>;   // 可以传入null
                popupEvent.OnSelectHandler = objArray[5] as Action<object>;  // 可以传入null
                return popupEvent;
            }
            catch
            {
                throw new Exception("can't cast payload from 'popup' event");
            }

        }
        

    }
}