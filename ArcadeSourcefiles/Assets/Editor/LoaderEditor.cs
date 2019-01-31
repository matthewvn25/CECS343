using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(Loader))]
public class LoaderEditor : Editor {
    // A button to instantiate our Singleton if something happened
    public override void OnInspectorGUI() {
        DrawDefaultInspector();
        
        Loader myScript = (Loader)target;
        
        if (GUILayout.Button("Load Manager")) {
            if (myScript.gamesManager != null) {
                PrefabUtility.InstantiatePrefab(myScript.gamesManager);
            }
        }
    }
}