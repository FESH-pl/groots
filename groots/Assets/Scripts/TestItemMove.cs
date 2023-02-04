using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestItemMove : MonoBehaviour
{

    void FixedUpdate()
    {
        transform.position += new Vector3(0.05f, 0, 0);
    }
}
