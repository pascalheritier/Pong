using System;
using System.Collections;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Logic : MonoBehaviour
{
    #region Helpers

    public const string LogicTagName = "Logic";

    #endregion

    #region Singleton

    public void Start()
    {
        Debug.Log($"{nameof(Logic)} started");
        pointHUD_Player1.text = pointsPlayer1.ToString();
        pointHUD_Player2.text = pointsPlayer2.ToString();
    }

    #endregion

    #region Score management

    [SerializeField]
    private TextMeshProUGUI pointHUD_Player1;

    [SerializeField]
    private TextMeshProUGUI pointHUD_Player2;

    public static int pointsPlayer1;
    public static int pointsPlayer2;

    public void AddScorePlayer1(int scoreToAdd)
    {
        pointsPlayer1 += scoreToAdd;
        pointHUD_Player1.text = pointsPlayer1.ToString();
        CheckVictoryCondition();
    }

    public void AddScorePlayer2(int scoreToAdd)
    {
        pointsPlayer2 += scoreToAdd;
        pointHUD_Player2.text = pointsPlayer2.ToString();
        CheckVictoryCondition();
    }

    #endregion

    #region Game Ending

    public int GameEndConditionCount = 3;

    [SerializeField]
    private TextMeshProUGUI victoryText;

    [SerializeField]
    private Button buttonNewMatch;

    private void CheckVictoryCondition()
    {
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

    private bool IsVictoryConditionMet => pointsPlayer1 == GameEndConditionCount || pointsPlayer2 == GameEndConditionCount;

    public void ResetGame()
    {
        pointsPlayer1 = 0;
        pointsPlayer2 = 0;
        pointHUD_Player1.text = pointsPlayer1.ToString();
        pointHUD_Player2.text = pointsPlayer2.ToString();
        ResetScene();
    }

    private async Task ResetScene()
    {
        Debug.Log($"{nameof(Logic)} reset scene");
        victoryText.gameObject.SetActive(false);
        buttonNewMatch.gameObject.SetActive(false);
        await SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().name);
    }

    #endregion
}
