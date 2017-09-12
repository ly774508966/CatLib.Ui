using CatLib.Ui;
using UnityEngine;
using UnityEngine.UI;

namespace YourNameSpace.Scripts
{
    public class PopupExample:MonoBehaviour
    {
        public Button ButtonInform;
        public Button ButtonConfirm;
        public Button ButtonWarning;
        public Button ButtonError;

        void Awake()
        {
            ButtonInform.onClick.AddListener(()=>Popup.Inform("title","body",_onConfirmHandler));
            ButtonConfirm.onClick.AddListener(()=>Popup.Confirm("title","body",_onConfirmHandler));
            ButtonWarning.onClick.AddListener(()=>Popup.Warning("title","body",_onConfirmHandler));
            ButtonError.onClick.AddListener(()=>Popup.Error("title","body",_onConfirmHandler));
        }

        private void _onConfirmHandler(bool obj)
        {
            Debug.Log("Confirm:"+obj);
        }
    }
}