using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace CatLib.Ui
{
    public class PopupWindowDefault: PopupWindow
    {
      
        public Button ConfirmTrueButton;
        public Button ConfirmFalseButton;
        public Button[] SelectionButtons;
        public Text TitleText;
        public Text BodyText;

        void Awake()
        {
            if(ConfirmTrueButton!=null) ConfirmTrueButton.onClick.AddListener(() =>
            {
                ReportConfirm(true);
            });
            if(ConfirmFalseButton!=null) ConfirmFalseButton.onClick.AddListener(() =>
            {
                ReportConfirm(false);
            });

            foreach (var selectionButton in SelectionButtons)
            {
                var tmp = selectionButton;  
                selectionButton.onClick.AddListener(() =>
                {
                    ReportSelect(tmp);
                });
            }
        }

        public override void SetWindowTitle(string messageTitle)
        {
            if (TitleText != null) TitleText.text = messageTitle;
        }

        public override void SetWindowBody(object messageBody)
        {
            if(BodyText==null) return;
            if (messageBody == null)
            {
                BodyText.text = "";
                return;
            }
            BodyText.text = messageBody.ToString();
        }
    }
}