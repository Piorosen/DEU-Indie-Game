﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{

    // Start is called before the first frame update
    protected void Start()
    {
        base.Start();
        
    }

    // Update is called once per frame
    protected void Update()
    {
        base.Update();

        if (Input.GetKey(KeyCode.Q))
        {
            Sword.Attack();
        }

    }
}
