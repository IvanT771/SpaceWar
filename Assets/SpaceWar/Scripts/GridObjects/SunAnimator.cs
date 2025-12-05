using UnityEngine;

[RequireComponent(typeof(Animator))]
public class SunAnimator : MonoBehaviour
{
    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void ClosePanel()
    {
        _animator.SetBool("IsRotation", false);
        _animator.SetBool("IsOpen", false);
    }

    public void OpenPanel()
    {
        _animator.SetBool("IsOpen", true);
    }

    public void OpenFinish()
    {
        Debug.Log("Панель активирована!");
        _animator.SetBool("IsRotation", true);
    }
}
