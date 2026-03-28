using UnityEngine;

public class GoalTrigger : MonoBehaviour
{
    public GameObject creditUI;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Safe"))
        {
            Debug.Log("ถึงแล้ว!");

            // เปิด Credit
            creditUI.SetActive(true);

            // หยุดเกม
            Time.timeScale = 0f;
        }
    }
}