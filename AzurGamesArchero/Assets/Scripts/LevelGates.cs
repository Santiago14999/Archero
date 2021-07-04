using System;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class LevelGates : MonoBehaviour
{
    public event Action PlayerEnteredPortal;

    [SerializeField] Animator _gatesAnimator;
    [SerializeField] ParticleSystem _portalParticle;

    public void OpenGates()
    {
        _gatesAnimator.SetBool("Opened", true);
        _portalParticle.Play();
    }

    public void CloseGates()
    {
        _gatesAnimator.SetBool("Opened", false);
        _portalParticle.Stop();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<ArcheroLike.Units.Player.PlayerMovement>(out var player))
            PlayerEnteredPortal?.Invoke();
    }
}
