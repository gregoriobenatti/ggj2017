using System.Collections;
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
    public int player_initial_life = 5;
    public float time_left = 0f;
    public float time_left_w2 = 0f;
    public float time_left_w3 = 0f;
    public int wave_in_play = 1;
    public bool is_counting = false;

    public bool game_win_state = false;
    public bool game_over_state = false;


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
        popcorn_manager.Instance.spawn_new_popcorn ();
    }

    void Start ()
    {
        game_win_state = false;
        game_over_state = false;

        reset_timer_and_life ();
        is_counting = true;
    }

    public void reset_timer_and_life ()
    {
        time_left = 61.0f;
        time_left_w2 = 61.0f;
        time_left_w3 = 91.0f;

        player_initial_life = 10;
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
        wave_time_manager (is_counting);

        if ((time_left <= 0) && (player_initial_life >= 0)) {
            game_win ();
        } else if ((time_left >= 0) && (player_initial_life <= 0)) {
            game_over ();
        }

    }

    public void wave_time_manager (bool is_counting)
    {
        if (is_counting) {
            time_left -= Time.deltaTime;
        }
    }

    public void change_player_life ()
    {
        player_initial_life -= 1;
    }

    public void start_game ()
    {
    }

    public void game_win ()
    {
        stop_this_shit ();

        game_win_state = true;

        GameManager.Instance.ChangeState (GameManager.States.Win);
        GameManager.Instance.LoadLevel ("game_win");

        is_counting = false;
        Destroy (gameObject);
    }

    public void game_over ()
    {
        stop_this_shit ();

        game_over_state = true;

        GameManager.Instance.ChangeState (GameManager.States.GameOver);
        GameManager.Instance.LoadLevel ("game_over");

        is_counting = false;
        Destroy (gameObject); 
    }

    public void stop_this_shit ()
    {
        GameObject[] gos = GameObject.FindGameObjectsWithTag ("blah");
        foreach (GameObject go in gos)
            Destroy (go);
    }

}
