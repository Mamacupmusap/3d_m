using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(BoxCollider))]
public class CameraTriggerVolume : MonoBehaviour
{
    [SerializeField]
    CinemachineVirtualCamera camera;
    [SerializeField]
    Vector3 boxSize;

    BoxCollider bc;
    Rigidbody rb;

    private void Awake()
    {
        bc = GetComponent<BoxCollider>();
        rb = GetComponent<Rigidbody>();
        bc.isTrigger = true;
        bc.size = boxSize;

        rb.isKinematic = true;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(transform.position, boxSize);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (CameraSwitcher.ActiveCamera != camera) CameraSwitcher.SwitchCamera(camera);
        }
    }
}
