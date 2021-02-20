using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeamCollision : MonoBehaviour {

    public GameObject player;

    void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Enemy") {
            other.GetComponent<EnemyHealthManager>().OnDamaged(player);
        }
    }
}
