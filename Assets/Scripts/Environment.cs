using System;
using System.Collections;
using UnityEngine;

public class Environment : MonoBehaviour
{
    private float windChangePeriod = 15f;
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
        SetRandomParametersAtStart();
    }

    private void SetRandomParametersAtStart()
    {
        Distance = DataHolder.Instance.PossibleDistances.GetRandomElement();
        StartCoroutine(ChangeWindSpeedPeriodically(windChangePeriod));
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
}