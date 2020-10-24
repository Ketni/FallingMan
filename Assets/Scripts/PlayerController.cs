using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _playerRigid;
    [SerializeField] private GameObject _playerObj;

    public bool IsAlive = true;
    public float Force;


    private void Update()
    {
        _playerRigid.velocity = new Vector2(0, -10f);
    }

    public void Move(Vector2 input)
    {
        _playerRigid.AddForce(input * Force);
    }
}
