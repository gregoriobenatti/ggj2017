using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement_manager : MonoBehaviour
{
    public float move_speed, jump_height;
    public bool is_ground = false;
    public bool change_direction = false;

    // Use this for initialization
    void Start ()
    {
		
    }
	
    // Update is called once per frame
    void Update ()
    {
        if (Input.GetAxisRaw ("Horizontal") > 0) {
            transform.Translate (Vector2.right * Time.deltaTime * move_speed);
        } else if (Input.GetAxisRaw ("Horizontal") < 0) {
            transform.Translate (Vector2.left * Time.deltaTime * move_speed);
        }

        if (Input.GetAxisRaw ("Vertical") > 0 && is_ground) {
            GetComponent<Rigidbody2D> ().AddForce (Vector2.up * jump_height, ForceMode2D.Impulse);
        }

        if (is_ground) {
            if (change_direction) {
                transform.Translate (Vector2.left * Time.deltaTime * move_speed);
            } else {
                transform.Translate (Vector2.right * Time.deltaTime * move_speed);
            }
        }
    }

    void OnCollisionEnter2D (Collision2D obj)
    {
        if (obj.gameObject.tag == "ground") {
            is_ground = true;
        }

        if (obj.gameObject.tag == "wall_right") {
            change_direction = true;
        } else if (obj.gameObject.tag == "wall_left") {
            change_direction = false;
        }
    }

    void OnCollisionExit2D (Collision2D obj)
    {
        if (obj.gameObject.tag == "ground") {
            is_ground = false;
        }
    }
}
