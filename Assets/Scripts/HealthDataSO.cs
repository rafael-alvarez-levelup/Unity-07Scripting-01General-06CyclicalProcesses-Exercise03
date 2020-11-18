using UnityEngine;

[CreateAssetMenu(fileName = "NewHealthData", menuName = "ScriptableObject/HealthData")]
public class HealthDataSO : ScriptableObject
{
    public int Health { get { return health; } }

    [SerializeField] private int health;
}