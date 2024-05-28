using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseTrap : MonoBehaviour
{
    [SerializeField] private GameObject _trap;

    public void SpawmTrap()
    {
        Instantiate(_trap, gameObject.transform);
    }
}
