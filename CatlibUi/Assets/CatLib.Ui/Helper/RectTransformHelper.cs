using UnityEngine;

namespace CatLib.Ui
{
    static class RectTransformHelper
    {
        /// <summary>
        /// 设置为拉伸
        /// </summary>
        /// <param name="rect"></param>
        public static void SetFullStretch(this RectTransform rect)
        {
            Assert.IsNotNull(rect, "rect 为null");
            rect.localPosition = Vector3.zero;
            rect.anchoredPosition = Vector2.zero;
            rect.anchorMin = Vector2.zero;
            rect.anchorMax = Vector2.one;
            rect.pivot = Vector2.zero;
            rect.offsetMin = Vector2.zero;
            rect.offsetMax = Vector2.zero;
            rect.transform.localScale = Vector3.one;
        }

        public static void HideAllChildren(this RectTransform rect)
        {
            for (int i = 0; i < rect.childCount; i++)
            {
                var child = rect.GetChild(i);
                var page = child.GetComponent<IPage>();
                if (page != null)
                {
                    page.Exit();
                }
                else
                {
                    child.gameObject.SetActive(false);
                }
            }
        }

        public static void ShowUi(this RectTransform rect)
        {
            var page = rect.GetComponent<IPage>();
            if (page != null)
            {
                page.Enter();
            }
            else
            {
                rect.gameObject.SetActive(true);
            }
            rect.SetFullStretch();
        }

        public static void HideUi(this RectTransform rect)
        {
            var page = rect.GetComponent<IPage>();
            if (page != null)
            {
                page.Exit();
            }
            else
            {
                rect.gameObject.SetActive(false);
            }
        }
    }
}