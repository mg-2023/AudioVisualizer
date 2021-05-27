using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SliderControl : MonoBehaviour
{
	public AudioSource source;
	public Slider slider;

	public MusicManager manager;

	// Start is called before the first frame update
	void Start()
	{
		slider.minValue = 0f;
		slider.maxValue = source.clip.samples;
		slider.wholeNumbers = true;
	}

	// Update is called once per frame
	void Update()
	{
		if(manager.IsPlaying)
		{
			slider.interactable = false;
			slider.value = source.timeSamples;
		}

		else
		{
			slider.interactable = true;
			source.timeSamples = (int)slider.value;
		}
	}
}
