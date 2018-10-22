using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovementScript : MonoBehaviour {
    public Transform target;
    public float speed = 3f;
    Rigidbody2D rbody2d;
    string objName;
    SpriteRenderer objSprite;
    public Animator rangeAnim;
    public Animator meleeAnim;
    bool rArrow = false;
    // Use this for initialization
    void Start()
    {
        target = this.transform;
        rbody2d = this.GetComponent<Rigidbody2D>();
        objSprite = this.GetComponent<SpriteRenderer>();
        objName = objSprite.name;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        double currentSec = DateTime.Now.Second;
        if (objName.Equals("EnemyRange"))
        {
            if(currentSec % 2 == 0)
            {
                Debug.Log("Working");
                rArrow = true;
                rbody2d.velocity = Vector3.zero;
                rangeAnim.SetBool("rArrow", rArrow);
                rArrow = false;
            }
            else
            {
                rangeAnim.SetBool("rArrow", rArrow);
                rbody2d.velocity = Vector3.left;
            }
        }
        if (objName.Equals("Enemy1") || objName.Equals("Enemy2") || objName.Equals("Enemy3"))
        {
            rbody2d.velocity = Vector3.left;
        }
    }
}
