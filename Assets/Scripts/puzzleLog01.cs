using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class puzzleLog01 : MonoBehaviour
{
    public static string log_text = ""; // the log entry made by the character Dr Scranton
    public static string correct_answer = "50"; // the correct answer for this puzzle
    public bool solved = false; // true would indicate that this puzzle has been solved, since this would allow us to put constraint on solving sequence
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
        PuzzleMechanics.puzzleCode = correct_answer;
        PuzzleMechanics.puzzle_selected = true;
    }
    void OnMouseOver()
    {
        GetComponent<SpriteRenderer>().color = new Color(0, 1, 0); // on click UI effect
    }

    void OnMouseExit()
    {
        GetComponent<SpriteRenderer>().color = new Color(1, 1, 1); // on click UI effect
    }
}
