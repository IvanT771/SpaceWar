using UnityEngine;

public class Cell
{
    #region Properties

    public int Index { get; private set; }
    public Vector3 WorldPosition { get; private set; }
    public float Size { get; private set; }
    public bool IsSelected { get; private set; }

    public bool IsEmpty => GridObject == null;

    public GridObject GridObject { get; private set; }

    #endregion

    #region Construct

    public Cell(int index, Vector3 position, float size)
    {
        Index = index;
        WorldPosition = position;
        Size = size;
    }

    #endregion

    #region PublicMethods

    public void Place(GridObject gridObject)
    {
        if (GridObject != null)
        {
            Debug.LogError("Ячейка занята!");
            return;
        }

        GridObject = gridObject;
    }

    public void Select()
    {
        IsSelected = true;
    }

    public void Deselect()
    {
        IsSelected = false;
    }

    public void DebugDrawGizmos()
    {
        Gizmos.color = IsSelected ? Color.green : Color.yellow;
        Gizmos.DrawCube(WorldPosition, new Vector3(Size * 0.95f, Size * 0.01f, Size * 0.95f));
    }

    #endregion
}
