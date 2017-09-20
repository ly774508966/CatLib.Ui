using System;
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
        public Button ButtonHideMask1;

        private Guid _mask;
        private Guid _mask1;

        void Awake()
        {
            ButtonHideMask.onClick.AddListener(()=>_hideMask());
            ButtonShowMask.onClick.AddListener(()=>_showMask());
            ButtonShowMask1.onClick.AddListener(()=>_showMask1());
            ButtonHideMask1.onClick.AddListener(()=>_hideMask1());
        }

        private void _hideMask1()
        {
            Mask.Instance.HideMask(_mask1);
        }

        private void _showMask1()
        {
           _mask1=  Mask.Instance.ShowMask("mask1");
        }

 

        private void _showMask()
        {
          _mask=  Mask.Instance.ShowMask("anything");
        }

        private void _hideMask()
        {
            Mask.Instance.HideMask(_mask);
        }
    }
}