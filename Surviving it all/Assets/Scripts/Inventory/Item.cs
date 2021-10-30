using UnityEngine;

[CreateAssetMenu]
public class Item : ScriptableObject
{
    public string ItemName;
    public Sprite Icon;
    [Range(1, 99)] public int MaxStacks = 1;
}
