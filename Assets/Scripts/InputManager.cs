using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public static Queue<(KeyCode, int, bool)> queue = new Queue<(KeyCode, int, bool)>();

    // Update is called once per frame
    void Update()
    {

    }
}
