 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealthManager : MonoBehaviour
{
    public int healthCount = 6;
    public Sprite[] healthSprite;
    public Image[] healthUI;
    public float whiteBlinkTimeSet = 0.2f;
    public GameObject deathMenu;

    private float whiteBlinkTime;
    private bool isBlinking;

    void OnHealthChanged() {
        if(healthCount <= 0) {
            deathMenu.SetActive(true);
            GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
            for(int i = 0; i < enemies.Length; ++i) {
                Destroy(enemies[i]);
            }
            Destroy(transform.gameObject);
        }
        for(int i = 0; i < healthUI.Length; ++i) {
            healthUI[i].sprite = healthSprite[4];
        }
        for(int i = healthCount, j = 0; i > 0; i -= 2, j++) {
            if(i / 2 == 0) {
                healthUI[j].sprite = healthSprite[2];
            } else {
                healthUI[j].sprite = healthSprite[0];
            }
        }
    }

    public void HealthDecreased(int amount) {
        healthCount -= amount;
        OnHealthChanged();
    }
}
