using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaminaBar : MonoBehaviour
{
    Transform Anchor;
    Transform staminaBar;
    GameObject player;
    player_movement player_movementScript;
    float staminaPercent;

    


    private void Start()
    {
        staminaBar = gameObject.transform;
        Anchor = transform.Find("Anchor");
        player = GameObject.Find("player");
        player_movementScript = player.GetComponent<player_movement>();

       
    }

    // Update is called once per frame
    void Update()
    {
        //staminaBar.position = new Vector3(Camera.position.x - 18.5f, Camera.position.y -8.9f, Anchor.position.z);
        staminaPercent = player_movementScript.stamina / player_movementScript.maxStamina;
        if (staminaPercent > 1)
        {
            staminaPercent = 1;
        }
        Anchor.localScale = new Vector3(staminaPercent, 1f);
    }
}
