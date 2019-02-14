using UnityEngine;
using UnityEngine.Serialization;

public class MiniMap : MonoBehaviour {
	[SerializeField] private PlayerPosition playerPosition;

	[SerializeField] private RectTransform miniMapParent;
	[SerializeField] private MiniMapRoom roomPrefab;

	[SerializeField] private RectTransform playerTokenPrefab;

	private void Awake() {
		playerPosition.onPlayerMoved += DrawFloor;
	}

	private void DrawFloor() {
		//Clear minimap
		foreach (Transform child in miniMapParent) {
			Destroy(child.gameObject);
		}

		// Min and max positions of rooms, used to determine minimap size
		int minX = int.MaxValue, maxX = int.MinValue, minY = int.MaxValue, maxY = int.MinValue;

		// Draw each room
		foreach (var room in playerPosition.Location.Floor(playerPosition.Position.z)) {
			minX = Mathf.Min(minX, room.GridPosition.x);
			maxX = Mathf.Max(maxX, room.GridPosition.x);
			minY = Mathf.Min(minY, room.GridPosition.x);
			maxY = Mathf.Max(maxY, room.GridPosition.x);

			var miniMapRoom = Instantiate(roomPrefab, GetMapPosition(room.GridPosition), Quaternion.identity);
			miniMapRoom.transform.SetParent(miniMapParent, false);
			miniMapRoom.SetRoom(room);
		}

		// Set scrollable area size
		miniMapParent.sizeDelta = new Vector2(
			(maxX - minX + 1) * roomPrefab.GridSize.x,
			(maxY - minY + 1) * roomPrefab.GridSize.y
		);


		// Draw player position
		var player = Instantiate(playerTokenPrefab, GetMapPosition(playerPosition.Position), Quaternion.identity);
		player.SetParent(miniMapParent, false);
	}

	private Vector3 GetMapPosition(Vector3Int gridPosition) {
		return new Vector3(
			(gridPosition.x + .5f) * roomPrefab.GridSize.x,
			(gridPosition.y + .5f) * roomPrefab.GridSize.y,
			0
		);
	}
}