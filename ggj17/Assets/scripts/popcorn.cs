using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class popcorn : MonoBehaviour
{

    public GameObject popcorn_prefab;

    // Use this for initialization
    void Start ()
    {
		
    }
	
    // Update is called once per frame
    void Update ()
    {
        //ARRUMAR SAPOHA
    }

    private static popcorn _instance;

    public static popcorn Instance {
        get {
            if (_instance == null)
                _instance = GameObject.FindObjectOfType<popcorn> ();

            if (_instance == null) {
                GameObject singleton = new GameObject ("popcorn");
                _instance = singleton.AddComponent<popcorn> ();
            }

            DontDestroyOnLoad (_instance);
            return _instance;
        }
    }

    public void mameluco_test ()
    {
        print ("mameluco...");
//        GameObject new_popcorn = (GameObject)Instantiate (popcorn_prefab);
        popcorn_prefab.transform.Translate (new Vector2 (Random.Range (-250, -200), Random.Range (80, 85)));
    }
}
