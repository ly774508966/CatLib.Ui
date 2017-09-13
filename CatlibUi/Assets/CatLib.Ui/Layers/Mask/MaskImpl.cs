using System;
using UnityEngine;
using UnityEngine.UI;

namespace CatLib.Ui
{
    public class MaskImpl:IMask,IServiceProvider
    {
        protected const string LayerName = UiType.Mask;

        protected const int LayerIndex = 300;

        protected RectTransform DefaultMask;

        protected Color DefaultMaskColor;

        protected RectTransform CurrentMask;

        public MaskImpl(Color defaultMaskColor)
        {
            DefaultMaskColor = defaultMaskColor;
        }


        public void Init()
        {
            App.Make<ILayer>().SetLayer(LayerName, LayerIndex);
            DefaultMask = _getDefaultMask(DefaultMaskColor);
        }

        public void Register()
        {
            App.Singleton<IMask>((_, __) => this);
        }

        public void ShowMask(string maskName)
        {
            if (CurrentMask != null)
            {
                if(CurrentMask.name==maskName) return;
                CurrentMask.HideUi();
            }
            var layer = Layer.Instance.GetLayer(LayerName);
            RectTransform mask;
            try
            {
                mask = UiFactory.Instance.GetUi(LayerName, maskName);
            }
            catch (Exception)
            {
                mask = DefaultMask;
            }
            mask.SetParent(layer);
            mask.SetFullStretch();
            mask.gameObject.SetActive(true);
            CurrentMask = mask;
        }

        public void HideMask()
        {
            CurrentMask.HideUi();
        }

        private RectTransform _getDefaultMask(Color defaultMaskColor)
        {
            var go = new GameObject("default mask");
            var layer = Layer.Instance.GetLayer(LayerName);
            var rect =go.AddComponent<RectTransform>();
            var image =go.AddComponent<Image>();
            image.color = defaultMaskColor;
            rect.SetParent(layer);
            rect.SetFullStretch();
            rect.gameObject.SetActive(false);
            return rect;
        }

    }
}