using TMPro;
using UnityEngine;

public class UIBank : MonoBehaviour
{
    #region Fields

    [SerializeField]
    private TextMeshProUGUI valueText;

    #endregion

    #region LifeCycle

    private void Start()
    {
        valueText.text = GridWorld.Instance.Bank.Value.ToString();
    }

    private void OnEnable()
    {
        GridWorld.Instance.Bank.OnChanged += Bank_OnChanged;
    }

    private void OnDisable()
    {
        GridWorld.Instance.Bank.OnChanged -= Bank_OnChanged;
    }

    private void Bank_OnChanged(int value)
    {
        valueText.text = value.ToString();
    }

    #endregion

}
