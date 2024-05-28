using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
[SerializeField] GameObject parentAllTraps;

[SerializeField] private float cooldown;
private float TimeNow = 0;
private bool active = false;
private Collider2D lastInTrap;

public void Start()
{
gameObject.transform.parent = gameObject.transform;
}
private void OnTriggerEnter2D(Collider2D other)
{
    if(other.gameObject.GetComponent<mob>())
    {
        active = true;
        lastInTrap = other;
        other.gameObject.GetComponent<mob>().SetCanWalk(false);
    }
}
private void ReturningCanWalk(Collider2D other)
{
other.gameObject.GetComponent<mob>().SetCanWalk(true);
Destroy(gameObject);
}
private void Update()
{
    if(active)
    {
    TimeNow += Time.deltaTime;
    if(TimeNow >= cooldown)
    {
        ReturningCanWalk(lastInTrap);
        TimeNow = 0;
        active = false;
    }
    }
}
}
