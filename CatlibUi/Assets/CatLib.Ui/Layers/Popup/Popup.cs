using System;

namespace CatLib.Ui
{
    public class Popup:Facade<IPopup>
    {
        public const string InformName = "inform";
        public const string ConfirmName = "confirm";
        public const string WarningName = "warning";
        public const string ErrorName = "error";

        public static void Inform(string messageTitle, object messageBody,
            Action<bool> onConfirmHandler)
        {
            App.Make<IPopup>().GetType();
            Assert.IsNotNull(Instance,"do not have popup instance");
            Instance.PopupWindow(InformName, messageTitle, messageBody,true, onConfirmHandler);
        }

        public static void Confirm(string messageTitle, object messageBody,
            Action<bool> onConfirmHandler)
        {
            Assert.IsNotNull(Instance,"do not have popup instance");
            Instance.PopupWindow(ConfirmName, messageTitle,messageBody, true, onConfirmHandler);
        }

        public static void Warning(string messageTitle, object messageBody,
            Action<bool> onConfirmHandler)
        {
            Assert.IsNotNull(Instance,"do not have popup instance");
            Instance.PopupWindow(WarningName, messageTitle, messageBody, true, onConfirmHandler);
        }

        public static void Error(string messageTitle, object messageBody,
            Action<bool> onConfirmHandler)
        {
            Assert.IsNotNull(Instance,"do not have popup instance");
            Instance.PopupWindow(ErrorName, messageTitle, messageBody, true, onConfirmHandler);
        }

    }
}