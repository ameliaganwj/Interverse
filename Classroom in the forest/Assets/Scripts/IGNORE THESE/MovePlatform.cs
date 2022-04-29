using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlatform : MonoBehaviour
{
    public bool moveSideToSide;
    public bool moveFrontToBack;
    public bool moveUpAndDown;
    public float moveTime;
    public float sideToSideSpeed;
    public float frontToBackSpeed;
    public float upAndDownSpeed;

    float currentTime;


    private void Start()
    {
        currentTime = moveTime;
    }

    // Update is called once per frame
    void Update()
    {
        currentTime -= Time.deltaTime;
        if(currentTime <= 0)
        {
            sideToSideSpeed *= -1; // Change direction!
            frontToBackSpeed *= -1;
            upAndDownSpeed *= -1;
            currentTime = moveTime;
        }

        if(moveSideToSide)
        {
            transform.Translate(Vector3.forward * sideToSideSpeed * Time.deltaTime);
        }

        if(moveFrontToBack)
        {
            transform.Translate(Vector3.right * frontToBackSpeed * Time.deltaTime);
        }

        if(moveUpAndDown)
        {
            transform.Translate(Vector3.up * upAndDownSpeed * Time.deltaTime);
        }


    }

    

}
