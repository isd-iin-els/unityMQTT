using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camGyro : MonoBehaviour
{
    public GameObject positionTracker; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = positionTracker.transform.rotation;
    }
}
