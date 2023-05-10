using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class getmove : MonoBehaviour
{
    public float movespd = 3;
    [HideInInspector] public Vector3 dir;
    float hzinput, vinput;
    CharacterController controller;



    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        Getdirandmove();
    }


    void Getdirandmove()
    {
        hzinput = Input.GetAxis("Horizontal")   ;
        vinput = Input.GetAxis("Vertical")      ;

        dir = transform.forward * vinput + transform.right * hzinput;

        controller.Move(dir * movespd * Time.deltaTime);

    }
}
