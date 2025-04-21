using System.Collections;
using UnityEngine;

public class PointCounter : MonoBehaviour
{
    private static int pointsPlayer1;
    public static int PointsPlayer1
    {
        get => pointsPlayer1;
        set
        {
            if(pointsPlayer1 == value) return;
            pointsPlayer1 = value;
            GameManager.PointsChanged = true;
        }
    }

    private static int pointsPlayer2;
    public static int PointsPlayer2
    {
        get => pointsPlayer2;
        set
        {
            if (pointsPlayer2 == value) return;
            pointsPlayer2 = value;
            GameManager.PointsChanged = true;
        }
    }

    [SerializeField]
    private PointHUD pointHUD_Player1;

    [SerializeField]
    private PointHUD pointHUD_Player2;

    public void Start()
    {
        StartCoroutine(CountPoints());
    }
    private IEnumerator CountPoints()
    {
        while (true)
        {
            pointHUD_Player1.Points = PointsPlayer1;
            pointHUD_Player2.Points = PointsPlayer2;
            yield return new WaitForSeconds(0.5f);
        }
    }
}