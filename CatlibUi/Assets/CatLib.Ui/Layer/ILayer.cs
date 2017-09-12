using System;
using UnityEngine;

namespace CatLib.Ui
{
    public interface ILayer
    {
        /// <summary>
        /// 设置Layer容器
        /// 可以在游戏中更换容器
        /// </summary>
        /// <param name="transform"></param>
        void SetLayerContainer(RectTransform transform);

        /// <summary>
        /// 直接访问指定层所在的transform
        /// </summary>
        /// <param name="layerName"></param>
        /// <returns></returns>
        /// <exception cref="Exception">can't get layer</exception>
        RectTransform GetLayer(string layerName);

        /// <summary>
        /// 设置layer，index表示层级关系
        /// 如果已经存在同名的层，则重新设置其层级关系
        /// </summary>
        /// <param name="layerName"></param>
        /// <param name="index"></param>
        void SetLayer(string layerName,int index);
    }
}