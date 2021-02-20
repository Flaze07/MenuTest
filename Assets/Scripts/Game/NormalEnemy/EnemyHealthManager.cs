using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthManager : MonoBehaviour
{
    public float hitCooldownSet = 0.5f;
    public int health = 3;
    public float knockbackForceSet = 300;

    private float hitCooldown;
    private Rigidbody2D rb;

    void Start() {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update() {
        if(hitCooldown > 0) {
            hitCooldown -= Time.deltaTime;
        }
    }

    public void OnDamaged(GameObject other) {
        if(hitCooldown > 0) return;
        hitCooldown = hitCooldownSet;
        health--;
        if(health == 0) {
            Destroy(this.gameObject);
        }
        Vector3 dir = transform.position - other.transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        angle -= 90;
        Vector3 knockbackForce = new Vector3(knockbackForceSet * Mathf.Cos(angle) * Mathf.Rad2Deg, 
                                    knockbackForceSet * Mathf.Sin(angle) * Mathf.Rad2Deg, 
                                    0);
        rb.AddForce(knockbackForce, ForceMode2D.Force);
    }
}
