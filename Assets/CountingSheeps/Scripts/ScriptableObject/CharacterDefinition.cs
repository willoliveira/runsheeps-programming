﻿using UnityEngine;
using System;
using System.Collections;

[CreateAssetMenu(fileName = "Data", menuName = "Character Definition")]
public class CharacterDefinition: ScriptableObject {

	public string nameCharacter;
	public int order;
	public Texture2D image;
	public int price;
	public bool isAvaliable;
}
