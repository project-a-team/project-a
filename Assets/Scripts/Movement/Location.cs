using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu]
public class Location : ScriptableObject {
	[SerializeField] private string locationName;
	public string Name => locationName;

	[SerializeField] private Room startingRoom;
	public Room StartingRoom => startingRoom;

	public override string ToString() => Name;
}