using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shipEngineLoop : MonoBehaviour

{
    [Header("Audio")]
    AudioSource m_AudioSource;
    public float minPitch;
    public float maxPitch;
    float shipSpeed;
    public Rigidbody target;

    // Start is called before the first frame update
    void Start()
    {
        
        m_AudioSource = GetComponent<AudioSource>();
        m_AudioSource.pitch = minPitch;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        shipSpeed = target.velocity.magnitude/15f;
        

        if(shipSpeed<minPitch)
        {
            m_AudioSource.pitch = minPitch;
        }
        else if(shipSpeed > maxPitch)
        {
            m_AudioSource.pitch = maxPitch;
        }
        else
        {
            m_AudioSource.pitch = shipSpeed;
        }
    }
}
