using UnityEngine;

/// <summary>
/// Represents a direction in the grid.
/// </summary>
public enum Direction {
	North = 0,
	East = 1,
	South = 2,
	West = 3
}

public static class DirectionExtension {
	public static Vector3Int ToVector(this Direction direction) {
		switch (direction) {
			case Direction.North:
				return Vector3Int.up;
			case Direction.East:
				return Vector3Int.right;
			case Direction.South:
				return Vector3Int.down;
			case Direction.West:
				return Vector3Int.left;
			default:
				return Vector3Int.zero;
		}
	}
}