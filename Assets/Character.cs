using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour {
    
    public float speed = 20;
    public int maxHealth = 6;
    public int health = 6;

    public GameObject weapon;

    private Vector2 movementVector = new Vector2();
    protected int dx, dy;

	void Start () {
		
	}
	
    protected void Update () {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.AddForce(movementVector * speed);

    }

    public void move(Vector2 vector) {
        movementVector = vector;
    }

    public void damage(int amount) {
        this.health -= amount;
    }

    public void knockback(float angle, float distance) {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        var vector = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));
        rb.AddForce(vector * distance);
    }

}
