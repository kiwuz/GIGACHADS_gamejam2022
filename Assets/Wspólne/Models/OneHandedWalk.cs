using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneHandedWalk : StateMachineBehaviour
{
    private EnemyController enemyController;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        enemyController = animator.GetComponent<EnemyController>();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //enemyController.navMesh.isStopped = false;
        enemyController.navMesh.SetDestination(enemyController.playerTransform.position);
        if (animator.GetBool("MotherInRange") == true)
        {
            enemyController.navMesh.SetDestination(enemyController.motherTransform.position);
        }
        //Debug.Log(animator.GetBool("MotherInRange"));
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //enemyController.navMesh.isStopped = true;
    }

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
