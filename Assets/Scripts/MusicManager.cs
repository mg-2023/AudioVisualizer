using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicManager : MonoBehaviour
{
	new AudioSource audio;

	float fadeInTimer;
	public bool IsPlaying { get; private set; }

	public float maxFadeInVolume;
	public float fadeInDuration;

	// Start is called before the first frame update
	void Start()
	{
		fadeInTimer = 0f;
		audio = gameObject.GetComponent<AudioSource>();
		audio.Play();
		IsPlaying = true;

		Debug.LogWarning($"audio.clip.samples = {audio.clip.samples}");
	}

	// Update is called once per frame
	void Update()
	{
		fadeInTimer += (Time.deltaTime / fadeInDuration);
		audio.volume = Mathf.Lerp(0, maxFadeInVolume, fadeInTimer);

		if (Input.GetKeyDown(KeyCode.P) && IsPlaying)
		{
			audio.Pause();
			IsPlaying = false;
		}

		else if (Input.GetKeyDown(KeyCode.P) && !IsPlaying)
		{
			audio.UnPause();
			IsPlaying = true;
		}
	}
}
