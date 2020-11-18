using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamerController : MonoBehaviour
{
    public Transform ball;
    public Vector3 offset;
    public Transform cam;



    public void Update()
    {
        transform.position = ball.position+offset;
        cam.LookAt(ball);
        
    }
}
