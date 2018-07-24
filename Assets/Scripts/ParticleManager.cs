using UnityEngine;

[RequireComponent(typeof(ParticleSystem))]
public class ParticleManager : MonoBehaviour {
    private ParticleSystem ps;
    private void Start()
    {
        ps = GetComponent<ParticleSystem>();
    }
    private void Update()
    {
        if (!ps.IsAlive())
        {
            Destroy(gameObject);
        }
    }
}
