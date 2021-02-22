using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowBehaviour : MonoBehaviour {
    public float speed = 2f;
    public float deathTimeSet = 5f;

    private float deathTime;
    private Rigidbody2D rb;

    void Start() {
        deathTime = deathTimeSet;
        rb = GetComponent<Rigidbody2D>();
    }

    void Update() {
        deathTime -= Time.deltaTime;
        if(deathTime <= 0) {
            Destroy(this.gameObject);
        }
    }

    void FixedUpdate() {
        rb.MovePosition(transform.position + (transform.up * speed * Time.deltaTime));
    }

    void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.tag == "Player") {
            other.gameObject.GetComponent<PlayerDamaged>().OnPlayerDamaged(transform.gameObject, 1);
            Destroy(this.gameObject);
        } else {
            Destroy(this.gameObject);
        }
    }
}
