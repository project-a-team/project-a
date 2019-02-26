using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

public class PlayerPosition : MonoBehaviour {
	[SerializeField] private ActionPanel actionPanel;
	[SerializeField] private Location startingLocation;

	public Location Location { get; private set; }
	public Room Room { get; private set; }

	public Action onRoomChanged, onLocationChanged;

	private void Start() {
		SetLocation(startingLocation);
	}

	private void SetLocation(Location newLocation) {
		Location = newLocation;
		onLocationChanged?.Invoke();

		SetRoom(Location.StartingRoom);
	}

	private void SetRoom(Room newRoom) {
		if (newRoom == null) {
			Debug.LogWarning("Attempted to move to null room from " + Room);
			return;
		}

		Room = newRoom;

		actionPanel.ClearActions();
		foreach (var neighbor in Room.Neighbors) {
			if (neighbor == null) continue;
			actionPanel.AddAction(neighbor.Name, delegate { SetRoom(neighbor); });
		}

		onRoomChanged?.Invoke();
	}
}