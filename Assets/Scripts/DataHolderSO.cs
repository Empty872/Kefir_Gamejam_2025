using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu(menuName = "ScriptalbeObjects/DataHolder")]
public class DataHolderSO : ScriptableObject
{
    [SerializeField] private List<Person> people;
    [SerializeField] private List<Person> shahids;
    [SerializeField] private List<int> possibleWindSpeeds;
    [SerializeField] private List<int> possibleDistances;
    
    public List<Person> People => people;
    public List<Person> Shahids => shahids;
    public List<int> PossibleWindSpeeds => possibleWindSpeeds;
    public List<int> PossibleDistances => possibleDistances;
}