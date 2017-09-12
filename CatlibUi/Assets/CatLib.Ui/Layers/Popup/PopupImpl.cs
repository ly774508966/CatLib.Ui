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
            App.Trigger("catlib.ui.popup.inited");
        }

        public void Register()
        {
            App.Singleton<PopupImpl>((_,__)=>this).Alias<IPopup>();
        }


        /// <inheritdoc />
        public void PopupWindow(string windowName, string messageTitle, Action<bool> onConfirmHandler, Action<object> onSelectionHandler = null)
        {

            _popupWindow(windowName,messageTitle, null, onConfirmHandler,onSelectionHandler);
        }


        /// <inheritdoc />
        public void PopupWindow(string windowName,string messageTitle,object messageBody, Action<bool> onConfirmHandler, Action<object> onSelectionHandler = null)
        {
            _popupWindow(windowName,messageTitle, messageBody, onConfirmHandler,onSelectionHandler);
        }

        public void _popupWindow(string windowName, string messageTitle, object messageBody, Action<bool> onConfirmHandler, Action<object> onSelectionHandler = null)
        {
            Assert.IsNull(CurrentPopupWindow, "window existed");
            Assert.IsNotNull(onConfirmHandler);
            var window = _showWindow(windowName, messageTitle, null);
            window.RegisterConfirmHandler(x => _onWindowConfirm(x, onConfirmHandler));
            window.RegisterSelectHandler(x => _onWindowSelect(x, onSelectionHandler));
            _showMask();
        }


        private void _onWindowSelect(object selectResult, Action<object> onSelectHandler)
        {
            Assert.IsNotNull(onSelectHandler);
            _closeWindow();
            onSelectHandler.Invoke(selectResult);

        }

        private void _onWindowConfirm(bool confirmResult, Action<bool> onConfirmHandler)
        {
            _closeWindow();
            onConfirmHandler.Invoke(confirmResult);
        }

        private void _closeWindow()
        {
            var layer = Layer.Instance.GetLayer(UiType.Popup);
            layer.HideAllChildren();
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