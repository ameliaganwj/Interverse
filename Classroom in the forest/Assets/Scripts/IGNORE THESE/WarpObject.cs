using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarpObject : MonoBehaviour
{
    public GameObject moveObject;
    public int[] direction = new int [2];
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame/
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
                moveObject.transform.position = new Vector3 (moveObject.transform.position.x - direction[0], moveObject.transform.position.y - direction[1], moveObject.transform.position.z - direction [2]) ;
            }
        }
    }
}
