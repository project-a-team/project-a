using UnityEngine;

public class Room {
	public string Name { get; }

	public Location Location { get; }

	public Vector3Int Position { get; }

	private readonly bool[] openDirections;

	public Room(Location location, Vector3Int position, string name, bool[] openDirections) {
		Location = location;
		Position = position;
		Name = name;
		this.openDirections = openDirections;
	}

	public bool GetOpen(Direction direction) => openDirections[(int) direction];

	public void SetOpen(Direction direction, bool open) => openDirections[(int) direction] = open;

	public Room GetNeighbor(Direction direction) => GetOpen(direction)
		? Location.GetRoom(Position + direction.Vector())
		: null;

	public override string ToString() => Name;
}