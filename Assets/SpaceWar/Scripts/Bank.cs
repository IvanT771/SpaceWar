using System;

public class Bank
{
    #region Fields

    private int _value = 0;

    #endregion

    #region Properties

    public int Value
    {
        get { return _value; }
        set
        {

            _value = value;
            OnChanged?.Invoke(_value);
        }
    }

    #endregion

    #region Events

    public event Action<int> OnChanged;

    #endregion

    #region Construct

    public Bank(int startValue)
    {
        Value = startValue;
    }

    #endregion

    #region PublicMethods

    public bool TryBuy(int price)
    {
        if (Value < price)
            return false;

        Value -= price;
        return true;
    }

    public void Add(int value)
    {
        Value += value;
    }

    #endregion
}
