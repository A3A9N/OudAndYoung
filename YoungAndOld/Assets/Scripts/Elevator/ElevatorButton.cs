using UnityEngine;
using UnityEngine.Events;
using System;
public class ElevatorButton : MonoBehaviour
{
    public event Action OnPressed;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Child")
        {
            Debug.Log("Elevator button pressed by Child");
            OnPressed?.Invoke();
        }
    }
}
