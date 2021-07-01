using UnityEngine;

public class EnemyRagdoll : MonoBehaviour
{

    public void SetupRagdoll(int animationHash, float animationTime)
    {
        Animator animator = GetComponent<Animator>();
        animator.Play(animationHash, 0, animationTime);
    }
}
