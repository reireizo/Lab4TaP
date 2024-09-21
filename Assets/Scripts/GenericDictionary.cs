using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenericDictionary : MonoBehaviour
{
    private Dictionary<object, object> _dict = new Dictionary<object, object>();

    public void Add<T>(string key, T value) where T : class
    {
        _dict.Add(key, value);
    }

    public T GetValue<T>(string key) where T : class
    {
        return _dict[key] as T;
    }
}
