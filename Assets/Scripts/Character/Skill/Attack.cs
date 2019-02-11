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
        for (int i = 0; i < 45; i++)
        {
            int ZAngle = 30 + i * 2;

            if (sprite.flipX == false)
            {
                sprite.transform.rotation = Quaternion.Euler(0, 0, ZAngle);
                sprite.transform.localPosition = new Vector3(-30, 20, 0);
            }
            else
            {
                sprite.transform.rotation = Quaternion.Euler(0, 0, -ZAngle);
                sprite.transform.localPosition = new Vector3(30, 20, 0);
            }

            yield return new WaitForSeconds(0.1f / 90.0f);
        }
        sprite.enabled = false;
    }
}
