using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class pause_script : MonoBehaviour
{
    bool ispaused;
    public GameObject PanelUI;
    void Start()
    {
        PanelUI.SetActive(false);
    }
    
    void Update()
    {
        if (Input.GetButtonDown("Pause"))
        {
            Time.timeScale = 0;
            ispaused = true;

            PanelUI.SetActive(!PanelUI.activeSelf);
        }
        else
        {
            Time.timeScale = 1;
            ispaused = false;
        }
    }
}
