using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    [Header("Dependencies: ")]
    [SerializeField] private Animator _anim;

    void OnEnable() 
    {
       GameManager.OnGameStartedorEnded += AnimationControl; 
    }

    void OnDisable() 
    {
        GameManager.OnGameStartedorEnded -= AnimationControl;
    }

    void AnimationControl(bool startOrEnd)
    {
        if(startOrEnd)
        {
            _anim.Play("Running");
        }

        else 
        {
            _anim.Play("Idle");
        }
    }
}
