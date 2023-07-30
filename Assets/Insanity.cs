using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Insanity : MonoBehaviour
{
    public string colors;
    public string taken; //pills taken
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
    GameManager gameManager;

    [SerializeField]
    GameObject pillz;


    void Start()
    {
        gameStarted = false;
    }

    public void StartTimer()
    {
        insanityTimer = 0;
        PillNeeded = false;
    }


    void Update()
    {
        if(gameStarted)
        {
            insanityTimer += 1*Time.deltaTime;
        }
        

        if (insanityTimer >= PillTime && PillNeeded == false) 
        {
            PillNeeded = true;
            img1.GetComponent<RandomizeColor>().RandomizeColors();
            img2.GetComponent<RandomizeColor>().RandomizeColors();
            img3.GetComponent<RandomizeColor>().RandomizeColors();
            img4.GetComponent<RandomizeColor>().RandomizeColors();

            colors = (img1.GetComponent<RandomizeColor>().randomColor.ToString() + img2.GetComponent<RandomizeColor>().randomColor.ToString() + img3.GetComponent<RandomizeColor>().randomColor.ToString() + img4.GetComponent<RandomizeColor>().randomColor.ToString());

        }
        
        if (taken.Length > colors.Length) 
        {
            gameManager.LoseGame(2);
        }

        if (insanityTimer >= 60f) 
        {
            gameManager.LoseGame(2);
        }

        if(taken == colors)
        {
            insanityTimer = 0f;
        }

        if(Input.GetKeyDown(KeyCode.Alpha2))
        {
            Destroy(pill);
            pill = Instantiate(pillz, transform.position, transform.rotation);
        }
    }

    public void AddValue(string value)
    {
        taken += value;
    }
}

public enum PillColor
{
    Yellow,
    Green,
    Red,
    Blue
}
