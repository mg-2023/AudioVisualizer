using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateBar : MonoBehaviour
{
	public int BarCount { get; set; }
	public GameObject bar;

	void Awake()
	{
		BarCount = 64;

		for(int i=1; i<BarCount; i++)
		{
			Instantiate(bar, bar.transform.position + new Vector3(32f/(float)BarCount * i, 0f, 0f), Quaternion.identity);
		}
	}
}
