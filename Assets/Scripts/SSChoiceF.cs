using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SSChoiceF : MonoBehaviour {
    //external Interface Variables
    public SimonSays SS;            //Simon Says Script
    public Text text;               //UI Text element
    public AudioSource Afront;      //audio source
    public Light front;             //lighting

    //private variables
    private float waittime = 1;     //set waittime to 1
    
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    //trigger while collider is inside
    public IEnumerator OnTriggerStay()
    {
        if (SS.getPlay())   //check if game is being played
        {
            text.text = "Press 'P' or 'X-Button' to select choice";   //change text object
            if (Input.GetButtonDown("Interact"))                  //on key input
            {
                front.enabled = true;                   //enable lighting
                Afront.Play();                          //play sound
                SS.sendchoice(1);                       //send choice to simon says script
                yield return StartCoroutine(wait());    //wait
                front.enabled = false;                  //disable lighting
            }
        }
    }

    //trigger on exit
    public void OnTriggerExit()
    {
        text.text = "";     //change text object
    }

    //wait function
    private IEnumerator wait()
    {
        yield return new WaitForSeconds(waittime);  //wait for x secounds
    }
}
