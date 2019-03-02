using UnityEngine;
using UnityEngine.UI;

public class MinimapRoom : MonoBehaviour {
	[SerializeField] private RectTransform rectTransform;
	[SerializeField] private Image image;

	public void SetRoom(Room newRoom) {
		name = newRoom.Name;

		rectTransform.anchoredPosition = newRoom.Position.position;
		rectTransform.sizeDelta = newRoom.Position.size;
		image.sprite = newRoom.Sprite;
	}
}