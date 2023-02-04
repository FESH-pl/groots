using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitlePlayBehaviour : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D item)
    {
        if (item.gameObject.tag == "Good")
        {
            // TODO: grandma animation

            SceneManager.LoadScene("MainGame");
        }
        else if (item.gameObject.tag == "Bad")
        {
            // TODO: confirm if they want to quit

            // TODO: respawn item (or quit)
        }


    }
}
