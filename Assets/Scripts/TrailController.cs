using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrailController : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;


    public void Update()
    {
        TrailMovement();
    }
    public void TrailMovement()
    {
        transform.position = target.position+offset;
    }
}
