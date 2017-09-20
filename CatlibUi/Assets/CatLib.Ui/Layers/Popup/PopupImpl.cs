using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace CatLib.Ui
{
    public class PopupImpl: IPopup,CatLib.IServiceProvider
    {
        protected const string LayerName = UiType.Popup;

        protected const int LayerIndex = 200;

        protected Color MaskColor;

        protected PopupWindow CurrentPopupWindow;

        // 遮住窗口以外的部分
        protected RectTransform Mask; 

        public PopupImpl( Color maskColor)
        {
            MaskColor = maskColor;
        }

        public void Init()
        {
            Layer.Instance.SetLayer(LayerName,LayerIndex);
            _setMask();
        }

        public void Register()
        {
            App.Singleton<PopupImpl>((_,__)=>this).Alias<IPopup>();
        }


        /// <inheritdoc />
       
        public void PopupWindow(string windowName, string messageTitle = null, object messageBody = null, bool isShowMask = true,
            Action<bool> onConfirmHandler = null, Action<object> onSelectionHandler = null)
        {
            _popupWindow(windowName,messageTitle,messageBody,isShowMask,onConfirmHandler,onSelectionHandler);
        }

        public void _popupWindow(string windowName, string messageTitle, object messageBody,bool isShowMask, Action<bool> onConfirmHandler, Action<object> onSelectionHandler = null)
        {
            Assert.IsNull(CurrentPopupWindow, "window existed");
            var window = _showWindow(windowName, messageTitle, messageBody);
            window.RegisterConfirmHandler(x => _onWindowConfirm(x, onConfirmHandler));
            window.RegisterSelectHandler(x => _onWindowSelect(x, onSelectionHandler));
            if(isShowMask) _showMask();
            CurrentPopupWindow = window;
        }


        public void CloseCurrentWindow()
        {
            Assert.IsNotNull(CurrentPopupWindow,"current window is null");
            CurrentPopupWindow.ClearHandler();
            CurrentPopupWindow.RectTransform.HideUi();
            CurrentPopupWindow = null;
            Mask.gameObject.SetActive(false);
        }


        private void _onWindowSelect(object selectResult, Action<object> onSelectHandler)
        {
            CloseCurrentWindow();
            if (onSelectHandler == null)
            {
                Debug.LogWarning(string.Format("select {0},but can't find select handler",selectResult.GetType().Name));
            }
            else
            {
                onSelectHandler.Invoke(selectResult);
            }

        }

        private void _onWindowConfirm(bool confirmResult, Action<bool> onConfirmHandler)
        {
            CloseCurrentWindow();
            if (onConfirmHandler == null)
            {
                Debug.LogWarning(string.Format("select {0},but can't find confirm handler", confirmResult));
            }
            else
            {
                onConfirmHandler.Invoke(confirmResult);
            }
        }



        private PopupWindow _showWindow(string windowName, string messageTitle, object messageBody)
        {
            PopupWindow window = _getWindow(windowName);
            var layer = Layer.Instance.GetLayer(LayerName);
            window.RectTransform.SetParent(layer);
            window.RectTransform.ShowUi();
            window.SetWindowTitle(messageTitle);
            window.SetWindowBody(messageBody);
            return window;
        }

        private PopupWindow _getWindow(string windowName)
        {
            var ui = UiFactory.Instance.GetUi(UiType.Popup, windowName);
            var popupWindow = ui.gameObject.AssertGetComponent<PopupWindow>();
            return popupWindow;
        }

        private void _showMask()
        {
            Mask.SetAsFirstSibling();
            Mask.gameObject.SetActive(true);
        }


        private void _setMask()
        {
            var go = new GameObject("mask");
            var rect = go.AddComponent<RectTransform>();
            var image = go.AddComponent<Image>();
            image.color = MaskColor;
            //image.color = new Color(MaskColor.r,MaskColor.g,MaskColor.b,MaskColor.a);
            var popupLayer = Layer.Instance.GetLayer(LayerName);
            image.transform.SetParent(popupLayer);
            rect.SetFullStretch();
            rect.gameObject.SetActive(false);
            Mask = rect;
        }



    }
}