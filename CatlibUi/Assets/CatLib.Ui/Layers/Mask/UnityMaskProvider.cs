using System;
using UnityEngine;

namespace CatLib.Ui
{
    [DisallowMultipleComponent]
    [AddComponentMenu("CatLib/Ui/Mask")]
    public class UnityMaskProvider:MonoBehaviour,IServiceProvider,IServiceProviderType
    {
        private MaskImpl _baseProvider;
        public Color DefaultMaskColor;

        void Awake()
        {
            _baseProvider =new MaskImpl(DefaultMaskColor);
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