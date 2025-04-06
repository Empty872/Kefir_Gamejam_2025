using System;
using System.Collections.Generic;
using UnityEngine;

public class DataHolder : MonoBehaviour
{
    public static DataHolder Instance { get; private set; }

    public void Awake()
    {
        Instance = this;
    }

    [SerializeField] private DataHolderSO dataHolderSO;
    public Dictionary<int, float> WindOffsetDictionary { get; private set; } = new()
        { { -3, -3f }, { -2, -2.35f }, { -1, -1.7f }, { 0, 0 }, { 1, 1.7f }, { 2, 2.35f }, { 3, 3f } };
    public Dictionary<int, float> DistanceOffsetDictionary { get; private set; } = new()
        { { 200, -3f }, { 150, -2.35f }, { 100, -1.7f }, { 50, 0 } };
    public List<Person> Players => dataHolderSO.People;
    public List<int> PossibleWindSpeeds => dataHolderSO.PossibleWindSpeeds;
    public List<int> PossibleDistances => dataHolderSO.PossibleDistances;
}