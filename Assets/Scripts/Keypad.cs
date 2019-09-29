using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Keypad : MonoBehaviour
{
	public GameObject keypadUI;
	void Update()
	{
		if (Input.GetButtonDown("Keypad"))
		{
			keypadUI.SetActive(!keypadUI.activeSelf);
		}
	}
}