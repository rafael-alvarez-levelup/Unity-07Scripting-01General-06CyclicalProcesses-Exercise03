using UnityEngine;
using UnityEngine.UI;

public class LifeValue : MonoBehaviour
{
    #region Private Fields

    [SerializeField] private HealthData healthData;

    private Text lifeAmount;
    private int health;

    #endregion

    #region Unity Methods

    private void Awake()
    {
        lifeAmount = GetComponent<Text>();

        health = healthData.Health;
        UpdateLifeAmount(health);
    }

    private void OnEnable()
    {
        HealthSystem.OnHealthChanged += UpdateLifeAmount;
    }

    private void OnDisable()
    {
        HealthSystem.OnHealthChanged -= UpdateLifeAmount;
    }

    #endregion

    #region Private Methods

    private void UpdateLifeAmount(int currentLifeAmount)
    {
        lifeAmount.text = currentLifeAmount.ToString();
    }

    #endregion
}