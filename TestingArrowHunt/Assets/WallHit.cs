using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallHit : MonoBehaviour {

    public Animator animator;
    public EnemyMovementScript enemyMovement;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        animator.SetBool("isAttack", true);
        enemyMovement.isAttack = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        animator.SetBool("isAttack", false);
        enemyMovement.isAttack = false;
    }
}
