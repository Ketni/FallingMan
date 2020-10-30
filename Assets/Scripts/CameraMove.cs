using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    [SerializeField] private GameObject _player;

    void Update()
    {
        if(_player)
            transform.position = new Vector3(_player.transform.position.x, _player.transform.position.y, -10);
    }
}
