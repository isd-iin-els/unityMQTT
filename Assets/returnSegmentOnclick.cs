using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using uPLibrary.Networking.M2Mqtt;
//using uPLibrary.Networking.M2Mqtt.Messages;
//using M2MqttUnity;
using System;
using UnityEngine.Networking;
using System.Security.Cryptography;
using System.Text;
using Assets.LSL4Unity.Scripts.Examples;

// [Serializable]
// public class unityCmd
// {
//     public string Spine1;
//     public string Spine2;
//     public string Hips;
//     public string LeftUpLeg;
//     public string RightUpLeg;
//     public string LeftLeg;
//     public string RightLeg;
//     public string LeftFoot;
//     public string RightFoot;
//     public string LeftShoulder;
//     public string RightShoulder;
//     public string LeftArm;
//     public string RightArm;
//     public string LeftForeArm;
//     public string RightForeArm;
//     public string LeftHand;
//     public string RightHand;
//     public string Head;
    
//     public void getAngles(ref List<Transform> articulacoes)
//     {
//         string[] angle;
//         angle = Spine1.Split(',');
//         articulacoes[0].transform.localEulerAngles = new Vector3(float.Parse(angle[0]),
//                                                                  float.Parse(angle[1]),
//                                                                  float.Parse(angle[2]));
//         angle = Spine2.Split(',');
//         articulacoes[1].transform.localEulerAngles = new Vector3(float.Parse(angle[0]),
//                                                                  float.Parse(angle[1]),
//                                                                  float.Parse(angle[2]));
//         angle = Hips.Split(',');
//         articulacoes[2].transform.localEulerAngles = new Vector3(float.Parse(angle[0]),
//                                                                  float.Parse(angle[1]),
//                                                                  float.Parse(angle[2]));
//         angle = LeftUpLeg.Split(',');
//         articulacoes[3].transform.localEulerAngles = new Vector3(float.Parse(angle[0]),
//                                                                  float.Parse(angle[1]),
//                                                                  float.Parse(angle[2]));
//         angle = RightUpLeg.Split(',');
//         articulacoes[4].transform.localEulerAngles = new Vector3(float.Parse(angle[0]),
//                                                                  float.Parse(angle[1]),
//                                                                  float.Parse(angle[2]));
//         angle = LeftLeg.Split(',');
//         articulacoes[5].transform.localEulerAngles = new Vector3(float.Parse(angle[0]),
//                                                                  float.Parse(angle[1]),
//                                                                  float.Parse(angle[2]));
//         angle = RightLeg.Split(',');
//         articulacoes[6].transform.localEulerAngles = new Vector3(float.Parse(angle[0]),
//                                                                  float.Parse(angle[1]),
//                                                                  float.Parse(angle[2]));
//         angle = LeftFoot.Split(',');
//         articulacoes[7].transform.localEulerAngles = new Vector3(float.Parse(angle[0]),
//                                                                  float.Parse(angle[1]),
//                                                                  float.Parse(angle[2]));
//         angle = RightFoot.Split(',');
//         articulacoes[8].transform.localEulerAngles = new Vector3(float.Parse(angle[0]),
//                                                                  float.Parse(angle[1]),
//                                                                  float.Parse(angle[2]));
//         angle = LeftShoulder.Split(',');
//         articulacoes[9].transform.localEulerAngles = new Vector3(float.Parse(angle[0]),
//                                                                  float.Parse(angle[1]),
//                                                                  float.Parse(angle[2]));
//         angle = RightShoulder.Split(',');
//         articulacoes[10].transform.localEulerAngles = new Vector3(float.Parse(angle[0]),
//                                                                  float.Parse(angle[1]),
//                                                                  float.Parse(angle[2]));
//         angle = LeftArm.Split(',');
//         articulacoes[11].transform.localEulerAngles = new Vector3(float.Parse(angle[0]),
//                                                                  float.Parse(angle[1]),
//                                                                  float.Parse(angle[2]));
//         angle = RightArm.Split(',');
//         articulacoes[12].transform.localEulerAngles = new Vector3(float.Parse(angle[0]),
//                                                                  float.Parse(angle[1]),
//                                                                  float.Parse(angle[2]));
//         angle = LeftForeArm.Split(',');
//         articulacoes[13].transform.localEulerAngles = new Vector3(float.Parse(angle[0]),
//                                                                  float.Parse(angle[1]),
//                                                                  float.Parse(angle[2]));
//         angle = RightForeArm.Split(',');
//         articulacoes[14].transform.localEulerAngles = new Vector3(float.Parse(angle[0]),
//                                                                  float.Parse(angle[1]),
//                                                                  float.Parse(angle[2]));
//         angle = LeftHand.Split(',');
//         articulacoes[15].transform.localEulerAngles = new Vector3(float.Parse(angle[0]),
//                                                                  float.Parse(angle[1]),
//                                                                  float.Parse(angle[2]));
//         angle = RightHand.Split(',');
//         articulacoes[16].transform.localEulerAngles = new Vector3(float.Parse(angle[0]),
//                                                                  float.Parse(angle[1]),
//                                                                  float.Parse(angle[2]));
//         angle = Head.Split(',');
//         articulacoes[17].transform.localEulerAngles = new Vector3(float.Parse(angle[0]),
//                                                                  float.Parse(angle[1]),
//                                                                  float.Parse(angle[2]));
//     }
// }

