using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class game_manager : MonoBehaviour
{
    

    // Use this for initialization
    void Start ()
    {
		
    }
	
    // Update is called once per frame
    void Update ()
    {
		
    }

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
    }

    public void LoadLevel (string Scene)
    {
        Application.LoadLevel (Scene);
    }
}
