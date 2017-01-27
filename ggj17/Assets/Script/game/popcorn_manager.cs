using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

    public Text wave_counter;
    public Text life_counter;
    public Text timer;

    public float initial_force = 90.0f;
    public float multiply_factor = 5.0f;

    private GameObject[] spawn_points;

    // Use this for initialization
    void Start ()
    {
        spawn_points = GameObject.FindGameObjectsWithTag ("popcorn_spawn_point");
    }
	
    // Update is called once per frame
    void Update ()
    {
        // if not game win and not game over
        if ((game_manager.Instance.game_win_state == false) && (game_manager.Instance.game_over_state == false)) {
            int aux = (int)game_manager.Instance.time_left;
            timer.text = "00:" + aux.ToString ();
            if (aux < 10) {
                timer.text = "00:0" + aux.ToString ();
            } else if (aux < 0) {
                timer.text = "00:00";
            }

            life_counter.text = "LIVES: " + game_manager.Instance.player_initial_life;
            if (game_manager.Instance.player_initial_life < 0)
                life_counter.text = "LIVES: 0";

            wave_counter.text = "WAVE: " + game_manager.Instance.wave_in_play;

        } 
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
