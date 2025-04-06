using System;
using System.Collections;
using System.Collections.Generic;
using Orderer;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public bool IsGameActive { get; private set; } = true;
    [SerializeField] private float startGameTime;
    private float currentGameTime;
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
        currentGameTime = startGameTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (!IsGameActive)
        {
            return;
        }

        currentGameTime -= Time.deltaTime;
        if (currentGameTime <= 0)
        {
            EndGame(false);
        }
    }

    public void EndGame(bool isWin)
    {
        if (isWin)
        {
            Debug.Log("You Win");
        }
        else
        {
            Debug.Log("You Lose");
        }

        IsGameActive = false;
    }
}