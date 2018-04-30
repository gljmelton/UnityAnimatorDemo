using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float speed = 7f;
    public float jumpHeight = 7f;
    public bool moving = false;

    private Animator anim;
    private Rigidbody2D rb2d;
    private SpriteRenderer sr;
    private Vector2 _velocity;

	// Use this for initialization
	void Start () {
        anim = GetComponentInChildren<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
        sr = GetComponentInChildren<SpriteRenderer>();

        _velocity = Vector2.zero;
	}
	
	// Update is called once per frame
	void Update () {
        _velocity = new Vector2(0, rb2d.velocity.y);

        if (Input.GetKey(KeyCode.A)) {
            _velocity.x = -speed;
            moving = true;
        } else if (Input.GetKey(KeyCode.D)) {
            _velocity.x = speed;
            moving = true;
        } else moving = false;
        
        if (Input.GetKeyDown(KeyCode.Space)) {
            rb2d.AddForce(Vector2.up * jumpHeight);
            anim.SetTrigger("jump");
        }

        if (rb2d.velocity.x < 0f) {
            sr.flipX = true;
        } else if (rb2d.velocity.x > 0f) {
            sr.flipX = false;
        }

        rb2d.velocity = new Vector2(_velocity.x, rb2d.velocity.y);
        anim.SetFloat("vspeed", rb2d.velocity.y);
        anim.SetBool("moving", moving);
    }
}
