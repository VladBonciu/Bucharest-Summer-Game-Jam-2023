using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Hand : MonoBehaviour
{
    [SerializeField]
    Camera cam;
    [SerializeField]
    Vector3 offset;
    [SerializeField]
    LayerMask mask;
    int counter;

    [SerializeField]
    TMP_Text interactionText;


    void Start()
    {
        interactionText.text = " ";
    }

    void Update()
    {
         Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if(Physics.Raycast(ray, out hit, mask))
        {
            if(hit.transform != transform)
            {
                transform.position = Vector3.Lerp(transform.position, hit.point - Vector3.up * hit.point.y + offset, Time.deltaTime);
            }
            
            transform.RotateAround(transform.position ,transform.right , Input.mousePosition.x / Screen.width);
        }
        
    }

    void OnTriggerEnter(Collider collider)
    {
        if(collider.gameObject.layer == LayerMask.NameToLayer("Interactable"))
        {
            interactionText.text = collider.gameObject.name;
        }
    }

    void OnTriggerStay(Collider collider)
    {
        if(collider.gameObject.layer == LayerMask.NameToLayer("Interactable"))
        {
            if(Input.GetKeyDown(KeyCode.Mouse0))
            {
                Debug.Log("Interacted");
                if(collider.GetComponent<Cable>())
                {
                    collider.GetComponent<Cable>().Cut();
                }
                if (collider.GetComponent<Interactible>()) 
                {
                    collider.GetComponent<Interactible>().Hit();
                    counter++;
                }
            }
        }
    }

    void OnTriggerExit(Collider collider)
    {
        interactionText.text = " ";
    }
}
