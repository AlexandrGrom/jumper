using System.Collections;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    [SerializeField] private Platform[] platformPrefabs;
    [SerializeField] private Transform player;
    [SerializeField] private int maxCountInChunk = 20;

    private Platform[] platformsCank;

    private Vector3 Position => transform.position + Vector3.up * (step += Random.Range(1.5f, 3f)) + Vector3.right * Random.Range(-3f, 3f);

    private float step;
    private bool firstPart;
    private int quarter;

    void Awake()
    {
        step = 0;
        quarter = maxCountInChunk / 4;
        platformsCank = new Platform[maxCountInChunk];
        GenerateChank();
        StartCoroutine(CheckRecalculation());
    }

    private IEnumerator CheckRecalculation()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            int index = maxCountInChunk / 2 + (firstPart ? -quarter : quarter);

            if (player.position.y > platformsCank[index].transform.position.y)
            {
                RecalculateHalfOfChunk(firstPart);
            }

        }
    }

    private void GenerateChank()
    {
        for (int i = 0; i < maxCountInChunk; i++)
        {
            platformsCank[i]=Instantiate(platformPrefabs[Random.Range(0,platformPrefabs.Length)], Position, Quaternion.identity, gameObject.transform);
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
            Vector3 newPosition = Position;
            platformsCank[i].Reinitialize(newPosition);
            platformsCank[i].transform.position = newPosition;
        }
        this.firstPart = !this.firstPart;
    }
}
