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
		SetDialogue(playerPosition.Room.Dialogue);
	}

	private void SetDialogue(DialogueNode dialogueNode) {
		if (dialogueNode == null) {
			mainText.text = "";
			return;
		}

		mainText.text = dialogueNode.Text;
	}
}