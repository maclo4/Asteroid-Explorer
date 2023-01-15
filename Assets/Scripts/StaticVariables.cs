using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class StaticVariables
{
    public static GameObject player;
}
/*
public class StaticVariables : MonoBehaviour
{
    public static StaticVariables instance;
    void Awake(){
        if (instance == null) {
            DontDestroyOnLoad (gameObject);
            instance = this;
        } else if (instance != this) {
            Destroy (gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}*/
