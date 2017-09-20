using System;
using UnityEngine;

namespace CatLib.Ui
{
    public abstract class PopupWindow:MonoBehaviour,IPopupWindow
    {

        public string WindowName { get { return this.name; } }

        public abstract void SetWindowTitle(string messageTitle);

        public abstract void SetWindowBody(object messageBody);
  
        private Action<bool> _onConfirmHandler;

        private Action<object> _onSelectHandler;

        private RectTransform _rectTransform;

        ///<inheritdoc />
        public void RegisterConfirmHandler(Action<bool> onConfirmHandler)
        {
            _onConfirmHandler = onConfirmHandler;
        }

        ///<inheritdoc />
        public void RegisterSelectHandler(Action<object> onSelectHandler)
        {
            _onSelectHandler = onSelectHandler;
        }


        ///<inheritdoc />
        public RectTransform RectTransform
        {
            get
            {
                if (_rectTransform == null)
                {
                    _rectTransform = this.GetComponent<RectTransform>();
                }
                Assert.IsNotNull(_rectTransform);
                return _rectTransform;
            }
        }

        protected void ReportSelect(object obj)
        {
            if(_onSelectHandler!=null) _onSelectHandler.Invoke(obj);
        }

        protected void ReportConfirm(bool confirmation)
        {
            if (_onConfirmHandler != null) _onConfirmHandler.Invoke(confirmation);
        }

        public void ClearHandler()
        {
            _onConfirmHandler = null;
            _onSelectHandler = null;
            
        }

        // 弹窗关闭的时候移除事件绑定
        void OnDisable()
        {
            ClearHandler();
        }


    }
}