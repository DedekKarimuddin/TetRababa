using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class TransitionLoader : MonoBehaviour
{
    [SerializeField] private Slider loadingBar;
    public float loadTime = 45f; // 45 seconds

    void Start()
    {
        StartCoroutine(LoadGame());
    }

    IEnumerator LoadGame()
    {
        float elapsed = 0f;
        while (elapsed < loadTime)
        {
            elapsed += Time.deltaTime;
            loadingBar.value = Mathf.Clamp01(elapsed / loadTime);
            yield return null;
        }

        SceneManager.LoadScene("Gameplay"); 
    }
}
