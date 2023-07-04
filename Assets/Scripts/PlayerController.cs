using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerController : MonoBehaviour //PlayerController inherits from MonoBehavior, which is a class that's applied to all difference object we create
{
    public int MPH;
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
    public GameObject uiRecommendation;

    public Text uiTargetText;
    public Text uiBullseyeText;

    public Text uiScoreNumber;
    private int score = 0;

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
        uiRecommendation.SetActive(false);
        uiScoreNumber.enabled = false;

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
        if (collision.gameObject.CompareTag("Destroy"))
        {
            Debug.Log("Destroy");
            score = MPH * 1200;
        }

        if (collision.gameObject.CompareTag("Bullseye"))
        {
            Debug.Log("Bullseye");
            uiTargetText.text = "Target: Yes";
            uiBullseyeText.text = "Bullseye: Yes";
            score = MPH * 5000;
        }

        if (collision.gameObject.CompareTag("Target"))
        {
            Debug.Log("Target");
            uiTargetText.text = "Target: Yes";
            score = MPH * 1500;
        }

        if (collision.gameObject.CompareTag("End"))
        {
            onRamp = false;
        }





        if (collision.gameObject.CompareTag("Destroy") || collision.gameObject.CompareTag("Target") || collision.gameObject.CompareTag("Bullseye"))
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
            uiRecommendation.SetActive(true);
            uiButtonGIF.SetActive(false);
            uiScoreNumber.enabled = true;
            uiScoreNumber.text = score.ToString();
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
