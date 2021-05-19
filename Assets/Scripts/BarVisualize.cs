using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarVisualize : MonoBehaviour
{
	const int COUNT = 2048;

	public AudioSource BGM;

	GameObject[] bars;
	SpriteRenderer[] sr;

	private int[] bands = {4, 4, 5, 5, 6, 6, 7, 8, 9, 10, 11, 12, 13, 14, 16, 17, 19, 21, 23, 26, 29, 
							31, 35, 38, 42, 46, 51, 56, 62, 68, 75, 83, 91, 101, 111, 122, 134, 148, 
							163, 179, 198, 217, 239, 264, 290, 319, 352, 387, 426, 469, 516, 568, 
							626, 689, 758, 835, 919, 1011, 1113, 1225, 1349, 1485, 1634, 1799};

	float[] LFreq = new float[COUNT];
	float[] RFreq = new float[COUNT];
	float[] meanFreq = new float[COUNT];

	// Start is called before the first frame update
	void Start()
	{
		bars = GameObject.FindGameObjectsWithTag("Bar");
		sr = new SpriteRenderer[bars.Length];
		for(int i=0; i<bars.Length; i++)
		{
			sr[i] = bars[i].GetComponent<SpriteRenderer>();
		}
	}

	// Update is called once per frame
	void Update()
	{
		CalcMeanData();
		VisualizeAudio();
	}

	void CalcMeanData()
	{
		AudioListener.GetSpectrumData(LFreq, 0, FFTWindow.BlackmanHarris);
		AudioListener.GetSpectrumData(RFreq, 1, FFTWindow.BlackmanHarris);

		for (int i = 0; i < COUNT; i++)
		{
			meanFreq[i] = (LFreq[i] + RFreq[i]) / 2;
		}
	}

	void VisualizeAudio()
	{
		for (int i = 0; i < bars.Length; i++)
		{
			bars[i].transform.localScale =
				new Vector3(bars[i].transform.localScale.x,
				(Mathf.Log(meanFreq[bands[i]] + 0.00005f, 2) + 14.5f) * 1.5f,
				bars[i].transform.localScale.z);
		}
	}
}
