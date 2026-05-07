using System;
using System.Collections.Generic;

namespace ConsoleApp10
{
    internal class Program
    {
        static void Main(string[] args)
        {
        }
    }

    #region Q1 - Generic Class
    // Generic class: class with type parameter <T>
    // Used for reusability, type safety, performance
    #endregion


    #region Q2 - Container<T>
    public class Container<T>
    {
        private T? _value;

        public void Add(T value) => _value = value;
        public T? Get() => _value;
    }
    #endregion

    #region Q3 - Pair<TKey, TValue>
    public class Pair<TKey, TValue>
    {
        public TKey Key { get; set; }
        public TValue Value { get; set; }

        public Pair(TKey key, TValue value)
        {
            Key = key;
            Value = value;
        }
    }
    #endregion


    #region Q4 - Swap<T>
    public static class Utils
    {
        public static void Swap<T>(ref T a, ref T b)
        {
            T temp = a;
            a = b;
            b = temp;
        }
    }
    #endregion

    #region Q5 - FindMax<T>
    public static class ComparerHelper
    {
        public static T FindMax<T>(T a, T b) where T : IComparable<T>
        {
            return a.CompareTo(b) > 0 ? a : b;
        }
    }
    #endregion

    #region Q6 - IRepository<T>
    public interface IRepository<T>
    {
        void Add(T item);
        T Get(int id);
        void Remove(T item);
    }
    #endregion

    #region Q7 - struct constraint
    public class StructExample<T> where T : struct
    {
        public T Value;
    }
    #endregion

    #region Q8 - class constraint
    public class ClassExample<T> where T : class
    {
        public T? Data;
    }
    #endregion

    #region Q9 - new() constraint
    public class NewExample<T> where T : new()
    {
        public T Create() => new T();
    }
    #endregion

    #region Q10 - Interface constraint
    public class DisposableExample<T> where T : IDisposable
    {
        public void Clean(T obj) => obj.Dispose();
    }
    #endregion


    #region Q11 - Base class constraint
    public class Animal { }
    public class Dog : Animal { }

    public class AnimalExample<T> where T : Animal
    {
        public T? Pet;
    }
    #endregion

    #region Q12 - Multiple constraints
    public class MultiConstraint<T>
        where T : class, IDisposable, new()
    {
        public T Create()
        {
            var obj = new T();
            return obj;
        }
    }
    #endregion

    #region Q13 - default keyword
    // default(T):
    // int -> 0
    // bool -> false
    // reference -> null
    #endregion


    #region Q14 - SafeList<T>
    public class SafeList<T>
    {
        private List<T> _list = new();

        public void Add(T item) => _list.Add(item);

        public T? Get(int index)
        {
            if (index < 0 || index >= _list.Count)
                return default;

            return _list[index];
        }
    }
    #endregion


    #region Q15 - Covariance (out)
    public interface IProducer<out T>
    {
        T GetItem();
    }
    #endregion


    #region Q16 - Contravariance (in)
    public interface IConsumer<in T>
    {
        void Consume(T item);
    }
    #endregion


    #region Q17 - Difference
    // out => return types
    // in  => input parameters
    #endregion


    #region Q18 - Static in generics
    public class StaticTest<T>
    {
        public static int Counter;
    }
    // StaticTest<int> != StaticTest<string>
    #endregion


    #region Q19 - Inheritance
    public class Base<T>
    {
        public T? Data;
    }

    public class Derived : Base<int>
    {
    }
    #endregion


    #region Q20 - Cache<TKey, TValue>
    public class CacheItem<T>
    {
        public T Value { get; set; } = default!;
        public DateTime Expiration { get; set; }
    }

    public class Cache<TKey, TValue> where TKey : notnull
    {
        private Dictionary<TKey, CacheItem<TValue>> _cache = new();

        public void Add(TKey key, TValue value, int seconds)
        {
            _cache[key] = new CacheItem<TValue>
            {
                Value = value,
                Expiration = DateTime.Now.AddSeconds(seconds)
            };
        }
    }
    #endregion
}