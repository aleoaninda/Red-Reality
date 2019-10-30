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
        if (Mathf.Abs(player.transform.localPosition.y) < 2.5 && Mathf.Abs(player.transform.localPosition.x) < 2.5) { 
		    if (Input.GetButtonDown("Keypad"))
		    {
		    	keypadUI.SetActive(!keypadUI.activeSelf);
		    }
        }
    }
}