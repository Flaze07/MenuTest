using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flamethrower : MonoBehaviour
{
    public float cooldownSet = 10.0f;

    private Animator animator;
    private GameObject flameCollider;
    private float cooldown;

    // Start is called before the first frame update
    void Start() {
        animator = GetComponent<Animator>();
        flameCollider = this.transform.GetChild(1).gameObject;
        cooldown = 0;
    }

    // Update is called once per frame
    void Update() {
        cooldown += Time.deltaTime;
        if(cooldown >= cooldownSet) {
            cooldown -= cooldownSet;
            animator.SetTrigger("activate");
        }
        /*
        if(Input.GetKeyDown(KeyCode.Space)) {
            animator.SetTrigger("activate");
        }*/
        if(animator.GetCurrentAnimatorStateInfo(0).IsName("Firing")) {
            flameCollider.SetActive(true);
        } else {
            flameCollider.SetActive(false);
        }
    }
}
