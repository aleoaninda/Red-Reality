using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManager : MonoBehaviour
{
    bool SceneHasBeenChanged = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!SceneHasBeenChanged) {
            SceneChanger();
        }
    }

    void SceneChanger() {
        if (PuzzleRepo.AllPuzzleSolved())
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("LabRoom");
            UnityEngine.SceneManagement.SceneManager.UnloadSceneAsync("MainMovement");
        }
    }
}
