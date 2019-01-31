using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Object = UnityEngine.Object;
#if UNITY_EDITOR
    using UnityEditor;
#endif

[ExecuteInEditMode]
public class GamesManager : MonoBehaviour {
    private static GamesManager _instance = null;
    public static GamesManager instance {get{return _instance;} set{_instance = value;}}
    public List<string> scenes;

    // Initialize the Singleton
    void Awake() {
        if (instance == null)
            instance = this;
        else {

            Debug.Log("Deleting excessive, instance of GamesManager");
            #if UNITY_EDITOR
                Object.DestroyImmediate(gameObject);
            #else
                Object.Destroy(gameObject);
            #endif
        }
    }

    // Constructor set to private for the Singleton
    private GamesManager() { }

}
