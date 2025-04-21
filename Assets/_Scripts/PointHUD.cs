using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PointHUD : MonoBehaviour
{
    [SerializeField] 
    private TextMeshProUGUI pointText;

    private int points;
    public int Points 
    {
        get => points;
        set
        {
            if (points == value) return;
            points = value;
            UpdateHUD();
        }
    }

    private void Awake()
    {
        UpdateHUD();
    }

    public void UpdateHUD()
    {
        pointText.text = points.ToString();
    }
}
