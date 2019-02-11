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

    protected void SetAnimation()
    {

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        JumpCount = MaxJumpCount;
    }

    protected void Movement(Vector2 Dir)
    {
        if (Dir.y > 0)
        {
            Jump();
            Dir.y = 0;
        }
        this.transform.Translate(Dir.normalized * MoveSpeed * Time.deltaTime);
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
