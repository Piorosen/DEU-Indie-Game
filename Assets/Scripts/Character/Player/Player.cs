using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{
    Dictionary<KeyCode, ISkill> Skill = new Dictionary<KeyCode, ISkill>();

    protected Attack Attack = new Attack();


    // Start is called before the first frame update
    protected virtual void Start()
    {
        base.Start();

        Skill[Key.Skill.Instance.Attack] = new Attack();
        Skill[Key.Skill.Instance.Hook] = new Hook();
        Skill[Key.Skill.Instance.Defense] = new Defense();
        Skill[Key.Skill.Instance.Attack] = new SwordThrow();

    }



    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 Dir = new Vector2();

        if (InputManager.Keys[Key.Move.Instance.Left])
        {
            Dir.x -= 1;
        }
        if (InputManager.Keys[Key.Move.Instance.Right])
        {
            Dir.x += 1;
        }
        if (InputManager.Keys[Key.Move.Instance.Up])
        {
            Dir.y += 1;
        }
        if (InputManager.Keys[Key.Move.Instance.Down])
        {
            Dir.y -= 1;
        }

        foreach (var i in Key.Skill.Instance.GetType().GetFields())
        {
            var code = (KeyCode)i.GetValue(Key.Skill.Instance);

            Skill[code].OnCastSkill();
        }

        Movement(Dir);
    }
}
