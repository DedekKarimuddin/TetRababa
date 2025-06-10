using UnityEngine;
using System.Collections.Generic;
using Game.Skill;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [SerializeField] private PlayerController player1;
    [SerializeField] private PlayerController player2;
    [SerializeField] private List<BaseSkill> listSkill;

    public PlayerController Player1 => player1;
    public PlayerController Player2 => player2;


    private void Awake()
    {
        Instance = this;
    }
    void Update()
    {
        if (!player1.gameObject.activeSelf && !player2.gameObject.activeSelf)
        {
            Debug.Log("Both players defeated. Game Over.");
        }
    }

    public BaseSkill GetSkill(string id)
    {
        return listSkill.Find(x => x.ID == id);

    }
}
