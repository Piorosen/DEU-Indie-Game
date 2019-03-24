using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hook : Skill
{
    public float HookRange = 200;
    public float HookSpeed = 10.0f;
    public bool Hit = false;
    public bool AnimEnd = true;

    public bool OverRange = false;

    public Transform PlayerPos;

    LineRenderer line;
    

    protected override void Awake()
    {
        base.Awake();
        line = GetComponent<LineRenderer>();
        line.startWidth = 10f;
        line.endWidth = 10f;
    }

    public override void OnCastSkill()
    {
        // 참 : 유저가 날라감.
        // 거짓 : 앵커가 날라감.
        
        if (AnimEnd == true)
        {
            AnimEnd = false;
            if (Hit == true)
            {
                StartCoroutine(EndHook(OverRange));
            }
            else
            {
                OverRange = false;
                line.enabled = true;
                Sprite.enabled = true;
                StartCoroutine(StartHook());
            }
        }
    }

    IEnumerator StartHook()
    {
        // 현재 내 위치
        var location = PlayerPos.position;
        // 마우스 위치
        var arrive = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        /// Z축 삭제
        location.z = 0;
        arrive.z = 0;

        // Hook 길이 만큼 길이 변경함.
        arrive = location + (arrive - location).normalized * HookRange;

        // 광선 사격
        var ray = Physics2D.RaycastAll(location, arrive - location, HookRange);

        // 충돌 처리 체크
        foreach (var check in ray)
        {
            // WalkAble 블럭만 체크함 == 9, 몬스터 13
            if (check.collider != null && check.collider.gameObject.layer == 9)
            {
                // 발견하면은 arrive를 변경함 위치를
                // 기존보다 더 짧아짐
                arrive = check.point;
                arrive.z = 0;

                Hit = true;

                break;
            }
        }

        // 갈고리 이동 모션
        yield return HookMove(location, arrive);

        if (OverRange != true)
        {
            if (Hit == false)
            {
                yield return EndHook(true);
            }
        }

        AnimEnd = true;
    }

    IEnumerator EndHook(bool whoFly)
    {
        if (whoFly)
        {
            yield return HookBack();
        }
        else
        {
            yield return HookFront();
        }
        line.enabled = false;
        Sprite.enabled = false;

        Hit = false;
        AnimEnd = true;
    }


    // 갈고리가 플레이어 에게 다시 돌아옴.
    IEnumerator HookBack()
    {
        var range = line.GetPosition(1) - line.GetPosition(0);

        while (range.magnitude > HookSpeed * Time.deltaTime)
        {
            range = line.GetPosition(1) - line.GetPosition(0);
            var lastPos = line.GetPosition(1) - range.normalized * HookSpeed * Time.deltaTime;
            SetHookPosition(lastPos);
            yield return new WaitForEndOfFrame();
        }
    }
    // 플레이어가 갈고리 따라 이동
    IEnumerator HookFront()
    {
        var location = PlayerPos.position;
        var arrive = Sprite.transform.position;
        location.z = 0;
        arrive.z = 0;

        var range = arrive - location;
        float totalTime = range.magnitude / HookSpeed;

        for (float time = totalTime; time > 0.0f; time -= Time.fixedDeltaTime)
        {
            var conv = new Vector2(range.x, range.y) * Time.fixedDeltaTime;
            //PlayerPos.position += new Vector3(conv.x, conv.y);
            PlayerPos.GetComponent<Rigidbody2D>().velocity = conv.normalized * HookSpeed;
            //transform.parent.GetComponent<Rigidbody2D>().velocity = conv.normalized * HookSpeed;
            yield return new WaitForFixedUpdate();
        }
        Sprite.transform.position = location;
    }
    void SetHookPosition(Vector3 pos)
    {
        pos.z = 0;
        line.SetPositions(new Vector3[]
            {
                PlayerPos.position,
                pos
            });


        Sprite.transform.position = pos;
    }

    IEnumerator HookMove(Vector3 l, Vector3 a)
    {
        // 길이 구함.
        var range = a - l;
        // 스칼라값 구하고 속도를 나눔
        float totalTime = range.magnitude / HookSpeed;

        // 특정 속도에 맞춰서 지속적인 계속 움직임.
        for (float time = totalTime; time > 0.0f; time -= Time.deltaTime)
        {
            // 마지막 이동한 위치 구함.
            var lastPos = l + range * (-(time - totalTime) / totalTime);
            

            // 위치 설정
            SetHookPosition(lastPos);
            
            yield return new WaitForEndOfFrame();
        }
        SetHookPosition(a);
    }

    


    void LateUpdate()
    {
        if (line.enabled == true)
        {
            line.SetPosition(0, PlayerPos.position);
            Sprite.transform.position = line.GetPosition(1);

            if ((Sprite.transform.position - PlayerPos.position).magnitude > HookRange)
            {
                OverRange = true;
                OnCastSkill();
            }
        }
    }


}
