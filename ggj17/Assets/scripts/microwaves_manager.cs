using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class microwaves_manager : MonoBehaviour
{
    public GameObject micro_wave_prefab;

    public int timeBetweenWaves = 5;
    private bool start_next_wave = false;

    IEnumerator  StartedQuest ()
    {
        yield return new WaitForSeconds (timeBetweenWaves);

        start_next_wave = true;
    }

    void Start ()
    {
        GameObject new_waver = (GameObject)Instantiate (micro_wave_prefab);
        new_waver.transform.Translate (new Vector2 (Random.Range (-16, -5), Random.Range (1, 3)));

        //first waver
        StartCoroutine (StartedQuest ());
    }

    // Update is called once per frame
    void Update ()
    {
        if (start_next_wave == true) {
            GameObject new_waver = (GameObject)Instantiate (micro_wave_prefab);
            new_waver.transform.Translate (new Vector2 (Random.Range (-16, -5), Random.Range (1, 3)));

            start_next_wave = false;

            //others wavers
            StartCoroutine (StartedQuest ());
        }
//        if (waver_count < max_waver) {
//            GameObject new_waver = (GameObject)Instantiate (micro_wave_prefab);
//            new_waver.transform.Translate (new Vector2 (Random.Range (-16, -5), Random.Range (1, 3)));
//
//            waver_count++;
//        }
    }
}
