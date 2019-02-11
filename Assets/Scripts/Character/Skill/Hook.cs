using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hook : Skill
{
    public override void OnCastSkill()
    {
        Debug.DrawLine(this.transform.position, Camera.main.ScreenToWorldPoint(Input.mousePosition),Color.red, 0.3f);
    }
}
