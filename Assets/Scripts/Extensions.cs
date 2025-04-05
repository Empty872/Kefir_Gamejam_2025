using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Random = UnityEngine.Random;

public static class Extensions
{
    public static T GetRandomElement<T>(this List<T> list)
    {
        return list[Random.Range(0, list.Count)];
    }

    public static List<T> GetRandomElements<T>(this List<T> list, int count)
    {
        if (count > list.Count)
        {
            throw new Exception("Requested count more than count of list elements");
        }

        var newList = new List<T>();
        foreach (var element in list)
        {
            newList.Add(element);
        }

        var result = new List<T>();
        for (int i = 0; i < count; i++)
        {
            var randomElement = newList.GetRandomElement();
            result.Add(randomElement);
            newList.Remove(randomElement);
        }

        return result;
    }
}