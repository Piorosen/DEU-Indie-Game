using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hook : Skill
{
    public float HookRange = 200;
    public float HookSpeed = 10.0f;
    public bool Hit = false;

    LineRenderer line;

    BoxCollider2D a;

    protected override void Awake()
    {
        base.Awake();
        line = GetComponent<LineRenderer>();
        line.startWidth = 10f;
        line.endWidth = 10f;
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
         Debug.Log("Hit");
        if (collision.gameObject.layer != 11)
        {
            Hit = true;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Hit");
        if (collision.gameObject.layer != 11)
        {
            Hit = true;
        }
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
            Hit = false;

            var location = this.transform.parent.position;
            var arrive = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            
            location.z = 0;
            arrive.z = 0;

            arrive = location + (arrive - location).normalized * HookRange;

            var ray = Physics2D.RaycastAll(location, arrive, HookRange);
            
            StartCoroutine(HookMove(location, arrive));
            Enable();
        }
    }
    IEnumerator DragHook()
    {
        var range = line.GetPosition(1) - line.GetPosition(0);

        while (range.magnitude > HookSpeed * Time.deltaTime)
        {
            range = line.GetPosition(1) - line.GetPosition(0);
            var lastPos = line.GetPosition(1) - range.normalized * HookSpeed * Time.deltaTime;
            line.SetPositions(new Vector3[]
            {
                this.transform.parent.position,
                lastPos
            });
            Sprite.transform.position = lastPos;
            yield return new WaitForEndOfFrame();
        }

        Disable();
    }

    IEnumerator HookMove(Vector3 l, Vector3 a)
    {
        if (CheckMode())
        {
            yield break;
        }
        var range = a - l;
        float totalTime = range.magnitude / HookSpeed;
        for (float time = totalTime; time > 0.0f; time -= Time.deltaTime)
        {
            var lastPos = l + range * (-(time - totalTime) / totalTime);
            line.SetPositions(new Vector3[]
            {
                this.transform.parent.position,
                lastPos
            });
            Sprite.transform.position = lastPos;

            if (Hit == true)
            {
                yield break;
            }
            yield return new WaitForFixedUpdate();
        }

        yield return DragHook();
    }


    IEnumerator Move()
    {
        var location = transform.parent.position;
        var arrive = Sprite.transform.position;
        location.z = 0;
        arrive.z = 0;
        var range = arrive - location;

        while (range.magnitude > 100)
        {
            if (Hit == false)
            {
                yield break;
            }
            location = transform.parent.position;
            location.z = 0;
            range = arrive - location;

            var conv = new Vector2(range.x, range.y);
            transform.parent.GetComponent<Rigidbody2D>().velocity = conv.normalized * HookSpeed;
            yield return new WaitForFixedUpdate();
        }
        Sprite.transform.position = location;
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
