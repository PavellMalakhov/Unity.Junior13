using UnityEngine;
using System;

public class ThiefDetector : MonoBehaviour
{
    public event Action AlarmEnabled;
    public event Action AlarmDisabled;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Thief thief))
        {
            AlarmEnabled.Invoke();
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out Thief thief))
        {
            AlarmDisabled.Invoke();
        }
    }
}
