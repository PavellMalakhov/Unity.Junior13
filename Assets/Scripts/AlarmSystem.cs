using System.Collections;
using UnityEngine;

public class AlarmSystem : MonoBehaviour
{
    [SerializeField] private ThiefDetector _thiefDetector;
    [SerializeField] private AudioSource _audioSource;

    [SerializeField] private float _volumeRegulationStep = 0.2f;
    [SerializeField] private float _volumeMax = 1f;
    [SerializeField] private float _volumeMin = 0f;
    [SerializeField] private bool _alarmOn = false;


    private void OnEnable()
    {
        _thiefDetector.AlarmEnable += AlarmOn;
        _thiefDetector.AlarmDisable += AlarmOff;
    }

    private void OnDisable()
    {
        _thiefDetector.AlarmEnable -= AlarmOn;
        _thiefDetector.AlarmDisable -= AlarmOff;
    }

    private void AlarmOn()
    {
        _audioSource.Play();
        _alarmOn = true;
        StartCoroutine(AdjustVolume(_volumeMax));
    }

    private void AlarmOff()
    {
        _alarmOn = false;
        StartCoroutine(AdjustVolume(_volumeMin));
    }

    private IEnumerator AdjustVolume(float targetValue)
    {
        var wait = new WaitForEndOfFrame();

        while (_alarmOn && _audioSource.volume < targetValue)
        {
            _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, targetValue, _volumeRegulationStep * Time.deltaTime);

            yield return wait;
        }

        while (!_alarmOn && _audioSource.volume > targetValue)
        {
            _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, targetValue, _volumeRegulationStep * Time.deltaTime);

            if (_audioSource.volume == 0)
            {
                _audioSource.Stop();
            }

            yield return wait;
        }
    }
}
