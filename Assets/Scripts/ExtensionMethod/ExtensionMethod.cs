using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ExtensionMethod
{

    public static List<T> ShuffleList<T>(this List<T> _list)
    {

        for (int i = 0; i < 100; i++)
        {
            int r = Random.Range(0, _list.Count);
            int p = Random.Range(0, _list.Count);
            T temp = _list[r];
            _list[r] = _list[p];
            _list[p] = temp;
        }

        return _list;
    }

    public static void LogWithColor(this Debug _g, string _msg, Color _color)
    {
        Debug.Log("<Color=#" + ColorUtility.ToHtmlStringRGBA(_color) + ">" + _msg + "</Color>");
    }

    public static void Visible(this GameObject _gameObject)
    {
        _gameObject.SetActive(true);
    }

    public static void InVisible(this GameObject _gameObject)
    {
        _gameObject.SetActive(false);
    }

}




