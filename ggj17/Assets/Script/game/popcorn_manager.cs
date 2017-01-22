using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class popcorn_manager : MonoBehaviour
{

    public GameObject popcorn_prefab;

    public GameObject popcorn_spwan_point1;
    public GameObject popcorn_spwan_point2;
    public GameObject popcorn_spwan_point3;
    public GameObject popcorn_spwan_point4;
    public GameObject popcorn_spwan_point5;
    public GameObject popcorn_spwan_point6;
    public GameObject popcorn_spwan_point7;

    public GameObject wave_counter;
    public GameObject life_counter;
    public GameObject timer;

    public float initial_force = 90.0f;
    public float multiply_factor = 3.0f;

    private GameObject[] spawn_points;

    // Use this for initialization
    void Start ()
    {
        spawn_points = GameObject.FindGameObjectsWithTag ("popcorn_spawn_point");
    }
	
    // Update is called once per frame
    void Update ()
    {
//        life_counter.gameObject.text = "LIVES: " + game_manager.Instance.player_initial_life;
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

    public void spawn_new_popcorn ()
    {
        GameObject new_popcorn = (GameObject)Instantiate (popcorn_prefab);

        new_popcorn.transform.position = spawn_points [Random.Range (1, 7)].transform.position;

        new_popcorn.GetComponent<Rigidbody2D> ().AddForce (Vector2.up * initial_force, ForceMode2D.Impulse);
    }


}
