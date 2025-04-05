using System;
using UnityEngine;

public class Environment : MonoBehaviour
{
    public static Environment Instance { get; private set; }
    public int WindSpeed { get; private set; }
    public int Distance { get; private set; }
    public event Action<int, int> OnChanged;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        SetRandomParameters();
    }

    private void SetRandomParameters()
    {
        // WindSpeed = 0;
        WindSpeed = DataHolder.Instance.PossibleWindSpeeds.GetRandomElement();
        Distance = DataHolder.Instance.PossibleDistances.GetRandomElement();
        OnChanged?.Invoke(WindSpeed, Distance);
    }
}