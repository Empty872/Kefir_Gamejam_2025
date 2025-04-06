using System;
using System.Collections;
using System.Collections.Generic;
using Orderer;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

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

    public UnityEvent youWin;
    public UnityEvent youKilledAnother;

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
                    StartCoroutine(DelayCoroutine(5, () => SceneManager.LoadScene(SceneNames.GameScene)));
                    IsGameActive = false;
                }

                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }

    public void SomeoneWasKilled(bool isWin)
    {
        Debug.Log("SomeoneWasKilled");
        switch (gameMode)
        {
            case GameMode.Tutorial:
                break;
            case GameMode.Game:
                if (isWin)
                {
                    youWin.Invoke();
                    Debug.Log("youWin");
                    StartCoroutine(DelayCoroutine(5, () => SceneManager.LoadScene(SceneNames.GameScene)));
                }
                else
                {
                    Debug.Log("youKilledAnother");
                    youKilledAnother.Invoke();
                    currentGameTime -= 20;
                }
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }
    private IEnumerator DelayCoroutine(float waitInSeconds, Action action)
    {
        yield return new WaitForSeconds(waitInSeconds);
        action.Invoke();
    }
}

public enum GameMode
{
    Tutorial,
    Game
}