using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactible : MonoBehaviour
{
    public int value;
    [SerializeField] GameManager gameManager;
    Insanity insanity;

    void Start()
    {
         gameManager = GetComponent<GameManager>();
         insanity = GetComponent<Insanity>();
    }

    void Awake()
    {
          gameManager = GetComponent<GameManager>();
          insanity = GetComponent<Insanity>();
    }
    
    public void Hit() 
    {
        gameManager = GetComponent<GameManager>();
        insanity = GetComponent<Insanity>();
        insanity.AddValue(value.ToString());
        Debug.Log("PillTaken");

        gameManager.GulpPill();
        Destroy(gameObject);
    }
}
