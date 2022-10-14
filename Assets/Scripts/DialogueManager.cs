using System.Collections;
using System.IO;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using Newtonsoft.Json;
//using UnityEditor.SceneManagement;

public class DialogueManager : MonoBehaviour
{
    public TextAsset json;
    public Text TextChanger;
    public GameObject btnNext;
    [SerializeField] private Queue<string> checkpointRaceDialogue;
    [SerializeField] private Queue<string> beginnerRaceDialogue;
    [SerializeField] private Queue<string> advancedRaceDialogue;
    [SerializeField] private Queue<string> expertDialogue;
    [SerializeField] private TextMeshProUGUI dialogueDisplay;


    private Sprite img1;
    public GameObject MyImage;
    public class Dialogue
    {
        public string Q1 { get; set; }
        public string Q2 { get; set; }
        public string Q3 { get; set; }
        public string Q4 { get; set; }
        public string Q5 { get; set; }
        public string Q6 { get; set; }
        public string Q7 { get; set; }
    }


    public class JSONSetup
    {
        Dialogue CheckpointRace = new Dialogue()
        {
            Q1 = "Hello Challenger",
            Q2 = "Today, you will be taking on the Checkpoint Race",
            Q3 = "This race is to test your skills with the vehicle",
            Q4 = "You will need to race through the checkpoints to gain more time around the course",
            Q5 = "If you run out of time, you will lose the race",
            Q6 = "So do not waste time while going aroudnd the course \nGood Luck!"
        };

        Dialogue BeginnerRace = new Dialogue()
        {
            Q1 = "Hello Challenger",
            Q2 = "Today, you will be taking on the Beginner Race",
            Q3 = "This race is to test your skills with the vehicle and how you face againsts an opponent",
            Q4 = "You will need to race through the course, passing checkpoints and try and beat your opponent",
            Q5 = "If you do not beat the opponent, you will not be able to advance through the game",
            Q6 = "So do not waste time while going aroudnd the course \nGood Luck!"
        };

        Dialogue AdvancedRace = new Dialogue()
        {
            Q1 = "Hello Challenger",
            Q2 = "Today, you will be taking on the Advanced Race",
            Q3 = "This race is to test your skills with the vehicle and how you face an opponent through a track with multiple ways to go",
            Q4 = "You will need to race through the course, passing checkpoints, and try and beat your opponent",
            Q5 = "If you do not beat the opponent, you will not be able to advance through the game",
            Q6 = "There will be two paths on this track, you may take either of them",
            Q7 = "So do not waste time while going around the course \nGoodLuck!"
        };

    }





