using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defense : Skill
{
    public override void OnCastSkill()
    {
        StartCoroutine(Casting(Sprite));
    }

    IEnumerator Casting(SpriteRenderer sprite)
    {
        sprite.enabled = true;
        for (int i = 0; i < 90; i++)
        {
            int ZAngle = i * 8;

            if (sprite.flipX == true)
            {
                sprite.transform.rotation = Quaternion.Euler(0, 0, ZAngle);
                sprite.transform.localPosition = new Vector3(30, 0, 0);
            }
            else
            {
                sprite.transform.rotation = Quaternion.Euler(0, 0, -ZAngle);
                sprite.transform.localPosition = new Vector3(-30, 0, 0);
            }

            yield return new WaitForSeconds(0.1f / 90f);
        }
        sprite.enabled = false;
    }
}
