using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationManager : MonoBehaviour
{
    private Animator mAnimator;

    // Start is called before the first frame update
    void Start()
    {
        mAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (mAnimator != null)
        {
            // Se segurar a tecla 1, ativa a animação "TrIdle"
            if (Input.GetKeyUp(KeyCode.Alpha1))
            {
                mAnimator.SetTrigger("TrIdle");
            }
            // Se segurar a tecla 2, ativa a animação "TrCrouch"
            else if (Input.GetKeyUp(KeyCode.Alpha2))
            {
                mAnimator.SetTrigger("TrCrouch");
            }
            // Se segurar a tecla 3, ativa a animação "TrFaling"
            else if (Input.GetKeyUp(KeyCode.Alpha3))
            {
                mAnimator.SetTrigger("TrFaling");
            }
        }
    }
}
