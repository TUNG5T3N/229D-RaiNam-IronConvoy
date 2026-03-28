using UnityEngine;
using UnityEngine.UI;

public class HealthSystem : MonoBehaviour
{
    public float maxHP = 100f;
    private float currentHP;

    public Image hpBar;
    public GameObject gameOverUI;

    void Start()
    {
        currentHP = maxHP;
        UpdateHPUI();
        gameOverUI.SetActive(false);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            TakeDamage(10f);
        }
    }

    void TakeDamage(float damage)
    {
        currentHP -= damage;

        if (currentHP <= 0)
        {
            currentHP = 0;
            Die();
        }

        UpdateHPUI();
    }

    void UpdateHPUI()
    {
        hpBar.fillAmount = currentHP / maxHP;
    }

    void Die()
    {
        Debug.Log("Game Over!");

        // áÊ´§ UI
        gameOverUI.SetActive(true);

        // ËÂØ´à¡Á
        Time.timeScale = 0f;
    }
}