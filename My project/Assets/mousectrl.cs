using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mousectrl : MonoBehaviour
{
    float rotx = 0f;
    float roty = 0f;

    public float sens = 15f;
    // Update is called once per frame
    void Update()
    {
        rotx += Input.GetAxis("Mouse Y") * sens*-1;
        roty += Input.GetAxis("Mouse X") * sens;
        transform.localEulerAngles = new Vector3(rotx, roty, 0);
    }
}
