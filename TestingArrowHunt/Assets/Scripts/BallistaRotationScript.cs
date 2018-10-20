using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallistaRotationScript : MonoBehaviour {
    public Animator animator;
    bool isTouch = false;
    Vector3 startPosition;
    Vector3 endPosition;
    float angle = 90;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                isTouch = true;
                animator.SetBool("isTouch", isTouch);
                startPosition = touch.position;                
            }
            else if (touch.phase == TouchPhase.Moved)
            {
                isTouch = true;
                endPosition = touch.position;
                Debug.Log("Difference - " + (endPosition.y - startPosition.y));
                animator.SetBool("isTouch", isTouch);
                //Add a logic to create an angle
                angle = endPosition.y - startPosition.y;
                animator.SetFloat("angle", angle);                              
            }
            else if (touch.phase == TouchPhase.Ended)
            {
                isTouch = false;
                animator.SetBool("isTouch", isTouch);
            }
        }
	}
}
