using System;
using UnityEngine;

namespace CatLib.Ui
{
    [DisallowMultipleComponent]
    [AddComponentMenu("CatLib/Ui/Background")]
    public class UnityBackgroundProvider:MonoBehaviour,IServiceProvider,IServiceProviderType
    {
        private BackgroundImpl _baseProvider;
        public BackgroundConfig[] BackgroundConfigs;

        void Awake()
        {
            _baseProvider = new BackgroundImpl(BackgroundConfigs);
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