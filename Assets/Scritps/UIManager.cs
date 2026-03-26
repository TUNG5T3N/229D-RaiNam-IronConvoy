using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public PointSystem pointSystem;
    public Text pointText;

    private void Start()
    {
        pointText = GetComponent<Text>();
    }

    void Update()
    {
        pointText.text = "Point: " + pointSystem.GetPoints();
    }
}
