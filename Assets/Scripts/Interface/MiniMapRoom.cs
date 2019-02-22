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

		northDoor.SetActive(room.IsOpen(Direction.North));
		eastDoor.SetActive(room.IsOpen(Direction.East));
		southDoor.SetActive(room.IsOpen(Direction.South));
		westDoor.SetActive(room.IsOpen(Direction.West));
	}
}