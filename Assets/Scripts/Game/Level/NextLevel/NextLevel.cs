using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextLevel : MonoBehaviour
{
    public Transform nextLevelPosition;

    public void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Player") {
            other.transform.position = nextLevelPosition.position;
            other.GetComponent<Player>().ResetCooldown();
        }
    }
}
