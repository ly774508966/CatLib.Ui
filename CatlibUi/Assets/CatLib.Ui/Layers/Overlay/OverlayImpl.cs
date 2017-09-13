using System.Linq;
using UnityEngine;

namespace CatLib.Ui
{
    public class OverlayImpl:IOverlay,IServiceProvider
    {
        protected const string LayerName = UiType.Overlay;

        protected const int LayerIndex = 100;

        protected OverlayConfig[] Configs;

        private RectTransform _previousOverlay;

        public OverlayImpl(OverlayConfig[] configs)
        {
            Configs = configs;
        }

        public void Init()
        {
            App.Make<ILayer>().SetLayer(LayerName, LayerIndex);
            App.Make<IBrowser>().RegisterOnPageEnterHandler(_onEnterPage);
        }

        public void Register()
        {
            App.Singleton<IOverlay>((_,__) => this);
        }

        private void _onEnterPage(IPage page)
        {
            var overlayConfig = Configs.FirstOrDefault(x => x.TriggerPageName == page.PageName);
            if (overlayConfig == null)
            {
                _hideOverlay(); // 如果找不到overlay，则啥也不干
            }
            else
            {
                _showOverlay(overlayConfig.UiToShow);

            }
        }

        private void _hideOverlay()
        {
            var layer = Layer.Instance.GetLayer(UiType.Overlay);
            layer.HideAllChildren();
        }

        private void _showOverlay(string overlayName)
        {
            var ui = UiFactory.Instance.GetUi(UiType.Overlay, overlayName);
            var layer = Layer.Instance.GetLayer(UiType.Overlay);
            if (_previousOverlay != null)
            {
                if(_previousOverlay.name==overlayName) return;
                _previousOverlay.HideUi();
            }

            ui.SetParent(layer);
            ui.ShowUi();
            _previousOverlay = ui;
        }
    }
}