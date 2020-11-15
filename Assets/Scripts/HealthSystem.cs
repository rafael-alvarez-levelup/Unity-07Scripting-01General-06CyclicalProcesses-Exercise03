using System.Collections;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    #region Events

    public delegate void HealthChangedEventHandler(int value);
    public static event HealthChangedEventHandler OnHealthChanged;

    #endregion

    #region Private Fields

    [SerializeField] private HealthData healthData;

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
        // Question: is it better to make this a field? It won't change at runtime so it is useless to reassing it after every call to Regeneration Routine.
        WaitForSeconds delay = new WaitForSeconds(1f);

        yield return new WaitUntil(() => currentHealth < healthData.Health);

        currentHealth++;

        OnHealthChanged(currentHealth);

        yield return delay;

        Coroutine regenerationRoutine = StartCoroutine(RegenerationRoutine());

        if (currentHealth == 0)
        {
            StopCoroutine(regenerationRoutine);
        }
    }

    #endregion
}