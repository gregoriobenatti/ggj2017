﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class game_manager : MonoBehaviour
{
    public enum states
    {
        logo,
        menu,
        intro,
        pause,
        playing,
        game_over,
        game_win
    }

    public bool isPausePressed = false;
    public bool isMuted = false;

    private static game_manager _instance;

    public static game_manager Instance {
        get {
            if (_instance == null)
                _instance = GameObject.FindObjectOfType<game_manager> ();

            if (_instance == null) {
                GameObject singleton = new GameObject ("game_manager");
                _instance = singleton.AddComponent<game_manager> ();
            }

            DontDestroyOnLoad (_instance);
            return _instance;
        }
    }

    public void hello ()
    {
        print ("HELLO MOTHERFOCA...");
        popcorn.Instance.mameluco_test ();
    }

    public void LoadLevel (string Scene)
    {
        Application.LoadLevel (Scene);
    }

    public void LoadLevelAditive (string Scene)
    {
        Application.LoadLevelAdditive (Scene);
    }

    private void Awake ()
    {
    }

    private void Update ()
    {
        //work on it
        if (Input.GetKeyDown (KeyCode.Escape) || isPausePressed) { 
            
        }
    }

}
