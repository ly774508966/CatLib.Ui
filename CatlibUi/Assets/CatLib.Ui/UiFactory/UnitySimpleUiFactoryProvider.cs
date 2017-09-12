using System;
using System.Collections.Generic;
using UnityEngine;

namespace CatLib.Ui
{
    /// <summary>
    /// 简易Ui工厂
    /// 直接拖拽场景中的Ui到对应层级即可
    /// </summary>
    [AddComponentMenu("CatLib/Ui/SimpleUiFactory")]
    public class UnitySimpleUiFactoryProvider:MonoBehaviour,IServiceProvider,IServiceProviderType
    {
        private UiFactoryImpl _baseProvider;

        public RectTransform[] BackGoundUiList;
        public RectTransform[] BrowserUiList;
        public RectTransform[] OverlayUiList;
        public RectTransform[] PopupUiList;
        public RectTransform[] MaskUiList;

        void Awake()
        {
            _baseProvider = new UiFactoryImpl();
        }

        [Priority(10)]
        public void Init()
        {
            var layer = App.Make<ILayer>();
            Assert.IsNotNull(layer,"layer is null");
            _baseProvider.AddUi(UiType.Background,BackGoundUiList);
            _baseProvider.AddUi(UiType.Browser,BrowserUiList);
            _baseProvider.AddUi(UiType.Overlay,OverlayUiList);
            _baseProvider.AddUi(UiType.Popup,PopupUiList);
            _baseProvider.AddUi(UiType.Mask,MaskUiList);
            _baseProvider.Init();
        }

        public void Register()
        {
            _baseProvider.Register();
        }

        public Type BaseType { get { return _baseProvider.GetType(); } }

    }
}