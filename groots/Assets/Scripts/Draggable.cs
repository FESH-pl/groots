using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Draggable : MonoBehaviour
{
    public TrailRenderer trail;
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
        Vector2 givenVelocity = transform.position - _lastPosition[_lastPosition.Length - 1];
        gameObject.GetComponent<Rigidbody2D>().velocity = givenVelocity * multiplier;

        if (trail != null && !trail.emitting) trail.emitting = true;
    }

}
