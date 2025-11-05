using UnityEngine;

public class GridWorld : MonoBehaviour
{
    #region Fields

    [SerializeField]
    private GameObject cubePrefab;

    #endregion

    #region Properties

    [field: SerializeField]
    public GridManager GridManager { get; private set; }

    [field: SerializeField]
    public PlaceableSystem PlaceableSystem { get; private set; }

    public FactoryBuildings FactoryBuildings { get; private set; }

    #endregion

    #region LifeCycle

    private void Awake()
    {
        FactoryBuildings = new(cubePrefab);
        PlaceableSystem.Initialize(FactoryBuildings, GridManager);
    }

    #endregion

}
