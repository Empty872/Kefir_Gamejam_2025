using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeopleSpawner : MonoBehaviour
{
    // [SerializeField] private int peopleCount;
    [SerializeField] private List<Transform> spawnPoints;
    public static PeopleSpawner Instance;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        // SpawnPlayers(peopleCount);
    }

    public List<Person> SpawnPlayers(int count)
    {
        var actualPoints = spawnPoints.GetRandomElements(count);
        var actualPeople = DataHolder.Instance.Players.GetRandomElements(count);
        var result = new List<Person>();
        for (int i = 0; i < count; i++)
        {
            var instance = Instantiate(actualPeople[i].gameObject, actualPoints[i].transform.position,
                Quaternion.identity).GetComponent<Person>();
            result.Add(instance);
        }

        return result;
    }
}