public class returnSegmentOnclick : MonoBehaviour//M2MqttUnityClient
{
    public List<Transform> articulacoes;
    public ExampleFloatInlet x;
    // public string site;
    // static int value = 0;
    // byte counter;
    // string unityInstance;
    //UnityWebRequest webRequest;
    // Start is called before the first frame update
    void Start(){
        x = FindObjectOfType<ExampleFloatInlet>();
        // int m_lenght = 4;

        // RandomNumberGenerator RNG = RandomNumberGenerator.Create();
        // byte[] buf = new byte[m_lenght];
        // RNG.GetBytes(buf);
        // if (value == 0)
        // 	value = buf[0]+ (buf[1]<<4) + (buf[1] << 8) + (buf[1] << 12);
        // unityInstance = value.ToString();
        // //StartCoroutine(GetRequest("http://localhost:8000/unityTopics?Module="+unityInstance));
        // Application.ExternalCall("jssendCredentials", "Module = "+unityInstance);
        //base.Start();
    }

    // Update is called once per frame
    void Update(){
        //base.Update();
        Debug.Log(x.lastSample[0]);
        articulacoes[0].transform.localEulerAngles = new Vector3(x.lastSample[0],
                                                                 x.lastSample[1],
                                                                 x.lastSample[2]);
        if (Input.GetMouseButtonDown(0)){
            Debug.Log("Mouse is down");
            RaycastHit hitInfo = new RaycastHit();
            bool hit = Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hitInfo);
            if (hit) 
            {
                Debug.Log("Hit " + hitInfo.transform.gameObject.name);
                //base.PublishTopics(hitInfo.transform.gameObject.name);
                string segment = hitInfo.transform.gameObject.name.Split(':')[1];
                // StartCoroutine(GetRequest("http://localhost:8000/unityAns?instance=" + unityInstance +"&value=" + segment));

                if (hitInfo.transform.gameObject.tag == "Construction")
                {
                    Debug.Log ("It's working!");
                } else {
                    Debug.Log ("nopz");
                }
            } else {
                Debug.Log("No hit");
            }
            Debug.Log("Mouse is down");
        }

        //string values;
        //if (msgs.TryGetValue("unityCmd", out values))
        //{
        //    unityCmd angles = JsonUtility.FromJson<unityCmd>(values);
        //    Debug.Log("angulos: " + values);
        //    angles.getAngles(ref articulacoes);
        //}
        // if (counter == 20)
        // {
        //     // StartCoroutine(GetRequest("http://localhost:8000/"+site+"?instance=" + unityInstance));
        //     counter = 0;
        // }
        // counter++;
    }

    // IEnumerator GetRequest(string uri)
    // {
    //     using (UnityWebRequest webRequest = UnityWebRequest.Get(uri))
    //     {
    //         // Request and wait for the desired page.
    //         yield return webRequest.SendWebRequest();

    //         string[] pages = uri.Split('/');
    //         int page = pages.Length - 1;

    //         if (webRequest.isNetworkError)
    //         {
    //             Debug.Log(pages[page] + ": Error: " + webRequest.error);
    //             var json = webRequest.downloadHandler.text;
    //             //Debug.Log(pages[page] + ":\nReceived: " + json);
    //             unityCmd angles = JsonUtility.FromJson<unityCmd>(json);
    //             angles.getAngles(ref articulacoes);
    //         }
    //         else
    //         {
    //             var json = webRequest.downloadHandler.text;
    //             //Debug.Log(pages[page] + ":\nReceived: " + json);
    //             unityCmd angles = JsonUtility.FromJson<unityCmd>(json);
    //             angles.getAngles(ref articulacoes);
    //         }
    //     }
    // }
}
