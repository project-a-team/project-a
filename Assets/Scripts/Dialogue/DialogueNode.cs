using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Dialogue/Dialogue Node")]
public class DialogueNode : ScriptableObject {
	[SerializeField, TextArea] private string text;
	[SerializeField] private List<DialogueChoice> choices;

	public string Text => text;
}