using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Keypad : MonoBehaviour
{
	public GameObject keypadUI;
    public GameObject player;

    private void Start()
    {
        player = GameObject.Find("player");
    }

    void Update()
	{
        if (Mathf.Abs(player.transform.localPosition.y) < 2.5 && Mathf.Abs(player.transform.localPosition.x) < 2.5) { //If the player is close to the keypad (Tom)
		    if (Input.GetButtonDown("Keypad")) //if Keypad button is pressed down
		    {
		    	keypadUI.SetActive(!keypadUI.activeSelf);
		    }
        }
        else if (!(Mathf.Abs(player.transform.localPosition.y) < 2.5 && Mathf.Abs(player.transform.localPosition.x) < 2.5) && keypadUI.active == true) //If the player is not close to keypad and it's active
        {
            keypadUI.SetActive(!keypadUI.activeSelf);
        }
    }
}