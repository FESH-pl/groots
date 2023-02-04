using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateBehaviour : MonoBehaviour
{
    private float minRotation = -5;
    private float maxRotation = 5;

    private float rotationSpeed;

    private void Start()
    {
        rotationSpeed = Random.Range(minRotation, maxRotation);

        if (rotationSpeed < 2 && rotationSpeed >= 0)
            rotationSpeed = 2;
        if (rotationSpeed > -2 && rotationSpeed <= 0)
            rotationSpeed = -2;
    }

    void FixedUpdate()
    {
        transform.Rotate(new Vector3(0, 0, transform.rotation.z + rotationSpeed));
    }
}
