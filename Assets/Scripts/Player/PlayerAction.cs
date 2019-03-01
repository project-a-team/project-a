using UnityEngine.Events;

public struct PlayerAction {
	public readonly string name;
	public readonly UnityAction unityAction;

	public PlayerAction(string name, UnityAction unityAction) {
		this.name = name;
		this.unityAction = unityAction;
	}
}