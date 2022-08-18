using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraRegister : MonoBehaviour
{
    private void OnEnable()
    {
        CameraSwitcher.Rigister(GetComponent<CinemachineVirtualCamera>());
    }
    private void OnDisable()
    {
        CameraSwitcher.Unrigister(GetComponent<CinemachineVirtualCamera>());
    }
}
