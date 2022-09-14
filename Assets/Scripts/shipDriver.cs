using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class shipDriver : MonoBehaviour
{
    [Header("Control Settings")]
    private Rigidbody rb;
    public float speed;
    public float TurnSpeed;
    public float gravity;
    public float shipVelocity;

    [Header("Particles")]
    public ParticleSystem smoke;

    //public Text speedDisplay;



    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        ParticleSystem smoke = GetComponentInChildren<ParticleSystem>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Turn();
        Accelerate();
        Drop();

        
        if (Vector3.Dot(transform.up, Vector3.down) > 0)
        {
            Debug.Log("sss");
           
            smoke.Play();
        }
        else
        {
            smoke.Stop();
        }
    }

    

    void Death()
    {
        //stop movement
        //smoke particle start & alarm sound start
        //rotate player (spinning)
        //small explosions & small explosion sounds
        //slow rotation
        //big explosion & big explosion sound
        //model switch to burnt & smoke + fire particles
        //wait 2 seconds
        //radio chatter sound
        //fade to black
        //game over screen


    }

    void Accelerate()
    {
        if (Input.GetKey(KeyCode.W))
        {
            //rb.AddRelativeForce(new Vector3(Vector3.forward.x, 0, Vector3.forward.z)* speed);
            Vector3 forceToAdd = transform.forward;
            forceToAdd.y = 0;
            rb.AddForce(forceToAdd * speed);

        }
        else if (Input.GetKey(KeyCode.S))
        {
            Vector3 forceToAdd = -transform.forward;
            forceToAdd.y = 0;
            rb.AddForce(forceToAdd * speed/3);

        }

        if (Input.GetKey(KeyCode.LeftShift))
        {
            Vector3 forceToAdd = transform.forward;
            forceToAdd.y = 0;
            rb.AddForce(forceToAdd * speed * 1.1f);
        }





        //Vector3 localVelocity = transform.InverseTransformDirection(rb.velocity); //makes velocity local
        //localVelocity.x = 0;
        //rb.velocity = transform.TransformDirection(localVelocity);
        Vector3 locVel = transform.InverseTransformDirection(rb.velocity);

        locVel = new Vector3(0, locVel.y, locVel.z);

        rb.velocity = new Vector3(transform.TransformDirection(locVel).x, rb.velocity.y, transform.TransformDirection(locVel).z);
    }



    void Turn()
    {
        if (Input.GetKey(KeyCode.D))
        {
            rb.AddTorque(Vector3.up * TurnSpeed);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            rb.AddTorque(-Vector3.up * TurnSpeed);
        }
    }

    void Drop()
    {
        rb.AddForce(Vector3.down * gravity);
    }


}
