using System;
using UnityEngine;
using UnityEngine.UI;

public class PositionPanel : MonoBehaviour {
	[SerializeField] private Text text;
	[SerializeField] private PlayerPosition playerPosition;

	public void OnPlayerMoved() {
		var positionText = $"{playerPosition.Position}\n";

		if (playerPosition.Room != null) {
			positionText += $"{playerPosition.Room}\n\n";

			foreach (var direction in new[] {Direction.North, Direction.East, Direction.South, Direction.West}) {
				var neighbor = playerPosition.Room.GetNeighbor(direction);
				if (neighbor != null) {
					positionText += $"{direction}: {neighbor}\n";
				}
			}
		}

		text.text = positionText;
	}
}