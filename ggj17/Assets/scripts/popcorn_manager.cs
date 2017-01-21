using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class popcorn_manager : MonoBehaviour
{

    public GameObject popcorn_prefab;
    public GameObject popcorn_spwan_point;

    // Use this for initialization
    void Start ()
    {
		
    }
	
    // Update is called once per frame
    void Update ()
    {
		
    }

    private static popcorn_manager _instance;

    public static popcorn_manager Instance {
        get {
            if (_instance == null)
                _instance = GameObject.FindObjectOfType<popcorn_manager> ();

            if (_instance == null) {
                GameObject singleton = new GameObject ("popcorn");
                _instance = singleton.AddComponent<popcorn_manager> ();
            }

            DontDestroyOnLoad (_instance);
            return _instance;
        }
    }

    public void mameluco_test ()
    {
        GameObject new_popcorn = (GameObject)Instantiate (popcorn_prefab);

        new_popcorn.transform.position = popcorn_spwan_point.transform.position;
    }


}
