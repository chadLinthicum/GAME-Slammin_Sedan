using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GIF : MonoBehaviour
{
    public Texture[] frames;
    public float frameRate = 0.1f;

    private int currentFrame;
    private float timer;

    void Start()
    {
        currentFrame = 0;
        timer = 0.0f;
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer > frameRate)
        {
            currentFrame = (currentFrame + 1) % frames.Length;
            GetComponent<RawImage>().texture = frames[currentFrame];
            timer = 0.0f;
        }
    }
}