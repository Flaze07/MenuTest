using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public int maxMelee = 3;
    public int maxRange = 3;

    public GameObject enemyMeleePrefab;
    public GameObject enemyRangedPrefab;

    public Transform targetTransform;

    void OnTriggerEnter2D(Collider2D other) {
        if(other.tag != "Player") {
            return;
        }
        int meleeCount = Random.Range(1, maxMelee);
        int rangeCount = Random.Range(1, maxRange);
        for(int i = 0; i < meleeCount; ++i) {
            var melee = Instantiate(enemyMeleePrefab, transform.position, transform.rotation);
            melee.GetComponent<EnemyMeleeBehaviour>().target = targetTransform;
        }
        for(int i = 0; i < rangeCount; ++i) {
            var ranged = Instantiate(enemyRangedPrefab, transform.position, transform.rotation);
            ranged.GetComponent<EnemyRangedBehaviour>().target = targetTransform;
        }
        Destroy(transform.gameObject);
    }
}
