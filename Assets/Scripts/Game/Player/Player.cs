using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour {
    public Transform meleeTransform;
    public Animator meleeAnimator;
    public float speed;
    public float attackCooldownSet;
    public float beamCooldownSet;
    public GameObject cameraObject;
    public GameObject beamAttack;
    public Image beamCooldownUI;

    private Vector2 prevPos;
    private float attackCooldown;
    private float beamCooldown;
    private bool hasAttacked;

    private Rigidbody2D rb;
    private Animator animator;

    void Start() {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        meleeAnimator.StopPlayback();
    }

    // Update is called once per frame
    void Update() {
        prevPos = transform.position;
        MeleeLook();
        if(Input.GetMouseButtonDown(0) && !hasAttacked) {
            meleeAnimator.Play("slice");
            hasAttacked = true;
        }
        if(Input.GetKey(KeyCode.E) && beamCooldown <= 0) {
            beamAttack.SetActive(true);
            beamCooldown += beamCooldownSet;
        }
        if(hasAttacked) {
            attackCooldown += Time.deltaTime;
            if(attackCooldown >= attackCooldownSet) {
                attackCooldown -= attackCooldownSet;
                hasAttacked = false;
            }
        }
        if(beamCooldown > 0) {
            beamCooldown -= Time.deltaTime;
            if(beamCooldown < 0) {
                beamCooldown = 0;
            }
            beamCooldownUI.rectTransform.sizeDelta = new Vector2(100, 100 / (beamCooldown+1));
        }
        cameraObject.transform.position = new Vector3(transform.position.x, transform.position.y, cameraObject.transform.position.z);
    }

    void FixedUpdate() {
        Movement();
    }

    void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.tag == "Wall") {
            transform.position = prevPos;
        }
    }

    void Movement() {
        bool up = false, down = false, left = false, right = false;
        if(Input.GetKey("w")) {
            up = true;
        }
        if(Input.GetKey("s")) {
            down = true;
        }
        if(Input.GetKey("d")) {
            right = true;
        }
        if(Input.GetKey("a")) {
            left = true;
        }
        Vector2 movement = new Vector2(0, 0);
        bool isMoving = up || down || left || right;
        float calSpeed = speed * Time.fixedDeltaTime;
        if(up) {
            movement.y += calSpeed;
        }
        if(down) {
            movement.y -= calSpeed;
        }
        if(left) {
            movement.x -= calSpeed;
        }
        if(right) {
            movement.x += calSpeed;
        }
        rb.velocity = movement;
        AnimateMovement(isMoving);
    }

    void AnimateMovement(bool isMoving) {
        Vector3 dir = Input.mousePosition - Camera.main.WorldToScreenPoint(meleeTransform.position);
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        if(angle < 0) {
            angle += 360;
        }
        if(isMoving) {
            if(angle >= 337.5 || angle < 22.5) {
                if(!animator.GetCurrentAnimatorStateInfo(0).IsName("WalkRight")) {
                    animator.enabled = false;
                    animator.enabled = true;
                    animator.Play("WalkRight", 0);
                }
                //right = true;
            } else if(angle >= 22.5 && angle < 67.5) {
                if(!animator.GetCurrentAnimatorStateInfo(0).IsName("WalkBackwardRight")) {
                    animator.enabled = false;
                    animator.enabled = true;
                    animator.Play("WalkBackwardRight", 0);
                }
                //backwardRight = true;
            } else if(angle >= 67.5 && angle < 112.5) {
                if(!animator.GetCurrentAnimatorStateInfo(0).IsName("WalkBackward")) {
                    animator.enabled = false;
                    animator.enabled = true;
                    animator.Play("WalkBackward", 0);
                }
                //backward = true;
            } else if(angle >= 112.5 && angle < 157.5) {
                if(!animator.GetCurrentAnimatorStateInfo(0).IsName("WalkBackwardLeft")) {
                    animator.enabled = false;
                    animator.enabled = true;
                    animator.Play("WalkBackwardLeft", 0);
                }
                //backwardLeft = true;
            } else if(angle >= 157.5 && angle < 202.5) {
                if(!animator.GetCurrentAnimatorStateInfo(0).IsName("WalkLeft")) {
                    animator.enabled = false;
                    animator.enabled = true;
                    animator.Play("WalkLeft", 0);
                }
                //left = true;
            } else if(angle >= 202.5 && angle < 247.5) {
                if(!animator.GetCurrentAnimatorStateInfo(0).IsName("WalkForwardLeft")) {
                    animator.enabled = false;
                    animator.enabled = true;
                    animator.Play("WalkForwardLeft", 0);
                }
                //forwardLeft = true;
            } else if(angle >= 247.5 && angle < 292.5) {
                if(!animator.GetCurrentAnimatorStateInfo(0).IsName("WalkForward")) {
                    animator.enabled = false;
                    animator.enabled = true;
                    animator.Play("WalkForward", 0);
                }
                //forward = true;
            } else if(angle >= 292.5 && angle < 337.5) {
                if(!animator.GetCurrentAnimatorStateInfo(0).IsName("WalkForwardRight")) {
                    animator.enabled = false;
                    animator.enabled = true;
                    animator.Play("WalkForwardRight", 0);
                }
                //forwardRight = true;
            }
        } else {
            if(angle >= 337.5 || angle < 22.5) {
                if(!animator.GetCurrentAnimatorStateInfo(0).IsName("IdleRight")) {
                    animator.enabled = false;
                    animator.enabled = true;
                    animator.Play("IdleRight", 0);
                }
                //right = true;
            } else if(angle >= 22.5 && angle < 67.5) {
                if(!animator.GetCurrentAnimatorStateInfo(0).IsName("IdleBackwardRight")) {
                    animator.enabled = false;
                    animator.enabled = true;
                    animator.Play("IdleBackwardRight", 0);
                }
                //backwardRight = true;
            } else if(angle >= 67.5 && angle < 112.5) {
                if(!animator.GetCurrentAnimatorStateInfo(0).IsName("IdleBackward")) {
                    animator.enabled = false;
                    animator.enabled = true;
                    animator.Play("IdleBackward", 0);
                }
                //backward = true;
            } else if(angle >= 112.5 && angle < 157.5) {
                if(!animator.GetCurrentAnimatorStateInfo(0).IsName("IdleBackwardLeft")) {
                    animator.enabled = false;
                    animator.enabled = true;
                    animator.Play("IdleBackwardLeft", 0);
                }
                //backwardLeft = true;
            } else if(angle >= 157.5 && angle < 202.5) {
                if(!animator.GetCurrentAnimatorStateInfo(0).IsName("IdleLeft")) {
                    animator.enabled = false;
                    animator.enabled = true;
                    animator.Play("IdleLeft", 0);
                }
                //left = true;
            } else if(angle >= 202.5 && angle < 247.5) {
                if(!animator.GetCurrentAnimatorStateInfo(0).IsName("IdleForwardLeft")) {
                    animator.enabled = false;
                    animator.enabled = true;
                    animator.Play("IdleForwardLeft", 0);
                }
                //forwardLeft = true;
            } else if(angle >= 247.5 && angle < 292.5) {
                if(!animator.GetCurrentAnimatorStateInfo(0).IsName("IdleForward")) {
                    animator.enabled = false;
                    animator.enabled = true;
                    animator.Play("IdleForward", 0);
                }
                //forward = true;
            } else if(angle >= 292.5 && angle < 337.5) {
                if(!animator.GetCurrentAnimatorStateInfo(0).IsName("IdleForwardRight")) {
                    animator.enabled = false;
                    animator.enabled = true;
                    animator.Play("IdleForwardRight", 0);
                }
                //forwardRight = true;
            }
        }
        animator.SetBool("PlayerMoving", isMoving);
    }

    void MeleeLook() {
        Vector3 dir = Input.mousePosition - Camera.main.WorldToScreenPoint(meleeTransform.position);
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        angle += 90;
        meleeTransform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        meleeTransform.position = transform.position;
    }

    public void ResetCooldown() {
        attackCooldown = 0;
        beamCooldown = 0;
        hasAttacked = false;
    }
}
