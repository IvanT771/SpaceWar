using UnityEngine;

public class PlaceableSystem : MonoBehaviour
{
    #region Fields

    private GridManager _gridManager;
    private FactoryBuildings _factoryBuildings;

    private Cell _currentCell = null;
    private bool _isInitialized = false;

    #endregion

    #region LifeCycle

    private void FixedUpdate()
    {
        if (!_isInitialized)
            return;

        if (!_gridManager.TryGetCellByMousePosition(Input.mousePosition, out var cell))
            return;

        if (_currentCell != null)
        {
            if (_currentCell == cell)
                return;

            _currentCell.Deselect();
        }

        _currentCell = cell;
        _currentCell.Select();
    }

    private void Update()
    {
        if (!_isInitialized)
            return;

        if (Input.GetMouseButtonDown(0))
        {
            _factoryBuildings.Create(_currentCell.WorldPosition);
        }
    }

    #endregion

    #region PublicMethods

    public void Initialize(FactoryBuildings factoryBuildings, GridManager gridManager)
    {
        _factoryBuildings = factoryBuildings;
        _gridManager = gridManager;

        _isInitialized = true;
    }

    #endregion
}
