using UnityEngine;
using System.Collections.Generic;
using Game.Skill;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [SerializeField] private BossController boss;
    [SerializeField] private PlayerController player1;
    [SerializeField] private PlayerController player2;
    [SerializeField] private List<BaseSkill> listSkill;

    public PlayerController Player1 => player1;
    public PlayerController Player2 => player2;
    public BossController Boss => boss;


    private void Awake()
    {
        Instance = this;
    }
    void Update()
    {
        if (!player1.gameObject.activeSelf && !player2.gameObject.activeSelf)
        {
            MatchData matchData = SaveSystem.LoadMatch();
            matchData.lastIswin = false;
            matchData.scorePlayer1 += 2;
            matchData.scorePlayer2 += 3;
            SaveSystem.SaveMatch(matchData);
            SceneManager.LoadScene("EndGame");
        }
    }

    public BaseSkill GetSkill(string id)
    {
        return listSkill.Find(x => x.ID == id);

    }
}
