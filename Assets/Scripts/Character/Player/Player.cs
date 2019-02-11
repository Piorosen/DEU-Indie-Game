using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{
    // Start is called before the first frame update
    void Start()
    {
        base.Start();
    }
    


    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 Dir = new Vector2();

        if (InputManager.Keys[KeyCode.A])
        {
            Dir.x -= 1;
        }
        if (InputManager.Keys[KeyCode.D])
        {
            Dir.x += 1;
        }
        if (InputManager.Keys[KeyCode.W])
        {
            Dir.y += 1;
        }
        if (InputManager.Keys[KeyCode.S])
        {
            Dir.y -= 1;
        }

        Movement(Dir);
    }
}
