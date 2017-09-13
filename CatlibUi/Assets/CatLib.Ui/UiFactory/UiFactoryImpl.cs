using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using ILogger = CatLib.API.Debugger.ILogger;

namespace CatLib.Ui
{
    public class UiFactoryImpl:IUiFactory,IServiceProvider
    {
        // 以UiType为键，Ui列表为值的字典
        private readonly Dictionary<string, List<RectTransform>> _uiDictionary = new Dictionary<string, List<RectTransform>>();

        public void Init()
        {
        }

        public void Register()
        {
            App.Singleton<IUiFactory>((_,__) => this);
        }

        /// <inheritdoc />
        public RectTransform GetUi(string uiType, string uiName)
        {
            List<RectTransform> uiList;
            _uiDictionary.TryGetValue(uiType, out uiList);
            Assert.IsNotNull(uiList,"can't find ui type:"+uiType);
            var ui= uiList.SingleOrDefault(x => x.name == uiName);
            Assert.IsNotNull(ui,"can't get ui by name:"+uiName);
            return ui;
        }

        /// <inheritdoc />
        public void AddUi(string uiType, RectTransform rectTransform)
        {
            List<RectTransform> uiList;
            _uiDictionary.TryGetValue(uiType, out uiList);
            if (uiList == null)
            {
                uiList = new List<RectTransform>();
                _uiDictionary[uiType] = uiList;
                uiList.Add(rectTransform);
            }
            else
            {
                if (uiList.Any(x => x.name == rectTransform.name))
                {
                    App.Make<ILogger>().Warning("add ui: ui exist and ignored "+rectTransform.name);
                    return;
                }
                uiList.Add(rectTransform);
            }
        }

        /// <inheritdoc cref="AddUi(string,UnityEngine.RectTransform)"/>
        public void AddUi(string uiType, RectTransform[] rectTransforms)
        {
            if (rectTransforms == null || rectTransforms.Length==0)
            {
                List<RectTransform> uiList;
                _uiDictionary.TryGetValue(uiType, out uiList);
                if (uiList == null)
                {
                    uiList = new List<RectTransform>();
                    _uiDictionary[uiType] = uiList;
                };
            }
            foreach (var rectTransform in rectTransforms)
            {
                AddUi(uiType,rectTransform);
            }
        }

    }
}