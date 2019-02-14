using UnityEngine;
using UnityEngine.UI;

public class ActionsPanel : MonoBehaviour {
	[SerializeField] private PlayerPosition playerPosition;

	[SerializeField] private RectTransform actionsPanel;
	[SerializeField] private Button actionButton;

	private void Awake() {
		playerPosition.onPlayerMoved += OnPlayerMoved;
	}

	private void OnPlayerMoved() {
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