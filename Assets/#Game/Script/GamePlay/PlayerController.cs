using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public delegate void OnTakeDamageDelegate(float hearts);
    public event OnTakeDamageDelegate OnTakeDamage;

    [SerializeField] private int playerNumber = 1;
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private int hearts = 3;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        Vector3 move = Vector3.zero;

        // Player 1 - WASD
        if (playerNumber == 1)
        {
            if (Input.GetKey(KeyCode.W)) move.z = 1;
            else if (Input.GetKey(KeyCode.S)) move.z = -1;

            if (Input.GetKey(KeyCode.A)) move.x = -1;
            else if (Input.GetKey(KeyCode.D)) move.x = 1;
        }
        // Player 2 - Arrow Keys
        else if (playerNumber == 2)
        {
            if (Input.GetKey(KeyCode.UpArrow)) move.z = 1;
            else if (Input.GetKey(KeyCode.DownArrow)) move.z = -1;

            if (Input.GetKey(KeyCode.LeftArrow)) move.x = -1;
            else if (Input.GetKey(KeyCode.RightArrow)) move.x = 1;
        }

        if (move.magnitude > 1)
        {
            move.Normalize();
        }

        if (rb != null)
        {
            rb.linearVelocity = move * moveSpeed; 
        }
        else
        {
            transform.position += move * moveSpeed * Time.deltaTime;
        }

        if (move != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(move);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 10f);
        }
    }

    public void TakeDamage()
    {
        hearts--;
        OnTakeDamage?.Invoke(hearts);
        if (hearts <= 0)
        {
            Debug.Log("Player " + playerNumber + " defeated.");
            gameObject.SetActive(false);
        }
      
    }
}