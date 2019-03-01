using UnityEngine;

[CreateAssetMenu]
public class Location : ScriptableObject {
	[field: SerializeField] public string Name { get; }

	[field: SerializeField] public Room StartingRoom { get; }

	public override string ToString() {
		return Name;
	}
}