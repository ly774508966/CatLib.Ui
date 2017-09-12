using System;
using UnityEngine;

namespace CatLib.Ui
{
    static class GameObjectExtend
    {
        public static T AddComponentIfNotExist<T>(this GameObject go) where T:UnityEngine.Component
        {
            var component = go.GetComponent<T>();
            if (component == null) component = go.AddComponent<T>();
            return component;
        }

        public static Component AddComponentIfNotExist(this GameObject go,Type type)
        {
            var component = go.GetComponent(type);
            if (component == null) component = go.AddComponent(type);
            return component;
        }

        public static T AssertGetComponent<T>(this GameObject go,string message=null)
        {
            var componet = go.GetComponent<T>();
            Assert.IsNotNull(componet, message?? string.Format("Can't find component: {0} in gameobject: {1}",
                                           typeof(T), go));
            return componet;
        }

        
        /// <summary>
        /// assert the child is exist
        /// </summary>
        /// <param name="go"></param>
        /// <param name="childName"></param>
        /// <returns></returns>
        public static GameObject AssertHasChild(this GameObject go, string childName)
        {
            var child = go.transform.Find(childName).gameObject;
            if (child == null) throw new Exception("Can't find child:" + childName);
            return child;
        }
    }
}
