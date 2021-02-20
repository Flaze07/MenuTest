using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamaged : MonoBehaviour
{
    public int flashCountSet = 3;
    public float flashTimeSet = 0.5f;
    public float knockbackForceSet = 5;

    private bool colored;
    private SpriteRenderer sprite;
    private Rigidbody2D rb;
    private float flashTime;
    private int flashCount;
    private Color originalColor;
    private Vector3 knockbackForce;

    void Start() {
        sprite = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        colored = false;
        originalColor = sprite.color;
    }

    void Update() {
        if(flashCount > 0) {
            flashTime += Time.deltaTime;
            if(flashTime >= flashTimeSet) {
                flashTime -= flashTimeSet;
                if(!colored) {
                    sprite.color = new Color(originalColor.r, originalColor.g, originalColor.b, 0.5f);
                    colored = true;
                } else {
                    sprite.color = originalColor;
                    flashCount--;
                    colored = false;
                }
            }
        }
    }

    public void OnPlayerDamaged(GameObject other, int amount) {
        if(flashCount == 0) {
            Vector3 dir = transform.position - other.transform.position;
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            angle -= 90;
            knockbackForce = new Vector3(knockbackForceSet * Mathf.Cos(angle) * Mathf.Rad2Deg, 
                                        knockbackForceSet * Mathf.Sin(angle) * Mathf.Rad2Deg, 
                                        0);
            rb.AddForce(knockbackForce, ForceMode2D.Force);
            flashCount = flashCountSet; 
            GetComponent<PlayerHealthManager>().HealthDecreased(amount);
        }
    }
}
