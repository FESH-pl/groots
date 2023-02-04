using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    GameObject[] players;

    void Start()
    {
        StartCoroutine(MatchTimer(60));

        players = GameObject.FindGameObjectsWithTag("Player");

    }


    IEnumerator MatchTimer(float matchSeconds)
    {
        float counter = 0;
        while(counter < matchSeconds)
        {
            counter += Time.deltaTime;
            yield return null;
        }

        // Save scores
        foreach(GameObject playerObject in players)
        {
            var player = playerObject.GetComponent<PlayerBehaviour>();
            var playerName = player.playerName;
            var score = player.score;

            Debug.Log(playerName + ": " + score);

            PlayerPrefs.SetInt(playerName, score);
        }

        // End the Match
        SceneManager.LoadScene("WinScreen");
    }
}
