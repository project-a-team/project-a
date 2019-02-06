using UnityEngine;

public class Location {
	public string Name { get; }

	/// <summary>
	/// A 3D array of rooms in the format [width, length, floor].
	/// </summary>
	private readonly Room[,,] rooms;

	public Vector3Int StartingRoom { get; }

	public Location(string name, Vector3Int gridSize, Vector3Int startingRoom) {
		Name = name;
		StartingRoom = startingRoom;
		rooms = new Room[gridSize.x, gridSize.y, gridSize.z];
	}

	public Room GetRoom(Vector3Int position) => rooms[position.x, position.y, position.z];

	public void AddRoom(Vector3Int position, string name, bool[] openDirections) =>
		rooms[position.x, position.y, position.z] = new Room(this, position, name, openDirections);


	/// <summary>
	/// Hardcoded test location
	/// </summary>
	public static Location Vault() {
		var startingPosition = new Vector3Int(1, 0, 0);
		var vault = new Location("Vault", new Vector3Int(3, 3, 2), startingPosition);

		vault.AddRoom(startingPosition, "Lobby", new[] {true, false, false, false});
		vault.AddRoom(new Vector3Int(1, 1, 0), "Corridor", new[] {false, false, true, true});
		vault.AddRoom(new Vector3Int(0, 1, 0), "Stairs", new[] {false, true, false, false});

		return vault;
	}

	public override string ToString() => Name;
}