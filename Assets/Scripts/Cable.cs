using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cable : MonoBehaviour
{
    [SerializeField]
    GameObject normalCable;

    [SerializeField]
    GameObject cutCable;

    [SerializeField]
    AudioSource source;

    [SerializeField]
    CableColor color;

    [SerializeField]
    GameManager gameManager;


    void Start()
    {
        normalCable.SetActive(true);
        cutCable.SetActive(false);
    }

    void Awake()
    {
        normalCable.SetActive(true);
        cutCable.SetActive(false);
    }

    public void Cut()
    {
        if(normalCable.activeSelf)
        {
            source.Play();
            gameManager.CutCable(color);
        }
        normalCable.SetActive(false);
        cutCable.SetActive(true);
    }

    public void Reset()
    {
        normalCable.SetActive(true);
        cutCable.SetActive(false);
    }
}
