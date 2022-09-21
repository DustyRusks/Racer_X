using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soundManager : MonoBehaviour
{
    public AudioSource menuOpen;
    public AudioSource menuClose;

    public bool paused=false;
    // Start is called before the first frame update
    void Start()
    {
        menuOpen = GetComponentInParent<AudioSource>(menuOpen);
        menuClose = GetComponentInParent<AudioSource>(menuClose);

        
    }



    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Checkpoint"))
        {

        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.Escape)&& paused == false)
        {
            menuOpen.Play();
            paused = true;
        }
        else if (Input.GetKey(KeyCode.Escape) && paused == true)
        {
            //menuOpen.Play();
            paused = true;
            return;
        }

        if (Input.GetKey(KeyCode.R)&&paused==true)
        {
            menuClose.Play();
            paused = false;
            
        }
        else if (Input.GetKey(KeyCode.R) && paused == false)
        {
            paused = false;
            //menuClose.Play();
            return;
        }

    }
}
