using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int health = 50;
    
    public void TakeDamage(int damage)
    {
        health -= damage;
        Debug.Log($"{name}: took {damage} damage!");

        if (health <= 0)
        {
            // ให้เสก VFX การตายของศัตรู และทำลาย VFX นั้นตามเวลาที่ต้องการ

            Destroy(gameObject, 0.5f);
        }
    }

    public bool isDead()
    {
        return health <= 0;
    }
}
