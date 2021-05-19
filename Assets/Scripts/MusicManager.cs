using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
	new AudioSource audio;

	float fadeInTimer;

	public float startTime;
	public float maxFadeInVolume;
	public float fadeInDuration;

	// Start is called before the first frame update
	void Start()
	{
		fadeInTimer = 0f;
		audio = gameObject.GetComponent<AudioSource>();

		// start from user-set position with high precision
		audio.timeSamples = (int)(startTime * audio.clip.frequency);
	}

	// Update is called once per frame
	void Update()
	{
		fadeInTimer += (Time.deltaTime / fadeInDuration);
		audio.volume = Mathf.Lerp(0, maxFadeInVolume, fadeInTimer);
	}
}
