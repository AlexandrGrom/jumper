using System.Collections;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    [SerializeField] private GameObject platform;

    void Awake()
    {
        
    }

    IEnumerator Spawn()
    {
        while (true)
        {
            yield return null;
            Instantiate(platform);
        }
    }
}
