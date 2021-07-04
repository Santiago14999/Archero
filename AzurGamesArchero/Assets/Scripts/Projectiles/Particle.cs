using UnityEngine;

public class Particle : MonoBehaviour
{
    [SerializeField] float _destroyTime = 1f;

    void Awake()
    {
        Destroy(gameObject, _destroyTime);
    }
}
