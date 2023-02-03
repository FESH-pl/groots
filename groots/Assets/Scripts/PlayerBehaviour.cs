using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    // For testing
    public string playerName;

    private int score = 0;

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    private void OnCollisionEnter2D(Collision2D item)
    {

    }

    private void UpdateScore(int points)
    {
        score += points;
    }

    // For testing
    // TODO: remove
    private void OnMouseDown()
    {
        UpdateScore(1);
        Debug.Log(playerName + ":  " + score);
    }

}
