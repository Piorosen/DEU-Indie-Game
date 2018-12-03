using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemy : Character {

    private int direction = 0;
    private int distance = 0;

	void Start () {
		
	}
	
	new void Update () {
        base.Update();
        randomMovement();
    }

    protected void randomMovement() {
        var anim = GetComponent<Animator>();

        if(distance <= 0) {
            direction = Mathf.RoundToInt(Random.Range(0, 5));
            distance = Mathf.RoundToInt(Random.Range(0, 100));
        }

        switch(direction) {
        case 1:
            dx = -1;
            break;
        case 2:
            dx = +1;
            break;
        case 3:
            dy = +1;
            break;
        case 4:
            dy = -1;
            break;
        }
        anim.SetFloat("dy", dy);
        anim.SetFloat("dx", dx);
        anim.SetBool("walking", dx != 0 && dy != 0);
        move(new Vector2(dx, dy));
        distance--;
    }

    protected void OnCollisionEnter2D(Collision2D collision) {
        var other = collision.collider.gameObject;
        if(other.name == "Mandle") {
            var mandle = other.GetComponent<Mandle>();
            mandle.damage(1);
            var dir = other.transform.position - this.transform.position;
            dir = other.transform.InverseTransformDirection(dir);
            var angle = Mathf.Atan2(dir.y, dir.x);
            mandle.knockback(angle, 500);
        }
    }

}
