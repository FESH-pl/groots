using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireworksManager : MonoBehaviour
{
    public GameObject fireworks;

    private float fireworksTimer1;
    private float fireworksTimer2;
    private float fireworksTimer3;
    private float fireworksTimer4;

    private GameObject fireworks1;
    private GameObject fireworks2;
    private GameObject fireworks3;
    private GameObject fireworks4;

    public Color winnerColor = Color.gray;

    void Awake()
    {
        transform.position = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, Camera.main.nearClipPlane));
        //resetTimer(fireworksTimer1);
        //resetTimer(fireworksTimer2);
        //resetTimer(fireworksTimer3);
        //resetTimer(fireworksTimer4);
    }

    void FixedUpdate()
    {
        fireworksTimer1 -= 0.02f;
        fireworksTimer2 -= 0.02f;
        fireworksTimer3 -= 0.02f;
        fireworksTimer4 -= 0.02f;

        if(fireworksTimer1 <= 0f)
        {
            //resetTimer(fireworksTimer1);
            fireworksTimer1 = Random.Range(1.1f, 3f);
            fireworks1 = Instantiate(fireworks, transform);
            ParticleSystem.MainModule ms = fireworks1.GetComponent<ParticleSystem>().main;
            ms.startColor = winnerColor;
            fireworks1.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Random.Range(0f, Screen.width), Random.Range(0f, Screen.height), 10));
            StartCoroutine(fireworksLifetime(fireworks1));
        }
        if (fireworksTimer2 <= 0f)
        {
            //resetTimer(fireworksTimer2);
            fireworksTimer2 = Random.Range(1.1f, 3f);
            fireworks2 = Instantiate(fireworks, transform);
            ParticleSystem.MainModule ms = fireworks2.GetComponent<ParticleSystem>().main;
            ms.startColor = winnerColor;
            fireworks2.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Random.Range(0f, Screen.width), Random.Range(0f, Screen.height), 10));
            StartCoroutine(fireworksLifetime(fireworks2));
        }
        if (fireworksTimer3 <= 0f)
        {
            //resetTimer(fireworksTimer3);
            fireworksTimer3 = Random.Range(1.1f, 3f);
            fireworks3 = Instantiate(fireworks, transform);
            ParticleSystem.MainModule ms = fireworks3.GetComponent<ParticleSystem>().main;
            ms.startColor = winnerColor;
            fireworks3.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Random.Range(0f, Screen.width), Random.Range(0f, Screen.height), 10));
            StartCoroutine(fireworksLifetime(fireworks3));
        }
        if (fireworksTimer4 <= 0f)
        {
            //resetTimer(fireworksTimer4);
            fireworksTimer4 = Random.Range(1.1f, 3f);
            fireworks4 = Instantiate(fireworks, transform);
            ParticleSystem.MainModule ms = fireworks4.GetComponent<ParticleSystem>().main;
            ms.startColor = winnerColor;
            fireworks4.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Random.Range(0f, Screen.width), Random.Range(0f, Screen.height), 10));
            StartCoroutine(fireworksLifetime(fireworks4));
        }
    }

    private void resetTimer(float timer)
    {
        timer = Random.Range(1.1f, 3f);
    }

    IEnumerator fireworksLifetime(GameObject fireworks)
    {
        yield return new WaitForSeconds(1);

        Destroy(fireworks);
    }
}
