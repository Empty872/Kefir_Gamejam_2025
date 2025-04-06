using System;
using System.Collections;
using System.Collections.Generic;
using Orderer;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private GameMode gameMode;
    public GameMode GameMode => gameMode;
    public bool IsGameActive { get; private set; } = true;
    [SerializeField] private float startGameTime;
    private float currentGameTime;
    [SerializeField] private int peopleCount;
    [SerializeField] private OrderManager orderManager;
    public static GameController Instance;
    public Person Target { get; private set; }

    public float StartGameTime => startGameTime;

    public float CurrentGameTime => currentGameTime;

    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        switch (gameMode)
        {
            case GameMode.Tutorial:
                break;
            case GameMode.Game:
                var players = PeopleSpawner.Instance.SpawnPlayers(peopleCount);
                Target = players.GetRandomElement();
                orderManager.StartGame(Target);
                currentGameTime = startGameTime;
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!IsGameActive)
        {
            return;
        }

        switch (gameMode)
        {
            case GameMode.Tutorial:
                break;
            case GameMode.Game:
                currentGameTime -= Time.deltaTime;
                if (currentGameTime <= 0)
                {
                    SomeoneWasKilled(false);
                }

                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }

    public void SomeoneWasKilled(bool isWin)
    {
        switch (gameMode)
        {
            case GameMode.Tutorial:
                Debug.Log("You eliminated target");
                break;
            case GameMode.Game:
                if (isWin)
                {
                    Debug.Log("You Win");
                }
                else
                {
                    Debug.Log("You Lose");
                }

                IsGameActive = false;
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }
}

public enum GameMode
{
    Tutorial,
    Game
}