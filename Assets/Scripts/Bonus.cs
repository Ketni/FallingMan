using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bonus : MonoBehaviour
{

    public string BonusType;

    private PlayerController _pc;

    private void Start()
    {
        _pc = GameObject.FindGameObjectWithTag("PlayerController").GetComponent<PlayerController>();
    }

    public void UseBonus()
    {
        switch (BonusType)
        {
            case "Speed":
                StartCoroutine("SpeedBonus");
                GetComponent<SpriteRenderer>().enabled = false;
                Destroy(gameObject, 2.2f);
                break;
        }
    }

    private IEnumerator SpeedBonus()
    {
        _pc.FallForce = -30f;
        _pc.IsImmortal = true;
        yield return new WaitForSeconds(2f);
        _pc.FallForce = -10f;
        _pc.IsImmortal = false;
    }
}
