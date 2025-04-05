using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu(menuName = "ScriptalbeObjects/DataHolder")]
public class DataHolderSO : ScriptableObject
{
    [SerializeField] private List<Person> people;
    public List<Person> People => people;
}