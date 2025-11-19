using UnityEngine;

[CreateAssetMenu(fileName = "CardData", menuName = "Cards/Card")]
public class CardDataSO : ScriptableObject
{
    [field: SerializeField]
    public string Name { get; private set; } = "Name";

    [field: SerializeField]
    public GridObject Prefab { get; private set; }

    [field: SerializeField]
    public int Coast { get; private set; } = 2;

    [field: SerializeField]
    public Sprite Sprite { get; private set; }
}
