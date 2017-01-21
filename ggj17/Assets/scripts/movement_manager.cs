using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement_manager : MonoBehaviour
{
    public float move_speed = 7.0f;
    public float jump_height = 7.0f;
    public bool is_ground = false;
    public bool is_free_to_walk = true;

    private bool change_direction = false;


    void flip (int d)
    {
        float direction = 0.3f * d;
        transform.localScale = new Vector2 (direction, transform.localScale.y);
    }

    // Use this for initialization
    void Start ()
    {
        
    }
    
    // Update is called once per frame
    void Update ()
    {
        if (is_free_to_walk) {
            // Free walk
            if (Input.GetAxisRaw ("Horizontal") > 0) {
                transform.Translate (Vector2.right * Time.deltaTime * move_speed);
                flip (1);
            } else if (Input.GetAxisRaw ("Horizontal") < 0) {
                transform.Translate (Vector2.left * Time.deltaTime * move_speed);
                flip (-1);
            }
        } else {
            //automatic walk
            if (is_ground) {
                if (Input.GetAxisRaw ("Horizontal") > 0) {
                    change_direction = false;
                } else if (Input.GetAxisRaw ("Horizontal") < 0) {
                    change_direction = true;
                }
                if (change_direction) {
                    transform.Translate (Vector2.left * Time.deltaTime * move_speed);
                    flip (-1);
                } else {
                    transform.Translate (Vector2.right * Time.deltaTime * move_speed);
                    flip (1);
                }
            }
        }

        //JUMP
        if (Input.GetAxisRaw ("Vertical") > 0 && is_ground) {
            //fix it
//            GetComponent<Rigidbody2D> ().AddForce (Vector2.up * jump_height, ForceMode2D.Impulse);

            GetComponent<Rigidbody2D> ().velocity = new Vector2 (GetComponent<Rigidbody2D> ().velocity.x, jump_height * 3);
        }
    }

    void OnCollisionEnter2D (Collision2D obj)
    {
        if (obj.gameObject.tag == "ground" || obj.gameObject.tag == "popcorn") {
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
