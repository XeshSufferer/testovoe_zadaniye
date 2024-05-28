using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private int _speed;
    [SerializeField] private bool _CanWalk;
    [SerializeField] private bool Left =false; // Если left = true то мы спавним в левой части, если true то наоборот

    [SerializeField] private KeyCode[] _Bind; // 0 - Право, 1 - Лево, 2 - прыжок, 3 - использовать капкан
    [SerializeField] private GameObject _player;

    [SerializeField] private UseTrap _trap_user;

    [SerializeField] private PlayerInventory _inventory;

    private void Walk(string RightLeftIdle)
    // RightLeftIdle - Направление
    {
        if(_CanWalk)
        {
        if(RightLeftIdle == "right")
        {
            _player.transform.Translate(Vector3.right * _speed * Time.deltaTime);

        }else if(RightLeftIdle == "left")
        {
            _player.transform.Translate(Vector3.left * _speed * Time.deltaTime);
        }else if(RightLeftIdle == "idle")
        {
            // Сюда при дальнейшей поддержке механики суются анимации и вся хуйня
        }
        }
    }
    private void Update()
    {
        if(Input.GetKey(_Bind[0]))
        {
            Walk("right");
            Left = false;
        }else if(Input.GetKey(_Bind[1]))
        {
            Walk("left");
            Left = true;
        }else 
        {
            Walk("idle");
        }
        if(Input.GetKeyDown(_Bind[3]))
        {
            if(_inventory.GetItemIDInCell(_inventory.GetSelectedCell()) == 1)
            {
            _trap_user.SpawnTrap();
            _inventory.DeleteTrapFromInv(_inventory.GetSelectedCell());
            }
        }
    }
    public void SetCanRun(bool canWalk_)
    {
        _CanWalk = canWalk_;
    }
    public bool GetHorisontal()
    {
        return Left;
    }
}
