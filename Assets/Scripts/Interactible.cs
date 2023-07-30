using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactible : MonoBehaviour
{
    public int value;
    [SerializeField] GameObject gameManager;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
  public void Hit() 
    {
    gameManager.GetComponent<Insanity>().taken += value.ToString();
        Debug.Log("PillTaken");
    }
}
