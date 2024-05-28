using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mob : MonoBehaviour
{
    private bool CanWalk = true;
    private void Update()
    {
        if(CanWalk)
        {
        gameObject.transform.Translate(Vector3.left * 2.5f * Time.deltaTime);
        }
    }
    public void SetCanWalk(bool Set)
    {
        CanWalk = Set;
    }
}
