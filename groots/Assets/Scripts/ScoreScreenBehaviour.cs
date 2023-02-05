using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class ScoreScreenBehaviour : MonoBehaviour
{
    public GameObject p1carrotTop;
    public GameObject p1carrotMiddle;
    public GameObject p1carrotBottom;
    public GameObject p2carrotTop;
    public GameObject p2carrotMiddle;
    public GameObject p2carrotBottom;
    public GameObject player1;
    public GameObject player2;
    public TextMeshProUGUI winnerText;
    public GameObject fireworks;
    public GameObject backButton;

    public GameObject background;
    public GameObject pot1;
    public GameObject pot2;

    public AudioSource soundEffect;
    public AudioClip cymbalSound;

    private bool startScoring;
    private float maxPullSpeed = 1f;
    private float pullSpeed = 0.001f;
    private float pullSpeedIncrease = 0.0015f;

    private float amountPulled = 0f;
    //private int segments1 = 0;
    //private int segments2 = 0;
    private int p1Score = 10;
    private int p2Score = 20;
    private bool p1Done = false;
    private bool p2Done = false;
    private bool endState = false;

    void Awake()
    {
        p1Score = PlayerPrefs.GetInt("p1");
        p2Score = PlayerPrefs.GetInt("p2");
        //Instantiate(p1carrotTop, player1.transform);
        //Instantiate(p2carrotTop, player2.transform);
        
        if(p1Score < 1)
        {
            p1Score = 1;
        }
        for(int i = 0; i<p1Score; i++)
        {
            GameObject o1 = Instantiate(p1carrotMiddle, player1.transform);
            o1.transform.localPosition = new Vector3(-0.3f, ((float)i*-9.23f)-12.515f, o1.transform.position.z);
        }
        GameObject o = Instantiate(p1carrotBottom, player1.transform);
        o.transform.localPosition = new Vector3(-0.3f, ((float)p1Score * -9.23f) - 12.515f, o.transform.position.z);

        if (p2Score < 1)
        {
            p2Score = 1;
        }
        for (int i = 0; i < p2Score; i++)
        {
            GameObject o2 = Instantiate(p2carrotMiddle, player2.transform);
            o2.transform.localPosition = new Vector3(0.3f, ((float)i * -9.23f) - 12.515f, o2.transform.position.z);
        }
        o = Instantiate(p2carrotBottom, player2.transform);
        o.transform.localPosition = new Vector3(0.3f, ((float)p2Score * -9.23f) - 12.515f, o.transform.position.z);

        StartCoroutine(StartDelay());
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if (startScoring)
        {
            if (!p1Done)
            {
                player1.transform.position = new Vector3(player1.transform.position.x, player1.transform.position.y + pullSpeed, player1.transform.position.z);
            }
            if (!p2Done)
            {
                player2.transform.position = new Vector3(player2.transform.position.x, player2.transform.position.y + pullSpeed, player2.transform.position.z);
            }

            amountPulled += pullSpeed;
            /*if(segments1 < p1Score && segments1 < (int)amountPulled)
            {
                segments1++;
                GameObject o1 = Instantiate(p1carrotMiddle, player1.transform);
                o1.transform.position = new Vector3(o1.transform.position.x, o1.transform.position.y - segments1, o1.transform.position.z);
            } else if (segments1 >= p1Score && !p1Done)
            {
                segments1++;
                GameObject o1 = Instantiate(p1carrotBottom, player1.transform);
                o1.transform.position = new Vector3(o1.transform.position.x, o1.transform.position.y - segments1, o1.transform.position.z);
                p1Done = true;
            }
            if(segments2 < p2Score && segments2 < (int)amountPulled)
            {
                segments2++;
                GameObject o2 = Instantiate(p2carrotMiddle, player2.transform);
                o2.transform.position = new Vector3(o2.transform.position.x, o2.transform.position.y - segments2, o2.transform.position.z);
            }
            else if (segments2 >= p2Score && !p2Done)
            {
                segments2++;
                GameObject o2 = Instantiate(p2carrotBottom, player2.transform);
                o2.transform.position = new Vector3(o2.transform.position.x, o2.transform.position.y - segments2, o2.transform.position.z);
                p2Done = true;
            }*/

            if (!(pullSpeed >= maxPullSpeed))
            {
                pullSpeed += pullSpeedIncrease;
            }

            if (amountPulled > (20 + (p1Score*10)) && amountPulled > (20 + (p2Score * 10)) && !endState)
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
        soundEffect.Play();
    }
    
    IEnumerator AnnounceWinner()
    {
        yield return new WaitForSeconds(2);
        fireworks.SetActive(true);
        FireworksManager fm = fireworks.GetComponent<FireworksManager>();
        backButton.SetActive(true);
        background.SetActive(false);
        pot1.SetActive(false);
        pot2.SetActive(false);
        soundEffect.Stop();
        soundEffect.PlayOneShot(cymbalSound);
        if(p1Score > p2Score)
        {
            winnerText.text = "Grandma Akari Wins!";
            fm.winnerColor = Color.red;
        } else if(p2Score > p1Score)
        {
            winnerText.text = "Grandma Ruriko Wins!";
            fm.winnerColor = Color.blue;
        } else
        {
            winnerText.text = "It's a tie!";
        }
        
    }
}
