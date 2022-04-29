using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatform : MonoBehaviour
{
    public GameObject platform;
    public bool fake;
    // Start is called before the first frame update
    private void Start()
    {
        Color objectColor = platform.GetComponent<Renderer>().material.color;
        float fadeAmount = objectColor.a - 0.2f;

        objectColor = new Color(objectColor.r, objectColor.g, objectColor.b, fadeAmount);
        if (fake)
            platform.GetComponent<Renderer>().material.color = objectColor;

    }
    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            CharacterController controller = other.GetComponent<CharacterController>();

            if (controller != null && fake)
            {
                platform.AddComponent<Rigidbody>();
                fake = false;
            }
        }
    }
}
