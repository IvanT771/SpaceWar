using UnityEngine;

public class PlaceableSystem : MonoBehaviour
{
    #region Fields

    private GridManager _gridManager;
    private FactoryBuildings _factoryBuildings;
    private Bank _bank;

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
            if (_currentCell == null)
                return;

            var view = ViewsManager.GetView<UIGameplayView>();
            var selectedCard = view.GetSelectedCard();

            if (selectedCard == null)
                return;

            if (!_currentCell.IsEmpty)
                return;

            if (!_bank.TryBuy(selectedCard.Coast))
                return;

            view.UnselectCard();

            var gridObject = _factoryBuildings.Create(selectedCard, _currentCell.WorldPosition);
            _currentCell.Place(gridObject);
        }
    }

    #endregion

    #region PublicMethods

    public void Initialize(FactoryBuildings factoryBuildings, GridManager gridManager, Bank bank)
    {
        _factoryBuildings = factoryBuildings;
        _gridManager = gridManager;
        _bank = bank;

        _isInitialized = true;
    }

    #endregion
}