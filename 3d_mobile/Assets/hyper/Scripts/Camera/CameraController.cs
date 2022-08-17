using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraController : MonoBehaviour
{
    //Input control

    [SerializeField]
    CinemachineVirtualCamera virtualCamera;

    CinemachineComponentBase componentBase;

    
    float cameraDistance;
    float TrackObjOffsetX;

    [SerializeField]
    float sensitivity = 20f;
    [SerializeField]
    float speed = 2;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        //zoom in-out 
        if(componentBase == null)
        {
            componentBase = virtualCamera.GetCinemachineComponent(CinemachineCore.Stage.Body);
        }
        if (Input.GetAxis("Mouse ScrollWheel") != 0)
        {
            cameraDistance = Input.GetAxis("Mouse ScrollWheel") * sensitivity;
                if(componentBase is CinemachineFramingTransposer)
            {
                (componentBase as CinemachineFramingTransposer).m_CameraDistance -= cameraDistance;
            }
        }

        //rotate camera by mouse
        
    }
}
