using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public class MovePlayer : MonoBehaviour {
    [SerializeField] Transform targetPlayer;
    [SerializeField] Direction direct;
    Vector3 targetPos;

    public void OnMouseDown()
    {
        targetPos = targetPlayer.position;
        switch(direct){
            case Direction.UP:            
                targetPos += Vector3.up;
                break;
            case Direction.DOWN:
                targetPos += Vector3.down;
                break;
            case Direction.LEFT:
                targetPos += Vector3.left;
                break;
            case Direction.RIGHT:
                targetPos += Vector3.right;
                break;

            default:
                targetPos += Vector3.zero;
                break;
        }
        targetPlayer.position = targetPos;
    }
}

public enum Direction
{
    UP,
    DOWN,
    LEFT,
    RIGHT
}
