using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieGroans : MonoBehaviour
{
    public AudioClip[] groans;
    public bool zombiesComing = false;
    private float startGroaningSound;
    private float timeToNextGroan;
    private const float MIN_TIME_TO_NEXT_GROAN = 5; // seconds
    private const float MAX_TIME_TO_NEXT_GROAN = 10; // seconds
    float RELATIVE_SFX_VOLUME = 0.1f;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (zombiesComing)
        {
            // play groaning sound
            int chompID = Mathf.CeilToInt(Random.Range(0, groans.Length));
            AudioClip thisGroan = groans[chompID];
            if (Time.time > startGroaningSound + thisGroan.length + timeToNextGroan)
            {
                AudioSource.PlayClipAtPoint(thisGroan, Camera.main.transform.position, Globals.Instance.sfxVolume * RELATIVE_SFX_VOLUME);
                startGroaningSound = Time.time;
                timeToNextGroan = Random.Range(MIN_TIME_TO_NEXT_GROAN, MAX_TIME_TO_NEXT_GROAN);
            }
        }
        else
        {
            startGroaningSound = Time.time;
            timeToNextGroan = 0;
        }
    }
}
