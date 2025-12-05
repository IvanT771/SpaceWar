using UnityEngine;

public class SunPanel : GridObject
{
    #region Fields

    [SerializeField]
    private SunAnimator sunAnimator;

    #endregion

    #region LifeCycle

    private void Start()
    {
        sunAnimator.OpenPanel();
    }

    [ContextMenu("Close")]
    public void Close()
    {
        sunAnimator.ClosePanel();
    }

    #endregion
}
