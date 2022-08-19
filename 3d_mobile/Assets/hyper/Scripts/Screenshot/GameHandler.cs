using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameHandler : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public DefaultAction Controls;
    private InputAction press0;

    private void Awake()
    {
        Controls = new DefaultAction();
    }
    private void OnEnable()
    {
        press0 = Controls.Player.Screenshot;
        press0.Enable();
    }

    private void OnDisable()
    {
        press0.Disable();
    }

    // Update is called once per frame
    void Update()
    {
        bool isPress0Key = press0.ReadValue<float>() > 0.1f;
        if (isPress0Key)
        {
            Debug.Log("Screenshot!");
            IconGenerator.TakeScreenshot_static(500, 500);
        }
    }
}
