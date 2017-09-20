using CatLib.Ui;
using UnityEngine;
using UnityEngine.UI;

namespace Example.Scripts
{
    public class SelectablePopupExample:MonoBehaviour
    {
        public Button ButtonSelectable;

        void Awake()
        {
            ButtonSelectable.onClick.AddListener(() => Popup.Instance.PopupWindow("select_popup", "title", "body",true, _onConfirmHandler,_onSelectHandler));
        }

        private void _onSelectHandler(object obj)
        {
            var go = obj as Component;
            Debug.Log(go.name);
        }

        private void _onConfirmHandler(bool obj)
        {
            Debug.Log("Confirm:" + obj);
        }
    }
}