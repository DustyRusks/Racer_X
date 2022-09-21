using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class checkpoint : MonoBehaviour
{
    [Header("Checkpoints")]
    public GameObject _start;
    public GameObject _end;
    public GameObject[] checkpointArray;

    [Header("Timer")]
    public TextMeshProUGUI _timer;
    public TextMeshProUGUI _bestLap;

    [Header("Countdown_Timer")]
    public float timeValue = 90;
    public TextMeshProUGUI _countdownTimer;
    public float checkpoiintAddTime=5f;

    [Header("Settings")]
    public float _laps = 1;
    [Header("Info")]
    private float currentCheckpoint;
    private float currentLap;
    private bool hasStarted;
    private bool hasFinished;
    private bool passedCheckpoint=false;
    private float currentLapTime;
    private float bestLapTime;
    private float bestLap;

    public Stack Checkpoints = new Stack();

    // Start is called before the first frame update
    void Start()
    {
        
        currentCheckpoint = 0;
        currentLap = 1;
        hasFinished = false;
        hasStarted = false;

        //currentLap = 0;
        bestLapTime = 0;
        //Checkpoints.Push("Start/End");
        Checkpoints.Push("Checkpoint1");
        Checkpoints.Push("Checkpoint2");
        Checkpoints.Push("Checkpoint3");
        Checkpoints.Push("Checkpoint4");


    }

    public void DisplayCountdownTime(float displayTime)
    {
        if(displayTime<0)
        {
            displayTime = 0;
            SceneManager.LoadScene(6);
        }


        //else if (displayTime>0)
        //{
            
        //}

        float _minutes = Mathf.FloorToInt(displayTime/60);
        float _seconds = Mathf.FloorToInt(displayTime%60);
        float _milliseconds = displayTime%1*100;
        _countdownTimer.text = string.Format("{0:00}:{1:00}:{2:00}", _minutes, _seconds, _milliseconds);
    }


    private void Update()
    {
        
        //if(timeValue>0)
        //{
        //    timeValue -= Time.deltaTime;
        //}
        //else
        //{
        //    timeValue = 0;
        //}
        //DisplayCountdownTime(timeValue);
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
                //passedCheckpoint = true;
                Debug.Log(Checkpoints.Count);
                Checkpoints.Pop();
                
            }
            //ended lap or race
            else if (thisCheckpoint == _end && hasStarted)
            {
                //if all laps are finished, race ends
                if (currentLap == _laps)
                {
                    if (currentCheckpoint == checkpointArray.Length)
                        //if (currentCheckpoint == Checkpoints.Count)
                        {
                        if(currentLapTime<bestLapTime)
                        {
                            bestLap = currentLap;
                        }

                        Debug.Log("FINISHED");
                        hasFinished = true;
                        SceneManager.LoadScene(5);
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

                    //trying to use the stack
                   // if (currentCheckpoint == Checkpoints.Count)
                    {
                        Checkpoints.Pop();
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
                     passedCheckpoint = true;

                 }
                 //check incorrect checkpoint
                 else if (thisCheckpoint == checkpointArray[i] && i != currentCheckpoint)
                 {
                     Debug.Log("WRONG CHECKPOINT");
                     currentCheckpoint++;
                 }
             }
            //tring to use the stack
            /* for (int i = 0; i < Checkpoints.Count; i++)
             {
                 if (hasFinished)
                 {
                     return;


                 }
                 else
                 //check correct checkpoint
                 if (thisCheckpoint == Checkpoints.Count)
                 {
                     Debug.Log($"PASSED CHECKPOINT - {Mathf.FloorToInt(currentLapTime / 60)}:{currentLapTime % 60:00.00}");
                     currentCheckpoint++;
                     passedCheckpoint = true;
                     Checkpoints.Pop();

                 }
                 //check incorrect checkpoint
                 else if (thisCheckpoint == checkpointArray[i] && i != currentCheckpoint)
                 {
                     Debug.Log("WRONG CHECKPOINT");
                     currentCheckpoint++;
                 }
             }*/
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

            if (timeValue > 0)
            {
                timeValue -= Time.deltaTime;
            }
            else
            {
                timeValue = 0;
            }

            if (passedCheckpoint == true)
            {
                timeValue = timeValue + checkpoiintAddTime;
                passedCheckpoint = false;
            }
            DisplayCountdownTime(timeValue);
        }
    }
}
