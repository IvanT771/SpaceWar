using UnityEngine;

public class GridManager : MonoBehaviour
{
    #region Fields

    [SerializeField]
    private Vector3 gridOrigin = Vector3.zero;

    private Plane _gridPlane;
    private Camera _camera;

    #endregion

    #region Properties

    [field: SerializeField]
    public Vector2Int GridSize { get; private set; } = new Vector2Int(9, 5);

    [field: SerializeField]
    public float CellSize { get; private set; } = 1;

    public Cell[] Cells { get; private set; }

    #endregion

    #region LifeCycle

    private void Awake()
    {
        _camera = Camera.main;
        Initialize();
    }

    private void OnValidate()
    {
        Initialize();
    }

    #endregion

    #region PublicMethods

    public bool TryGetCellByWorldPosition(Vector3 worldPosition, out Cell cell)
    {
        cell = null;

        int x = Mathf.FloorToInt((worldPosition.x - gridOrigin.x) / CellSize);
        int y = Mathf.FloorToInt((worldPosition.z - gridOrigin.z) / CellSize);

        if (x < 0 || y < 0)
            return false;

        if (x >= GridSize.x)
            return false;

        if (y >= GridSize.y)
            return false;

        var index = GetLineIndex(x, y);

        if (index < 0)
            return false;

        if (index >= Cells.Length)
            return false;

        cell = Cells[index];
        return true;
    }

    public bool TryGetCellByMousePosition(Vector3 mousePosition, out Cell cell)
    {
        cell = null;
        var ray = _camera.ScreenPointToRay(mousePosition);

        if (_gridPlane.Raycast(ray, out var enter))
        {
            var point = ray.GetPoint(enter);
            return TryGetCellByWorldPosition(point, out cell);
        }

        return false;
    }

    #endregion

    #region PrivateMethods

    [ContextMenu("Initialize Grid")]
    private void Initialize()
    {
        Cells = new Cell[GridSize.x * GridSize.y];
        Vector3 offset = Vector3.zero;
        offset.y = gridOrigin.y;

        for (int x = 0; x < GridSize.x; x++)
        {
            for (int y = 0; y < GridSize.y; y++)
            {
                offset.x = gridOrigin.x + (x * CellSize) + (CellSize / 2);
                offset.z = gridOrigin.z + (y * CellSize) + (CellSize / 2);

                var index = GetLineIndex(x, y);
                var cell = new Cell(index, offset, CellSize);

                Cells[index] = cell;
            }
        }

        _gridPlane = new Plane(Vector3.up, gridOrigin);
    }

    private int GetLineIndex(int x, int y)
    {
        return (x * GridSize.y) + y;
    }

    #endregion

    #region Debug

    private void OnDrawGizmos()
    {
        if (Cells == null)
            return;

        if (Cells.Length <= 0)
            return;

        for (int i = 0; i < Cells.Length; i++)
        {
            var cell = Cells[i];
            cell.DebugDrawGizmos();
        }
    }

    #endregion
}
