using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace test_1C.Models
{
    public static class DictionaryExtension
    {
        public static TValue ValueOrDefault<TValue>(this Dictionary<string, TValue> dictionary, string key)
        {
            if (dictionary.ContainsKey(key))
                return dictionary[key];
            return default(TValue);
        }
    }
}