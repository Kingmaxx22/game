using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    public float timer  = 3;
    public bool timeron = false;

    private void Start()
    {
        timeron = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (timeron)
        {
            if (timer > 0)
            {
                timer -= Time.deltaTime;

            }
            else { }
            

        }
        if (Input.GetKeyDown("space"))
        {
            GetComponent<Rigidbody>().velocity = new Vector3(0, 5, 0);


        }

        
    }
}
