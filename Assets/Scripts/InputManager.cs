using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public Queue<(long Ticks, KeyCode Code)> Keys = new Queue<(long Ticks, KeyCode Code)>();

    int Ticks = 0;

    // Update is called once per frame
    void Update()
    {
        foreach (var key in Enum.GetValues(typeof(KeyCode)))
        {
            if (Input.GetKeyDown((KeyCode)key))
            {
                Keys.Enqueue((this.Ticks, (KeyCode)key));
            }
        }
        Ticks++;
    }
}
