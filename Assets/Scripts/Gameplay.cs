using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gameplay : MonoBehaviour
{
    public GameObject MenuUI;
    // Start is called before the first frame update
    bool play;

    public void SwitchShowHide()
    {
        play = !play;
        MenuUI.gameObject.SetActive(play);
    }
}
