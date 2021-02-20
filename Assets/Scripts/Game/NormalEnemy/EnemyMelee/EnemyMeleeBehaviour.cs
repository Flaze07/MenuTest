using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMeleeBehaviour : MonoBehaviour {
    public Transform target;
    public float speed;

    private Rigidbody2D rb;
    private Animator animator;
    private float attackTimeSet = 0.5f;
    private float attackTime;
    
    void Start() {
        rb = this.GetComponent<Rigidbody2D>();
        animator = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update() {
        LookAtPlayer();
    }

    void FixedUpdate() {
        characterMovement();
    }

    // void OnCollisionStay2D(Collision2D other) {
    //     if(other.gameObject.tag == "Player") {
    //         attackTime += Time.deltaTime;
    //         if(attackTime >= attackTimeSet) {
    //             other.gameObject.GetComponent<PlayerDamaged>().OnPlayerDamaged(transform.gameObject, 2);
    //             attackTime -= attackTimeSet;
    //         }
    //     }
    // }

    // void OnCollisionExit2D(Collision2D other) {
    //     if(other.gameObject.tag == "Player") {
    //         attackTime = 0;
    //     }
    // }

    void OnTriggerStay2D(Collider2D other) {
        if(other.tag == "Player") {
            attackTime += Time.deltaTime;
            if(attackTime >= attackTimeSet) {
                other.GetComponent<PlayerDamaged>().OnPlayerDamaged(transform.gameObject, 2);
                attackTime -= attackTimeSet;
            }
        }
    }

    void OnTriggerExit2D(Collider2D other) {
        if(other.tag == "Player") {
            attackTime = 0;
        }
    }

    void LookAtPlayer() {
        Vector3 direction = target.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        if(angle < 0) {
            angle += 360;
        }
        if(angle >= 315 || angle < 45 ) {
            if(!animator.GetCurrentAnimatorStateInfo(0).IsName("WalkRight")) {
                animator.enabled = false;
                animator.enabled = true;
                animator.Play("WalkRight");
            }
        } else if(angle >= 45 && angle < 135) {
            if(!animator.GetCurrentAnimatorStateInfo(0).IsName("WalkBackward")) {
                animator.enabled = false;
                animator.enabled = true;
                animator.Play("WalkBackward");
            }
        } else if(angle >= 135 && angle < 225) {
            if(!animator.GetCurrentAnimatorStateInfo(0).IsName("WalkLeft")) {
                animator.enabled = false;
                animator.enabled = true;
                animator.Play("WalkLeft");
            }
        } else if(angle >= 225 && angle < 315) {
            if(!animator.GetCurrentAnimatorStateInfo(0).IsName("WalkForward")) {
                animator.enabled = false;
                animator.enabled = true;
                animator.Play("WalkForward");
            }
        }
    }

    void characterMovement()
    {
        Vector3 direction = target.position - transform.position;
        direction.Normalize();
        Vector2 movement;
        movement.x = direction.x * speed * Time.fixedDeltaTime;
        movement.y = direction.y * speed * Time.fixedDeltaTime;
        rb.velocity = movement;
    }
}
