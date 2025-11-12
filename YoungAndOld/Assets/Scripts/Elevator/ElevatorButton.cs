using UnityEngine;
using UnityEngine.Events;
using System;
public class ElevatorButton : MonoBehaviour
{
    public event Action OnPressed;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Child")
        {
            Debug.Log("Elevator button pressed by Child");
            OnPressed?.Invoke();
        }
    }
}
