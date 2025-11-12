using System;
using System.Collections;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;
using UnityEngine.Events;

public class ElevatorRise : MonoBehaviour
{
    [Header("Elevator Settings")]
    [SerializeField] float riseHeight;
    [SerializeField] float riseSpeed;
    [SerializeField] bool ElevatorGoesUp;
    [SerializeField] float riseDelay = 1f;
    [Header("Debug Settings")]
    [SerializeField] bool debugHeight;
    private bool elevatorIsRising;
    private bool buttonPressed;
    private float startY;
    private float targetY;   
    private ElevatorButton elevatorButton;
    private int numberOfSwitches = 1;
    private int numberOfLoops = 0;
    float destinationY;


    
    void Start()
    {
        elevatorButton = gameObject.GetComponentInParent<ElevatorButton>();
        elevatorButton.OnPressed += RiseElevator;
        Debug.Log("Listener added to elevator button");
        startY = transform.position.y;
        if (ElevatorGoesUp)
        {
            targetY = startY + riseHeight;
        }
        else
        {
            targetY = startY - riseHeight;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if (buttonPressed)
        {            
            if (!Mathf.Approximately(transform.position.y, destinationY))
            {
                gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, new Vector3(transform.position.x, destinationY, transform.position.z), riseSpeed * Time.deltaTime);
                if (Mathf.Abs(transform.position.y - destinationY) <= 0.12f)
                    transform.position = new Vector3(transform.position.x, destinationY, transform.position.z);
            }
            else
            {
                RiseElevator();
                Debug.Log("Elevator reached target position");
                buttonPressed = false;
                numberOfLoops++;
            }
        }
    }
    public void RiseElevator()
    {
        if (numberOfLoops < 1)
        {
            switch (numberOfSwitches)
            {
                case 1:
                    numberOfSwitches = 0;
                    elevatorIsRising = false;
                    break;
                case 0:
                    numberOfSwitches = 1;
                    elevatorIsRising = true;
                    break;
            }
            Invoke(nameof(EnableRising), riseDelay);
        }
        else    
        {
            numberOfLoops = 0;
        }
    }

    private void EnableRising()
    {
        buttonPressed = true;
        Debug.Log(elevatorIsRising);
        destinationY = elevatorIsRising ? startY : targetY;
        Debug.Log(destinationY);
        Debug.Log(startY);
        Debug.Log(transform.position.y);
    }

    void OnDrawGizmos()
    {
        if (debugHeight)
        { 
            if (ElevatorGoesUp)
            {
                Gizmos.color = Color.red;
                Gizmos.DrawLine(new Vector3(transform.position.x, startY + riseHeight, transform.position.z - 1), new Vector3(transform.position.x, startY + riseHeight, transform.position.z + 1));
                Gizmos.DrawLine(new Vector3(transform.position.x - 1, startY + riseHeight, transform.position.z), new Vector3(transform.position.x + 1, startY + riseHeight, transform.position.z));
            }
            else
            {
                Gizmos.color = Color.red;
                Gizmos.DrawLine(new Vector3(transform.position.x, startY - riseHeight, transform.position.z - 1), new Vector3(transform.position.x, startY - riseHeight, transform.position.z + 1));
                Gizmos.DrawLine(new Vector3(transform.position.x - 1, startY - riseHeight, transform.position.z), new Vector3(transform.position.x + 1, startY - riseHeight, transform.position.z));
            }
        }
    }
}
