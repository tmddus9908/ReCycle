using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T _instnace;

    public static T Instance
    {
        get
        {
            if (_instnace == null)
            {
                _instnace = FindObjectOfType<T>();
                DontDestroyOnLoad(_instnace.gameObject);
            }

            return _instnace;
        }
    }

    private void Awake()
    {
        if (_instnace != null)
        {
            if (_instnace != this)
            {
                Destroy(gameObject);
            }

            return;
        }

        _instnace = GetComponent<T>();
        DontDestroyOnLoad(gameObject);
    }
}
