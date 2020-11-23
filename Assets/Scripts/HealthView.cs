using UnityEngine;
using UnityEngine.UI;

public class HealthView : MonoBehaviour
{
    #region Private Fields

    [SerializeField] private HealthDataSO healthData;

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
        HealthBehaviour.OnChanged += UpdateLifeAmount;
    }

    private void OnDisable()
    {
        HealthBehaviour.OnChanged -= UpdateLifeAmount;
    }

    #endregion

    #region Private Methods

    private void UpdateLifeAmount(int currentLifeAmount)
    {
        lifeAmount.text = currentLifeAmount.ToString();
    }

    #endregion
}