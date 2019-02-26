using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ActionPanel : MonoBehaviour {
	[SerializeField] private RectTransform actionsPanel;
	[SerializeField] private Button actionButton;

	public void ClearActions() {
		foreach (Transform child in actionsPanel) {
			Destroy(child.gameObject);
		}
	}

	public void AddAction(string actionName, UnityAction action, bool valid = true) {
		var button = Instantiate(actionButton, actionsPanel);
		button.onClick.AddListener(action);
		button.GetComponentInChildren<Text>().text = actionName;
		button.interactable = valid;

		var rectTransform = button.GetComponent<RectTransform>();
		var pos = rectTransform.position;
		pos.y -= rectTransform.sizeDelta.y * (actionsPanel.childCount - 1);
		rectTransform.position = pos;
	}
}