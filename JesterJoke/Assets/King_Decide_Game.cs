using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class King_Decide_Game : StateMachineBehaviour
{
    int randomGame;
    int previousInt;

    //OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        GameObject.Find("NPC_Manager").GetComponent<NPC_Manager>().lookAtMe();

        randomGame = Random.Range(1, 4);
        while(previousInt == randomGame)
        {
            randomGame = Random.Range(1, 4);
        }
        previousInt = randomGame;
    }

    //OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (randomGame == 1)
        {
            animator.GetComponent<King_Man>().textBox.SetActive(true);
            animator.GetComponent<King_Man>().jugglingIcon.SetActive(true);
            animator.GetComponent<King_Man>().balloonsIcon.SetActive(false);
            animator.GetComponent<King_Man>().letterIcon.SetActive(false);
            animator.GetComponent<King_Man>().selectedGame = randomGame;
        }

        if (randomGame == 2)
        {
            animator.GetComponent<King_Man>().textBox.SetActive(true);
            animator.GetComponent<King_Man>().jugglingIcon.SetActive(false);
            animator.GetComponent<King_Man>().balloonsIcon.SetActive(true);
            animator.GetComponent<King_Man>().letterIcon.SetActive(false);
            animator.GetComponent<King_Man>().selectedGame = randomGame;
        }
        if (randomGame == 3)
        {
            animator.GetComponent<King_Man>().textBox.SetActive(true);
            animator.GetComponent<King_Man>().jugglingIcon.SetActive(false);
            animator.GetComponent<King_Man>().balloonsIcon.SetActive(false);
            animator.GetComponent<King_Man>().letterIcon.SetActive(true);

            animator.GetComponent<King_Man>().selectedGame = randomGame;
        }
    }

    //OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.GetComponent<King_Man>().textBox.SetActive(false);
        animator.GetComponent<King_Man>().jugglingIcon.SetActive(false);
        animator.GetComponent<King_Man>().balloonsIcon.SetActive(false);
        animator.GetComponent<King_Man>().letterIcon.SetActive(false);

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
