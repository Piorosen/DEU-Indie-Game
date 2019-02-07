using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{
    public SpriteRenderer render;
    int dir = 0;
    public int Dir
    {
        set
        {
            switch (value)
            {
                case 0:
                    render.transform.localPosition = new Vector3(0.342f, 0.068f);
                    render.flipX = false;
                    break;
                case 1:
                    render.transform.localPosition = new Vector3(-0.342f, 0.068f);
                    render.flipX = true;
                    break;
            }
            dir = value;
        }
    }

    IEnumerator Courutine()
    {
        for (int i = 0; i < 15; i++)
        {
            if (dir == 0)
            {
                transform.rotation = Quaternion.Euler(0, 0, -90 / 15 * i);
            }
            else
            {
                transform.rotation = Quaternion.Euler(0, 0, 90 / 15 * i);
            }

            yield return new WaitForSeconds(0.01f);
        }
        transform.rotation = Quaternion.Euler(0, 0, 0);
    }

    public void Attack()
    {
        StartCoroutine(Courutine());
    }



}
