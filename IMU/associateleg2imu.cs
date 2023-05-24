using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class associateleg2imu : MonoBehaviour
{
    //public GameObject mqttobj;
    public GameObject hips,knee,ankle;
    private mqttscript mqtt;
     public bool isRightLeg = false;
     public string topicss;
    float lastValue = 0;
    public float hx=0,hy=0,hz=0,nx=0,ny=0,nz=0,ax=0,ay=0,az=0;
    Vector3 filteredAngle;
    public float filterFactor = 0.1f;
    // Start is called before the first frame update
    void Start()
    {
        mqtt = mqttscript.getInstance();
        filteredAngle = new Vector3(0.0f,0.0f,0.0f);
    }

    // Update is called once per frame
    void Update()
    {
        mqtt.subscribe(topicss);
        string data = mqtt.read(topicss);
        string[] acc = data.Split(',');
        if(acc.Length >= 11 && acc[0] == "c"){
            
		hx = float.Parse(acc[1]);
		hy = float.Parse(acc[2]);
		hz = float.Parse(acc[3]);
		nx = float.Parse(acc[4]);
		ny = float.Parse(acc[5]);
		nz = float.Parse(acc[6]);
		ax = float.Parse(acc[7]);
		ay = float.Parse(acc[8]);
		az = float.Parse(acc[9]);
		filterFactor = float.Parse(acc[10]);
        }
        filteredAngle.x +=  filterFactor*(float.Parse(acc[0])-filteredAngle.x);
        filteredAngle.y +=  filterFactor*(float.Parse(acc[1])-filteredAngle.y);
        filteredAngle.z +=  filterFactor*(float.Parse(acc[2])-filteredAngle.z);
        if(acc.Length > 2){
            if (isRightLeg){
                hips.transform.localEulerAngles = new Vector3((float)Math.Atan2(filteredAngle.z, filteredAngle.y)*180.0f+hx, 0.0f+hy, 180.0f+hz);
                knee.transform.localEulerAngles = new Vector3((float)Math.Atan2(filteredAngle.z, filteredAngle.y)*50.0f+nx, 0.0f+ny, 0.0f+nz);
                ankle.transform.localEulerAngles = new Vector3((float)Math.Atan2(filteredAngle.z, filteredAngle.y)*1.8f+ax, 0.0f+ay, 0.0f+az);
            }
            else {
                hips.transform.localEulerAngles = new Vector3(-(float)Math.Atan2(filteredAngle.z, filteredAngle.y)*180.0f+hx, 0.0f+hy, 180.0f+hz);
                knee.transform.localEulerAngles = new Vector3((float)Math.Atan2(filteredAngle.z, filteredAngle.y)*50.0f+nx, 0.0f+ny, 0.0f+nz);
                ankle.transform.localEulerAngles = new Vector3((float)Math.Atan2(filteredAngle.z, filteredAngle.y)*1.8f+ax, 0.0f+ay, 0.0f+az);
            }
        }
    }
}
