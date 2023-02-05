using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    /*code used when countdown was not integrated in music file.
    //public AudioClip countdownFile;
    public AudioSource source;

    private bool countdownDone = false;

    void Awake()
    {
        StartCoroutine(waitForCountdown());
    }

    private void FixedUpdate()
    {
        if(countdownDone && source.volume < 1f)
        {
            source.volume += 0.005f;
        }
    }

    IEnumerator waitForCountdown()
    {
        yield return new WaitForSeconds(3);
        countdownDone = true;
    }*/

    public AudioSource musicSource;
    public float musicDelay = 0.3f;

    private void Awake()
    {
        StartCoroutine(WaitForCountDown());
    }

    IEnumerator WaitForCountDown()
    {
        yield return new WaitForSecondsRealtime(musicDelay);
        musicSource.Play();
    }
}
