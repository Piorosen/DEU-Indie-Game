using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordThrow : Skill
{
    public override void OnCastSkill()
    {
        if (Sprite.enabled == false)
        {
            StartCoroutine(Casting(Sprite));
        }
    }

    IEnumerator Casting(SpriteRenderer sprite)
    {
        sprite.enabled = true;
        float speed = 800.0f;
        int dir = 0;
        if (sprite.flipX == false)
        {
            dir = -1;
        }
        else
        {
            dir = 1;
        }
        sprite.transform.localPosition = new Vector3(dir * 30, 30, 0);
        Vector3 location = this.transform.position;
        
        for (float time = 1.0f; time > 0.0f; time -= Time.deltaTime)
        {
            location.x += dir * speed * Time.deltaTime;
            sprite.transform.position = location;
            yield return new WaitForEndOfFrame();
        }
        sprite.enabled = false;
    }
}
