using UnityEngine;

public class TimeController : MonoBehaviour
{
    [SerializeField] float _timeScale = 1f;
    public float TimeScale => _timeScale;

    public void UpdateTimeScale()
    {
        Time.timeScale = _timeScale;
    }
}
