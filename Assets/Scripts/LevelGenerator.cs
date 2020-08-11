using System.Collections;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    [SerializeField] private GameObject platform;
    [SerializeField] private Transform player;
    [SerializeField] private int maxCountInChunk = 20;

    private GameObject[] platformsCank;

    private float step = 0;
    private bool firstTime;
    private int halfOfHalf;

    void Awake()
    {
        halfOfHalf = maxCountInChunk / 4;
        platformsCank = new GameObject[maxCountInChunk];
        GenerateChank();
    }


    private void Update()
    {
        int idx;
        idx = maxCountInChunk / 2 + (firstTime ? -halfOfHalf : halfOfHalf);

        if (player.position.y > platformsCank[idx].transform.position.y)
        {
       // if (Input.GetKeyDown(KeyCode.K))
        //{
            RecalculateHalfOfChunk(firstTime);
        //}
        }
    }

    private void GenerateChank()
    {
        for (int i = 0; i < maxCountInChunk; i++)
        {
            Vector3 postion = transform.position + Vector3.up * step + Vector3.right * Random.Range(-3f,3f) + Vector3.forward * 0.5f;
            step += Random.Range(1f,3f);
            platformsCank[i]=Instantiate(platform, postion, Quaternion.identity);
        } 
    }

    private void RecalculateHalfOfChunk(bool firstPart)
    {
        int start;
        int end;
        if (!firstPart)
        {
            start = 0;
            end = maxCountInChunk / 2;
        }
        else
        {
            start = maxCountInChunk / 2;
            end = maxCountInChunk;
        }
        for (int i = start; i < end; i++)
        {
            platformsCank[i].transform.position = transform.position + Vector3.up * step + Vector3.right * Random.Range(-3f, 3f) + Vector3.forward * 0.5f;
            step += Random.Range(1f, 3f);
        }
        firstTime = !firstTime;
    }
}
