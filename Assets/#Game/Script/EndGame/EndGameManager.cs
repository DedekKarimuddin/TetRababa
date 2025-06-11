using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections.Generic;
using TMPro;
using System.Linq;

public class EndGameManager : MonoBehaviour
{
    [Header("UI References")]
    [SerializeField] private TMP_Text statusText;
    [SerializeField] private Button restartButton;
    [SerializeField] private Button mainMenuButton;
    [SerializeField] private Transform leaderboardContainer;
    [SerializeField] private GameObject leaderboardEntryPrefab;


    [Header("Data")]
    [SerializeField] private List<LeaderboardData> leaderboardPlayers = new List<LeaderboardData>();

    private bool isWin;

    void Start()
    {
        MatchData matchData = SaveSystem.LoadMatch();
        isWin = matchData.lastIswin;

        leaderboardPlayers.Clear();
        leaderboardPlayers.Add(new LeaderboardData("Player 1", matchData.scorePlayer1));
        leaderboardPlayers.Add(new LeaderboardData("Player 2", matchData.scorePlayer2));
        leaderboardPlayers = leaderboardPlayers
            .OrderByDescending(player => player.score) 
            .ToList();
        DisplayEndStatus();

        restartButton.onClick.AddListener(RestartFight);
        mainMenuButton.onClick.AddListener(ReturnToMainMenu);

        PopulateLeaderboard();
    }

    void PopulateLeaderboard()
    {
        foreach (Transform child in leaderboardContainer)
        {
            Destroy(child.gameObject);
        }

        foreach (var player in leaderboardPlayers)
        {
            GameObject entry = Instantiate(leaderboardEntryPrefab, leaderboardContainer);
            entry.gameObject.SetActive(true);
            entry.transform.SetParent(leaderboardContainer);
            TMP_Text nameText = entry.transform.GetChild(0).GetComponent<TMP_Text>();
            if (nameText != null)
            {
                nameText.text = player.name;
            }

            TMP_Text scoreText = entry.transform.GetChild(1).GetComponent<TMP_Text>();
            if (scoreText != null)
            {
                scoreText.text = player.score.ToString();
            }
        }

    }

    void DisplayEndStatus()
    {
        statusText.text = isWin ? "You Win!" : "You Lose!";
    }

    void RestartFight()
    {
        SceneManager.LoadScene("Gameplay");
    }

    void ReturnToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
