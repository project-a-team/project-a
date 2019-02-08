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
	/// Contains the rooms as a 3D array
	/// </summary>
	private Room[,,] roomGrid;

	private Vector3Int roomGridSize;

	/// <summary>
	/// Returns the room at the specified position. Returns null if out of bounds or no room present.
	/// </summary>
	public Room GetRoom(Vector3Int position) =>
		position.x < 0 || position.x >= roomGridSize.x ||
		position.y < 0 || position.y >= roomGridSize.y ||
		position.z < 0 || position.z >= roomGridSize.z
			? null
			: roomGrid[position.x, position.y, position.z];


	/// <summary>
	/// Generates a room grid from the room list for easier access.
	/// </summary>
	/// <returns></returns>
	public void GenerateRoomGrid() {
		// First, determine the grid size by getting the max room position 
		var maxX = 0;
		var maxY = 0;
		var maxZ = 0;

		foreach (var room in roomList) {
			maxX = Mathf.Max(maxX, room.GridPosition.x);
			maxY = Mathf.Max(maxY, room.GridPosition.y);
			maxZ = Mathf.Max(maxZ, room.GridPosition.z);
		}

		roomGridSize = new Vector3Int(maxX + 1, maxY + 1, maxZ + 1);

		roomGrid = new Room[maxX + 1, maxY + 1, maxZ + 1];

		foreach (var room in roomList) {
			roomGrid[room.GridPosition.x, room.GridPosition.y, room.GridPosition.z] = room;
			room.Location = this;
		}
	}

	public override string ToString() => Name;
}