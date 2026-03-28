using UnityEngine;
using UnityEngine.UI;

public class TimerBar : MonoBehaviour
{
    public float maxTime = 60f;
    private float currentTime;

    public Image timeBar;

    void Start()
    {
        currentTime = maxTime;
    }

    void Update()
    {
        if (currentTime > 0)
        {
            currentTime -= Time.deltaTime;

            // แปลงเป็น 0-1
            timeBar.fillAmount = currentTime / maxTime;
        }
        else
        {
            currentTime = 0;
            Debug.Log("Time Up!");
        }
    }
}