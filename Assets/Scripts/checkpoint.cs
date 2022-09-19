using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class checkpoint : MonoBehaviour
{
    [Header("Checkpoints")]
    public GameObject _start;
    public GameObject _end;
    public GameObject[] checkpointArray;

    [Header("Timer")]
    public TextMeshProUGUI _timer;
    public TextMeshProUGUI _bestLap;

    [Header("Settings")]
    public float _laps = 1;
    [Header("Info")]
    private float currentCheckpoint;
    private float currentLap;
    private bool hasStarted;
    private bool hasFinished;
    private float currentLapTime;
    private float bestLapTime;
    private float bestLap;

    // Start is called before the first frame update
    void Start()
    {
        
        currentCheckpoint = 0;
        currentLap = 1;
        hasFinished = false;
        hasStarted = false;

        //currentLap = 0;
        bestLapTime = 0;


    }


    private void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {

        

        if (other.CompareTag("Checkpoint"))
        {
            GameObject thisCheckpoint = other.gameObject;
            //started race
            if (thisCheckpoint == _start && !hasStarted)
            {
                Debug.Log("STARTED");
                hasStarted = true;
            }
            //ended lap or race
            else if (thisCheckpoint == _end && hasStarted)
            {
                //if all laps are finished, race ends
                if (currentLap == _laps)
                {
                    if (currentCheckpoint == checkpointArray.Length)
                    {
                        if(currentLapTime<bestLapTime)
                        {
                            bestLap = currentLap;
                        }

                        Debug.Log("FINISHED");
                        hasFinished = true;
                        //hasStarted=false;
                    }
                    else
                    {
                        Debug.Log("MISSED CHECKPOINTS!");
                    }
                }
                //if all laps not finished, start a new lap. -------------------START NEW LAP
                else if (currentLap < _laps)
                {
                    if (currentCheckpoint == checkpointArray.Length)
                    {
                        if (currentLapTime < bestLapTime)
                        {
                            bestLap = currentLap;
                            bestLapTime = currentLapTime;
                        }

                        currentLap++;
                        currentCheckpoint = 0;
                        currentLapTime = 0;
                        Debug.Log($"STARTED LAP {currentLap} - {Mathf.FloorToInt(currentLapTime / 60)}:{currentLapTime % 60:00.00}");
                    }
                }
                else
                {
                    Debug.Log("MISSED CHECKPOINTS!");
                }
            }

            //loop through checkpoints; compare and check which have been passed

            for (int i = 0; i < checkpointArray.Length; i++)
            {
                if (hasFinished)
                {
                    return;
                }
                //check correct checkpoint
                if (thisCheckpoint == checkpointArray[i] && i == currentCheckpoint)
                {
                    Debug.Log($"PASSED CHECKPOINT - {Mathf.FloorToInt(currentLapTime / 60)}:{currentLapTime % 60:00.00}");
                    currentCheckpoint++;
                }
                //check incorrect checkpoint
                else if (thisCheckpoint == checkpointArray[i] && i != currentCheckpoint)
                {
                    Debug.Log("WRONG CHECKPOINT");
                    currentCheckpoint++;
                }
            }
        }

    }



    // Update is called once per frame
    void FixedUpdate()  //------------------------------TIMER
    {
        string formattedcurrenttime = $"Current: {Mathf.FloorToInt(currentLapTime / 60)} :{currentLapTime % 60:00.00} | Lap\n {currentLap}/{_laps}";
        string formattedBestttime = $"Best: {Mathf.FloorToInt(bestLapTime / 60)}:{bestLapTime % 60:00.00} | Lap {bestLap}";
        if (hasStarted&&!hasFinished)
        {
            currentLapTime += Time.deltaTime;
            _timer.text = formattedcurrenttime;
            _bestLap.text = formattedBestttime;

            if (bestLap == 0)
            {
                bestLap = 1;
            }
            if(hasStarted)
            {
                if(bestLap==currentLap)
                {
                    bestLapTime = currentLapTime;
                }
            }
        }
    }
}
