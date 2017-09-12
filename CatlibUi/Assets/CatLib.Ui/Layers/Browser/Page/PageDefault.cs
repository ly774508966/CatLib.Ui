using UnityEngine;

namespace CatLib.Ui
{
    public class PageDefault : MonoBehaviour,IPage
    {

        public virtual bool IsLocked
        {
            get { return false; }
        }

        public virtual string PageName
        {
            get { return this.name; }
        }

        public virtual void Enter()
        {
            gameObject.SetActive(true);
        }

        public virtual void Exit()
        {
            gameObject.SetActive(false);
        }

        private RectTransform _rectTransform;

        public RectTransform RectTransform
        {
            get
            {
                if (_rectTransform == null)
                {
                    _rectTransform = this.GetComponent<RectTransform>();
                }
                Assert.IsNotNull(_rectTransform);
                return _rectTransform;
            }
        }
    }
}

