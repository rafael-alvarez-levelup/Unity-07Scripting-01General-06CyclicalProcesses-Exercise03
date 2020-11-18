using System.Collections;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    #region Events

    public delegate void HealthChangedEventHandler(int value);
    public static event HealthChangedEventHandler OnHealthChanged;

    #endregion

    #region Private Fields

    [SerializeField] private HealthDataSO healthData;

    private int currentHealth;

    #endregion

    #region Unity Methods

    private void Awake()
    {
        currentHealth = healthData.Health;
    }

    private void OnEnable()
    {
        DamageButton.OnClicked += TakeDamage;
    }

    private void Start()
    {
        StartCoroutine(RegenerationRoutine());
    }

    private void OnDisable()
    {
        DamageButton.OnClicked -= TakeDamage;
    }

    #endregion

    #region Private Methods

    private void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount;

        if (currentHealth <= 0)
        {
            currentHealth = 0;

            DamageButton.OnClicked -= TakeDamage;
        }

        if (OnHealthChanged != null)
        {
            OnHealthChanged(currentHealth);
        }
    }

    private IEnumerator RegenerationRoutine()
    {
        // Does this allocate and deallocate memory each iteration?
        WaitForSeconds delay = new WaitForSeconds(1f);

        yield return new WaitUntil(() => currentHealth < healthData.Health);

        currentHealth++;

        OnHealthChanged(currentHealth);

        yield return delay;

        if (currentHealth != 0)
        {
            StartCoroutine(RegenerationRoutine());
        }
    }

    #endregion
}