using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public static Dictionary<KeyCode, bool> Keys = new Dictionary<KeyCode, bool>();

    void Awake()
    {
        foreach (var key in Enum.GetValues(typeof(KeyCode)))
        {
            Keys[(KeyCode)key] = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        foreach (var key in Enum.GetValues(typeof(KeyCode)))
        {
            foreach (var i in Key.Move.Instance.GetType().GetFields())
            {
                if ((KeyCode)i.GetValue(Key.Move.Instance) != (KeyCode)key)
                {
                    Keys[(KeyCode)key] = Input.GetKeyDown((KeyCode)key) ? true : Keys[(KeyCode)key];
                }
                else
                {
                    continue;
                }
            }
        }
    }
}
