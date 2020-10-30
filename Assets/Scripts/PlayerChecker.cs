using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class PlayerChecker : MonoBehaviour
{
    [Header("Death")]
    [SerializeField]
    private GameObject Player;

    [SerializeField]
    private GameObject _deathParticles;

    [SerializeField]
    private GameObject _deathPanel;

    [SerializeField]
    private Text _scores;

    [Space]
    [SerializeField] 
    private bool _canSpawn = false;

    public WallGenerator wallGenerator;
    public PlayerController PlayerController;

    private int _currentScore = 0;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Checker" && _canSpawn)
        {
            wallGenerator.Generator(collision.transform.position);

            _scores.text = (++_currentScore).ToString();
        }

        if(collision.tag == "Bonus")
        {
            collision.GetComponent<Bonus>().UseBonus();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Wall" && !PlayerController.IsImmortal)
        {
            Death();
        }
    }

    private void Death()
    {
        PlayerController.IsAlive = false;

        _deathPanel.SetActive(true);

        GameObject particles = Instantiate(_deathParticles, new Vector3(transform.position.x, transform.position.y, 0), Quaternion.identity) as GameObject;
        Destroy(particles, 3f);
        Destroy(Player);
    }
}
