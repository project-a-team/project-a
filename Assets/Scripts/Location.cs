using System.Collections.Generic;
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
	/// Returns the rooms as a 3D array, creating it from the list if needed
	/// </summary>
	private Room[,,] RoomGrid => roomGrid ?? GenerateRoomGrid();

	private Room[,,] roomGrid;

	public Room GetRoom(Vector3Int position) => RoomGrid[position.x, position.y, position.z];


	/// <summary>
	/// Generates a room grid from the room list for easier access.
	/// </summary>
	/// <returns></returns>
	private Room[,,] GenerateRoomGrid() {
		// First, determine the grid size by getting the max room position 
		var maxX = 0;
		var maxY = 0;
		var maxZ = 0;

		foreach (var room in roomList) {
			maxX = Mathf.Max(maxX, room.GridPosition.x);
			maxY = Mathf.Max(maxY, room.GridPosition.y);
			maxZ = Mathf.Max(maxZ, room.GridPosition.z);
		}

		roomGrid = new Room[maxX + 1, maxY + 1, maxZ + 1];

		foreach (var room in roomList) {
			roomGrid[room.GridPosition.x, room.GridPosition.y, room.GridPosition.z] = room;
			room.Location = this;
		}

		return roomGrid;
	}

	public override string ToString() => Name;
}