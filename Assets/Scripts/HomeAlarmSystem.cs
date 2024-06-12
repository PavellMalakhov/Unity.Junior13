using UnityEngine;

public class HomeAlarmSystem : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private float _speedVolumeUp = 0.2f;
    [SerializeField] private bool _onAlarm = false;

    private void OnTriggerEnter(Collider other)
    {
        _onAlarm = true;
        _audioSource.volume = 0;
        _audioSource.Play();
    }

    private void OnTriggerExit(Collider other)
    {
        _onAlarm = false;
        _audioSource.Stop();
    }

    private void Update()
    {
        if (_onAlarm)
        {
            _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, 1f, _speedVolumeUp * Time.deltaTime);
        }
    }
}
