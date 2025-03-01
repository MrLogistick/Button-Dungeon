using System.Collections;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.InputSystem;
using Unity.Cinemachine;

public class Health : MonoBehaviour
{
    [SerializeField] float startHealth;
    float maxHealth;
    [SerializeField] float health;

    [SerializeField] Image toxinFill;
    [SerializeField] GameObject gameOverPanel;

    [HideInInspector]
    public bool hasMask = false;

    void Start() {
        maxHealth = startHealth;
        health = startHealth;
    }

    void Update() {
        if (health <= 0) {
            Die();
        }

        if (toxinFill != null) {
            toxinFill.fillAmount = health / startHealth;
        }

        if (Input.GetKey(KeyCode.LeftShift) && Input.GetKeyDown(KeyCode.M)) {
            hasMask = true;
        }
    }

    public void TakeDamage(float damage) {
        health -= damage;
    }

    public void LoseMaxHealth(float damage) {
        maxHealth -= damage;

        if (health > maxHealth) {
            health = maxHealth;
        }
    }

    void Die() {
        print("You Died");
        gameOverPanel.SetActive(true);
        GetComponent<PlayerInput>().enabled = false;
    }
}