using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationControler : MonoBehaviour
{

    //variables for pot animation
    private bool goLeft = true;
    private float distanceTraveled = 5f;
    private float animationSpeed = 0.02f;

    private float initScale;
    private float shrinkScale;
    private float bounceBackSpeed = 0.000005f;

    void Awake()
    {
        initScale = transform.localScale.y;
        shrinkScale = initScale - 0.0001f;
    }

    private void Update()
    {
        if(transform.rotation.z == 0)
        {
            if (goLeft)
            {
                //transform.rotation.z += 0.1f;
            }
        }
        if (goLeft && distanceTraveled < 10)
        {
            distanceTraveled += animationSpeed;
            //transform.Rotate(new Vector3(transform.rotation.x, transform.rotation.y, transform.rotation.z), animationSpeed);
            transform.Rotate(0f, 0f, animationSpeed);
        }
        else if (!goLeft && distanceTraveled < 10)
        {
            distanceTraveled += animationSpeed;
            //transform.Rotate(new Vector3(transform.rotation.x, transform.rotation.y, transform.rotation.z), -animationSpeed);
            transform.Rotate(0f, 0f, -animationSpeed);
        }
        else
        {
            goLeft = !goLeft;
            distanceTraveled = 0f;
        }

        if(transform.localScale.y < initScale)
        {
            transform.localScale += new Vector3(0,bounceBackSpeed,0);
        }
    }

    public void getHit()
    {
        transform.localScale = new Vector3(transform.localScale.x, shrinkScale, transform.localScale.z);
    }
}
