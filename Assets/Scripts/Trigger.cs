using UnityEngine;
using System;

public class Trigger : MonoBehaviour
{
    public event Action AlarmEnable;
    public event Action AlarmDisable;

    private void OnTriggerEnter(Collider other)
    {
        AlarmEnable.Invoke();
    }

    private void OnTriggerExit(Collider other)
    {
        AlarmDisable.Invoke();
    }
}
