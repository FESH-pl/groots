using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitlePlayBehaviour : MonoBehaviour
{
    public GameObject leftGrandma;
    public GameObject rightGrandma;

    private bool pressedPlay = false;
    private void OnMouseDown()
    {
        pressedPlay = true;
        StartCoroutine(LoadGameScene());
    }

    private void FixedUpdate()
    {
        if (pressedPlay)
        {
            leftGrandma.transform.position = new Vector3(leftGrandma.transform.position.x - 0.1f, leftGrandma.transform.position.y, leftGrandma.transform.position.z);
            rightGrandma.transform.position = new Vector3(rightGrandma.transform.position.x + 0.1f, rightGrandma.transform.position.y, rightGrandma.transform.position.z);
        }
    }

    private IEnumerator LoadGameScene()
    {
        yield return new WaitForSeconds(1.3f);
        SceneManager.LoadScene("MainGame");
    }
}
