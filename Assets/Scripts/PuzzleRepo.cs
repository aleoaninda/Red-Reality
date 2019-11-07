using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleRepo : MonoBehaviour
{
    public static string[] log_text = new string[8]; // the log entry made by the character Dr Scranton
    public static string[] correct_answer = new string[8]; // the correct answer for this puzzle
    public static bool[] solved = new bool[8]; // true would indicate that this puzzle has been solved, since this would allow us to put constraint on solving sequence
    public static List<int> PuzzleList = new List<int>();

    // Start is called before the first frame update
    void Start()
    {
        //all the log texts
        log_text[0] = "Date: September 19, 2000 @My name is Robert Scranton, former researcher at Foundation Site - 120.It has been(gibberish) 10 days I think I do not know, actually, I (gibberish) I can't remember. @Oh god I dont know whats happened, I dont know where I am! @I m really hungry thirsty, too. I think I should be dead from dehydration by now but I dont know.";
        log_text[1] = "Date: September 25, 2000 @I found a picture of Anna in my pocket. I almost forgot it was Anna’s birthday today. @Is she 49? 50? I am not sure (gibberish) not sure about anything @Hi, Anna, I'm still here, I'm still here. I'm coming back, okay?";
        log_text[2] = "Date: October 15, 2000 @I haven't really recorded much in the past few weeks @gotta keep it together @I've been (gibberish) busy. trying to learn more about the place I'm in. My prison. My kingdom all my own. Heh, King Robert. God, I stink. Is there even air in this goddamn place? Stinky King Robert, king of GODDAMN NOTHING FUCK.";
        log_text[3] = "Date: December 20, 2000 @My name is… Robert Scranton. I am a former Head Researcher of Site… 120, a Foundation facility dedicated to studying various reality-bending SCPs, for the purpose of developing more advanced countermeasures towards such threats. @I need to keep a record. There might be some poor bastard in the future who ends up like me, and maybe... I can help stop that from happening. @That's all I have going for me right now, and I really need something to go for";
        log_text[4] = "Date: January 18, 2001 @I don't know if we could… contain wherever I am in. It's… definitely not on Earth. To be honest I don't know where it is. I… I think it has do something with the Stabilizer prototype. I came into this place because of some really bad reality-bending accident and… don't know if there's no exit yet. @I went 200 feet back and forth from the machine, and yet there seems to be no end to this MADNESS. Sometimes it feels like I am stuck in a position even when I am moving my feet. I lost track of how much I had walked so far @I've been thinking I might be walking on… some sort of… flat ground. As far as I could see, and it seems I could walk in a straight, flat path. But, if my hypothesis is correct, and this really is some sort of reality… void, then there shouldn't be anything to walk on.";
        log_text[5] = "Date: February 8, 2001 @Okay, this place… if we're using the standard Hume scale, I'm pretty sure I'm in a reality where the Hume Field is… four… ish. Yeah, really, really, really fucking low, so… Like I said above, space-time exists on a very minuscule scale @However, if we crank it up to eight and then turn on the Hume Field Stabilizer then I might be able to buy some more time ...for me and red";
        log_text[6] = "Date: March 19, 2001 @Adding on from the last entry. I'm… I'm not sure how my biology will react in such a low Hume concentration, actually. @I mostly worked with higher than average Hume Fields, and the reality benders we tested never had a Field lower than 8. This… this is gonna be a first. An all-time first. Maybe I should crank it up higher?";
        log_text[7] = "Date: March 27, 2001 @I was lying. I was lying, last log… I… I'm lying to myself. My own body, and… little red here too… @I'm… I'm gonna go for now, I have some… some calculation to do again. Red, Anna, take note I'm using Kejel's Second, Third, and Fourth Laws, got it? Use… use 8 as the surrounding, and tune the Frequency Generator… somewhere in between 1 and 1.5, use the Second Law's error estimation correction, and my internal as… as… as… shit. I'm not done yet.";

        //all the puzzle answers
        correct_answer[0] = "";
        correct_answer[1] = "50";
        correct_answer[2] = "4";
        correct_answer[3] = "";
        correct_answer[4] = "400";
        correct_answer[5] = "8";
        correct_answer[6] = "8";
        correct_answer[7] = "815";

        //all the non-puzzles will be set to solved, since they are not part of the puzzle mechanics
        solved[0]=true;
        solved[3]=true;

    }

    // Update is called once per frame
    void Update()
    {
    }

    public static void AddPuzzle(int PuzzleID) {
        if (correct_answer[PuzzleID].Length > 0) //checks if it is a puzzle or a non-puzzle
        {
            PuzzleList.Add(PuzzleID);
            PuzzleList.Sort(); // esnures the puzzles are solved in a sequence
        }
    }

    public static void FetchPuzzle()
    {
        if (PuzzleList.Count > 0) {
            int PuzzleID = PuzzleList[0];
            Debug.Log("Puzzle in the first index is "+PuzzleID);
            if (PrerequisiteSolved(PuzzleID)) {
                PuzzleList.Remove(PuzzleID);
                PuzzleMechanics.PuzzleID = PuzzleID;
                PuzzleMechanics.puzzleCode = correct_answer[PuzzleID];
            }
        }
    }

    public static void PuzzleSolved(int PuzzleID) {
        solved[PuzzleID] = true;
        PuzzleList.Remove(PuzzleID);
    }

    public static bool PrerequisiteSolved(int PuzzleID) {
        for (int i = 0; i < PuzzleID; i++) {
            if (solved[i] == false) {
                return false;
            }
        }
        return true;
    }

    public static bool AllPuzzleSolved() {
        for (int i = 0; i < solved.Length; i++) {
            if (solved[i] == false) {
                return false;
            }
        }
        return true;
    }
}
