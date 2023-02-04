using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDestroyer : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D item)
    {
        Destroy(item.gameObject);
    }
}
