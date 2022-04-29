using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelayDelete : MonoBehaviour
{
    public int deleteTimer = 3;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Destroy(gameObject, deleteTimer);
    }
}
