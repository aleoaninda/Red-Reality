using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class keypadControl : MonoBehaviour
{ 
    public static int charCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    void OnMouseUp()
    {
        PuzzleMechanics.playerInput += gameObject.name; //game object name is passed as a string to the input variable
        PuzzleMechanics.charCount += 1; //number of inputs given so far by the player for that puzzle
        GetComponent<SpriteRenderer>().color = new Color(1,0,0); // UI effect
    }

    void OnMouseOver()
    {
        GetComponent<SpriteRenderer>().color = new Color(0,1,0); // UI effect
    }

    void OnMouseExit()
    {
        GetComponent<SpriteRenderer>().color = new Color(1,1,1); //UI effect
    }


}
