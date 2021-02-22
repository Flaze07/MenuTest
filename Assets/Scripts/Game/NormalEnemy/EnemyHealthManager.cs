using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthManager : MonoBehaviour
{
    public float hitCooldownSet = 0.5f;
    public int health = 3;
    public float knockbackForceSet = 300;
    public SpriteRenderer spriteRenderer;
    public int flashCountSet = 5;
    public float flashTimeSet = 0.2f;

    private float hitCooldown;
    private Rigidbody2D rb;
    private int flashCount;
    private float flashTime;
    private bool colored;
    private Color originalColor;

    void Start() {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        originalColor = spriteRenderer.color;
        colored = false;
    }

    void Update() {
        if(hitCooldown > 0) {
            hitCooldown -= Time.deltaTime;
        }
        Flashing();
    }

    void Flashing() {
        if(flashCount > 0) {
            flashTime += Time.deltaTime;
            if(flashTime >= flashTimeSet) {
                flashTime -= flashTimeSet;
                if(!colored) {
                    spriteRenderer.color = new Color(originalColor.r, originalColor.g, originalColor.b, 0.5f);
                    colored = true;
                } else {
                    spriteRenderer.color = originalColor;
                    flashCount--;
                    colored = false;
                }
            }
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
        flashCount = flashCountSet;
        rb.AddForce(knockbackForce, ForceMode2D.Force);
    }
}
