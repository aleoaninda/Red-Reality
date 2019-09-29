using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleMechanics : MonoBehaviour
{
    public static int PuzzleID;
    public static string puzzleCode = ""; // the answer explected by the machine
    public static string playerInput = ""; // input given by the player
    public static int charCount = 0; // a counter to keep track of how many inputs have been made
    public static bool puzzle_selected = false; // a flag to check if a puzzle has been sent or not
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (puzzleCode.Length>0) { //handling condtion of when the player hasn't picked any puzzle
            if (charCount == puzzleCode.Length)
            {
                Debug.Log("char count: " + charCount + " is puzzle selected: " + puzzle_selected);
                if (playerInput == puzzleCode)
                {
                    SafeZoneController.safeZoneState=2; // execute the operation for expansion
                    Debug.Log("Correct answer: " + playerInput + " Right answer: " + puzzleCode + " char count: " + charCount);
                    playerInput = ""; //player input no longer required
                    charCount = 0; // input length no longer required
                    puzzleCode = ""; //since this puzzle has been solved, it will be removed
                    PuzzleRepo.PuzzleSolved(PuzzleID);
                    PuzzleRepo.FetchPuzzle(); //ask the inventory send out the last unsolved puzzle
                }
                else
                {
                    SafeZoneController.safeZoneState = 0;
                    Debug.Log("Wrong answer: " + playerInput + " Right answer: " + puzzleCode + " char count: " + charCount);
                    playerInput = "";
                    charCount = 0;
                }
            }
        }
        else { //fetch a puzzle from the inventory if they exist
            playerInput = "";
            charCount = 0;
            PuzzleRepo.FetchPuzzle();
            Debug.Log("Fetching puzzle request");
        }
    }
}
