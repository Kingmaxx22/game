using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class getmove : MonoBehaviour
{
    public float movespd = 3;
    [HideInInspector] public Vector3 dir;
    float hzinput, vinput;
    CharacterController controller;

    [SerializeField] float groundyoff;
    [SerializeField] LayerMask groundmask;
    Vector3 spherepos;

    [SerializeField] float gravity = -20f;
    Vector3 velocity;




    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        Getdirandmove();
        Gravity();
    }


    void Getdirandmove()
    {
        hzinput = Input.GetAxis("Horizontal")   ;
        vinput = Input.GetAxis("Vertical")      ;

        dir = transform.forward * vinput + transform.right * hzinput;

        controller.Move(dir * movespd * Time.deltaTime);

    }

    bool IsGrounded ()
    {
        spherepos = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        if (Physics.CheckSphere(spherepos, controller.radius = 0.05f,groundmask)) return true ;
        return false;
    }
    void Gravity()
    {
        if (!IsGrounded()) velocity.y += gravity * Time.deltaTime;
        else if (velocity.y <0) velocity.y = -2;


        controller.Move(velocity * Time.deltaTime);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(spherepos, controller.radius = 0.05f);
    }
}
