/*
Name: Marc Domingo
Student ID: 2346778
Chapman Email: mdomingo@chapman.edu
Course Number and Section: 236-03
Assignment: Project 4
This is my own work, and I did not cheat on this assignment.
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// The following class is used to simulate the concept of a score tracker, and contains a function that updates the score recorded on a games' UI.

public class score_controller : MonoBehaviour
{
    public int score = 0;

    public void UpdateScore()
    {
        GetComponent<Text>().text = "Score: " + score;
    }
}
