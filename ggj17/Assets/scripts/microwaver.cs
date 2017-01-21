using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class microwaver : MonoBehaviour
{
    public float force_constant = 300f;
    private int count_collisions = 0;

    // Use this for initialization
    void Start ()
    {
//        GetComponent<Rigidbody2D> ().AddForce (new Vector2 (force_constant, force_constant));
        Vector3 dir = Quaternion.AngleAxis (Random.Range (12, 35), Vector3.forward) * Vector3.right;

        GetComponent<Rigidbody2D> ().AddForce (dir * force_constant);
    }
	
    // Update is called once per frame
    void Update ()
    {
        if (count_collisions > 3) {
            game_manager.Instance.hello ();
            Destroy (gameObject);
        }
    }

    void OnCollisionEnter2D (Collision2D obj)
    {
        if ((obj.gameObject.tag == "ground") || (obj.gameObject.tag == "wall_left") || (obj.gameObject.tag == "wall_right")) {
            count_collisions++;
        }
    }

    void OnCollisionExit2D (Collision2D obj)
    {
    }
}
