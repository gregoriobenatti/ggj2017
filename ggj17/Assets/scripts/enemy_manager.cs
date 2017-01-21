using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_manager : MonoBehaviour
{
    public GameObject enemy_prefab;
    public GameObject enemy_spawn_point_left;
    public GameObject enemy_spawn_point_center;
    public GameObject enemy_spawn_point_right;

    private GameObject[] enemies;

    public int timeBetweenWaves = 2;
    private bool start_next_wave = false;


    IEnumerator  StartedQuest ()
    {
        yield return new WaitForSeconds (timeBetweenWaves);

        start_next_wave = true;
    }

    private void add_enemy ()
    {
        GameObject new_enemy = Instantiate (enemy_prefab);
        new_enemy.transform.position = enemies [Random.Range (1, 3)].transform.position;
    }

    void Start ()
    {
        enemies = GameObject.FindGameObjectsWithTag ("enemies_spawn_point");
      
        //first waver
        StartCoroutine (StartedQuest ());
    }

    // Update is called once per frame
    void Update ()
    {
        if (start_next_wave == true) {
            add_enemy ();

            start_next_wave = false;

            //others wavers
            StartCoroutine (StartedQuest ());
        }
    }
}
