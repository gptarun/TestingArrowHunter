using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovementScript : MonoBehaviour
{
    public Transform target;
    private readonly float speed = 0.02f;
    string objName;
    SpriteRenderer objSprite;
    public Animator rangeAnim;
    public Animator meleeAnim;
    bool rArrow = false;
    public bool isAttack = false;
    public WallHealth wallHealth;
    string attackedGameObject;

    // Use this for initialization
    void Start()
    {
        target = this.transform;
        objSprite = this.GetComponent<SpriteRenderer>();
        objName = objSprite.name;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        AttackAndMoveEnemy();              //This calls enemies movement.
    }


    private void OnTriggerEnter2D(Collider2D collision)     // If the entering collider is the Tower/Wall...
    {
        if (meleeAnim != null)
        {
            meleeAnim.SetBool("isAttack", true);
        }
        isAttack = true;
        attackedGameObject = collision.name;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (meleeAnim != null)
        {
            meleeAnim.SetBool("isAttack", false);
        }
        isAttack = false;
    }

    private void AttackAndMoveEnemy()
    {
        double currentSec = DateTime.Now.Second;
        if (objName.Equals("EnemyR1(Clone)"))               //Archer should stop while hitting an arrow.
        {
            if (currentSec % 2 == 0)
            {
                rArrow = true;
                transform.position = new Vector3(target.position.x, target.position.y);
                rangeAnim.SetBool("rArrow", rArrow);
                rArrow = false;
            }
            else
            {
                rangeAnim.SetBool("rArrow", rArrow);            // Archer keeps moving
                if (!isAttack)
                {
                    target.position = new Vector3(target.position.x - speed, target.position.y);
                }
                else
                {
                    target.position = new Vector3(target.position.x, target.position.y);
                    Attack();
                }
            }
        }
        else                        //All keeps moving and hitting xD. 
        {
            if (!isAttack)
            {
                target.position = new Vector3(target.position.x - speed, target.position.y);
            }
            else
            {
                target.position = new Vector3(target.position.x, target.position.y);
                Attack();
            }
        }
    }

    internal void DisableEffects()
    {
        isAttack = false;
        //Need to write code about what will happen if enemy breaks the tower.
    }

    void Attack()
    {
        Debug.Log("Game object "+ attackedGameObject);
        if (wallHealth != null)          //Need to write random archer hit logic to hit wall or anything.
        {
            wallHealth.TakeWallDamage(1);
        }
    }
}
