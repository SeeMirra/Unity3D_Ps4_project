using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SimonSays : MonoBehaviour {
    //external input variable
    public Animator ExitRight;      //Animator from right exit gate object
    public Animator ExitLeft;       //Animator from left exit gate object
    public Text text;               //ui text element
    public Light top;               //Spotlight object for top field
    public Light right;             //Spotlight object for right field
    public Light bottom;            //Spotlight object for bottom field
    public Light left;              //Spotlight object for left field
    public AudioSource Atop;        //sound source for top field
    public AudioSource Aright;      //sound source for right field
    public AudioSource Abottom;     //sound source for bottom field
    public AudioSource Aleft;       //sound source for left field
    public AudioSource background;  //background music

    //private variables 
    private int seqnumber;          //current sequence number
    private int currentcount;       //number of selected choices
    private int[] seq = new int[8]; //stored sequence to eb repeated
    private bool play;              //if game is being played
    private float waittime;         //waittime for wait function

    // Use this for initialization
    void Start () {
        seqnumber = 1;          //set start sequence to 1
        currentcount = 0;       //set current count to 0
        play = false;           //set play false
	}
	
	// Update is called once per frame
	void Update () {
	}

    //getter for play variable
    public bool getPlay()
    {
        return play;    //return play value
    }

    //function to start a new game
    public void startGame()
    {
        play = true;                            //set play true
        waittime = 1;                           //set waittime 1
        seqnumber = 1;                          //set sequence to 1
        currentcount = 0;                       //set current count to 0
        StartCoroutine(generateNewSeq());       //generate a new sequence
    }

    //function to handle player choice
    public void sendchoice(int choice)
    {
        if (CheckInput(choice))//if player choice is correct
        {
            currentcount++;//increase current count
            if (currentcount == seqnumber)  //if current round has been completted
            {
                if (seqnumber == 5)     //if five rounds have been completted
                {
                    text.text = "Congratulations! The final Gate is now open";  //change text element
                    background.Play();
                    ExitLeft.SetTrigger("open");                                //trigger left gate to open
                    ExitRight.SetTrigger("open");                               //trigger right get to open
                    play = false;                                               //set play to false
                }
                else
                {
                    seqnumber++;                                                //increase sequence number
                    currentcount = 0;                                           //set current count to 0
                    StartCoroutine(generateNewSeq());                           //generate a new sequence
                }
            }
        }
        else
        {
            text.text = "Wrong sequence has been entered. The game will start again.";  //change text element
            reset();                                                                    //reset the game
        }
    }


    //function to check player input
    private bool CheckInput(int input)
    {
        if(seq[currentcount]==input)    //if choice matches the given input
            return true;                //return true
        else
            return false;               //return false
    }

    //function to reset the game
    private void reset()
    {
        seq = new int[8];               //create new sequence array
        seqnumber =1;                   //set sequence number to 1
        currentcount=0;                 //set current count to 0
        play = false;                   //set play to false
    }

    //function to generate a new game sequence
    private IEnumerator generateNewSeq()
    {
        if(seqnumber>1) //if not first round
            yield return new WaitForSeconds(3); //wait 3 secounds
        else
            yield return new WaitForSeconds(1); //wait 1 secound

        for (int i=0; i<seqnumber; i++)     //run through the entire given sequence
        {
            seq[i] = Random.Range(1, 5);    //create random number between 1 and 4
            switch(seq[i])                  //decide what to do in relation to generated number
            {
                case 1:                     //if 1             
                    top.enabled = true;                         //enable top field lighting
                    Atop.Play();                                //play top sound
                    yield return new WaitForSeconds(waittime);  //wait for x secounds
                    top.enabled = false;                        //disable top field lighting
                    break;
                case 2:                     //if 2
                    right.enabled = true;                       //enable right lighting
                    Aright.Play();                              //play right sound
                    yield return new WaitForSeconds(waittime);  //wait for x secounds
                    right.enabled = false;                      //disable right lighting
                    break;
                case 3:                     //if 3
                    bottom.enabled = true;                      //enable bottom lighting
                    Abottom.Play();                             //play bottom sound
                    yield return new WaitForSeconds(waittime);  //wait for x secounds
                    bottom.enabled = false;                     //disable bottom lighting
                    break;
                case 4:                     //if 4
                    left.enabled = true;                        //enable left lighting
                    Aleft.Play();                               //play left sound
                    yield return new WaitForSeconds(waittime);  //wait for x secounds
                    left.enabled = false;                       //disable left lighting
                    break;
            }
        }
    }
}
