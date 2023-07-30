using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPills : MonoBehaviour
{
    public GameObject pill;
    [SerializeField] float offsetX;
    [SerializeField] float offsetZ;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Spawn() 
    {
    Instantiate(pill,transform.position + new Vector3(Random.Range(-offsetX,offsetX),0,Random.Range(-offsetZ,offsetZ)),Quaternion.identity);
    }
}
