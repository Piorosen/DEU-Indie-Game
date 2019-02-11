using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Character : MonoBehaviour
{
    protected int MaxJumpCount = 1;
    protected int JumpCount = 1;

    protected int JumpPower = 10000;
    protected int MoveSpeed = 50;

    protected bool IsGround = true;

    public Rigidbody2D rigidBody;

    protected void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    protected void SetAnimation()
    {

    }

    void OnCollisionEnter2D(Collision2D collision)
    {

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
            rigidBody.AddForce(Vector2.up * JumpPower);
            IsGround = false;
            JumpCount--;
        }
    }


}
