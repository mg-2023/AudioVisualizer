using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetFont : MonoBehaviour
{
	public Font customFont;
	Text[] fontSetter;

	// Start is called before the first frame update
	void Start()
	{
		fontSetter = GetComponentsInChildren<Text>();

		for (int i = 0; i < fontSetter.Length; i++)
			fontSetter[i].font = customFont;
	}

	/*
	// Update is called once per frame
	void Update()
	{
		
	}
	*/
}
