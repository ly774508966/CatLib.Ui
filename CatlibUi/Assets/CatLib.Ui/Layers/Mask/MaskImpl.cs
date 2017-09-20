using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using ILogger = CatLib.API.Debugger.ILogger;

namespace CatLib.Ui
{
    public class MaskImpl:IMask,IServiceProvider
    {
        [Inject]
        public ILogger Logger { get; set; }

        class GuidMask
        {
            public string Guid;
            public RectTransform Mask;
            public bool MarkAsDelete;
        }

        protected const string LayerName = UiType.Mask;

        protected const int LayerIndex = 300;

        protected RectTransform DefaultMask;

        protected Color DefaultMaskColor;


        List<GuidMask> _guidMaskList = new List<GuidMask>();

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

        public string ShowMask(string maskName)
        {

            RectTransform mask;
            try
            {
                mask = UiFactory.Instance.GetUi(LayerName, maskName);
            }
            catch (Exception)
            {
                mask = DefaultMask;
            }

            var guid =  Guid.NewGuid().ToString();
            
            var guidMask = new GuidMask{Guid =guid,Mask = mask};
            _guidMaskList.Add(guidMask) ;
            _refreshMask();
            return guid;

        }

        /// <summary>
        /// 判断需要展示哪个Mask
        /// 1. 优先展示相同的mask
        /// </summary>
        private void _refreshMask()
        {
            if(_guidMaskList.Count==0) return;
            var deleteMask = _guidMaskList.SingleOrDefault(x => x.MarkAsDelete);
            if (deleteMask==null)
            {
                var guidMak = _guidMaskList.First();
                var mask = guidMak.Mask;
                var layer = Layer.Instance.GetLayer(LayerName);
                mask.SetParent(layer);
                mask.SetFullStretch();
                mask.gameObject.SetActive(true);
                Logger.Debug(string.Format("show mask {0}",guidMak.Guid));
            }
            else
            {
                _guidMaskList.Remove(deleteMask);
                Logger.Debug(string.Format("remove mask {0}",deleteMask.Guid));
                var transform = deleteMask.Mask;
                if (_guidMaskList.All(x => x.Mask != transform))
                {
                    deleteMask.Mask.HideUi();
                    _refreshMask(); // 注意,此处递归
                }
            }
            Logger.Debug(string.Format("{0} masks left",_guidMaskList.Count));
        }

        public void HideMask(string maskId)
        {

            var guidMask = _guidMaskList.SingleOrDefault(x => x.Guid == maskId);
            Assert.IsNotNull(guidMask,"can't get mask:"+maskId);
            guidMask.MarkAsDelete = true;
            _refreshMask();
        }

       

        public void HideAllMask()
        {
            foreach (var mask in _guidMaskList)
            {
                mask.MarkAsDelete = true;
            }
            _refreshMask();
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