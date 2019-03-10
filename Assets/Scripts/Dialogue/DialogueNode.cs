using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Dialogue/Dialogue Node")]
public class DialogueNode : ScriptableObject {
	[SerializeField] private TextAsset text;
	[SerializeField] private List<DialogueChoice> choices;
}