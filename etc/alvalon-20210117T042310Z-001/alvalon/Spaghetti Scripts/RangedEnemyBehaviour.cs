using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedEnemyBehaviour : MonoBehaviour
{
    public Transform target;
    private Rigidbody2D rb;
    private Vector2 movement;
    public float Speed;
    public float enemyDistance;
    public float retreatDistance;

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
    }
}
