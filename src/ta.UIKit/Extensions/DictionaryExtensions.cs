using System;
using System.Collections.Generic;

namespace ta.UIKit;

public static class DictionaryExtensions
{
    public static TValue GetOrAdd<TKey, TValue>(this Dictionary<TKey, TValue> dictionary, TKey key, TValue addValue)
    {
        if (dictionary.TryGetValue(key, out TValue value)) return value;

        dictionary.Add(key, addValue);
        return addValue;
    }

    public static TValue GetOrAdd<TKey, TValue>(this Dictionary<TKey, TValue> dictionary, TKey key, Func<TValue> addValueFactory)
    {
        if (dictionary.TryGetValue(key, out TValue value)) return value;

        TValue addValue = addValueFactory();
        dictionary.Add(key, addValue);
        return addValue;
    }
}
