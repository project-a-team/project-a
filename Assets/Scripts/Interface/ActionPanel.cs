using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ActionPanel : MonoBehaviour {
	[SerializeField] private PlayerPosition playerPosition;
	[SerializeField] private Button actionButton;
	[SerializeField] private RectTransform actionsPanel;

	private float buttonHeight;

	private void Awake() {
		playerPosition.onRoomChanged += OnRoomChanged;
		buttonHeight = actionButton.GetComponent<RectTransform>().rect.height;
	}

	private void OnRoomChanged() {
		foreach (Transform child in actionsPanel) Destroy(child.gameObject);

		var offset = 0f;
		foreach (var room in playerPosition.Room.Neighbors) {
			AddAction(room.Name, delegate { playerPosition.SetRoom(room); }, offset);
			offset += buttonHeight;
		}
	}

	private void AddAction(string name, UnityAction action, float offset) {
		var button = Instantiate(actionButton, actionsPanel);
		button.onClick.AddListener(action);
		button.GetComponentInChildren<Text>().text = name;

		var rectTransform = button.GetComponent<RectTransform>();
		var pos = rectTransform.localPosition;
		pos.y -= offset;
		rectTransform.localPosition = pos;
	}
}