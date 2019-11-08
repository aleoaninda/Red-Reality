using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pause : MonoBehaviour
{
	public GameObject PauseUI;
	void Update()
	{
		if (Input.GetButtonDown("Pause"))
		{
			PauseUI.SetActive(!PauseUI.activeSelf);
		}
	}
}