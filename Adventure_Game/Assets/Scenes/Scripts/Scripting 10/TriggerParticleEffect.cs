using UnityEngine;
using System.Collections;

[RequireComponent(typeof(ParticleSystem), typeof(Collider))]

public class TriggerParticleEffect : MonoBehaviour
{
    public int firstEmissionAmount = 10;
    public int secondEmissionAmount = 20;
    public int thirdEmissionAmount = 30;
    public float delayBetweenEmissions = 0.5f;
    public ParticleSystem particles;

    private void Start()
    {
        particles = GetComponent<ParticleSystem>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(EmitParticlesCoroutine());
        }
    }

    private IEnumerator EmitParticlesCoroutine()
    {
        particles.Emit(firstEmissionAmount);
        yield return new WaitForSeconds(delayBetweenEmissions);

        particles.Emit(secondEmissionAmount);
        yield return new WaitForSeconds(delayBetweenEmissions);

        particles.Emit(thirdEmissionAmount);
    }
}
