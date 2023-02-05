using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitlePlayBehaviour : MonoBehaviour
{
    public GameObject leftGrandma;
    public GameObject rightGrandma;

    public GameObject leftGrandmaName;
    public GameObject rightGrandmaName;

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
            leftGrandma.transform.position = new Vector3(leftGrandma.transform.position.x - 20f, leftGrandma.transform.position.y, leftGrandma.transform.position.z);
            leftGrandmaName.transform.position = new Vector3(leftGrandmaName.transform.position.x - 20f, leftGrandmaName.transform.position.y, leftGrandmaName.transform.position.z);

            rightGrandma.transform.position = new Vector3(rightGrandma.transform.position.x + 20f, rightGrandma.transform.position.y, rightGrandma.transform.position.z);
            rightGrandmaName.transform.position = new Vector3(rightGrandmaName.transform.position.x + 20f, rightGrandmaName.transform.position.y, rightGrandmaName.transform.position.z);
        }
    }

    private IEnumerator LoadGameScene()
    {
        yield return new WaitForSeconds(1.4f);
        SceneManager.LoadScene("MainGame");
    }
}
