using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class rotate3dCellCameraOld : MonoBehaviour
{
	public float biasZ = 90, biasX = 90;
	//Gyroscope m_Gyro;
    // Start is called before the first frame update
    void Start()
    {
        //Input.compass.enabled = true;
    	//Input.location.Start();
        //Input.gyro.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(Input.gyro.attitude);
        //Debug.Log(Input.compass.trueHeading);
        //transform.rotation = Input.gyro.attitude;
        //transform.eulerAngles = new Vector3(-transform.eulerAngles.y+biasX,transform.eulerAngles.x,transform.eulerAngles.z+biasZ);
        transform.eulerAngles =  new Vector3(180+((float)Math.Atan2(Input.acceleration.z,Input.acceleration.y))*180f/3.14f,0.0f,0.0f);
    }
        
}

