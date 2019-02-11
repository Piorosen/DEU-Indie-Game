using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{
    Dictionary<KeyCode, Skill> Skill = new Dictionary<KeyCode, Skill>();

    public Skill Sword;
    public Skill Defense;
    public Skill Hook;
    public Skill SwordThrow;


    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();

        Skill[Key.Skill.Instance.Attack] = Sword;
        Skill[Key.Skill.Instance.Hook] = Hook;
        Skill[Key.Skill.Instance.Defense] = Defense;
        Skill[Key.Skill.Instance.SwordThrowing] = SwordThrow;
    }

    protected override void SetAnimation(Vector2 dir)
    {
        base.SetAnimation(dir);

        foreach (var value in Skill.Values)
        {
            value.Sprite.flipX = this.GetComponent<SpriteRenderer>().flipX;
        }
    }


    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 Dir = new Vector2();

        if (Input.GetKey(Key.Move.Instance.Left))
        {
            Dir.x -= 1;
        }
        if (Input.GetKey(Key.Move.Instance.Right))
        {
            Dir.x += 1;
        }
        if (Input.GetKey(Key.Move.Instance.Up))
        {
            Dir.y += 1;
        }
        if (Input.GetKey(Key.Move.Instance.Down))
        {
            Dir.y -= 1;
        }

        foreach (var i in Key.Skill.Instance.GetType().GetFields())
        {
            var code = (KeyCode)i.GetValue(Key.Skill.Instance);
            if (InputManager.Keys[code])
            {
                //Debug.Log(code);
                //foreach (var value in Skill.Values)
                //{
                //    value.Sprite.enabled = false;
                //}
                InputManager.Keys[code] = false;
                Skill[code].OnCastSkill();
            }
        }

        Movement(Dir);
    }
}
