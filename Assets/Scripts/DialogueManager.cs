using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public Text TextChanger;
    public GameObject btnNext;
    [SerializeField] private Queue<string> checkpointRaceDialogue;
    [SerializeField] private Queue<string> beginnerRaceDialogue;
    [SerializeField] private Queue<string> advancedRaceDialogue;
    [SerializeField] private Queue<string> expertDialogue;
    [SerializeField] private TextMeshProUGUI dialogueDisplay;

    public void nextDialogue()
    {
        checkpointRaceDialogue = new Queue<string>();
        checkpointRaceDialogue.Enqueue("Hello Challenger");
        checkpointRaceDialogue.Enqueue("Today, you will be taking on the Checkpoint Race");
        checkpointRaceDialogue.Enqueue("This race is to test your skills with the vehicle");
        checkpointRaceDialogue.Enqueue("You will need to race through the checkpoints to gain more time around the course");
        checkpointRaceDialogue.Enqueue("If you run out of time, you will lose the race");
        checkpointRaceDialogue.Enqueue("So do not waste time while going aroudnd the course. Good Luck!");


        beginnerRaceDialogue = new Queue<string>();
        beginnerRaceDialogue.Enqueue("Hello Challenger");
        beginnerRaceDialogue.Enqueue("Today, you will be taking on the Beginner Race");
        beginnerRaceDialogue.Enqueue("This race is to test your skills with the vehicle and how you face againsts an opponent");
        beginnerRaceDialogue.Enqueue("You will need to race through the course, passing checkpoints and try and beat your opponent");
        beginnerRaceDialogue.Enqueue("If you do not beat the opponent, you will not be able to advance through the game");
        beginnerRaceDialogue.Enqueue("So do not waste time while going aroudnd the course. Good Luck!");

        advancedRaceDialogue = new Queue<string>();

        advancedRaceDialogue.Enqueue("Hello Challenger");
        advancedRaceDialogue.Enqueue("This part of the game is not implemented.");
        advancedRaceDialogue.Enqueue("So go away.");

    }
    public void nextConvo()
    {
        //print(dialogue1.Peek());
        

        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("DialogueForCheckpointRace"))
        {
            dialogueDisplay.text = checkpointRaceDialogue.Peek();
            Debug.Log("You are in checkpointRace");



        }
        else
            if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("DialogueForBeginnerRace"))
        {
            dialogueDisplay.text = beginnerRaceDialogue.Dequeue().ToString();

            Debug.Log("You are in BeginnerRace");


        }
        else
            if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("DialogueForAdvancedRace"))
        {
            dialogueDisplay.text = advancedRaceDialogue.Dequeue().ToString();
            Debug.Log("You are in AdvancedRace");


        }

        checkpointRaceDialogue.Dequeue();
    }
    public void Start()
    {
        nextDialogue();
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



        }
        else
            if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("DialogueForAdvancedRace"))
        {
            TextChanger.text = AdvancedRace.Dequeue().ToString();
            Debug.Log("You are in AdvancedRace");


        }


    }
    public void SceneChanger(string SceneName)
    {
        SceneManager.LoadScene(SceneName);
    }









}
