using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class transporterControlScript : MonoBehaviour {
    //external Interface Variables
    public Animator anim_Origin;        //Animator Origin
    public Animator anim_Target;        //Animator destination
    public Text text;                   //ui text object
    
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
    }

    //Trigger Enter Event(change to trigger stay and call button press check)
    public IEnumerator OnTriggerStay(Collider obj)
    {
        text.text = "Press 'T' or 'triangle-button' to activate transporter";    //change text object
        if (Input.GetButtonDown("Teleport"))                          //on KeyPress t when inside the trigger zone 
        {
            activateTransporter(anim_Target, anim_Origin);  //call transporter animation
            yield return new WaitForSeconds(1);             //wait for 1 secound
        }
    }

    //trigger on exit
    public void OnTriggerExit(Collider obj)
    {
        text.text = "";     //change text object
    }

    //activate transporter animation
    public void activateTransporter(Animator target, Animator origin)
    {
        target.SetTrigger("activate");  //play animation at target 
        origin.SetTrigger("activate");  //play animation at origin    
    }
}
