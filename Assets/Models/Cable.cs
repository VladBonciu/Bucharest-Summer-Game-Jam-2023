using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cable : MonoBehaviour
{
    [SerializeField]
    GameObject normalCable;
    [SerializeField]
    GameObject cutCable;


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
        normalCable.SetActive(false);
        cutCable.SetActive(true);
    }
}
