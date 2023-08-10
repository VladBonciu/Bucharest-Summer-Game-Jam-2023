using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColor : MonoBehaviour
{
    Material[] materials;
    public Material material1;
    public Material material2;
    public Material material3;
    public Material material4;

    // Start is called before the first frame update
    void Start()
    {
        materials = new Material[6];
        materials[0] = material1;
        materials[1] = material2;
        materials[2] = material3;
        materials[3] = material4;
        GetComponent<Renderer>().material = materials[Random.Range(0, 3)];
    }

  
}
