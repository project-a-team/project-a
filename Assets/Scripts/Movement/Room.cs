using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Room : ScriptableObject {
	[SerializeField] private string roomName;
	public string Name => roomName;

	[SerializeField] private Rect position;

	[SerializeField] private Sprite sprite;
	public Sprite Sprite => sprite;


	[SerializeField] private List<Room> neighbors;
	public IEnumerable<Room> Neighbors => neighbors;

	public override string ToString() => Name;
}