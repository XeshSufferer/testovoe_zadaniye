using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private int _speed;
    [SerializeField] private bool _CanWalk;


    [SerializeField] private KeyCode[] _Bind; // 0 - Право, 1 - Лево, 2 - прыжок, 3 - использовать капкан
    [SerializeField] private GameObject _player;

    [SerializeField] private UseTrap _trap_user;

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
        }else if(Input.GetKey(_Bind[1]))
        {
            Walk("left");
        }else 
        {
            Walk("idle");
        }
        if(Input.GetKey(_Bind[3]))
        {
            _trap_user.SpawmTrap();
        }
    }
    public void SetCanRun(bool canWalk_)
    {
        _CanWalk = canWalk_;
    }
}
