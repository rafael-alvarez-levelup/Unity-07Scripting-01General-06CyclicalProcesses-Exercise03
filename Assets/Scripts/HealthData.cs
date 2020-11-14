using UnityEngine;

[CreateAssetMenu(fileName = "HealthData", menuName = "Data/Health")]
public class HealthData : ScriptableObject
{
    public int Health { get { return health; } }

    [SerializeField] private int health;
}