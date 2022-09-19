using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public Text TextChanger;
    public GameObject btnNext;
    public GameObject btnGoToRace;

    public void Start()
    {

        //adding the dialogue for the queues
        Queue CheckpointRace = new Queue();
        CheckpointRace.Enqueue("Hello Challenger");
        CheckpointRace.Enqueue("Today, you will be taking on the Checkpoint Race");
        CheckpointRace.Enqueue("This race is to test your skills with the vehicle");
        CheckpointRace.Enqueue("You will need to race through the checkpoints to gain more time around the course");
        CheckpointRace.Enqueue("If you run out of time, you will lose the race");
        CheckpointRace.Enqueue("So do not waste time while going aroudnd the course \n GoodLuck");


        Queue BeginnerRace = new Queue();
        BeginnerRace.Enqueue("Hello Challenger");
        BeginnerRace.Enqueue("Today, you will be taking on the Beginner Race");
        BeginnerRace.Enqueue("This race is to test your skills with the vehicle and how you face againsts an opponent");
        BeginnerRace.Enqueue("You will need to race through the course, passing checkpoints and try and beat your opponent");
        BeginnerRace.Enqueue("If you do not beat the opponent, you will not be able to advance through the game");
        BeginnerRace.Enqueue("So do not waste time while going aroudnd the course \n GoodLuck");




        Queue AdvancedRace = new Queue();
        AdvancedRace.Enqueue("Hello Challenger");
        AdvancedRace.Enqueue("Hello Challenger");
        AdvancedRace.Enqueue("Hello Challenger");
        AdvancedRace.Enqueue("Hello Challenger");
        AdvancedRace.Enqueue("Hello Challenger");
        AdvancedRace.Enqueue("So do not waste time while going aroudnd the course \n GoodLuck");


        //checks what scene we are currently in to decide what queue to use
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("DialogueForCheckpointRace"))
        {
            TextChanger.text = CheckpointRace.Dequeue().ToString();
            Debug.Log("You are in checkpointRace");
            if (btnGoToRace == true)
            {
                SceneManager.LoadScene(0);
            }


        }
        else
            if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("DialogueForBeginnerRace"))
        {
            TextChanger.text = BeginnerRace.Dequeue().ToString();
            if(Input.GetMouseButtonDown(0))
            {
                BeginnerRace.Dequeue().ToString();
                Debug.Log("You are in Beginner Race");
            }
            if (btnGoToRace == true)
            {
                SceneManager.LoadScene(0);
            }


        }
        else
            if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("DialogueForAdvancedRace"))
        {
            TextChanger.text = AdvancedRace.Dequeue().ToString();
            Debug.Log("You are in AdvancedRace");
            if(btnGoToRace ==true)
            {
                SceneManager.LoadScene(0);
            }

        }
    }









}
