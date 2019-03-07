using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Character : MonoBehaviour
{
    public int MaxJumpCount = 1;
    protected int JumpCount = 0;

    public int JumpPower = 20000;
    public int MoveSpeed = 100;

    protected bool IsGround = true;

    protected Rigidbody2D rigidBody;

    protected virtual void Start()
    {
        rigidBody = this.transform.GetComponent<Rigidbody2D>();
    }

    protected virtual void SetAnimation(Vector2 dir)
    {
        if (dir.x > 0)
        {
            this.transform.GetComponent<SpriteRenderer>().flipX = true;
        }
        else if (dir.x < 0)
        {
            this.transform.GetComponent<SpriteRenderer>().flipX = false;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        JumpCount = MaxJumpCount;
    }

    protected void Movement(Vector2 dir)
    {
        if (dir.y > 0)
        {
            Jump();
            dir.y = 0;
        }
        rigidBody.velocity = new Vector2(dir.x != 0 ? dir.normalized.x * MoveSpeed : rigidBody.velocity.x, rigidBody.velocity.y);
        SetAnimation(dir);
    }

    protected void Jump()
    {
        if (JumpCount > 0)
        {
            rigidBody.velocity = Vector2.zero;
            rigidBody.AddForce(Vector2.up * JumpPower);
            IsGround = false;
            JumpCount--;
        }
    }


}
