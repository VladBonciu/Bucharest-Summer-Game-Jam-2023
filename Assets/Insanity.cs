using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Insanity : MonoBehaviour
{
    public string colors;
    public string taken;//pills taken
    public float insanityTimer;
    public float PillTime;
    public float EndGameTime;

   public Image img1;
    public Image img2; 
    public  Image img3;
    public Image img4;
<<<<<<< Updated upstream

=======
    public GameObject pill;
    bool PillNeeded = false;

    // Start is called before the first frame update
>>>>>>> Stashed changes
    void Start()
    {
        
    }


    void Update()
    {
        insanityTimer += 1*Time.deltaTime;

        if (insanityTimer >= PillTime && PillNeeded == false) 
        {
           PillNeeded = true;
            img1.GetComponent<RandomizeColor>().RandomizeColors();
            img2.GetComponent<RandomizeColor>().RandomizeColors();
            img3.GetComponent<RandomizeColor>().RandomizeColors();
            img4.GetComponent<RandomizeColor>().RandomizeColors();
            colors =( img1.GetComponent<RandomizeColor>().randomColor.ToString() + img2.GetComponent<RandomizeColor>().randomColor.ToString() + img3.GetComponent<RandomizeColor>().randomColor.ToString() + img4.GetComponent<RandomizeColor>().randomColor.ToString());

        }
        if (colors == taken)
        {
            insanityTimer = 0;
            PillNeeded = false;
        }
        if (taken.Length >= colors.Length) 
        {
            Debug.Log("Overdosed");
        }
        if (insanityTimer == EndGameTime) 
        {
<<<<<<< Updated upstream
            //End Game
=======
            Debug.Log("Kaboom");
>>>>>>> Stashed changes
        }
    }
}
