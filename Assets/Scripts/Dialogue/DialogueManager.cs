using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour {
	[SerializeField] private PlayerPosition playerPosition;
	[SerializeField] private Text mainText;
	[SerializeField] private RectTransform buttonsParent;
	[SerializeField] private Button buttonPrefab;

	private void Awake() {
		playerPosition.onRoomChanged += OnRoomChanged;
	}

	private void OnRoomChanged() {
		mainText.text = playerPosition.Room.Text;
	}
}