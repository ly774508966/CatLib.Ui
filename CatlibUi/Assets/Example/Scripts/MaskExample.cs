using UnityEngine;
using UnityEngine.UI;
using Mask = CatLib.Ui.Mask;

namespace YourNameSpace.Scripts
{
    public class MaskExample:MonoBehaviour
    {
        public Button ButtonShowMask;
        public Button ButtonHideMask;
        public Button ButtonShowMask1;

        void Awake()
        {
            ButtonHideMask.onClick.AddListener(()=>_hideMask());
            ButtonShowMask.onClick.AddListener(()=>_showMask());
            ButtonShowMask1.onClick.AddListener(()=>_showMask1());
        }

        private void _showMask1()
        {
            Mask.Instance.ShowMask("mask1");
        }

 

        private void _showMask()
        {
            Mask.Instance.ShowMask("anything");
        }

        private void _hideMask()
        {
            Mask.Instance.HideMask();
        }
    }
}