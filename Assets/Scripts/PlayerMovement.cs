using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //THis is a reference to the Rigidbody component called "rb"
    public Rigidbody rb;

    public float forwardForce = 2000f;
    public float sidewaysForce = 500f;

    //we marked this as "FixedUpdate" because we are using it
    //to mess eith physics.
    void FixedUpdate()
    {
        //Add a forward force
        if(Input.GetKey("w")){
              rb.AddForce(0,0,(forwardForce+300) * Time.deltaTime);
        }
        if(Input.GetKey("s")){
              rb.AddForce(0,0,(-forwardForce-300) * Time.deltaTime);
        }
        if (Input.GetKey("d"))
        {
            rb.AddForce(sidewaysForce  * Time.deltaTime, 0, 0);
        }
         if (Input.GetKey("a"))
        {
            rb.AddForce(-sidewaysForce  * Time.deltaTime, 0, 0);
        }
       
    }
}
