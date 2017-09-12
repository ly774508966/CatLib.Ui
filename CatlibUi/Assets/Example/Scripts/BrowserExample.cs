using CatLib;
using CatLib.Ui;
using UnityEngine;
using UnityEngine.UI;

namespace YourNameSpace.Scripts
{
    public class BrowserExample:MonoBehaviour
    {
        public Button Button1;
        public Button Button2;
        public Button ButtonError;

        void Awake()
        {
            Button1.onClick.AddListener(()=>_showPage("page1"));
            Button2.onClick.AddListener(()=>_showPage("page2"));
            ButtonError.onClick.AddListener(()=>_showPage("pagewrong"));
        }

        private void _showPage(string page)
        {
            Browser.Instance.EnterPage(page);
        }
    }
}