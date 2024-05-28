using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseTrap : MonoBehaviour
{
    [SerializeField] private GameObject _trap;
    [SerializeField] private Vector2 Offset;
    //[SerializeField] private Vector2 PlayerPosition;
    [SerializeField] private GameObject player;
    [SerializeField] private PlayerController PlayerController;

    public void SpawnTrap()
    {
        //PlayerPosition = player.transform.position;
        Vector2 pos_right = new Vector2 (player.transform.position.x + Offset.x, player.transform.position.y + Offset.y);
        Vector2 pos_left = new Vector2 (player.transform.position.x + -Offset.x, player.transform.position.y + Offset.y);
        if(PlayerController.GetHorisontal())
        {
        GameObject newObject = Instantiate(_trap, pos_left, Quaternion.identity);
        }else{
            GameObject newObject = Instantiate(_trap,   pos_right, Quaternion.identity);
        }
    }
}
