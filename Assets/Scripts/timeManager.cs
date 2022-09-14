using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class timeManager : MonoBehaviour
{
    [Header("Time")]
    public TextMeshProUGUI _timer;
    private float startTime;



    // Start is called before the first frame update
    void Start()
    {
        startTime = Time.time;

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float _tm = Time.time - startTime;

        string minutes = ((int)_tm / 60).ToString();
        string seconds = (_tm % 60).ToString("N2");
        _timer.text = minutes + ":" +seconds;
    }

    
    



}
