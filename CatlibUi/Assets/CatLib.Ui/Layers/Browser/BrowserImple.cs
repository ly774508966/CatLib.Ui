using System;
using CatLib.API.Debugger;

namespace CatLib.Ui
{
    public class BrowserImple : IBrowser, IServiceProvider
    {

        protected const int LayerIndex = 0;

        protected const string LayerName = UiType.Browser;

        public IPage CurrentPage { get; private set; }

        public IPage PreviousPage { get; private set; }

        private Action<IPage> _onPageEnterHandler;
        private Action<IPage> _onPageExitHandler;

        public void Init()
        {
            App.Make<ILayer>().SetLayer(LayerName,LayerIndex);
        }

        public void Register()
        {
            App.Singleton<BrowserImple>((_,__)=>this).Alias<IBrowser>();
        }

        public IPage EnterPage(string pageName)
        {
            var page = _getPage(pageName);
            Assert.IsTrue(CanEnterPage(pageName), "can't enter page:" + pageName);
            if (CurrentPage != null)
            {
                PreviousPage = CurrentPage;
                PreviousPage.Exit();
                if(_onPageExitHandler!=null) _onPageExitHandler.Invoke(PreviousPage);
                App.Make<ILogger>().Debug("exit page:"+pageName);
            }

            CurrentPage = page;
            var layer= App.Make<ILayer>().GetLayer(UiType.Browser);
            page.RectTransform.SetParent(layer);
            page.RectTransform.SetFullStretch();
            page.Enter();
            if(_onPageEnterHandler!=null) _onPageEnterHandler.Invoke(page);
            App.Make<ILogger>().Debug("enter page:"+pageName);
            return page;
        }

        public bool CanEnterPage(string pageName)
        {

            if (CurrentPage == null) return true;
            if (CurrentPage.IsLocked) return false;
            return true;
        }

        public void RegisterOnPageEnterHandler(Action<IPage> handler)
        {
            _onPageEnterHandler += handler;
        }

        public void RegisterOnPageExitHandler(Action<IPage> handler)
        {
            _onPageExitHandler += handler;
        }

        private IPage _getPage(string pageName)
        {
            var ui = UiFactory.Instance.GetUi(UiType.Browser, pageName);
            var page = ui.GetComponent<IPage>();
            Assert.IsNotNull(page,"Ui is not IPage"+page);
            return page;
        }

    }
}