using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public static class Extensions
{
    public static T GetRandomElement<T>(this List<T> enumerable)
    {
        return enumerable[Random.Range(0, enumerable.Count)];
    }
}