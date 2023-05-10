using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class getmove : MonoBehaviour
{
    private bool issprinting => cansprint && Input.GetKey(sprintkey) && Input.GetKey(W);

    [Header("functional options")]
    [SerializeField]
    private bool cansprint = true;

    [Header("controls")]
    private KeyCode sprintkey = KeyCode.LeftShift;
    private KeyCode W = KeyCode.W;
    private float movespd = 12f;
    private float sprintingspd = 30f;
    private float jumpforce = 20f;
    [HideInInspector] public Vector3 dir;
    float hzinput, vinput;
    CharacterController controller;
    [SerializeField] Transform groundcheck;
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
        Debug.Log(velocity);
        jump();
    }



    void Getdirandmove()
    {
        hzinput = Input.GetAxis("Horizontal");
        vinput = Input.GetAxis("Vertical");
        dir = transform.forward * vinput + transform.right * hzinput;
        controller.Move(dir.normalized * (issprinting ? sprintingspd : movespd) * Time.deltaTime);

    }
    

    bool IsGrounded()
    {
        return Physics.CheckSphere(groundcheck.position, .1f, groundmask);
    }
    void Gravity()
    {
        if (!IsGrounded()) velocity.y += gravity * Time.deltaTime;
        else if (velocity.y < 0) velocity.y = 0;
        controller.Move(velocity * Time.deltaTime);
    }

    void jump()
    {
        if (IsGrounded() && Input.GetKeyDown(KeyCode.Space))
            velocity.y += jumpforce;
        controller.Move(velocity * Time.deltaTime);
    }
}
