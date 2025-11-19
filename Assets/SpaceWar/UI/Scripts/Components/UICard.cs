using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class UICard : MonoBehaviour
{
    #region Fields

    [SerializeField]
    private Image objectImage;

    [SerializeField]
    private Image selectFrameImage;

    [SerializeField]
    private TextMeshProUGUI coastText;

    private Button _button;

    #endregion

    #region Properties

    public CardDataSO Card { get; private set; }

    #endregion

    #region Events

    public event Action<UICard> OnClick;

    #endregion

    #region LifeCycle

    private void Awake()
    {
        _button = GetComponent<Button>();
        selectFrameImage.enabled = false;
    }

    private void OnEnable()
    {
        _button.onClick.AddListener(OnClickButtun);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(OnClickButtun);
    }

    #endregion

    #region PublicMethods

    public void Initialize(CardDataSO cardData)
    {
        Card = cardData;
        objectImage.sprite = Card.Sprite;
        coastText.text = Card.Coast.ToString();
    }

    public void Select()
    {
        selectFrameImage.enabled = true;
    }

    public void UnSelect()
    {
        selectFrameImage.enabled = false;
    }

    #endregion

    #region PrivateMethods

    private void OnClickButtun()
    {
        OnClick?.Invoke(this);
    }

    #endregion
}
