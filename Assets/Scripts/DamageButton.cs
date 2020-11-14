using UnityEngine;
using UnityEngine.EventSystems;

public class DamageButton : MonoBehaviour, IPointerClickHandler
{
    public delegate void ButtonClickedEventHandler(int value);
    public static event ButtonClickedEventHandler OnClicked;

    private readonly int damage = 10;

    public void OnPointerClick(PointerEventData eventData)
    {
        if (OnClicked != null)
        {
            OnClicked(damage);
        }
    }
}