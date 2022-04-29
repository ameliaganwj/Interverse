using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSoundToggler : MonoBehaviour
{
    public GameObject soundToggler;

    // Start is called before the first frame update
    void Start()
    {
        GameObject uiElement = Instantiate(soundToggler);
        uiElement.transform.position = uiElement.transform.position + new Vector3(0, 1, 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
