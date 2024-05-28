using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
private void OnTriggerEnter2D(Collider2D other)
{
    if(other.gameObject.GetComponent<mob>())
    {
        other.gameObject.GetComponent<mob>().SetCanWalk(false);
    }
}
}
