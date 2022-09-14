using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class uiDisplay : MonoBehaviour
{

    float shipVelocity;
    //string shipSpeed;
    public Rigidbody target;
    public TextMeshProUGUI speedDisplay;
    


    // Start is called before the first frame update
    void Start()
    {
        
    }

  
    void FixedUpdate()
    {
        shipVelocity = target.velocity.magnitude * 3.5f;
        //Mathf.Round(shipVelocity).ToString();
        //Debug.Log(shipVelocity);

        if (speedDisplay != null)
        {
            speedDisplay.text =  shipVelocity.ToString("N0") + "km/h";

            if(Input.GetKey(KeyCode.S))
            {
                speedDisplay.text = shipVelocity.ToString("N0") + "km/h (r.)";
            }
            //speedDisplay.text = string.Format("{0:#.00}", shipVelocity + "km/h");
        }

    }
}
