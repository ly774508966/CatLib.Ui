using System.Linq;
using UnityEngine;

namespace CatLib.Ui
{
    [DisallowMultipleComponent]
    [AddComponentMenu("CatLib/Ui/Background")]
    public class BackgroundImpl : IServiceProvider
    {
        protected const string LayerName = UiType.Background;

        protected const int LayerIndex = -100;

        protected BackgroundConfig[] Configs;

        protected RectTransform CurrentBackground;

        public BackgroundImpl(BackgroundConfig[] configs)
        {
            Configs = configs;
        }

        public void Init()
        {
            App.Make<ILayer>().SetLayer(LayerName,LayerIndex);
            App.Make<IBrowser>().RegisterOnPageEnterHandler(_onEnterPage);
        }

        public void Register()
        {
            App.Singleton<IBackground>((_, __) => this);
        }

        private void _onEnterPage(IPage page)
        {
            var bgConfig = Configs.FirstOrDefault(x => x.TriggerPageName == page.PageName);
            if (bgConfig == null)
            {
                _hideBackground(); // 如果找不到bg，则啥也不干
            }
            else
            {
                _showBackground(bgConfig.UiToShow);

            }
        }

        private void _hideBackground()
        {
            var layer = Layer.Instance.GetLayer(UiType.Background);
            layer.HideAllChildren();
            CurrentBackground = null;
        }

        private void _showBackground(string bgName)
        {
            if (CurrentBackground != null)
            {
                if(CurrentBackground.name==bgName) return;
                CurrentBackground.HideUi();
            }
            var ui = UiFactory.Instance.GetUi(UiType.Background, bgName);
            var layer = Layer.Instance.GetLayer(UiType.Background);
            ui.SetParent(layer);
            ui.ShowUi();
            CurrentBackground = ui;
        }
    }
}