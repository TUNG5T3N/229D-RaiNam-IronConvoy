using UnityEngine;

public class PointSystem : MonoBehaviour
{
    private int playerPoint = 0;

    public void AddPoints(int point)
    {
        playerPoint += point;
        Debug.Log("Point: " + playerPoint);
    }

    public int GetPoints()
    {
        return playerPoint;
    }
}
