using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponEnemy : BasicEnemy {

	void Start () {
		
	}

    new void Update()
    {
        base.Update();
        var script = weapon?.GetComponent<Weapon>();
        //script.Swing(dx, dy);
    }

    new void OnCollisionEnter2D(Collision2D collision) {

    }
}
