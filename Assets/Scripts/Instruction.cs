using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instruction : MonoBehaviour
{
    [SerializeField] int animationCount;
    Animator anim;
    int animationIndex = 0;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    public void AnimationForward()
    {
        if (animationIndex < animationCount)
        {
            animationIndex++;
            anim.SetInteger("index", animationIndex);
        }
    }

    public void AnimationBackward()
    {
        if (animationIndex > 0)
        {
            animationIndex--;
            anim.SetInteger("index", animationIndex);
        }
    }
}
