using CatLib.API.Debugger;

namespace CatLib.Ui
{
    public class BrowserImple : IBrowser, IServiceProvider
    {

        protected const int LayerIndex = 0;

        protected const string LayerName = UiType.Browser;

        public IPage CurrentPage { get; private set; }

        public IPage PreviousPage { get; private set; }

        public void Init()
        {
            App.Make<ILayer>().SetLayer(LayerName,LayerIndex);
            App.Trigger("catlib.ui.browser.inited");
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
                App.Trigger("catlib.ui.browser.exit", page);
                App.Make<ILogger>().Debug("exit page:"+pageName);
            }

            CurrentPage = page;
            var layer= App.Make<ILayer>().GetLayer(UiType.Browser);
            page.RectTransform.SetParent(layer);
            page.RectTransform.SetFullStretch();
            page.Enter();
            App.Trigger("catlib.ui.browser.enter", page);
            App.Make<ILogger>().Debug("enter page:"+pageName);
            return page;
        }

        public bool CanEnterPage(string pageName)
        {

            if (CurrentPage == null) return true;
            if (CurrentPage.IsLocked) return false;
            return true;
        }

        private IPage _getPage(string pageName)
        {
            var ui = UiFactory.Instance.GetUi(UiType.Browser, pageName);
            var page = ui.GetComponent<IPage>();
            Assert.IsNotNull(page,"page not found:"+page);
            return page;
        }



    }
}