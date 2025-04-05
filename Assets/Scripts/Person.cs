using System.Collections;
using System.Collections.Generic;
using Charcter;
using UnityEngine;

public class Person : MonoBehaviour
{
    [SerializeField] private PersonData personData;
    public PersonData Data => personData;

    public void Die()
    {
        Destroy(gameObject);
    }
}