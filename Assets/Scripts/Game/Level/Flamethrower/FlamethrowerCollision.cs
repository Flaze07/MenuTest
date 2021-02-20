using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlamethrowerCollision : MonoBehaviour
{
    void OnTriggerStay2D(Collider2D other) {
        if(other.tag == "Player") {
            other.GetComponent<PlayerDamaged>().OnPlayerDamaged(transform.gameObject, 1);
        }
    }
}
