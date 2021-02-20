using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBehaviour : MonoBehaviour
{
    public Transform target;
    private Rigidbody2D rb;
    private Vector2 movement;
    public float Speed;

    public float damage;
    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = target.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        rb.rotation = angle;
        direction.Normalize();
        movement = direction;
    }
    private void FixedUpdate()
    {
         charge(movement);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.tag == "Player")
        {
            Speed = 0;
            /*transform.GetComponent<Player>.health -= damage;*/
        }
    }
    void charge(Vector2 direction)
    {
        rb.MovePosition((Vector2)transform.position + (direction * Speed * Time.fixedDeltaTime));
    }
}