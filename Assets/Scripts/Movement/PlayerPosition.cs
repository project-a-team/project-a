﻿using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

public class PlayerPosition : MonoBehaviour {
	[SerializeField] private ActionPanel actionPanel;
	[SerializeField] private Location startLocation;

	public Location Location { get; private set; }
	public Vector3Int Position { get; private set; }
	public Room Room => Location.GetRoom(Position);

	public Action onPlayerMoved, onLocationChanged;

	private void Start() {
		SetLocation(startLocation);
	}

	private void SetLocation(Location newLocation) {
		Location = newLocation;
		onLocationChanged?.Invoke();

		MoveToPosition(Location.StartingPosition);
	}

	public void Move(int dir) {
		var direction = (Direction) dir;
		var targetPosition = Position + direction.ToVector();

		if (Room.IsOpen(direction) && Location.GetRoom(targetPosition) != null) {
			MoveToPosition(targetPosition);
		}
	}

	private void MoveToPosition(Vector3Int targetPosition) {
		Position = targetPosition;

		actionPanel.ClearActions();
		foreach (var connection in Room.RoomConnections) {
			actionPanel.AddAction(connection.Name, delegate { TakeConnection(connection); });
		}

		onPlayerMoved?.Invoke();
	}

	private void TakeConnection(RoomConnection connection) {
		switch (connection.type) {
			case RoomConnection.Type.Relative:
				MoveToPosition(Position + connection.target);
				break;
			case RoomConnection.Type.Absolute:
				MoveToPosition(connection.target);
				break;
			default:
				throw new ArgumentOutOfRangeException();
		}
	}
}