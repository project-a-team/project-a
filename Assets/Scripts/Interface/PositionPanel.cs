using UnityEngine;
using UnityEngine.UI;

public class PositionPanel : MonoBehaviour {
	[SerializeField] private Text text;
	[SerializeField] private PlayerPosition playerPosition;
	[SerializeField] private RectTransform actionsPanel;
	[SerializeField] private Button actionButton;

	public void OnPlayerMoved() {
		// Set text about the current position
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

		// Clear action panel
		foreach (Transform child in actionsPanel) {
			Destroy(child.gameObject);
		}

		// Add connections to action panel
		foreach (var roomConnection in playerPosition.Room.RoomConnections) {
			var button = Instantiate(actionButton, actionsPanel);
			button.onClick.AddListener(delegate { playerPosition.TakeConnection(roomConnection); });
			button.GetComponentInChildren<Text>().text = roomConnection.name;
		}
	}
}