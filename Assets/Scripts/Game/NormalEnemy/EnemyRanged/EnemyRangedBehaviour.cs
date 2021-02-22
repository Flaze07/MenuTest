using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRangedBehaviour : MonoBehaviour
{
    public Transform target;
    public float speed;
    public float enemyDistance;
    public float retreatDistance;
    public float attackCooldownSet = 1f;
    public GameObject arrow;

    private Rigidbody2D rb;
    private Vector2 movement;
    private Animator animator;
    private float attackCooldown;
    private EnemyRangedAudioManager audioManager;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        audioManager = GetComponent<EnemyRangedAudioManager>();
    }

    // Update is called once per frame
    void Update()
    {
        LookAtPlayer();
        float dist = Vector2.Distance(transform.position, target.position);
        if(attackCooldown <= 0) {
            if(dist < enemyDistance && dist > retreatDistance) {
                Vector3 direction = target.position - transform.position;
                float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
                Instantiate(arrow, transform.position, Quaternion.Euler(0, 0, angle - 90));
                audioManager.PlaySound("shoot");
            }
            attackCooldown = attackCooldownSet;
        } else {
            attackCooldown -= Time.deltaTime;
        }
    }

    void FixedUpdate() {
        characterMovement();
    }

    void characterMovement() {
        /*
        Vector3 direction = target.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        direction.Normalize();
        float dist = Vector2.Distance(transform.position, target.position);
        if(dist > enemyDistance) {
            rb.MovePosition((Vector2)transform.position + (Vector2)(direction * speed * Time.deltaTime));
        } else if(dist < retreatDistance) {
            rb.MovePosition((Vector2)transform.position + (Vector2)(direction * -speed * Time.deltaTime));
        }
        */
        Vector3 direction = target.position - transform.position;
        //float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        float dist = Vector2.Distance(transform.position, target.position);
        direction.Normalize();
        Vector2 movement;
        movement.x = direction.x * speed * Time.fixedDeltaTime;
        movement.y = direction.y * speed * Time.fixedDeltaTime;
        if(dist > enemyDistance) {
            rb.velocity = movement;
        } else if(dist < retreatDistance) {
            movement.x = -movement.x;
            movement.y = -movement.y;
            rb.velocity = movement;
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

    /*
    private void FixedUpdate()
    {
        if (Vector2.Distance(transform.position, target.position) > enemyDistance)
        {
            moveEnemy(movement);
        }else if(Vector2.Distance(transform.position, target.position) < enemyDistance && Vector2.Distance(transform.position, target.position) > retreatDistance)
        {
            transform.position = this.transform.position;
        }else if(Vector2.Distance(transform.position, target.position) < retreatDistance)
        {
            moveBackwardsEnemy(movement);
        }
    }
    void moveEnemy(Vector2 direction)
    {
            rb.MovePosition((Vector2)transform.position + (direction * Speed * Time.fixedDeltaTime));
    }

    void moveBackwardsEnemy(Vector2 direction)
    {
        rb.MovePosition((Vector2)transform.position + (direction * -Speed * Time.fixedDeltaTime));
    }*/
}
