using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    // For testing
    public string playerName;

    private int score = 0;

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    void Start()
    {
        Debug.Log(playerName + " created");
    }


    void Update()
    {
        
    }


    // For testing
    // TODO: remove
    private void OnMouseDown()
    {
        UpdateScore(1);
        Debug.Log(playerName + ":  " + score);
    }

    public void UpdateScore(int points)
    {
        score += points;
    }
}
