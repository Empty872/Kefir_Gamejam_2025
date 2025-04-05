using System;
using System.Collections;
using System.Collections.Generic;
using Orderer;
using UnityEngine;

public class GameController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private int peopleCount;
    [SerializeField] private OrderManager orderManager;
    public static GameController Instance;
    public Person Target { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        var players = PeopleSpawner.Instance.SpawnPlayers(peopleCount);
        Target = players.GetRandomElement();
        orderManager.StartGame(Target);
    }

    // Update is called once per frame
    void Update()
    {
    }
}