using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu(fileName = "Enemy", menuName = "characters/enemy", order = 1)]
public class EnemyData : ScriptableObject
{
    [Header("Enemy statistics:")]
    public float detectionRadius;
    public float stoppingDistance;
    public float attackRange;
    public float maxHealth;
    [Header("Player data")]
    public LayerMask layerMask;
    public Transform playerTransform;
    public GameObject prefab;
}

