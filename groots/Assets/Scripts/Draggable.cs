using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Draggable : MonoBehaviour
{
    public bool _isDragged = false;
    private Vector3[] _lastPosition;

    void Awake()
    {
        _lastPosition = new Vector3[20];
    }

    void FixedUpdate()
    {
        UpdatePosition();
    }

    public void UpdatePosition()
    {
        for (int i = _lastPosition.Length; i > 1; i--)
        {
            _lastPosition[i - 1] = _lastPosition[i - 2];
        }
        _lastPosition[0] = transform.position;
    }

    public void giveVelocity(int multiplier)
    {
        Debug.Log(_lastPosition[0] + " " + _lastPosition[1] + " " + _lastPosition[2] + " " + _lastPosition[3] + " " + _lastPosition[4] + " " + _lastPosition[5] + " " + _lastPosition[6] + " " + _lastPosition[7] + " " + _lastPosition[8] + " " + _lastPosition[9] + " " + _lastPosition[10] + " " + _lastPosition[11] + " " + _lastPosition[12] + " " + _lastPosition[13] + " " + _lastPosition[14] + " " + _lastPosition[15] + " " + _lastPosition[16] + " " + _lastPosition[17] + " " + _lastPosition[18] + " " + _lastPosition[19]);
        Vector2 givenVelocity = transform.position - _lastPosition[_lastPosition.Length - 1];
        gameObject.GetComponent<Rigidbody2D>().velocity = givenVelocity * multiplier;
        //Debug.Log(givenVelocity);
    }

}
