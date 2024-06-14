using UnityEngine;
using System;

public class ThiefDetector : MonoBehaviour
{
    public event Action AlarmEnable;
    public event Action AlarmDisable;

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Thief>() != null)
        {
            AlarmEnable.Invoke();
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<Thief>() != null)
        {
            AlarmDisable.Invoke();
        }
    }
}
