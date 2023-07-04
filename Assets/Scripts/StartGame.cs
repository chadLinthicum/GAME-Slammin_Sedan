using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class StartGame : MonoBehaviour
{
    public AudioClip backgroundMusic;
    public AudioSource audioSource;
    public Text text;
    public float blinkInterval = 0.5f;
    private CanvasGroup canvasGroup;

    void Start()
    {
        audioSource.clip = backgroundMusic;
        audioSource.loop = true;
        audioSource.Play();

        // Prevent this game object from being destroyed when a new scene is loaded
        DontDestroyOnLoad(audioSource);

        canvasGroup = GetComponentInChildren<CanvasGroup>();
        StartCoroutine(Blink());
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene("Game");
        }
    }
    private IEnumerator Blink()
    {
        while (true)
        {
            canvasGroup.alpha = 1f;
            yield return new WaitForSeconds(blinkInterval);
            canvasGroup.alpha = 0f;
            yield return new WaitForSeconds(blinkInterval);
        }
    }
}