    public void nextDialogue()
    {

        checkpointRaceDialogue = new Queue<string>();
        checkpointRaceDialogue.Enqueue("Hello Challenger");
        checkpointRaceDialogue.Enqueue("Today, you will be taking on the Checkpoint Race");
        checkpointRaceDialogue.Enqueue("This race is to test your skills with the vehicle");
        checkpointRaceDialogue.Enqueue("You will need to race through the checkpoints to gain more time around the course");
        checkpointRaceDialogue.Enqueue("If you run out of time, you will lose the race");
        checkpointRaceDialogue.Enqueue("So do not waste time while going aroudnd the course \nGood Luck!");


        beginnerRaceDialogue = new Queue<string>();
        beginnerRaceDialogue.Enqueue("Hello Challenger");
        beginnerRaceDialogue.Enqueue("Today, you will be taking on the Beginner Race");
        beginnerRaceDialogue.Enqueue("This race is to test your skills with the vehicle and how you face againsts an opponent");
        beginnerRaceDialogue.Enqueue("You will need to race through the course, passing checkpoints and try and beat your opponent");
        beginnerRaceDialogue.Enqueue("If you do not beat the opponent, you will not be able to advance through the game");
        beginnerRaceDialogue.Enqueue("So do not waste time while going aroudnd the course \nGood Luck!");

        advancedRaceDialogue = new Queue<string>();
        advancedRaceDialogue.Enqueue("Hello Challenger");
        advancedRaceDialogue.Enqueue("Today, you will be taking on the Advanced Race");
        advancedRaceDialogue.Enqueue("This race is to test your skills with the vehicle and how you face an opponent through a track with multiple ways to go");
        advancedRaceDialogue.Enqueue("You will need to race through the course, passing checkpoints, and try and beat your opponent");
        advancedRaceDialogue.Enqueue("If you do not beat the opponent, you will not be able to advance through the game");
        advancedRaceDialogue.Enqueue("There will be two paths on this track, you may take either of them");
        advancedRaceDialogue.Enqueue("So do not waste time while going around the course \nGoodLuck!");

    }
    public void nextConvo()
    {
        //print(dialogue1.Peek());
        

        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("DialogueForCheckpointRace"))
        {






            dialogueDisplay.text = checkpointRaceDialogue.Dequeue().ToString();
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

        //checkpointRaceDialogue.Dequeue();
    }
    public void Start()
    {
        
        nextDialogue();

        //Debug.Log(JSONReader.getJSON(json).num1);
        //adding the dialogue for the queues
        /*Queue CheckpointRace = new Queue();
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
        AdvancedRace.Enqueue("Today, you will be taking on the Advanced Race");
        AdvancedRace.Enqueue("This race is to test your skills with the vehicle and how you face an opponent through a track with multiple ways to go");
        AdvancedRace.Enqueue("You will need to race through the course, passing checkpoints, and try and beat your opponent");
        AdvancedRace.Enqueue("If you do not beat the opponent, you will not be able to advance through the game");
        AdvancedRace.Enqueue("There will be two paths on this track, you may take either of them");
        AdvancedRace.Enqueue("So do not waste time while going around the course \n GoodLuck");*/


        //checks what scene we are currently in to decide what queue to use
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("DialogueForCheckpointRace"))
        {
            //Adds the image for the Character that speaks to you
            MyImage.AddComponent(typeof(Image));
            img1 = Resources.Load<Sprite>("Images/RaceCheckpoint");
            MyImage.GetComponent<Image>().sprite = img1;



            //TextChanger.text = CheckpointRace.Dequeue().ToString();
            Debug.Log("You are in checkpointRace");
           // LoadJson();



        }
        else
            if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("DialogueForBeginnerRace"))
        {
            //Adds the image for the Character that speaks to you
            MyImage.AddComponent(typeof(Image));
            img1 = Resources.Load<Sprite>("Images/RaceBeginner");



            MyImage.GetComponent<Image>().sprite = img1;
            //TextChanger.text = BeginnerRace.Dequeue().ToString();
            if(Input.GetMouseButtonDown(0))
            {
               // BeginnerRace.Dequeue().ToString();
                Debug.Log("You are in Beginner Race");
            }



        }
        else
            if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("DialogueForAdvancedRace"))
        {
            //Adds the image for the Character that speaks to you
            MyImage.AddComponent(typeof(Image));
            img1 = Resources.Load<Sprite>("Images/RaceAdvanced");
            MyImage.GetComponent<Image>().sprite = img1;



           // TextChanger.text = AdvancedRace.Dequeue().ToString();
            Debug.Log("You are in AdvancedRace");


        }


    }
    public void SceneChanger(string SceneName)
    {
        SceneManager.LoadScene(SceneName);
    }

/*    public void LoadJson()
    {
        using(StreamReader r = new StreamReader("file.json"))
        {
            string json = r.ReadToEnd();
            dynamic array = JsonConvert.DeserializeObject(json);
            foreach (var item in array)
            {
                Debug.Log("{0} {1}"+ item.temp+ item.vcc);
            }
        }
    }*/









}
//public static class JSONReader
//{
//    public static JSONexample getJSON(TextAsset json)
//    {
//        JSONexample example = JsonUtility.FromJson<JSONexample>(json.text);
//            return example;
//    }
//}

//[System.Serializable]
//public class JSONexample
//{
//    public int num1;
//}