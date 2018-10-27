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
        double currentSec = DateTime.Now.Second;
        if (objName.Equals("EnemyR1(Clone)"))
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
                rangeAnim.SetBool("rArrow", rArrow);
                if (!isAttack)
                {
                    target.position = new Vector3(target.position.x - speed, target.position.y);
                }
                else
                {
                    target.position = new Vector3(target.position.x, target.position.y);
                }
            }
        }
        if (objName.Equals("EnemyM1(Clone)") || objName.Equals("EnemyM2(Clone)") || objName.Equals("EnemyM3(Clone)"))
        {
            if (!isAttack)
            {
                target.position = new Vector3(target.position.x - speed, target.position.y);
            }
            else
            {
                target.position = new Vector3(target.position.x, target.position.y);
            }
        }
    }
}
