using CatLib;
using CatLib.Ui;
using UnityEngine;

namespace DevelopHelper.Popup
{
    public class PopupDevelopHelper:MonoBehaviour,IServiceProvider
    {
        protected const string ResPath = "DevelopHelper/Popup/";

        private void _addUi(string uiName)
        {
            var ui = Resources.Load(ResPath + uiName);
            var uiTr = (GameObject.Instantiate(ui) as GameObject).AssertGetComponent<RectTransform>();
            uiTr.name = ui.name;
            UiFactory.Instance.AddUi(UiType.Popup,uiTr);
            uiTr.gameObject.SetActive(false);
        }

        public void Init()
        {
            _addUi("inform");
            _addUi("confirm");
            _addUi("warning");
            _addUi("error");
        }

        public void Register()
        {
        }
    }
}