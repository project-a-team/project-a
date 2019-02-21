using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu]
public class Location : ScriptableObject {
	public string Name => name;

	/// <summary>
	/// The initial position of the player when entering this location
	/// </summary>
	[SerializeField] private Vector3Int startingPosition;

	public Vector3Int StartingPosition => startingPosition;

	/// <summary>
	/// List of rooms for this location, to be set from the inspector
	/// </summary>
	[SerializeField] private List<Room> roomList;

	/// <summary>
	/// Returns all the rooms on the matching floor
	/// </summary>
	public IEnumerable<Room> Floor(int floor) =>
		from Room room in roomList
		where room.GridPosition.z == floor
		select room;

	private Vector3Int roomGridSize;

	/// <summary>
	/// Returns the room at the specified position. Returns null if out of bounds or no room present.
	/// </summary>
	public Room GetRoom(Vector3Int position) => roomList.Find(room => room.GridPosition == position);

	public override string ToString() => Name;
}