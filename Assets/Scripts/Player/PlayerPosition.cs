using System;
using UnityEngine;

public class PlayerPosition : MonoBehaviour {
	public Action onRoomChanged, onLocationChanged;
	[SerializeField] private Location startingLocation;

	public Location Location { get; private set; }
	public Room Room { get; private set; }

	private void Start() {
		SetLocation(startingLocation);
	}

	private void SetLocation(Location newLocation) {
		Location = newLocation;
		onLocationChanged?.Invoke();

		SetRoom(Location.StartingRoom);
	}

	public void SetRoom(Room newRoom) {
		Room = newRoom;

		onRoomChanged?.Invoke();
	}
}