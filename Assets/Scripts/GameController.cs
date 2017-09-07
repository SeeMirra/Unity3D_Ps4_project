using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameController : MonoBehaviour {
    //external input variable
    public cameraControl cam;           //camera control script
    public Ball Player;                 //player control script
    public GameObject StartCanvas;      //menu ui elements
    public GameObject GameCanvas;       //game ui elements
    public Text text;                   //text element
    public Text lvldesc;                //level description text element
    public Text button;                 //button text element

    //private variables
    private int level;                  //current level being played

    // Use this for initialization
    void Start () {
        level = 0;                      //set level value to 0
        GameCanvas.SetActive(false);    //set game ui to off
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Quit"))    //get key input
        {
           Application.Quit();              //close application
        }
	}

    //change UI layover to game ui
    public void changeLayover()
    {
        StartCanvas.SetActive(false);   //turn off menu ui
        GameCanvas.SetActive(true);     //turn on game ui
    }

    //change level
    public void changeLevel()
    {
        if (level< 4&&Cursor.visible==false)    //if level is less then 4 and cursor is off
        {
            Camera.main.cullingMask ^= 1 << LayerMask.NameToLayer("Lvl" + level);   //hide current level
            level++;                                                                //increas level
            Camera.main.cullingMask ^= 1 << LayerMask.NameToLayer("Lvl" + level);   //show next level

            switch(level)           //select depending on level value
            {
                case 0: //level 0
                    lvldesc.text = "Objective: Can you beat 'The GAUNTLET'";  //change text object
                    break;
                case 1: //level 1
                    lvldesc.text = "Objective: Reach the transporter";  //change text object
                    break;
                case 2: //level 2
                    lvldesc.text = "Objective: Find a way to reach the other side";     //change text object
                    break;
                case 3: //level 3
                    lvldesc.text = "Objective: Messing with Gravity can be dangerous";      //change text object
                    break;
                case 4: //level 4
                    lvldesc.text = "Objective: Lets play Simon Says.\r\n Beat the game to advance";     //change text object
                    break;
            }
        }
        else if(level>=4)   //if level is 4 or higher
        {
            text.text = "CONGRATULATIONS! \r\n You have beaten the gauntlet.";  //set text to show
            button.text = "Play Again.";                                            //set button text
            GameCanvas.SetActive(false);                                            //turn off game ui
            StartCanvas.SetActive(true);                                            //turn on menu ui
            Camera.main.cullingMask ^= 1 << LayerMask.NameToLayer("Lvl" + level);   //turn off curent level
            level=0;                                                                //set level to 0
            Camera.main.cullingMask ^= 1 << LayerMask.NameToLayer("Lvl" + level);   //turn on level 0

            Player.enabled = false;                                                 //disable player control
            cam.enabled = false;                                                    //disable camera control
            Cursor.visible = true;                                                  //show cursor
        }
    }

    //getter for level variable
    public int getLevel()
    {
        return level;   //return level value
    }

    //wait function
    private IEnumerator wait()
    {
        yield return new WaitForSeconds(5); //wait for 1 secound
    }
}
