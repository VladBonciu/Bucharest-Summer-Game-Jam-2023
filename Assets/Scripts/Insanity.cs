using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class Insanity : MonoBehaviour
{
    public List<int> colors;
    public List<int> inputColors;

    public float insanityTimer;
    public float PillTime;

    public Image img1;
    public Image img2; 
    public  Image img3;
    public Image img4;

    public GameObject pill;
    bool PillNeeded = false;
    public bool gameStarted;
    
    [SerializeField]
    private float timerSpeed;

    [SerializeField]
    GameManager gameManager;

    [SerializeField]
    GameObject pillz;

    [SerializeField]
    Hand hand;

    [SerializeField]
    Volume volume;

    Vignette vignette;

    Color VignetteColor;

    void Start()
    {
        gameStarted = false;
    }

    public void StartTimer()
    {
        insanityTimer = 100;
        PillNeeded = false;
    }


    void Update()
    {
        volume.profile.TryGet<Vignette>(out vignette );
        vignette.color.value = VignetteColor;

        if(gameStarted)
        {
            insanityTimer -= timerSpeed * Time.deltaTime;
        }

        if (insanityTimer >= PillTime && PillNeeded == false && gameStarted) 
        {
            PillNeeded = true;
            img1.GetComponent<RandomizeColor>().RandomizeColors();
            img2.GetComponent<RandomizeColor>().RandomizeColors();
            img3.GetComponent<RandomizeColor>().RandomizeColors();
            img4.GetComponent<RandomizeColor>().RandomizeColors();

            colors.Add(img1.GetComponent<RandomizeColor>().randomColor);
            colors.Add(img2.GetComponent<RandomizeColor>().randomColor);
            colors.Add(img3.GetComponent<RandomizeColor>().randomColor);
            colors.Add(img4.GetComponent<RandomizeColor>().randomColor);
        }

        if (insanityTimer < 70f) 
        {
            StartCoroutine(hand.Twitch(1 - insanityTimer/70));
            
            VignetteColor = Color.Lerp(VignetteColor, Color.red, Time.deltaTime);
        }
        else
        {
            VignetteColor = Color.Lerp(VignetteColor, Color.black, Time.deltaTime);
        }

        if (insanityTimer <= 0f) 
        {
            gameManager.LoseGame(2);
            insanityTimer = 100f;
            
        }

        if (inputColors.Count == colors.Count && inputColors.Count != 0)
        {
            CompareColors();

            for (int i = 0; i < inputColors.Count; i++)
            {
                if (inputColors[i] != colors[i]) 
                {
                    gameManager.LoseGame(2);
                    insanityTimer = 100f;
                    break;
                }
                else if(i == 3)
                {
                    insanityTimer = 100f;
                    Debug.Log("Replenished Colors");
                    PillNeeded = false;

                    colors.Clear();
                    inputColors.Clear();
                }
            }
        }

        if(Input.GetKeyDown(KeyCode.Alpha2))
        {
            Destroy(pill);
            pill = Instantiate(pillz, transform.position, transform.rotation);
        }
    }


    public void AddValue(int value)
    {
        inputColors.Add(value);
        CompareColors();
    }

    public void CompareColors()
    {
        for (int i = 0; i < inputColors.Count; i++)
        {
            if (inputColors[i] != colors[i]) 
            {
                gameManager.LoseGame(2);
                break;
            }
        }
    }
}

public enum PillColor
{
    Yellow,
    Green,
    Red,
    Blue
}
