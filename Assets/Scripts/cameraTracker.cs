using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraTracker : MonoBehaviour
{
    [Header("Camera Settings")]
    public Transform player;
    public float cameraSmoothing;
    public float turnSmoothing;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, player.position, cameraSmoothing); //Vector3 for position
        transform.rotation = Quaternion.Slerp(transform.rotation, player.rotation, turnSmoothing); //SPHEREICAL LINEAR INTERPOLATION for angles
        transform.rotation = Quaternion.Euler(new Vector3(0, transform.rotation.eulerAngles.y, turnSmoothing)); //get euler angles, set angles XYZ
    }
}
