using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Location/Room")]
public class Room : ScriptableObject {
	[SerializeField] private string roomName;
	[SerializeField] private int floor;
	[SerializeField] private Rect position;
	[SerializeField] private Sprite sprite;
	[SerializeField] private List<Room> neighbors;

	public string Name => roomName;
	public int Floor => floor;
	public Rect Position => position;
	public Sprite Sprite => sprite;
	public IEnumerable<Room> Neighbors => neighbors;

	public override string ToString() => Name;
}