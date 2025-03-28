using UnityEngine;

[RequireComponent(typeof(ParticleSystem), typeof(Collider))]

public class TriggerParticleEffect : MonoBehaviour
{
    public ParticleSystem particles;
    public int particleAmount = 10;

    private void Start()
    {
        particles = GetComponent<ParticleSystem>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            particles.Emit(particleAmount);
        }
    }
}
