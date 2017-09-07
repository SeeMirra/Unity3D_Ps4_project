using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SSStart : MonoBehaviour {
    //external Interface Variables
    public SimonSays SS;            //Simon Says Script
    public Text text;               //UI Text element
    public AudioSource background;  //background audio source

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    //trigger while collider inside
    private void OnTriggerStay()
    {
        if (!SS.getPlay())                                                      //if no game is being played
        {
            text.text = "Press 'P' or 'X-Button' to start playing Simon Says";  //change text object
            if (Input.GetButtonDown("Interact"))                                //get key input
            {
                background.Stop();                                              //stop background music
                SS.startGame();                                                 //start game of simon says
            }
        }
        else
            text.text = "";                                                     //change text object
    }

    //trigger on exit
    private void OnTriggerExit()
    {
        text.text = ""; //change text object
    }
}
