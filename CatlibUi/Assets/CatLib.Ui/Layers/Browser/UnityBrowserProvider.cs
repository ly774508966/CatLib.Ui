using System;
using UnityEngine;

namespace CatLib.Ui
{
    [DisallowMultipleComponent]
    [AddComponentMenu("CatLib/Ui/Browser")]
    public class UnityBrowserProvider:MonoBehaviour,IServiceProvider,IServiceProviderType
    {
        private BrowserImple _baseProvider;

        void Awake()
        {
            _baseProvider =new BrowserImple();
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