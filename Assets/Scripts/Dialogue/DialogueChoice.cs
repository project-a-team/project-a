using UnityEngine;

[CreateAssetMenu(menuName = "Dialogue/Choice/Choice")]
public class DialogueChoice : ScriptableObject {
	[SerializeField] private string text;
	[SerializeField] private string tooltip;
	[SerializeField] private DialogueNode nextNode;

	public virtual bool IsValid() => true;
}