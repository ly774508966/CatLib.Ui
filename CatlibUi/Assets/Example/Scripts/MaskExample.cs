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

        private string _mask;
        private string _mask1;

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
            _mask1 = null;
        }

        private void _showMask1()
        {
            if (_mask1 != null) return;
           _mask1=  Mask.Instance.ShowMask("mask1");
        }

 

        private void _showMask()
        {
           if (_mask != null) return;
          _mask=  Mask.Instance.ShowMask("anything");
        }

        private void _hideMask()
        {
            Mask.Instance.HideMask(_mask);
            _mask = null;
        }
    }
}