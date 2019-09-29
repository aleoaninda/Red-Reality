using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetText : MonoBehaviour
{
    private Text myText;
    void Start(){
        myText =GetComponent<Text>();
    }
    public void SetMyText(float value)
    {
        myText.text = value.ToString("o.##");
    }
}
