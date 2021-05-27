using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarColor : MonoBehaviour
{
	float switchColorTimer;

	GameObject[] bars;
	SpriteRenderer[] sr;

	[SerializeField]
	[Tooltip("If enabled, forces bar color to rainbow")]
	bool enableRainbow;

	[SerializeField]
	[Tooltip("Sets bar color to either interpolate(on) or switch(off) between two colors")]
	bool interpolateColor;

	[ColorUsage(true, false)]
	public Color color1;
	[ColorUsage(true, false)]
	public Color color2;

	public float loopTimer;

	// Start is called before the first frame update
	void Start()
	{
		switchColorTimer = 0f;

		bars = GameObject.FindGameObjectsWithTag("Bar");
		sr = new SpriteRenderer[bars.Length];
		for (int i = 0; i < bars.Length; i++)
		{
			sr[i] = bars[i].GetComponent<SpriteRenderer>();
		}
	}

	// Update is called once per frame
	void Update()
	{
		SetColor();
	}

	void SetColor()
	{
		// forces bar color to rainbow
		if (enableRainbow && !interpolateColor)
		{
			for (int i = 0; i < bars.Length; i++)
			{
				sr[i].color = Color.HSVToRGB((float)i / (float)bars.Length, 1f, 1f);
			}
		}

		// forces bar color to rainbow + color automatically switches
		else if (enableRainbow && interpolateColor)
        {
			switchColorTimer += Time.deltaTime/loopTimer;
			if (switchColorTimer > 1f)
				switchColorTimer = 0f;

			for (int i = 0; i < bars.Length; i++)
			{
				sr[i].color = Color.HSVToRGB(switchColorTimer, 1f, 1f);
			}
		}

		// bar color interpolates between two colors
		else if (!enableRainbow && interpolateColor)
		{
			for (int i = 0; i < bars.Length; i++)
			{
				sr[i].color = Color.Lerp(color1, color2, (float)i / (float)bars.Length);
			}
		}

		// bar color switches between two colors
		else
		{
			for (int i = 0; i < bars.Length; i++)
			{
				sr[i].color = (i % 2 == 0) ? color1 : color2;
			}
		}
	}
}
