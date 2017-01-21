using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class popcorn : MonoBehaviour
{

    public GameObject popcorn_prefab;

    // Use this for initialization
    void Start ()
    {
//        Vector3 dir = Quaternion.AngleAxis (Random.Range (12, 78), Vector3.forward) * Vector3.right;
//
//        GetComponent<Rigidbody2D> ().AddForce (dir * -10000.0f);	
    }
	
    // Update is called once per frame
    void Update ()
    {
    }

    void OnCollisionEnter2D (Collision2D obj)
    {
//        print ("popcorn on collision enter");
    }

    void OnCollisionExit2D (Collision2D obj)
    {
//        print ("popcorn on collision exit");
    }
}
