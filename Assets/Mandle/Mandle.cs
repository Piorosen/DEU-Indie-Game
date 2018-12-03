using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mandle : Character {

	void Start () {
		
	}
	
    new void Update () {
        base.Update();
        Rigidbody2D rb = GetComponent<Rigidbody2D>();

        Animator anim = GetComponent<Animator>();
        var horizontal = Input.GetAxisRaw("Horizontal");
        var vertical = Input.GetAxisRaw("Vertical");
        bool walking = false;
        if(vertical < 0) {
            anim.SetFloat("dy", -1);
            walking = true;
            this.dy = -1;
        } else if(vertical > 0) {
            anim.SetFloat("dy", +1);
            anim.SetFloat("dx", 0);
            walking = true;
            this.dy = +1;
        } else {
            this.dy = 0;
        }

        if(horizontal < 0) {
            anim.SetFloat("dx", -1);
            walking = true;
            this.dx = -1;
        } else if(horizontal > 0) {
            anim.SetFloat("dx", +1);
            walking = true;
            this.dx = +1;
        } else {
            this.dx = 0;
        }
        anim.SetBool("walking", walking);

        if(this.weapon != null) {
            var script = weapon.GetComponent<Weapon>();
            script.dx = dx;
            script.dy = dy;
            if(Input.GetButtonDown("Fire1")) {
                script.swing();
            }
        }

        this.move(new Vector2(horizontal, vertical));

	}

}
