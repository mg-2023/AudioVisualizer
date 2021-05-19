using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpeedControl : MonoBehaviour
{
	public Button[] speedControl = new Button[2];
	public InputField speedSet;
	new public AudioSource audio;

	// Start is called before the first frame update
	void Start()
	{
		speedControl[0].onClick.AddListener(atempo);
		speedControl[1].onClick.AddListener(reverse);

		speedSet.text = "1.0";
	}

	// Update is called once per frame
	void Update()
	{
		if(!speedSet.isFocused)
		{
			float value;
			if (float.TryParse(speedSet.text, out value))
				audio.pitch = value;

			else
				Debug.LogError("Failed to set playspeed");

			speedSet.text = $"{audio.pitch:0.00}";
		}
	}

	void atempo()
	{
		speedSet.text = "1.00";
	}

	void reverse()
	{
		if (audio.pitch > 0)
			speedSet.text = $"-{audio.pitch}";

		else
			speedSet.text = $"{-audio.pitch}";
	}
}
