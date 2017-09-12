using System;
using UnityEngine;

namespace CatLib.Ui
{
    [DisallowMultipleComponent]
    [AddComponentMenu("CatLib/Ui/Overlay")]
    public class UnityOverlayProvider:MonoBehaviour,IServiceProvider,IServiceProviderType
    {
        private OverlayImpl _baseProvider;
        public OverlayConfig[] OverlayConfig;

        void Awake()
        {
            _baseProvider = new OverlayImpl(OverlayConfig);
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