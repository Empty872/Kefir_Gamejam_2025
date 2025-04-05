using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeopleSpawner : MonoBehaviour
{
    [SerializeField] private int peopleCount;
    [SerializeField] private List<Transform> spawnPoints;

    private void Start()
    {
        SpawnPlayers(peopleCount);
    }

    private void SpawnPlayers(int count)
    {
        var actualPoints = spawnPoints.GetRandomElements(count);
        var actualPeople = DataHolder.Instance.Players.GetRandomElements(count);
        for (int i = 0; i < count; i++)
        {
            Instantiate(actualPeople[i].gameObject, actualPoints[i].transform.position, Quaternion.identity);
        }
    }
}