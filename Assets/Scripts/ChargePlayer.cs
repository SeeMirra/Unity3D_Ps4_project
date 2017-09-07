using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ChargePlayer : MonoBehaviour {
    //external variable input
    public Ball player_script;  //Script attached to the player object
    public Text text;   //UI Text element

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    //trigger event when collider inside
    private IEnumerator OnTriggerStay()
    {
        if(!player_script.readCharge()) //if ball is not charged
        {
            text.text = "Press 'P' or 'X-Button' to charge the ball"; //change text of ui object
            if (Input.GetButtonDown("Interact"))  //get key input
            {
                player_script.charge(); //charge ball
                yield return new WaitForSeconds(1); //debounce/wait for 1 secound
            }
        }
        else
            text.text = "Ball is already charged";  //change text of ui object
    }

    //trigger event when leaving
    private void OnTriggerExit()
    {
        text.text = ""; //set text to empty
    }
}
