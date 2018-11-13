using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallistaRotationScript : MonoBehaviour {
    public Animator animator;
    bool isTouch = false;
    public Camera myCam;
    private Vector3 screenPos;
    private float angleOffset;
    float angle = 90;
    int calculatedAngle;
    // Use this for initialization
    void Start () {
        myCam = Camera.main;
        animator = GetComponent<Animator>();
        Debug.Log("initialization");
    }
	
	// Update is called once per frame
	void Update () {
        //This fires only on the frame the button is clicked
        if (Input.GetMouseButtonDown(0))
        {
            isTouch = true;
            Debug.Log("Pressed mouse down button");
            screenPos = myCam.WorldToScreenPoint(transform.position);
            Vector3 v3 = Input.mousePosition - screenPos;
            
            angleOffset = (Mathf.Atan2(transform.right.y, transform.right.x) - Mathf.Atan2(v3.y, v3.x)) * Mathf.Rad2Deg;
        }
        //This fires while the button is pressed down
        if (Input.GetMouseButton(0))
        {
            Vector3 v3 = Input.mousePosition - screenPos;
            float angle = Mathf.Atan2(v3.y, v3.x) * Mathf.Rad2Deg;
            calculatedAngle = (int)(angle + angleOffset);
            Debug.Log("angle + angleOffset : " + calculatedAngle);
            animator.SetBool("isTouch", isTouch);
            animator.SetInteger("Angle", calculatedAngle);
        }
        if (Input.GetMouseButtonUp(0) && isTouch==true)
        {
            Debug.Log("Pressed mouse up button");
            isTouch = false;
            animator.SetBool("isTouch", isTouch);
        }
    }
}
