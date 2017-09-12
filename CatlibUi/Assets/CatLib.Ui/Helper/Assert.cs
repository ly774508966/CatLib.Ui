using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace CatLib.Ui
{
    static class Assert
    {
        public static void IsTrue(bool b,string warnning =null)
        {
            if (b) return;
            if (warnning == null) warnning = string.Format("Assert IsTrue Fail,{0}", b);
            throw new Exception(warnning);
        }

        public static void IsTrue<T>(bool b)where T:Exception,new()
        {
            _check<T>(b);
        }

        public static void IsFalse(bool b, string warnning = null)
        {
            if (!b) return;
            if (warnning == null) warnning = string.Format("Assert IsFalse Fail,{0}", b);
            throw new Exception(warnning);
        }

        public static void IsFalse<T>(bool b)where T:Exception,new()
        {
            _check<T>(!b);
        }

        public static void AreEqual(int b,int a,string warnning=null) 
        {
            if (a==b) return;
            if (warnning == null) warnning = string.Format("Assert IsEqual Fail,{0},{1}", b, a);
            throw new Exception(warnning);
        }


        public static void AreEqual(string b,string a,string warnning=null) 
        {
            if (a==b) return;
            if (warnning == null) warnning = string.Format("Assert IsEqual Fail,{0},{1}", b, a);
            throw new Exception(warnning);
        }

        public static void AreEqual(Guid b,Guid a,string warnning=null) 
        {
            if (a==b) return;
            if (warnning == null) warnning = string.Format("Assert IsEqual Fail,{0},{1}", b, a);
            throw new Exception(warnning);
        }

        public static void AreEqual(object b,object a,string warnning=null) 
        {
            if (a==b) return;
            if (warnning == null) warnning = string.Format("Assert IsEqual Fail,{0},{1}", b, a);
            throw new Exception(warnning);
        }

        public static void AreEqual<T>(int b,int a) where T:Exception,new()
        {
            _check<T>(a == b);
        }

        public static void AreEqual<T>(object b,object a) where T:Exception,new()
        {
            _check<T>(a == b);
        }

        public static void Between<T>(int num, int min, int max)where T:Exception,new()
        {
            _check<T>(num > min && num < max);
        }

        public static void BetweenWithBorder<T>(int num, int min, int max)where T:Exception,new()
        {
            _check<T>(num >= min && num <= max);
        }

        public static void BetweenWithBorder<T>(uint num, uint min, uint max)where T:Exception,new()
        {
            _check<T>(num >= min && num <= max);
        }

        public static void IsNull(object b, string warnning = null)
        {
            if (b==null) return;
            if (warnning == null) warnning = string.Format("Assert IsNull Fail,{0}", b);
            throw new Exception(warnning);
        }

        public static void IsNull<T>(object b) where T:Exception,new()
        {
            _check<T>(b==null);
        }


        public static void IsNotNull(object b, string warnning = null)
        {
            if (b != null) return;
            if (warnning == null) warnning = string.Format("Assert IsNotNull Fail,{0}", b);
            throw new Exception(warnning);
        }

        public static void IsNotNull<T>(object b) where T:Exception,new()
        {
            _check<T>(b!=null);
        }

        public static void IsNotNullOrEmpty<T>(IEnumerable<T> b, string warnning = null)
        {
            if (b != null && b.Any()) return;
            if (warnning == null) warnning = string.Format("Assert IsNotNullOrEmpty Fail,{0}", b);
            throw new Exception(warnning);
        }

        public static void IsNotNullOrEmpty(string b, string warnning = null)
        {
            if (!string.IsNullOrEmpty(b)) return;
            if (warnning == null) warnning = string.Format("Assert IsNotNullOrEmpty Fail,{0}", b);
            throw new Exception(warnning);
        }
        public static void IsNullOrEmpty(string b, string warnning = null)
        {
            if (string.IsNullOrEmpty(b)) return;
            if (warnning == null) warnning = string.Format("Assert IsNotNullOrEmpty Fail,{0}", b);
            throw new Exception(warnning);
        }

        public static void HasAny(ICollection collection, string warnning = null)
        {
            if (collection.Count > 0) return;
            if (warnning == null) warnning = string.Format("Assert HasAny Fail,{0}", collection);
            throw new Exception(warnning);
        }

        public static void HasNothing(ICollection collection, string warnning = null)
        {
            if (collection.Count == 0) return;
            if (warnning == null) warnning = string.Format("Assert HasNothing Fail,{0}", collection);
            throw new Exception(warnning);
        }

        public static void IsType<T>(object b, string warnning = null)
        {
            if(b is T) return;
            if (warnning == null) warnning = string.Format("Assert IsType Fail,{0}", b);
            throw new Exception(warnning);
        }

        public static void IsType<T>(Type type, string warnning = null)
        {
            if(typeof(T).IsAssignableFrom(type)) return;
            if (warnning == null) warnning = string.Format("Assert IsType Fail,{0}", type);
            throw new Exception(warnning);
        }

        private static void _check<T>(bool comparer) where T : Exception,new()
        {
            if(comparer) return;
            throw new T();
        }
    }
}
