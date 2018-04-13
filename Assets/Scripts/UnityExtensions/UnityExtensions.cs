using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class MonoBehaviorExtensions
{
    static public T GetOrAddComponent<T> (this GameObject go) where T : Component
    {
        T result = go.GetComponent<T>();
        if (result == null)
        {
            result = go.AddComponent<T>();
        }

        return result;
    }
}

public static class ComponentExtensions
{
    static public T GetOrAddComponent<T> (this Component comp) where T : Component
    {
        return comp.gameObject.GetOrAddComponent<T>();
    }
}

public static class Vector3Extensions
{
    static public string ToFullString (this Vector3 vec)
    {
        return "(" + vec.x + ", " + vec.y + ", " + vec.z + ")";
    }
}
