using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    public int id;
    private void Start()
    {
        GameEventSystem.current.onDoorwayTriggerEnter += OnDoorwayOpen;
        GameEventSystem.current.onDoorwayTriggerExit += OnDoorwayClose;
    }

    private void OnDoorwayOpen(int id)
    {
        if (id == this.id) {
            LeanTween.moveLocalY(gameObject, 1.6f, 1f).setEaseOutQuad();
        }
    }

    private void OnDoorwayClose(int id)
    {
        if(id == this.id)
        {
            LeanTween.moveLocalY(gameObject, 0.125f, 1f).setEaseInQuad();
        }
        
    }
}
