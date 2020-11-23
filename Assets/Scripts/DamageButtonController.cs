using UnityEngine;
using UnityEngine.EventSystems;

public class DamageButtonController : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private HealthBehaviour healthBehaviour;

    private readonly int damage = 10;

    public void OnPointerClick(PointerEventData eventData)
    {
        DealDamage(damage);
    }

    private void DealDamage(int damageAmount)
    {
        healthBehaviour.TakeDamage(damageAmount);
    }
}