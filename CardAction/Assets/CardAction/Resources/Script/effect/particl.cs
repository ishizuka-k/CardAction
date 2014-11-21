using UnityEngine;
using System.Collections;

public class particl : MonoBehaviour {

    ParticleSystem myParticleSystem;

    void Awake()
    {
        myParticleSystem = this.particleSystem;
    }

    // Update is called once per frame
    void Update()
    {
        if (!myParticleSystem.IsAlive())
        {
            Destroy(this.gameObject.transform.parent.gameObject);
        }
    }
}
