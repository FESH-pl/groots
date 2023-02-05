using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI countdownDisplay;
    public int countdownTime = 3;

    private GameObject[] players;

    private float matchDuration = 63f;

    void Start()
    {
        StartCoroutine(CountDown());

        players = GameObject.FindGameObjectsWithTag("Player");

    }

    IEnumerator CountDown()
    {
        while(countdownTime > 0)
        {
            countdownDisplay.text = countdownTime.ToString();

            yield return new WaitForSeconds(1f);

            countdownTime--;
        }

        countdownDisplay.text = "GROW!";

        StartCoroutine(MatchTimer(matchDuration));

        yield return new WaitForSeconds(1f);

        countdownDisplay.gameObject.SetActive(false);

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

            PlayerPrefs.SetInt(playerName, score);
        }

        countdownDisplay.gameObject.SetActive(true);
        countdownDisplay.text = "FINISHED!";
        // End the Match
        SceneManager.LoadScene("WinScreen");
    }
}
