using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Location/Location")]
public class Location : ScriptableObject {
	[SerializeField] private string locationName;
	[SerializeField] private Room startingRoom;

	public string Name => locationName;
	public Room StartingRoom => startingRoom;

	public IEnumerable<Room> GetFloor(int floor) {
		// list of rooms on the floor we want
		var rooms = new List<Room>();

		// hashset of the rooms we have already looked at
		var seen = new HashSet<Room>();

		// queue of rooms to look at next
		var queue = new Queue<Room>();
		queue.Enqueue(startingRoom);

		while (queue.Count > 0) {
			var room = queue.Dequeue();

			// If we already looked at the room, skip it
			if (seen.Contains(room)) continue;

			if (room.Floor == floor) rooms.Add(room);

			seen.Add(room);

			foreach (var neighbor in room.Neighbors) {
				queue.Enqueue(neighbor);
			}
		}

		return rooms;
	}

	public override string ToString() => Name;
}