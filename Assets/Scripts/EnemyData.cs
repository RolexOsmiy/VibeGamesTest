using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Character", menuName = "Character Data", order = 1)]
public class CharacterData : ScriptableObject
{
    [SerializeField] private string characterName;
    public float attackRange;
    public float attackTime;
    public int maxHealth;
}
