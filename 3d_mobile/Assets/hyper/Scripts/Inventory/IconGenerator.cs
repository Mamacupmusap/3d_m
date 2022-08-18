using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IconGenerator : MonoBehaviour
{
    public Camera Camera;
    void TakeScreenshot(string fullPath)
    {
        if(Camera == null)
        {
            Camera = GetComponent<Camera>();
        }
    }

   
}
