using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scores : MonoBehaviour
{
    [SerializeField] private Text _scores;

    private int _currentScore = 0;

    private void Start()
    {
        StartCoroutine("Scoring");
    }

    private IEnumerator Scoring()
    {
        yield return new WaitForSeconds(1f);

        _scores.text = _currentScore++.ToString();

        StartCoroutine("Scoring");
    }
}
