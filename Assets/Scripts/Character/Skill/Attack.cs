using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : Skill
{
    public override void OnCastSkill()
    {
        StartCoroutine(Casting(Sprite));
    }

    IEnumerator Casting(SpriteRenderer sprite)
    {
        sprite.transform.rotation = Quaternion.Euler(0, 0, 30);
        sprite.enabled = true;
        for (int i = 0; i < 90; i++)
        {
            sprite.transform.rotation = Quaternion.Euler(0, 0, 30 + i);
            yield return new WaitForSeconds(0.1f / 90.0f);
        }
        sprite.enabled = false;
    }
}
