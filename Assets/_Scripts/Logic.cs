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

    public static Logic Instance { get; private set; }

    private void Awake()
    {
        // If there is already an instance and it's not this one, destroy this
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        // Set the instance and mark this to not be destroyed on load
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void Start()
    {
    }

    #endregion

    #region Score management

    [SerializeField]
    private TextMeshProUGUI pointHUD_Player1;

    [SerializeField]
    private TextMeshProUGUI pointHUD_Player2;

    private int pointsPlayer1;
    private int pointsPlayer2;

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
        victoryText.gameObject.SetActive(false);
        buttonNewMatch.gameObject.SetActive(false);
        await SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().name);
    }

    #endregion
}
