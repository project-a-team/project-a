using UnityEngine;
using UnityEngine.UI;

public class PositionPanel : MonoBehaviour {
	[SerializeField] private Text text;
	[SerializeField] private PlayerPosition playerPosition;

	public void OnPlayerMoved() {
		text.text = $"{playerPosition.Room}\n\n" +
		            $"North: {playerPosition.Room.GetNeighbor(Direction.North)}\n" +
		            $"East: {playerPosition.Room.GetNeighbor(Direction.East)}\n" +
		            $"South: {playerPosition.Room.GetNeighbor(Direction.South)}\n" +
		            $"West: {playerPosition.Room.GetNeighbor(Direction.West)}";
	}
}