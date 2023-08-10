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
    bool canTake;
    
    public TMP_Text interactionText;

    [SerializeField]
    Insanity insanity;

    [SerializeField]
    Vector3 twitchOffset;

    void Start()
    {
        interactionText.text = " ";
        canTake = true;
    }

    void Update()
    {
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if(Physics.Raycast(ray, out hit, mask))
        {
            if(hit.transform != transform)
            {
                transform.position = Vector3.Lerp(transform.position, hit.point - Vector3.up * hit.point.y + offset + twitchOffset, Time.deltaTime);
            }
            
            
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
            if(Input.GetKeyDown(KeyCode.Mouse0)  && canTake)
            {
                StartCoroutine(CanTakeCooldown());

                if(collider.GetComponent<Cable>())
                {
                    collider.GetComponent<Cable>().Cut();
                }

                if (collider.GetComponent<Interactible>()) 
                {
                    insanity.AddValue(collider.GetComponent<Interactible>().value);
                    Destroy(collider.gameObject);
                    counter++;
                }
            }
        }
    }

    void OnTriggerExit(Collider collider)
    {
        interactionText.text = " ";
    }

    public IEnumerator Twitch(float twitchIndex)
    {
        twitchOffset = new Vector3(Random.Range(-twitchIndex, twitchIndex), 0, Random.Range(-twitchIndex, twitchIndex));
        yield return new WaitForSeconds(1f);
    }

    IEnumerator CanTakeCooldown()
    {
        canTake = false;
        yield return new WaitForSeconds(0.2f);
        canTake = true;
    }
}
