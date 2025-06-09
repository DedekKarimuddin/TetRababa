using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class MainMenuController : MonoBehaviour
{
    [SerializeField] TMP_Text player1CharText;
    [SerializeField] TMP_Text player2CharText;
    [SerializeField] TMP_Text bestScoreText;
    [SerializeField] Toggle musicToggle;
    [SerializeField] Toggle sfxToggle;

    private SettingsData data;

    void Start()
    {
        data = SaveSystem.Load();

        UpdateUI();

        musicToggle.onValueChanged.AddListener(OnMusicToggle);
        sfxToggle.onValueChanged.AddListener(OnSfxToggle);
    }

    void UpdateUI()
    {
        player1CharText.text = "Player 1: " + data.selectedCharacterPlayer1;
        player2CharText.text = "Player 2: " + data.selectedCharacterPlayer2;
        bestScoreText.text = "Best Score: " + data.bestScore;

        musicToggle.isOn = data.musicOn;
        sfxToggle.isOn = data.sfxOn;
    }

    void OnMusicToggle(bool isOn)
    {
        data.musicOn = isOn;
        SaveSystem.Save(data);
    }

    void OnSfxToggle(bool isOn)
    {
        data.sfxOn = isOn;
        SaveSystem.Save(data);
    }

    
    public void OnCharacterSelectPressed()
    {
    }

    public void OnSettingsPressed()
    {
      }
}
