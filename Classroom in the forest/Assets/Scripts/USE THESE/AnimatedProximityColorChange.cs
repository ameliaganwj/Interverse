using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatedProximityColorChange : MonoBehaviour
{
    Renderer myRenderer;
    Color originalColor;

    bool interactable = false;
    bool currentlyInteracting = false;

    public AudioSource openSound;
    public AudioSource closeSound;
    public string interactionKey = "e";
    public GameObject text;

    // Animation Control
    public string openAnimName;
    public string closeAnimName;
    Animator animator;
    bool open = false;

    // Start is called before the first frame update
    void Start()
    {
        myRenderer = GetComponent<Renderer>();
        originalColor = myRenderer.material.color;
        text.SetActive(false);
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (interactable && !currentlyInteracting && Input.GetKeyDown(interactionKey))
        {
            currentlyInteracting = true;

            if(!open) // Not open
            {
                animator.Play(openAnimName);
                open = true;
                openSound.Play();
                Invoke("ResetInteractable", openSound.clip.length);
            }
            else // currently open
            {
                animator.Play(closeAnimName);
                open = false;
                closeSound.Play();
                Invoke("ResetInteractable", closeSound.clip.length);
            }    
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
