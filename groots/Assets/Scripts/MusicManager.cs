using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{

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
    }
}
