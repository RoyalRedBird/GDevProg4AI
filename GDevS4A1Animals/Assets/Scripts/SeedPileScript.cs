using UnityEngine;

public class SeedPileScript : MonoBehaviour
{

    [SerializeField] private float seedsLeft = 100;
    [SerializeField] private ParticleSystem seedParticles;

    
    public void EatSeeds()
    {

        if (!seedParticles.isEmitting)
        {

            seedParticles.Play();

        }

        seedsLeft -= Time.deltaTime;

        if(seedsLeft <= 0)
        {

            Destroy(gameObject);

        }
        

    }

}
