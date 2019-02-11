using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Character : MonoBehaviour
{
    protected int MaxJumpCount = 1;
    protected int JumpCount = 1;

    protected int JumpPower = 1000;
    protected int MoveSpeed = 3;

    void SetAnimation()
    {

    }

    void Movement(Vector2 Dir)
    {
        this.transform.Translate(Dir.normalized * MoveSpeed * Time.deltaTime);
    }


}
