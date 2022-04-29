using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakableWall : MonoBehaviour
{
    public GameObject wall;
    // Start is called before the first frame update
    void Start()
    {

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

            if (controller != null)
            {
                Color objectColor = wall.GetComponent<Renderer>().material.color;
                float fadeAmount = objectColor.a - 0.34f; 

                objectColor = new Color(objectColor.r, objectColor.g, objectColor.b, fadeAmount);
                wall.GetComponent<Renderer>().material.color = objectColor;
                if (objectColor.a <= 0)
                {
                    wall.gameObject.SetActive(false);
                    this.gameObject.SetActive(false);
                }
            }
        }
    }
}

