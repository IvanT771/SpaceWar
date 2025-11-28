using UnityEngine;

public class FactoryBuildings
{
    public GridObject Create(CardDataSO card, Vector3 position)
    {
        return GridObject.Instantiate(card.Prefab, position, Quaternion.identity);
    }
}
