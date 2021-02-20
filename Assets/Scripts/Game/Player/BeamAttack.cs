using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeamAttack : MonoBehaviour {

    public float beamActiveTimeSet = 0.2f;

    float beamActiveTime;

    void Update() {
        if(beamActiveTime <= 0) {
            gameObject.SetActive(false);
        }
        beamActiveTime -= Time.deltaTime;
    }

    void OnEnable() {
        Vector3 dir = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        angle += 90;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        beamActiveTime = beamActiveTimeSet;
    }
}
