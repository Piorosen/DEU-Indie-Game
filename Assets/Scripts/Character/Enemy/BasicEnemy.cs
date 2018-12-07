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
        RandomMovement();
    }


    protected void RandomMovement() {
        var anim = GetComponent<Animator>();

        if(distance <= 0) {
            direction = Mathf.RoundToInt(Random.Range(0, 5));
            distance = Mathf.RoundToInt(Random.Range(0, 100));
        }

        Vector2 nextMove = new Vector2();

        switch(direction) {
            case 1:
            {
                nextMove.x = -1;
            }
            break;
        case 2:
            {
                nextMove.x = +1;
            }
            break;
        case 3:
           {
               nextMove.x = +1;
           }
           break;
        case 4:
            {
                nextMove.x = +1;
            }
            break;
        }
        anim.SetFloat("dy", nextMove.y);
        anim.SetBool("walking", nextMove.x != 0 && nextMove.y != 0);
        Move(nextMove);
        distance--;
    }

    protected void OnCollisionEnter2D(Collision2D collision) {
        var other = collision.collider.gameObject;
        if(other.name == "Mandle") {
            var mandle = other.GetComponent<Mandle>();
            mandle.Damage(1);
            var dir = other.transform.position - this.transform.position;
            dir = other.transform.InverseTransformDirection(dir);
            var angle = Mathf.Atan2(dir.y, dir.x);
            mandle.Knockback(angle, 500);
        }
    }

}
