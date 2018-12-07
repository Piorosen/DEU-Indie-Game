using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mandle : Character {
    new void Update()
    {
        base.Update();

        Animator anim = GetComponent<Animator>();
        Vector2 direction = new Vector2(Input.GetAxisRaw("Horizontal"),
                                        Input.GetAxisRaw("Vertical"));
        bool walking = false;

        if (direction.y < 0)
        {
            anim.SetFloat("dy", -1);
            walking = true;
        }
        else if (direction.y > 0)
        {
            anim.SetFloat("dy", 1);
            walking = true;
        }

        if (direction.x < 0)
        {
            walking = true;
        }
        else if (direction.x > 0)
        {
            walking = true;
        }

        anim.SetBool("walking", walking);

        var script = weapon?.GetComponent<Weapon>();
        if (Input.GetButtonDown("Fire1"))
        {
            script.Swing((int)direction.x, (int)direction.y);
        }
        Move(direction);
    }

}
