using UnityEngine;
using UnityEngine.UI;

public class MiniMapRoom : MonoBehaviour {
	[SerializeField] private Vector2 gridSize = new Vector2(130, 130);
	public Vector2 GridSize => gridSize;
	[SerializeField] private GameObject northDoor, eastDoor, southDoor, westDoor;
	[SerializeField] private Image image;

	private Room room;

	public void SetRoom(Room room) {
		this.room = room;

		image.sprite = room.Sprite;

		northDoor.SetActive(room.GetOpen(Direction.North));
		eastDoor.SetActive(room.GetOpen(Direction.East));
		southDoor.SetActive(room.GetOpen(Direction.South));
		westDoor.SetActive(room.GetOpen(Direction.West));
	}
}