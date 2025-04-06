using System;
using System.Collections;
using UnityEngine;

public class Environment : MonoBehaviour
{
    [SerializeField] private float windChangePeriod;
    public static Environment Instance { get; private set; }
    public int WindSpeed { get; private set; } = 0;
    public int Distance { get; private set; } = 50;
    public event Action<int, int> OnChanged;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        SetRandomParametersAtStart();
    }

    private void SetRandomParametersAtStart()
    {
        switch (GameController.Instance.GameMode)
        {
            case GameMode.Tutorial:
                Distance = 50;
                WindSpeed = 0;
                OnChanged?.Invoke(WindSpeed, Distance);
                break;
            case GameMode.Game:
                Distance = DataHolder.Instance.PossibleDistances.GetRandomElement();
                StartCoroutine(ChangeWindSpeedPeriodically(windChangePeriod));
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }

    private IEnumerator ChangeWindSpeedPeriodically(float period)
    {
        while (true)
        {
            WindSpeed = DataHolder.Instance.PossibleWindSpeeds.GetRandomElement();
            OnChanged?.Invoke(WindSpeed, Distance);
            yield return new WaitForSeconds(period);
        }
    }

    public void SetWind(int wind)
    {
        Debug.Log($"Wind set {wind}");
        WindSpeed = wind;
        OnChanged?.Invoke(WindSpeed, Distance);
    }
    
    public void SetDistance(int distance)
    {
        Debug.Log($"Distance set {distance}");
        Distance = distance;
        OnChanged?.Invoke(WindSpeed, Distance);
    }
}