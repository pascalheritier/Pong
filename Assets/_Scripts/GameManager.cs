using System;
using System.Collections;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int GameEndConditionCount = 3;
    public static bool IsNewMatchAsked = false;
    public static bool PointsChanged = false;

    [SerializeField]
    private TextMeshProUGUI victoryText;

    [SerializeField]
    Button buttonNewMatch;

    public void Start()
    {
        victoryText.gameObject.SetActive(false);
        buttonNewMatch.gameObject.SetActive(false);
        StartCoroutine(ManageGame());
    }

    private IEnumerator ManageGame()
    {
        Console.WriteLine("Started ManageGame");
        while (true)
        {
            if (IsNewMatchAsked)
            {
                IsNewMatchAsked = false;
                PointsChanged = false;
                PointCounter.PointsPlayer1 = 0;
                PointCounter.PointsPlayer2 = 0;
                ResetScene();
                continue;
            }

            if (PointsChanged)
            {
                PointsChanged = false;
                if (IsVictoryConditionMet)
                {
                    victoryText.gameObject.SetActive(true);
                    buttonNewMatch.gameObject.SetActive(true);
                }
                else
                {
                    ResetScene();
                }
            }
            yield return new WaitForSeconds(0.5f);
        }
    }

    private bool IsVictoryConditionMet => PointCounter.PointsPlayer1 == GameEndConditionCount || PointCounter.PointsPlayer2 == GameEndConditionCount;

    private async Task ResetScene()
    {
        victoryText.gameObject.SetActive(false);
        buttonNewMatch.gameObject.SetActive(false);
        await SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
    }
}
