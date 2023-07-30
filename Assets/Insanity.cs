using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Insanity : MonoBehaviour
{
    public float insanityTimer;
    public float PillTime;
    public float EndGameTime;

   public Image img1;
    public Image img2; 
    public  Image img3;
    public Image img4;

    void Start()
    {
        
    }


    void Update()
    {
        insanityTimer += 1*Time.deltaTime;
        if (insanityTimer >= PillTime) 
        {
            insanityTimer = 0;
            img1.GetComponent<RandomizeColor>().RandomizeColors();
            img2.GetComponent<RandomizeColor>().RandomizeColors();
            img3.GetComponent<RandomizeColor>().RandomizeColors();
            img4.GetComponent<RandomizeColor>().RandomizeColors();
            
        }
        if (insanityTimer == EndGameTime) 
        {
            //End Game
        }
    }
}
