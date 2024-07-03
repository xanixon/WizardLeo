using UnityEngine;

public abstract class UIScreen : MonoBehaviour
{
    public void Show(bool state = true)
    {
        gameObject.SetActive(state);
    }
}
