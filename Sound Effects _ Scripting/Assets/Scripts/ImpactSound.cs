using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImpactSound : MonoBehaviour
{
    public AudioClip impactSoft;
    public AudioClip impactHard;

    private AudioSource source;
    private float lowPitchRange = .75F;
    private float highPitchRange = 1.25F;
    private float velToVol = .2F;
    private float velocityClipSplit = 10F;

    void Awake()
    {
        source = GetComponent<AudioSource>();  
    }

    private void OnCollisionEnter(Collision coll)

    {
        source.pitch = Random.Range(lowPitchRange, highPitchRange);
        float hitVol = coll.relativeVelocity.magnitude * velToVol;
        if (coll.relativeVelocity.magnitude < velocityClipSplit)
            source.PlayOneShot(impactSoft, hitVol);
        else
            source.PlayOneShot(impactHard, hitVol);

    }

}
