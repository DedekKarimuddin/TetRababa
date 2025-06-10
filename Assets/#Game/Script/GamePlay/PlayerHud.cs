using UnityEngine;
using UnityEngine.UI;

public class PlayerHud : MonoBehaviour
{
    [SerializeField] private Image[] imgHearts;
    [SerializeField] private int playerNumber = 1;

    PlayerController player;

    private void Start()
    {
        if (playerNumber == 1)
            player = GameManager.Instance.Player1;
        else
            player = GameManager.Instance.Player2;

        player.OnTakeDamage += UpdateHearts;
    }

    private void OnDestroy()
    {
        player.OnTakeDamage -= UpdateHearts;
    }

    private void UpdateHearts(float hearts)
    {
       foreach(var heart in imgHearts)
        {
            heart.gameObject.SetActive(hearts > 0);
            hearts--;           
        }
    }

}
