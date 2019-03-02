using UnityEngine;

public class Minimap : MonoBehaviour {
	[SerializeField] private PlayerPosition playerPosition;
	[SerializeField] private RectTransform minimapParent;
	[SerializeField] private MinimapRoom minimapRoomPrefab;
	[SerializeField] private RectTransform playerPrefab;

	private void Awake() {
		playerPosition.onRoomChanged += DrawFloor;
	}

	private void DrawFloor() {
		foreach (Transform child in minimapParent) {
			Destroy(child.gameObject);
		}

		var floor = playerPosition.Room.Floor;

		foreach (var room in playerPosition.Location.GetFloor(floor)) {
			var minimapRoom = Instantiate(minimapRoomPrefab, minimapParent);
			minimapRoom.SetRoom(room);
		}

		var player = Instantiate(playerPrefab, minimapParent);
		player.anchoredPosition = playerPosition.Room.Position.position;
	}
}