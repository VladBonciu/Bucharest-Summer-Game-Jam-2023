using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class RandomizeColor : MonoBehaviour
{
   
   
    public Image pillColor;
  public int randomColor;
    // Start is called before the first frame update
    void Start()
    {

 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void RandomizeColors() 
    {
        randomColor = Random.Range(1, 5);
        
        if (randomColor == 1)
        {
            pillColor.color = Color.red;
        }
        else if (randomColor == 2)
        {
            pillColor.color = Color.green;
        }
        else if (randomColor == 3)
        {
            pillColor.color = Color.blue;
        }
        else if (randomColor == 4) 
        {
            pillColor.color = Color.yellow;
        }

    }
}
