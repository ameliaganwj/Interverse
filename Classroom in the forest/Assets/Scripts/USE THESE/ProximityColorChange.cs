using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProximityColorChange : MonoBehaviour
{
    Renderer myRenderer;
    Color originalColor;

    bool interactable = false;
    bool currentlyInteracting = false;

    public AudioSource sound;
    public string interactionKey = "e";
    public GameObject text;

    // Start is called before the first frame update
    void Start()
    {
        myRenderer = GetComponent<Renderer>();
        originalColor = myRenderer.material.color;
        text.SetActive(false);
    }

    private void Update()
    {
        if (interactable && !currentlyInteracting && Input.GetKeyDown(interactionKey))
        {
            currentlyInteracting = true;
            sound.Play();
            Invoke("ResetInteractable", sound.clip.length);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            myRenderer.material.color = Color.yellow;
            interactable = true;
            text.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            myRenderer.material.color = originalColor;
            interactable = false;
            text.SetActive(false);
        }
    }

    void ResetInteractable()
    {
        currentlyInteracting = false;
    }
}
