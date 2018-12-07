using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{

    public float speed = 20;
    public int maxHealth = 6;
    public int health = 6;

    public GameObject weapon;

    private Vector2 movementVector = new Vector2();
    protected Rigidbody2D rigidBody;
    protected new SpriteRenderer renderer;

    private void Awake()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        renderer = GetComponent<SpriteRenderer>();
    }

    protected void Update()
    {
        rigidBody.AddForce(movementVector * speed);
    }

    void SetAnim(Vector2 nextMove)
    {
        if (nextMove.x > 0)
        {
            renderer.flipX = false;
        }
        else if (nextMove.x < 0)
        {
            renderer.flipX = true;
        }
    }

    public void Move(Vector2 vector)
    {
        SetAnim(vector);
        movementVector = vector;
    }

    public void Damage(int amount)
    {
        this.health -= amount;
    }

    public void Knockback(float angle, float distance)
    {
        var vector = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));
        rigidBody.AddForce(vector * distance);
    }

}
