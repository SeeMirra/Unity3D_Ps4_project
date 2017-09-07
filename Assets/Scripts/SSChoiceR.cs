using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SSChoiceR : MonoBehaviour {
    //external Interface Variables
    public SimonSays SS;                //Simon Says Script
    public Text text;                   //UI Text element
    public AudioSource Aright;          //audio source
    public Light right;                 //lighting

    //private variables
    private float waittime = 1;         //set waittime to 1
    
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    //trigger while collider inside
    public IEnumerator OnTriggerStay()
    {
        if (SS.getPlay())   //if game is being played
        {
            text.text = "Press 'P' or 'X-Button' to select choice";   //change text object
            if (Input.GetButtonDown("Interact"))                  //on key input
            {
                right.enabled = true;                   //enable lighting
                Aright.Play();                          //play sound
                SS.sendchoice(2);                       //send choice to simon says script
                yield return StartCoroutine(wait());    //wait
                right.enabled = false;                  //disable lighting
            }
        }
    }

    //trigger on exit
    public void OnTriggerExit()
    {
        text.text = ""; //change text object
    }

    //wait function
    private IEnumerator wait()
    {
        yield return new WaitForSeconds(waittime);  //wait for x secounds
    }
}
