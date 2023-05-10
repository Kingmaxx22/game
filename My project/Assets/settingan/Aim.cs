using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class Aim : MonoBehaviour
{
    public Cinemachine.AxisState xaxis, yaxis;
    [SerializeField] Transform camfolpos;





    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        xaxis.Update(Time.deltaTime);
        yaxis.Update(Time.deltaTime);

    }
    private void LateUpdate()
    {
        camfolpos.localEulerAngles = new Vector3(yaxis.Value, camfolpos.localEulerAngles.y, camfolpos.localEulerAngles.z);
        transform.eulerAngles = new Vector3(transform.eulerAngles.x ,xaxis.Value, transform.eulerAngles.z);
    }



}
