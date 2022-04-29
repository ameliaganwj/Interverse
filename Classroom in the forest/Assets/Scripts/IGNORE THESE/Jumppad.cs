using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jumppad : MonoBehaviour
{
    public GameObject player;
    public float bounceHeight = -10;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            CharacterController controller = other.GetComponent<CharacterController>();

            if (controller != null)
            {
                player.GetComponent<SimplePlayerController>().velocity.y = Mathf.Sqrt(player.GetComponent<SimplePlayerController>().jumpHeight * bounceHeight * player.GetComponent<SimplePlayerController>().gravity);
            }
        }
    }
}
