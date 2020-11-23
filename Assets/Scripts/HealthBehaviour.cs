using System.Collections;
using UnityEngine;

public class HealthBehaviour : MonoBehaviour
{
    #region Events

    public delegate void HealthChangedEventHandler(int value);
    public static event HealthChangedEventHandler OnChanged;

    #endregion

    #region Private Fields

    [SerializeField] private HealthDataSO healthData;

    private int currentHealth;
    private WaitForSeconds delay;
    private WaitUntil isDamagedDelay;

    #endregion

    #region Unity Methods

    private void Awake()
    {
        currentHealth = healthData.Health;
    }

    private void Start()
    {
        delay = new WaitForSeconds(1f);
        isDamagedDelay = new WaitUntil(() => currentHealth < healthData.Health);

        StartCoroutine(RegenerationRoutine());
    }

    #endregion

    #region Private Methods

    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount;

        if (currentHealth <= 0)
        {
            currentHealth = 0;
        }

        HealthChanged();
    }

    private void HealthChanged()
    {
        if (OnChanged != null)
        {
            OnChanged(currentHealth);
        }
    }

    private IEnumerator RegenerationRoutine()
    {
        yield return isDamagedDelay;

        currentHealth++;

        HealthChanged();

        yield return delay;

        if (currentHealth != 0)
        {
            StartCoroutine(RegenerationRoutine());
        }
    }

    #endregion
}