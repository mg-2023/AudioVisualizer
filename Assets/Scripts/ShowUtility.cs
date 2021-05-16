using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowUtility : MonoBehaviour
{
	private int length;
	private int realtime;

	public Text playtime;
	public AudioSource BGM;

	// Start is called before the first frame update
	void Start()
	{
		length = BGM.clip.samples / (BGM.clip.frequency / 100);
	}

	// Update is called once per frame
	void Update()
	{
		ShowPlaytime();
		ShowAuxUtil();
	}

	void ShowPlaytime()
	{
		realtime = BGM.timeSamples / (BGM.clip.frequency / 100);

		playtime.text = string.Format("Playtime: {0:00}:{1:00}.{2:00} / {3:00}:{4:00}.{5:00}",
			realtime / 6000, realtime / 100 % 60, realtime % 100, length / 6000, length / 100 % 60, length % 100);
	}

	void ShowAuxUtil()
	{
		if (BGM.pitch >= 0)
		{
			playtime.text += $"\n<size=20>Playspeed: {BGM.pitch:0.00} // Now Playing: {BGM.clip.name}</size>";
		}

		else
		{
			playtime.text += $"\n<size=20>Playspeed: {-BGM.pitch:0.00} (Reversed) // Now Playing: {BGM.clip.name}</size>";
		}
	}
}
