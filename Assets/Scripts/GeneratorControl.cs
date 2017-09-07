using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GeneratorControl : MonoBehaviour {
    //external Interface Variables
    public Animator generator;  //Animator generator
    public Animator supplying;  //Animator target to power
    public Ball player;         //player control script
    public Text text;           //ui text element

    //internalprivate  variables
    private bool active; //generator current state

    // Use this for initialization
    void Start () {
        active = false; //set active to false
	}
	
	// Update is called once per frame
	void Update () {
	}

    //trigger input event to power/unpoer generator
    public IEnumerator OnTriggerStay(Collider obj)
    {
        if (!active && player.readCharge())//generator is not active and ball is charged
        {
            text.text = "Press 'P' or 'X-Button' to charge the generator";    //change text element
            if (Input.GetButtonDown("Interact"))                          //on key input
            {
                active = true;                                  //set generator to active
                player.charge();                                //set player charge

                generator.SetTrigger("power");                  //trigger animation generator
                supplying.SetBool("power_supply", true);        //start animation bridge
                yield return new WaitForSeconds(1);             //wait for 1 secound
            }
        }
        else if (active && !player.readCharge())//generator is active and ball is uncharged
        {
            text.text = "Press 'P' or 'X-Button' to decharge the generator";  //change text element
            if (Input.GetButtonDown("Interact"))                          //on key input
            {
                active = false;                                 //set generator to inactive
                player.charge();                                //set player charge

                generator.SetTrigger("unpower");                //trigger animation generator
                supplying.SetBool("power_supply", false);       //stop animation bridge
                yield return new WaitForSeconds(1);             //wait for 1 secound
            }
        }
        else if (!active && !player.readCharge())                           //if not active and player is not charged
        {
            text.text = "Find a charge to activate the generator";          //change text element
        }
        else if (active && player.readCharge())                             //if active and player is charged
        {
            text.text = "Already charged - Cannot take on another charge";  //change text element
        }
    }

    //trigger on leave
    public void OnTriggerExit(Collider obj)
    {
        text.text = "";     //change text element
    }
}
