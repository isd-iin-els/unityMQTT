// // Unity SDK for Qualisys Track Manager. Copyright 2015-2018 Qualisys AB
// //
// using UnityEngine;

// namespace QualisysRealTime.Unity
// {
//     class RTObjectChair : MonoBehaviour
//     {
//         public string ObjectName = "Put QTM 6DOF object name here";
//         public bool isToRotate = true;
//         public bool isToTranslate = true;
//         public int orientationState = 0;
//         public Vector3 PositionOffset = new Vector3(0, 0, 0);
//         public Vector3 RotationOffset = new Vector3(0, 0, 0);

//         protected RTClient rtClient;

//         protected virtual void applyBodyTransform(SixDOFBody body)
//         {
//             if (!float.IsNaN(body.Position.sqrMagnitude)) //just to avoid error when position is NaN
//             {
//                 if(isToTranslate){
//                     transform.position = body.Position + PositionOffset;
//                     if (transform.parent) transform.position += transform.parent.position;
//                 }
//                 if(isToRotate){
//                     transform.rotation = body.Rotation * Quaternion.Euler(RotationOffset);
//                     if(orientationState==0)
//                         transform.rotation = Quaternion.Euler(new Vector3(transform.rotation.eulerAngles.x,transform.rotation.eulerAngles.y,transform.rotation.eulerAngles.z));
//                     if(orientationState==1)
//                         transform.rotation = Quaternion.Euler(new Vector3(transform.rotation.eulerAngles.x,transform.rotation.eulerAngles.z,transform.rotation.eulerAngles.y));
//                     if(orientationState==2)
//                         transform.rotation = Quaternion.Euler(new Vector3(transform.rotation.eulerAngles.y,transform.rotation.eulerAngles.x,transform.rotation.eulerAngles.z));
//                     if(orientationState==3)
//                         transform.rotation = Quaternion.Euler(new Vector3(transform.rotation.eulerAngles.y,transform.rotation.eulerAngles.z,transform.rotation.eulerAngles.x));
//                     if(orientationState==4)
//                         transform.rotation = Quaternion.Euler(new Vector3(transform.rotation.eulerAngles.z,transform.rotation.eulerAngles.y,transform.rotation.eulerAngles.x));
//                     if(orientationState==5)
//                         transform.rotation = Quaternion.Euler(new Vector3(transform.rotation.eulerAngles.z,transform.rotation.eulerAngles.x,transform.rotation.eulerAngles.y));
//                     if(orientationState==6)
//                         transform.rotation = Quaternion.Euler(new Vector3(transform.rotation.eulerAngles.x,0,0));
//                     if(orientationState==7)
//                         transform.localRotation = Quaternion.Euler(new Vector3(0,transform.rotation.eulerAngles.x,0));//
//                     if(orientationState==8)
//                         transform.rotation = Quaternion.Euler(new Vector3(0,0,transform.rotation.eulerAngles.x));
//                     if(orientationState==9)
//                         transform.rotation = Quaternion.Euler(new Vector3(transform.rotation.eulerAngles.y,0,0));
//                     if(orientationState==10)
//                         transform.localRotation = Quaternion.Euler(new Vector3(0,transform.rotation.eulerAngles.y,0));//
//                     if(orientationState==11)
//                         transform.rotation = Quaternion.Euler(new Vector3(0,0,transform.rotation.eulerAngles.y));
//                     if(orientationState==12)
//                         transform.rotation = Quaternion.Euler(new Vector3(transform.rotation.eulerAngles.z,0,0));
//                     if(orientationState==13)
//                         transform.localRotation = Quaternion.Euler(new Vector3(0,transform.rotation.eulerAngles.z,0));//
//                     if(orientationState==14)
//                         transform.rotation = Quaternion.Euler(new Vector3(0,0,transform.rotation.eulerAngles.z));
//                     if(orientationState==15)
//                         transform.rotation = Quaternion.Euler(new Vector3(transform.rotation.eulerAngles.x,transform.rotation.eulerAngles.y,0));
//                     if(orientationState==16)
//                         transform.rotation = Quaternion.Euler(new Vector3(transform.rotation.eulerAngles.y,transform.rotation.eulerAngles.x,0));
//                     if(orientationState==17)
//                         transform.rotation = Quaternion.Euler(new Vector3(transform.rotation.eulerAngles.x,0,transform.rotation.eulerAngles.y));
//                     if(orientationState==18)
//                         transform.rotation = Quaternion.Euler(new Vector3(transform.rotation.eulerAngles.y,0,transform.rotation.eulerAngles.x));
//                     if(orientationState==19)
//                         transform.rotation = Quaternion.Euler(new Vector3(0,transform.rotation.eulerAngles.x,transform.rotation.eulerAngles.y));
//                     if(orientationState==20)
//                         transform.rotation = Quaternion.Euler(new Vector3(0,transform.rotation.eulerAngles.y,transform.rotation.eulerAngles.x));

//                     if(orientationState==21)
//                         transform.rotation = Quaternion.Euler(new Vector3(transform.rotation.eulerAngles.z,transform.rotation.eulerAngles.y,0));
//                     if(orientationState==22)
//                         transform.rotation = Quaternion.Euler(new Vector3(transform.rotation.eulerAngles.y,transform.rotation.eulerAngles.z,0));
//                     if(orientationState==23)
//                         transform.rotation = Quaternion.Euler(new Vector3(transform.rotation.eulerAngles.z,0,transform.rotation.eulerAngles.y));
//                     if(orientationState==24)
//                         transform.rotation = Quaternion.Euler(new Vector3(transform.rotation.eulerAngles.y,0,transform.rotation.eulerAngles.z));
//                     if(orientationState==25)
//                         transform.rotation = Quaternion.Euler(new Vector3(0,transform.rotation.eulerAngles.z,transform.rotation.eulerAngles.y));
//                     if(orientationState==26)
//                         transform.rotation = Quaternion.Euler(new Vector3(0,transform.rotation.eulerAngles.y,transform.rotation.eulerAngles.z));
                    
//                     if(orientationState==27)
//                         transform.rotation = Quaternion.Euler(new Vector3(transform.rotation.eulerAngles.x,transform.rotation.eulerAngles.z,0));
//                     if(orientationState==28)
//                         transform.rotation = Quaternion.Euler(new Vector3(transform.rotation.eulerAngles.z,transform.rotation.eulerAngles.x,0));
//                     if(orientationState==29)
//                         transform.rotation = Quaternion.Euler(new Vector3(transform.rotation.eulerAngles.x,0,transform.rotation.eulerAngles.z));
//                     if(orientationState==30)
//                         transform.rotation = Quaternion.Euler(new Vector3(transform.rotation.eulerAngles.z,0,transform.rotation.eulerAngles.x));
//                     if(orientationState==31)
//                         transform.rotation = Quaternion.Euler(new Vector3(0,transform.rotation.eulerAngles.x,transform.rotation.eulerAngles.z));
//                     if(orientationState==32)
//                         transform.rotation = Quaternion.Euler(new Vector3(0,transform.rotation.eulerAngles.z,transform.rotation.eulerAngles.x));

//                     if (transform.parent) transform.rotation *= transform.parent.rotation;
//                 }
//             }
//         }

//         // Use this for initialization
//         void Start()
//         {
//             rtClient = RTClient.GetInstance();
//         }

//         // Update is called once per frame
//         void Update()
//         {
//             if (rtClient == null) rtClient = RTClient.GetInstance();

//             var body = rtClient.GetBody(ObjectName);
//             if (body != null)
//                 applyBodyTransform(body);
//         }
//     }
// }