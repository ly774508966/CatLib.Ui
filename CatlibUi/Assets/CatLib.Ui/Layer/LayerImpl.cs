using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace CatLib.Ui
{
    public class LayerImpl:ILayer,IServiceProvider
    {
        protected RectTransform UIContainer;

        protected Dictionary<string, int> LayerDictionary = new Dictionary<string, int>();

        public LayerImpl(RectTransform uiContainer)
        {
            UIContainer = uiContainer;
        }

        public void Init()
        {

        }

        public void Register()
        {
            App.Singleton<LayerImpl>((_,__)=>this).Alias<ILayer>();
        }


        public void SetLayerContainer(RectTransform transform)
        {
            UIContainer = transform;
        }


        /// <inheritdoc />
        public RectTransform GetLayer(string layerName)
        {
            var layer = _getLayerByName(layerName);
            var layerRect= layer.GetComponent<RectTransform>();
            Assert.IsNotNull(layerRect);
            return layerRect;
        }

        /// <inheritdoc />
        public void SetLayer(string layerName, int index)
        {
            var layerTr = UIContainer.transform.Find(layerName);
            if (layerTr == null)
            {
                var go = new GameObject(layerName);
                var rect = go.AddComponent<RectTransform>();
                go.transform.SetParent(UIContainer);
                rect.SetFullStretch();
            }
            LayerDictionary.Add(layerName, index);

            // 把layerName排序后，再把Transform排序
            var orderedLayerNames = LayerDictionary.OrderBy(x => x.Value).Select(x => x.Key);
            foreach (var layer in orderedLayerNames)
            {
                var layerTransform = _getLayerByName(layer);
                layerTransform.SetAsLastSibling();
            }

        }

        private Transform _getLayerByName(string layerName)
        {
            var layer= UIContainer.Find(layerName);
            Assert.IsNotNull(layer,"can't get layer:"+layerName);
            return layer;
        }


    }
}