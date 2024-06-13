using System.Collections;
using UnityEngine;

public class AlarmSystem : MonoBehaviour
{
    [SerializeField] private Trigger _trigger;
    [SerializeField] private AudioSource _audioSource;

    [SerializeField] private float _volumeRegulationStep = 0.05f;
    [SerializeField] private float _delayAfterStep = 0.5f;
    [SerializeField] private bool _alarmOn = false;

    private void OnEnable()
    {
        _trigger.AlarmEnable += AlarmOn;
        _trigger.AlarmDisable += AlarmOff;
    }

    private void OnDisable()
    {
        _trigger.AlarmEnable -= AlarmOn;
        _trigger.AlarmDisable -= AlarmOff;
    }

    private void AlarmOn()
    {
        _audioSource.Play();
        _alarmOn = true;
        StartCoroutine(IncreaseVolume(_delayAfterStep));
    }

    private void AlarmOff()
    {
        _alarmOn = false;
        StartCoroutine(DecreaseVolume(_delayAfterStep));
    }

    private IEnumerator IncreaseVolume(float delay)
    {
        var wait = new WaitForSeconds(delay);

        while (_audioSource.volume < 1 && _alarmOn)
        {
            _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, 1f, _volumeRegulationStep);
            yield return wait;
        }
    }

    private IEnumerator DecreaseVolume(float delay)
    {
        var wait = new WaitForSeconds(delay);

        while (_audioSource.volume > 0 && !_alarmOn)
        {
            _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, 1f, -_volumeRegulationStep);
            yield return wait;
        }
    }
}
