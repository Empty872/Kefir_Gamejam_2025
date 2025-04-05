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
    public List<Person> Players => dataHolderSO.People;
}