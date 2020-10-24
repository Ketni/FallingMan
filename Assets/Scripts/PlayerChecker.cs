using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerChecker : MonoBehaviour
{
    [Header("Death")]
    [SerializeField] private GameObject Player;
    [SerializeField] private GameObject _mainCamera;
    [SerializeField] private GameObject _deathParticles;

    public PlayerController pc;

    [Space]
    public WallGenerator wallGenerator;
    [SerializeField] private bool _canSpawn = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Checker" && _canSpawn)
        {
            wallGenerator.Generator(collision.transform.position);
        }

        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            pc.IsAlive = false;
            _mainCamera.SetActive(true);
            _mainCamera.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - 10);
            GameObject particles = Instantiate(_deathParticles, new Vector3(transform.position.x, transform.position.y, 0), Quaternion.identity) as GameObject;
            Destroy(particles, 3f);
            Destroy(Player);
        }
    }
}
