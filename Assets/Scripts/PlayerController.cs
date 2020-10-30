using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private GameObject _playerObj;

    [SerializeField] private Rigidbody2D _playerRigid;

    public bool IsAlive = true;
    public bool IsImmortal = false;
    public float Force;

    public float FallForce = -10f;


    public void Update()
    {
        if (IsAlive)
            _playerRigid.velocity = new Vector2(Mathf.Clamp(_playerRigid.velocity.x, -2f, 2f), FallForce);
    }

    public void Move(Vector2 input)
    {
        _playerRigid.AddForce(input * Force);
    }
}
