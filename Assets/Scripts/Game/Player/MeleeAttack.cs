using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttack : MonoBehaviour
{
    public Animator meleeAnimator;
    public float hitCooldownSet = 0.3f;

    private float hitCooldown;

    void Update() {
        if(hitCooldown > 0) {
            hitCooldown -= Time.deltaTime;
        }
    }

    void OnTriggerStay2D(Collider2D other) {
        if(other.tag == "Enemy") {
            if(hitCooldown <= 0 && meleeAnimator.GetCurrentAnimatorStateInfo(0).IsName("slice")) {
                other.GetComponent<EnemyHealthManager>().OnDamaged(transform.gameObject);
                hitCooldown = hitCooldownSet;
            }
        }
    }
}
