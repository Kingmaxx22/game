using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class follow : MonoBehaviour
{

    public Transform target;

    public float smoothSpeed = 0.125f;

    private void LateUpdate()
    {
        transform.position = target.position;

    }



}
