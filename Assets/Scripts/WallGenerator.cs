using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallGenerator : MonoBehaviour
{
    public List<GameObject> LeftWallPrefabs;
    public List<GameObject> RightWallPrefabs;

    private int _lastLeftBot;
    private int _lastRightBot;

    private void Start()
    {
        GameObject rightStartWall = RightWallPrefabs[Random.Range(0, RightWallPrefabs.Count)];
        Instantiate(rightStartWall, new Vector3(0 + 7, 0, 0), Quaternion.identity);
        _lastLeftBot = rightStartWall.GetComponent<WallSize>().BotSize;

        GameObject leftStartWall = Instantiate(LeftWallPrefabs[Random.Range(0, LeftWallPrefabs.Count)], new Vector3(0 - 7, 0, 0), Quaternion.identity);
        leftStartWall.transform.GetChild(1).gameObject.SetActive(false);
        _lastRightBot = leftStartWall.GetComponent<WallSize>().BotSize;

        Generator(new Vector2(0, 0));
    }

    public void Generator(Vector2 checkerPos)
    {
        int offset = GetRandomOffset();
        GameObject leftWall = Instantiate(CheckTopLeft(), new Vector3(-7 + offset, checkerPos.y - 10, 0), Quaternion.identity);
        _lastLeftBot = leftWall.GetComponent<WallSize>().BotSize;
        GameObject rightWall = Instantiate(CheckTopRight(), new Vector3(7 + offset, checkerPos.y - 10, 0), Quaternion.identity);
        _lastRightBot = rightWall.GetComponent<WallSize>().BotSize;

        Destroy(leftWall, 5f);
        Destroy(rightWall, 5f);
    }


    private GameObject CheckTopLeft()
    {
        int botSize = _lastLeftBot;
        List<GameObject> correctList = new List<GameObject>();
        foreach (GameObject wall in LeftWallPrefabs)
        {
            if (botSize == wall.GetComponent<WallSize>().TopSize)
                correctList.Add(wall);
        }
        return correctList[Random.Range(0, correctList.Count)];
    }

    private GameObject CheckTopRight()
    {
        int botSize = _lastRightBot;
        List<GameObject> correctList = new List<GameObject>();
        foreach (GameObject wall in RightWallPrefabs)
        {
            if (botSize == wall.GetComponent<WallSize>().TopSize)
                correctList.Add(wall);
        }
        return correctList[Random.Range(0, correctList.Count)];
    }

    private int GetRandomOffset()
    {
        return Random.Range(-2, 3);
    }
}
