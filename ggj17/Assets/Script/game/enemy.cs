using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    public float force_constant = 1200f;
    private int count_collisions = 0;
    public int max_collision = 3;

    // Use this for initialization
    void Start ()
    {
        Vector3 dir = Quaternion.AngleAxis (Random.Range (12, 78), Vector3.forward) * Vector3.right;

        GetComponent<Rigidbody2D> ().AddForce (dir * force_constant);

        Physics2D.IgnoreLayerCollision (10, 11);
    }
	
    // Update is called once per frame
    void Update ()
    {
        if (count_collisions > max_collision) {
            Destroy (gameObject);
            game_manager.Instance.hello ();
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
