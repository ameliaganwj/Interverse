using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveDown : MonoBehaviour
{
    bool moveDown;
    public GameObject wall;
    public Vector3 direction = new Vector3 (0, -.05f, 0);
    public int maxMovement;
    int storedMaxMovement;
    bool activeMovement;
    bool moveUp;

    public AudioSource wallMoveAudio;

    // Start is called before the first frame update
    // Update is called once per frame
    void Start()
    {
        storedMaxMovement = maxMovement;
    }
    void FixedUpdate()
    {
        if (moveDown && maxMovement >= 0 && activeMovement)
            moveWallDown();
           
        if (moveUp && maxMovement >= 0 && activeMovement)
            moveWallUp();

        if (maxMovement <= 0 && activeMovement && (moveDown || moveUp))
        {
            activeMovement = false;
            maxMovement = storedMaxMovement;
            wallMoveAudio.Stop();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            CharacterController controller = other.GetComponent<CharacterController>();

            if (controller != null && !activeMovement && !moveDown)
            {
                moveDown = true;
                activeMovement = true;
                moveUp = false;
                wallMoveAudio.Play();
            }

            if (controller != null && !activeMovement && !moveUp)
            {
                moveUp = true;
                activeMovement = true;
                moveDown = false;
                wallMoveAudio.Play();
            }
        }
    }

    void moveWallDown()
    {
        wall.transform.Translate(direction);
        maxMovement--;
    }

    void moveWallUp()
    {
        wall.transform.Translate(-direction);
        maxMovement--;
    }
}
