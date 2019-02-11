using System.Collections;
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
        Debug.Log(CheckMode());
        if (CheckMode())
        {
            StartCoroutine(Move());

            Disable();
        }
        else
        {
            var a = this.transform.parent.position;
            var b = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            a.z = 0;
            b.z = 0;
            line.SetPositions(new Vector3[]
            {
                a,b
            });

            Sprite.transform.position = b;

            Enable();
        }
    }

    IEnumerator Move()
    {
        var location = this.transform.parent.position;
        var arrive = Sprite.transform.position;

        location.z = 0;
        arrive.z = 0;
        for (float time = 0.5f; time > 0.0f; time -= Time.deltaTime)
        {
            this.transform.parent.Translate(Vector3.Lerp(location, arrive, 0.1f));
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
