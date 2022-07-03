using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarVisualize : MonoBehaviour
{
	const int COUNT = 2048;

	public AudioSource BGM;

	GameObject[] bars;
	SpriteRenderer[] sr;

	private int[] bands = { 4, 4, 4, 4, 4, 4, 4, 5, 5, 5, 5, 5, 5, 5, 5, 6,
		6, 6, 6, 6, 6, 7, 7, 7, 7, 7, 7, 8, 8, 8, 8, 8, 9, 9, 9, 9, 10, 10,
		10, 10, 11, 11, 11, 11, 12, 12, 12, 13, 13, 13, 14, 14, 14, 15, 15,
		15, 16, 16, 17, 17, 17, 18, 18, 19, 19, 20, 20, 21, 21, 22, 22, 23,
		23, 24, 25, 25, 26, 27, 27, 28, 29, 29, 30, 31, 31, 32, 33, 34, 35,
		36, 36, 37, 38, 39, 40, 41, 42, 43, 44, 45, 46, 48, 49, 50, 51, 52,
		54, 55, 56, 58, 59, 61, 62, 64, 65, 67, 68, 70, 72, 74, 75, 77, 79,
		81, 83, 85, 87, 89, 91, 94, 96, 98, 101, 103, 106, 108, 111, 114, 116,
		119, 122, 125, 128, 131, 134, 138, 141, 144, 148, 152, 155, 159, 163,
		167, 171, 175, 179, 184, 188, 193, 198, 202, 207, 212, 217, 223, 228,
		234, 239, 245, 251, 257, 264, 270, 277, 283, 290, 297, 304, 312, 319,
		327, 335, 343, 352, 360, 369, 378, 387, 397, 406, 416, 426, 437, 447,
		458, 469, 481, 492, 504, 516, 529, 542, 555, 568, 582, 596, 611, 626,
		641, 657, 672, 689, 706, 723, 740, 758, 777, 796, 815, 835, 855, 876,
		897, 919, 941, 964, 987, 1011, 1036, 1061, 1087, 1113, 1140, 1168, 1196,
		1225, 1255, 1286, 1317, 1349, 1381, 1415, 1449, 1485, 1521, 1558, 1595,
		1634, 1674, 1714, 1756, 1799, 1842, 1887, 1933 };

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
