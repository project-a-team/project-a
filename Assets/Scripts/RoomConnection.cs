using UnityEngine;

[System.Serializable]
public struct RoomConnection {
	public string name;
	public Type type;
	public Vector3Int target;

	public enum Type {
		Relative,
		Absolute
	}
}