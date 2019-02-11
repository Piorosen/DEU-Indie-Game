using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Skill : MonoBehaviour
{
    public SpriteRenderer Sprite;
    public abstract void OnCastSkill();

    protected virtual void Awake()
    {
        Sprite = GetComponent<SpriteRenderer>();
    }
}
