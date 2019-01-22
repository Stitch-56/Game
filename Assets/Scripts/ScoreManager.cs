using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {
    //sets a static number for the score than can be accessed anywhere
    public static int score;
    //allows access to the score text shown on screen
    Text text;

    // Use this for initialization
    void Start()
        //our start funtion allows us to get the component for text and at the start of the game set it to 0
    {
        text = GetComponent<Text>();
        score = 0;
    }

    // Update is called once per frame
    void Update()
        //in this update funtion if the score is less than 0 then it = 0 just to make sure we dont deal with negative numbers
        //it then allows us to access the text and use it for counting score
    {
        if (score < 0)
            score = 0;

        text.text = "" + score;
    }

    public static void AddPoints (int pointsToAdd)
        //this static funtion allows us to call it and add points using the int we created called pointsToAdd
    {
        score += pointsToAdd;
    }

    public static void Reset()
        //this static funtion allows a reset of points whenever called if i wanted to add a death penalty at some point
    {
        score = 0;
    }
}
