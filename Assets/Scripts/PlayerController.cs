using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerController : MonoBehaviour //PlayerController inherits from MonoBehavior, which is a class that's applied to all difference object we create
{
    public float speed = 5.0f;
    public float turnSpeed = 25.0f;
    public float horizonalInput;
    public float forwardInput;

    public float MPH;
    public Text MPH_Text;
    public Text timerText;
    private float elapsedTime = 0f;
    private bool isTimerRunning = false;
    public GameObject uiBlack;
    public GameObject uiRetry;
    public GameObject uiTarget;
    public GameObject uiBullseye;
    public GameObject uiScore;
    public GameObject uiButtonGIF;

    private bool onRamp = true;

    [SerializeField] private ParticleSystem testParticleSystem = default;

    public AudioClip backgroundMusic;
    public AudioClip explosionSound;
    public AudioSource audioSource;

    void Start()
    {
        uiBlack.SetActive(false);
        uiRetry.SetActive(false);
        uiTarget.SetActive(false);
        uiBullseye.SetActive(false);
        uiScore.SetActive(false);

        audioSource.clip = backgroundMusic;
        audioSource.loop = true;
        //audioSource.Play();
    }

    void Update()
    {
        if (isTimerRunning)
        {
            UpdateTimer();
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {

            isTimerRunning = true;
            if (onRamp)
            {
                MPH++;
                if (MPH == 0)
                {
                    MPH_Text.text = "000";
                }
                else if (MPH != 0 && MPH < 10)
                {
                    MPH_Text.text = "00" + MPH;
                }
                else if (MPH >= 10 && MPH < 100)
                {
                    MPH_Text.text = "0" + MPH;
                }
                else
                {
                    MPH_Text.text = MPH.ToString(); ;
                }
            }
        }

        transform.Translate(Vector3.forward * Time.deltaTime * MPH); //At speed per sec

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Destroy") || collision.gameObject.CompareTag("Target"))
        {
            StopTimer();
            Destroy(gameObject);
            testParticleSystem.Play();
            audioSource.PlayOneShot(explosionSound, 3);
            uiBlack.SetActive(true);
            uiRetry.SetActive(true);
            uiTarget.SetActive(true);
            uiBullseye.SetActive(true);
            uiScore.SetActive(true);
            uiButtonGIF.SetActive(false);

        }
        if (collision.gameObject.CompareTag("End"))
        {
            onRamp = false;
        }
    }
    public void StopTimer()
    {
        isTimerRunning = false;
    }
    void UpdateTimer()
    {
        elapsedTime += Time.deltaTime;
        int minutes = Mathf.FloorToInt(elapsedTime / 60f);
        int seconds = Mathf.FloorToInt(elapsedTime % 60f);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
