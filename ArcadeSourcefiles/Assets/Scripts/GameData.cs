using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Score : IComparable<Score>
{

    public string name;
    public int score;
    public bool increasing;

    public Score(string n, int s) {
        name = n;
        score = s;
    }

    public int CompareTo(Score obj)
    {
        return score - obj.score;
    }
}

/**
 * JSonUtility provided by Unity doesn't support arrays
 * this class is here to fulfill this operation
 */
public static class JsonHelper
{
    public static T[] FromJson<T>(string json)
    {
        Wrapper<T> wrapper = JsonUtility.FromJson<Wrapper<T>>(json);
        return wrapper != null ? wrapper.scores : null;
    }

    public static string ToJson<T>(T[] array)
    {
        Wrapper<T> wrapper = new Wrapper<T>();
        wrapper.scores = array;
        return JsonUtility.ToJson(wrapper);
    }

    public static string ToJson<T>(T[] array, bool prettyPrint)
    {
        Wrapper<T> wrapper = new Wrapper<T>();
        wrapper.scores = array;
        return JsonUtility.ToJson(wrapper, prettyPrint);
    }

    [Serializable]
    private class Wrapper<T>
    {
        public T[] scores;
    }
	
}