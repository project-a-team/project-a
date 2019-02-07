using UnityEngine;
using UnityEngine.Events;

public class PlayerPosition : MonoBehaviour {
	[SerializeField] private Location startLocation;

	public Location Location { get; private set; }
	public Vector3Int Position { get; private set; }
	public Room Room => Location.GetRoom(Position);

	/// <summary>
	/// An event called after the player moved.
	/// </summary>
	public UnityEvent onMove;

	private void Start() {
		SetLocation(startLocation);
		onMove.Invoke();
	}

	private void SetLocation(Location newLocation) {
		newLocation.GenerateRoomGrid();
		Location = newLocation;
		Position = Location.StartingPosition;
	}

	public void Move(int dir) {
		var direction = (Direction) dir;

		if (Room.GetNeighbor(direction) != null) {
			Position += direction.Vector();

			onMove.Invoke();
		}
	}
}