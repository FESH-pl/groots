using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    
    void Start()
    {
        StartCoroutine(MatchTimer(60));
    }


    IEnumerator MatchTimer(float matchSeconds)
    {
        float counter = 0;
        while(counter < matchSeconds)
        {
            counter += Time.deltaTime;
            yield return null;
        }

        // End the Match
        SceneManager.LoadScene("WinScreen");
    }
}
