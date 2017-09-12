using UnityEngine;

namespace CatLib.Ui
{
    public interface IUi
    {

        void Enter();

        void Exit();

        RectTransform RectTransform { get; }
    }
}