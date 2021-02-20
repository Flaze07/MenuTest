using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    public int index;
    public GameManagerLevel1 gameManager;

    private Animator animator;

    void Start() {
        animator = GetComponent<Animator>();
    }

    void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "PlayerLeg" || other.tag == "Beam") {
            animator.SetBool("isPressed", true);
            gameManager.SetPressurePlateState(index, true);
        }
    }
}
