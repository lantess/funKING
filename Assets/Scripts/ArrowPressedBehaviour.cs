using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowPressedBehaviour : StateMachineBehaviour
{
    public int max;
    public int offset;
    

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if(animator.GetInteger("Last")==offset)
        {
            animator.SetInteger("No", 1);
            animator.SetInteger("Last", offset + 1);
        }
        else if (animator.GetInteger("Last") == offset + 1)
        {
            animator.SetInteger("No", 0);
            animator.SetInteger("Last", offset);
        }
        else
        {
            int r = Random.Range(0, max);
            animator.SetInteger("No", r);
            animator.SetInteger("Last", offset + r);
        }
        
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    //override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    //override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
