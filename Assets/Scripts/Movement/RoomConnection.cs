using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public struct RoomConnection {
	[SerializeField] private string name;
	public string Name => name;

	// Whether the movement is relative from the current room, or an absolute target position
	public Type type;
	public Vector3Int target;

	public enum Type {
		Relative,
		Absolute
	}
}