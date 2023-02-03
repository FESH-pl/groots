using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    // For testing
    public string playerName;

    public Sprite neutral;
    public Sprite happy;
    public Sprite upset;

    private int score = 0;

    private SpriteRenderer spriteRenderer;

    private Coroutine lastCoroutine = null;

    /// <summary>
    /// Makes sure player game object won't be destroyed on new scene load
    /// </summary>
    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    /// <summary>
    /// Handles item collision with player
    /// Sets sprite to happy/upset
    /// Updates score
    /// Destroys item
    /// </summary>
    /// <param name="item">item that collided with player</param>
    private void OnCollisionEnter2D(Collision2D item)
    {
        Debug.Log("OnCollisionEnter2D");


        if(item.gameObject.tag == "Good")
        {
            // TODO: handle points better
            UpdateScore(1);

            // Set sprite to happy and set coroutine to return to neutral
            spriteRenderer.sprite = happy;
            if (lastCoroutine != null) StopCoroutine(lastCoroutine);
            lastCoroutine = StartCoroutine(BackToNeutralFace());

        }
        else if (item.gameObject.tag == "Bad")
        {
            // TODO: handle points better
            UpdateScore(-1);

            // Set sprite to upset and set coroutine to return to neutral
            spriteRenderer.sprite = upset;
            if (lastCoroutine != null) StopCoroutine(lastCoroutine);
            lastCoroutine = StartCoroutine(BackToNeutralFace());
        }

        // TODO: particle effects?

        Destroy(item.gameObject);
    }

    private void UpdateScore(int points)
    {
        score += points;
        Debug.Log(playerName + ":  " + score);
    }

    /// <summary>
    /// Waits 0.5 seconds then returns player sprite to neutral
    /// </summary>
    /// <returns></returns>
    private IEnumerator BackToNeutralFace()
    {
        yield return new WaitForSeconds(0.8f);
        spriteRenderer.sprite = neutral;
    }

    // For testing
    // TODO: remove
    private void OnMouseDown()
    {
        UpdateScore(1);
        Debug.Log(playerName + ":  " + score);
        spriteRenderer.sprite = happy;


        if(lastCoroutine != null) StopCoroutine(lastCoroutine);
        lastCoroutine = StartCoroutine(BackToNeutralFace());
    }

}
