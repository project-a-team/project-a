using UnityEngine;

[CreateAssetMenu(menuName = "Dialogue/Choice/Item Requirement")]
public class ItemRequirement : DialogueChoice {
	[SerializeField] private string item;
	[SerializeField] private bool consumeItem;

	public override bool IsValid() {
		//return player.HasItem(item);
		return true;
	}
}