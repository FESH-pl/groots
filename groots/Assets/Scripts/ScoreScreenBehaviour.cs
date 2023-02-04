using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class ScoreScreenBehaviour : MonoBehaviour
{
    public GameObject carrotTop;
    public GameObject carrotMiddle;
    public GameObject carrotBottom;
    public GameObject player1;
    public GameObject player2;
    public TextMeshProUGUI winnerText;

    private bool startScoring;
    private float maxPullSpeed = 1f;
    private float pullSpeed = 0.001f;
    private float pullSpeedIncrease = 0.0015f;

    private float amountPulled = 0f;
    private int segments1 = 0;
    private int segments2 = 0;
    private int p1Score = 10;
    private int p2Score = 20;
    private bool p1Done = false;
    private bool p2Done = false;
    private bool endState = false;

    void Awake()
    {
        Instantiate(carrotTop, player1.transform);
        Instantiate(carrotTop, player2.transform);
        StartCoroutine(StartDelay());
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if (startScoring)
        {
            //if (!p1Done)
            //{
                player1.transform.position = new Vector3(player1.transform.position.x, player1.transform.position.y + pullSpeed, player1.transform.position.z);
            //}
            //if (!p2Done)
            //{
                player2.transform.position = new Vector3(player2.transform.position.x, player2.transform.position.y + pullSpeed, player2.transform.position.z);
            //}

            amountPulled += pullSpeed;
            if(segments1 < p1Score && segments1 < (int)amountPulled)
            {
                segments1++;
                GameObject o1 = Instantiate(carrotMiddle, player1.transform);
                o1.transform.position = new Vector3(o1.transform.position.x, o1.transform.position.y - segments1, o1.transform.position.z);
            } else if (segments1 >= p1Score && !p1Done)
            {
                segments1++;
                GameObject o1 = Instantiate(carrotBottom, player1.transform);
                o1.transform.position = new Vector3(o1.transform.position.x, o1.transform.position.y - segments1, o1.transform.position.z);
                p1Done = true;
            }
            if(segments2 < p2Score && segments2 < (int)amountPulled)
            {
                segments2++;
                GameObject o2 = Instantiate(carrotMiddle, player2.transform);
                o2.transform.position = new Vector3(o2.transform.position.x, o2.transform.position.y - segments2, o2.transform.position.z);
            }
            else if (segments2 >= p2Score && !p2Done)
            {
                segments2++;
                GameObject o2 = Instantiate(carrotBottom, player2.transform);
                o2.transform.position = new Vector3(o2.transform.position.x, o2.transform.position.y - segments2, o2.transform.position.z);
                p2Done = true;
            }

            if (!(pullSpeed >= maxPullSpeed))
            {
                pullSpeed += pullSpeedIncrease;
            }

            if (p1Done && p2Done && !endState)
            {
                StartCoroutine(AnnounceWinner());
                endState = true;
            }

        }
    }

    IEnumerator StartDelay()
    {
        yield return new WaitForSeconds(1);
        startScoring = true;
    }
    
    IEnumerator AnnounceWinner()
    {
        yield return new WaitForSeconds(2);
        if(p1Score > p2Score)
        {
            winnerText.text = "Red Player Wins!";
        } else if(p2Score > p1Score)
        {
            winnerText.text = "Blue Player Wins!";
        } else
        {
            //TIE
        }
        
    }
}
