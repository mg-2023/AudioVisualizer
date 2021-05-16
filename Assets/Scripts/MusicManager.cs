using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
	new AudioSource audio;

	float fadeInTimer;
	[SerializeField]
	float startTime;

	[Range(0, 1)]
	public float maxFadeInVolume;
	[Range(0, 5)]
	public float fadeInDuration;

	// Start is called before the first frame update
	void Start()
	{
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
