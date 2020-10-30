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
        //GameObject leftStartWall = LeftWallPrefabs[Random.Range(0, LeftWallPrefabs.Count)];
        //Instantiate(leftStartWall, new Vector3(0 - 7, 0, 0), Quaternion.identity);
        //_lastLeftBot = leftStartWall.GetComponent<WallSize>().BotSize;

        GameObject rightStartWall = RightWallPrefabs[Random.Range(0, RightWallPrefabs.Count)];
        Instantiate(rightStartWall, new Vector3(0 + 7, 0, 0), Quaternion.identity);
        _lastLeftBot = rightStartWall.GetComponent<WallSize>().BotSize;

        GameObject leftStartWall = RightWallPrefabs[Random.Range(0, RightWallPrefabs.Count)];
        Instantiate(leftStartWall, new Vector3(0 - 7, 0, 0), Quaternion.identity);
        _lastRightBot = leftStartWall.GetComponent<WallSize>().BotSize;

        Generator(new Vector2(0, 0));

        //kekWaitGitCheck;
    }

    public void Generator(Vector2 checkerPos)
    {
        GameObject leftWall = Instantiate(CheckTopLeft(), new Vector3(-7, checkerPos.y - 10, 0), Quaternion.identity);
        _lastLeftBot = leftWall.GetComponent<WallSize>().BotSize;
        GameObject rightWall = Instantiate(CheckTopRight(), new Vector3(7, checkerPos.y - 10, 0), Quaternion.identity);
        _lastRightBot = rightWall.GetComponent<WallSize>().BotSize;

        Destroy(leftWall, 3f);
        Destroy(rightWall, 3f);
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

}
