using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Room : ScriptableObject {
	public string Name => name;

	public Location Location { get; set; }

	[SerializeField] private Vector3Int gridPosition;
	public Vector3Int GridPosition => gridPosition;

	[SerializeField] private bool northOpen, eastOpen, southOpen, westOpen;

	[SerializeField] private RoomEvent roomEvent;

	[SerializeField] private List<RoomConnection> roomConnections;
	public IEnumerable<RoomConnection> RoomConnections => roomConnections.AsReadOnly();

	[SerializeField] private TextAsset description;

	public bool GetOpen(Direction direction) {
		switch (direction) {
			case Direction.North:
				return northOpen;
			case Direction.East:
				return eastOpen;
			case Direction.South:
				return southOpen;
			case Direction.West:
				return westOpen;
			default:
				throw new ArgumentOutOfRangeException(nameof(direction), direction, null);
		}
	}

	public Room GetNeighbor(Direction direction) => GetOpen(direction)
		? Location.GetRoom(GridPosition + direction.ToVector())
		: null;

	public override string ToString() => Name;
}