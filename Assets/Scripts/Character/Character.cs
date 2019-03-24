using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Character : MonoBehaviour
{
    public int MaxJumpCount = 1;
    public int JumpCount = 0;

    public int JumpPower = 20000;
    public int MoveSpeed = 100;

    protected bool IsGround = true;

    public Rigidbody2D PlayerRigidBody;
    public SpriteRenderer PlayerSprite;

    protected virtual void Start()
    {
    }

    protected virtual void SetAnimation(Vector2 dir)
    {
        if (dir.x > 0)
        {
            PlayerSprite.flipX = true;
        }
        else if (dir.x < 0)
        {
            PlayerSprite.flipX = false;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        JumpCount = MaxJumpCount;
    }

    protected void Movement(Vector2 dir)
    {
        Debug.Log(dir);
        if (dir.y > 0)
        {
            Jump();
            dir.y = 0;
        }
        PlayerRigidBody.velocity = new Vector2(dir.x != 0
            ? dir.normalized.x * MoveSpeed
            : PlayerRigidBody.velocity.x, PlayerRigidBody.velocity.y);
        SetAnimation(dir);
    }

    protected void Jump()
    {
        if (JumpCount > 0)
        {
            PlayerRigidBody.velocity = Vector2.zero;
            PlayerRigidBody.AddForce(Vector2.up * JumpPower);
            IsGround = false;
            JumpCount--;
        }
    }


}
