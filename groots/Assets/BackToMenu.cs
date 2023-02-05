using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackToMenu : MonoBehaviour
{
    private void OnMouseDown()
    {
        SceneManager.LoadScene("TitleScreen");
    }
}
