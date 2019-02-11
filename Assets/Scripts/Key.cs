using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Assets.Pattern;


public class Key : SingleTon<Key>
{
    public class Move : SingleTon<Move>
    {
        public KeyCode Left = KeyCode.A;
        public KeyCode Right = KeyCode.D;
        public KeyCode Up = KeyCode.W;
        public KeyCode Down = KeyCode.S;


    }

    public class Skill : SingleTon<Skill>
    {
        public KeyCode Attack = KeyCode.Mouse0;
        public KeyCode Defense = KeyCode.Space;
        public KeyCode Hook = KeyCode.Mouse1;
        public KeyCode SwordThrowing = KeyCode.R;
    }
}