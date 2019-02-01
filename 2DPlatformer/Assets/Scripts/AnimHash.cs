using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimHash : MonoBehaviour {
    public static int Speed = Animator.StringToHash("Speed");
    public static int Attack = Animator.StringToHash("IsAttack");
    public static int Jump = Animator.StringToHash("IsJump");
    public static int Dead = Animator.StringToHash("IsDead");
    public static int VertSpeed = Animator.StringToHash("VertSpeed");
    public static int Move = Animator.StringToHash("IsMove");
    public static int View = Animator.StringToHash("ViewNumber");
}
