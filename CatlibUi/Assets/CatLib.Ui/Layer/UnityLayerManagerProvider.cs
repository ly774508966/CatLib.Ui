using System;
using UnityEngine;

namespace CatLib.Ui
{
    [DisallowMultipleComponent]
    [AddComponentMenu("CatLib/Ui/Layer")]
    public class UnityLayerManagerProvider:MonoBehaviour ,IServiceProvider,IServiceProviderType
    {
        private LayerImpl _baseProvider;
        public RectTransform UIContainer;

        void Awake()
        {
            _baseProvider = new LayerImpl(UIContainer);
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