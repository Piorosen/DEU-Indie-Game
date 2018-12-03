using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponEnemy : BasicEnemy {

	void Start () {
		
	}
	
	new void Update () {
        base.Update();
        if(weapon != null) {
            var script = weapon.GetComponent<Weapon>();
            script.dx = dx;
            script.dy = dy;
            script.swing();
        }
    }

    new void OnCollisionEnter2D(Collision2D collision) {

    }
}
