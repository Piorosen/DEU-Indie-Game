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
            Keys[(KeyCode)key] = Input.GetKey((KeyCode)key);
        }
    }
}
