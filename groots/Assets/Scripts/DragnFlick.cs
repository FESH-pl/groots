using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragnFlick : MonoBehaviour
{

    //private bool _isDragActive = false;//only for mouse use
    //private Vector2 _screenPosition;//only for mouse use
    private Vector3 _worldPosition;
    //private Vector3[] _lastPosition;//only for mouse use
    //private Draggable _lastDragged;//only for mouse use
    private Dictionary<int,Draggable> _touchList;

    public int _velocityMultiplier = 20;

    private GameManager gameManager;

    void Awake()
    {
        //_lastPosition = new Vector3[10]; //only for mouse use
        _touchList = new Dictionary<int, Draggable>();
        gameManager = gameObject.GetComponent<GameManager>();
    }

    void Update()
    {
        // disable input during countdown
        if (gameManager != null && gameManager.countdownTime > 0)
            return;

        for(int i=0;i<Input.touchCount; i++)
        {
            Touch t = Input.GetTouch(i);
            _worldPosition = Camera.main.ScreenToWorldPoint(t.position);
            if (t.phase == TouchPhase.Began) //Happens when a finger first touches the screen. If touching a draggable object, starts the drag.
            {
                RaycastHit2D hit = Physics2D.Raycast(_worldPosition, Vector2.zero);
                if (hit.collider != null)
                {
                    Draggable draggable = hit.transform.gameObject.GetComponent<Draggable>();
                    if (draggable != null && !draggable._isDragged) //if touching a draggable object and that object is not already dragged...
                    {
                        draggable._isDragged = true;
                        draggable.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2();
                        _touchList.Add(t.fingerId, draggable);
                        
                    }
                    else
                    {
                        _touchList.Add(t.fingerId, null);
                    }
                }
                else
                {
                    _touchList.Add(t.fingerId, null);
                }
            } 
            else if(t.phase == TouchPhase.Moved) //Happens when moving finger across the screen
            {
                if (_touchList[t.fingerId])
                {
                    _touchList[t.fingerId].transform.position = new Vector2(_worldPosition.x, _worldPosition.y);
                    //_touchList[t.fingerId].UpdatePosition();
                }
                
            } 
            else if(t.phase == TouchPhase.Ended) //Happens when finger leaves the screen. Frees the object dragged, and gives it velocity
            {
                Draggable draggable = _touchList[t.fingerId];
                if(draggable != null)
                {
                    draggable._isDragged = false;
                    draggable.giveVelocity(_velocityMultiplier);
                }
                
                _touchList.Remove(t.fingerId);
            }
        }

        /* CODE THAT WORKS FOR MOUSE INPUT
        if(_isDragActive && Input.GetMouseButtonUp(0))
        {
            Release();
            return;
        }

        if (Input.GetMouseButton(0))
        {
            Vector3 mousePos = Input.mousePosition;
            _screenPosition = new Vector2(mousePos.x, mousePos.y);
        } 
        else if (Input.touchCount > 0)
        {

        }
        else
        {
            return;
        }

        _worldPosition = Camera.main.ScreenToWorldPoint(_screenPosition);

        if (_isDragActive)
        {
            Drag();
        }
        else
        {
            RaycastHit2D hit = Physics2D.Raycast(_worldPosition, Vector2.zero);
            if(hit.collider != null)
            {
                Draggable draggable = hit.transform.gameObject.GetComponent<Draggable>();
                if(draggable != null && !draggable._isDragged)
                {
                    draggable._isDragged = true;
                    _lastDragged = draggable;
                    InitDrag();
                }
            }
        }
        */
    }
    /*
    void InitDrag()
    {
        _isDragActive = true;

    }

    void Drag()
    {
        _lastDragged.transform.position = new Vector2(_worldPosition.x, _worldPosition.y);
        UpdatePosition(_lastDragged.transform.position);
    }

    void Release()
    {
        _isDragActive = false;
        _lastDragged._isDragged = false;
        Vector2 givenVelocity = _lastDragged.transform.position - _lastPosition[_lastPosition.Length-1];
        Debug.Log(_lastDragged.transform.position + "\n" + _lastPosition[_lastPosition.Length - 1]);
        _lastDragged.gameObject.GetComponent<Rigidbody2D>().velocity = givenVelocity*_velocityMultiplier;
    }

    void UpdatePosition(Vector3 newPos)
    {
        for (int i=_lastPosition.Length ; i>1 ; i--)
        {
            _lastPosition[i-1] = _lastPosition[i-2];
        }
        _lastPosition[0] = newPos;
    }
    */

}
