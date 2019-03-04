﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hook : Skill
{
    LineRenderer line;

    protected override void Awake()
    {
        base.Awake();
        line = GetComponent<LineRenderer>();

        line.startWidth = 10f;
        line.endWidth = 10f;
    }

    void Enable()
    {
        line.enabled = true;
        Sprite.enabled = true;
    }
    void Disable()
    {
        line.enabled = false;
        Sprite.enabled = false;
    }

    bool CheckMode()
    {
        return Sprite.enabled;
    }

    public override void OnCastSkill()
    {
        // 참 : 유저가 날라감.
        // 거짓 : 앵커가 날라감.

        if (CheckMode())
        {
            // 캐릭터 이동
            StartCoroutine(Move());

            Disable();
        }
        else
        {
            var location = this.transform.parent.position;
            var arrive = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            
            location.z = 0;
            arrive.z = 0;
            var tmp = arrive;

            var ray = Physics2D.RaycastAll(location, arrive - location, 10000);

            bool bcheck = false;
            foreach (var check in ray)
            {
                if (check.collider != null && check.collider.gameObject.layer == 9)
                {
                    arrive = check.point;
                    Debug.Log(check.point);
                    arrive.z = 0;
                    bcheck = true;
                    
                    break;
                }
            }
            StartCoroutine(HookMove(location, arrive, !bcheck));
            Enable();
        }
    }
    IEnumerator DragHook()
    {
        var range = line.GetPosition(1) - line.GetPosition(0);
        
        for (float time = 0.1f; time > 0.0f; time -= Time.deltaTime)
        {
            line.SetPositions(new Vector3[]
            {
                this.transform.parent.position,
                line.GetPosition(1) - (range * Time.deltaTime * (1 / 0.1f))
            });
            yield return new WaitForEndOfFrame();
        }

        Disable();
    }

    IEnumerator HookMove(Vector3 l, Vector3 a, bool check = false)
    {
        var range = a - l;

        var move = (range * Time.deltaTime * (1 / 0.1f));
        for (float time = 0.1f; time > 0.0f; time -= Time.deltaTime)
        {
            line.SetPositions(new Vector3[]
            {
                this.transform.parent.position,
                l + move
            });
            move += (range * Time.deltaTime * (1 / 0.1f));
            yield return new WaitForEndOfFrame();
        }

        line.SetPositions(new Vector3[]
        {
            this.transform.parent.position,
            a   
        });

        Sprite.transform.position = a;
        
        if (check == true)
        {
            yield return DragHook();
        }
    }


    IEnumerator Move()
    {
        var location = this.transform.parent.position;
        var arrive = Sprite.transform.position;
        
        location.z = 0;
        arrive.z = 0;

        var distance = arrive - location;

        this.transform.parent.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        for (float time = 0.1f; time > 0.0f; time -= Time.deltaTime)
        {
            this.transform.parent.Translate(distance * Time.deltaTime * (1 / 0.1f));
            yield return new WaitForEndOfFrame();
        }
    }


    void LateUpdate()
    {
        if (line.enabled == true)
        {
            line.SetPosition(0, this.transform.parent.position);
            Sprite.transform.position = line.GetPosition(1);
        }
    }


}
