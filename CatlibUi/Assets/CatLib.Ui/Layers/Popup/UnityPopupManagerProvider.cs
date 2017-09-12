using System;
using UnityEngine;

namespace CatLib.Ui
{
    [DisallowMultipleComponent]
    [AddComponentMenu("CatLib/Ui/Popup")]
    public class UnityPopupManagerProvider:MonoBehaviour,IServiceProvider,IServiceProviderType
    {
        private PopupImpl _baseProvider;
        public Color MaskColor;

        void Awake()
        {
            _baseProvider = new PopupImpl(MaskColor);
        }

        public void Init()
        {
            _baseProvider.Init();
        }

        public void Register()
        {
            _baseProvider.Register();
        }

        public Type BaseType { get { return _baseProvider.GetType(); } }
    }
}