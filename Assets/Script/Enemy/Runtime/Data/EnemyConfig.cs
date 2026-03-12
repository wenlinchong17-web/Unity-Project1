using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Enemy.Runtime.Data
{
    using UnityEngine;
    using Shared.Data;

    [CreateAssetMenu(menuName = "Enemy/Enemy Config")]
    public class EnemyConfig : ScriptableObject
    {
        [Header("基础属性")]
        public float MaxHP = 100f;
        public float MoveSpeed = 8f;
        public float AttackRange = 1.5f;
        public AttackData Attack;
        public float AttackCoolDown = 1f;
        public TeamType Team = TeamType.Enemy;
        [Header("AI 设置")]
        public float LoseTargetRange = 7f;//丢失索敌范围要比发现范围宽一些
        public float PatrolRadius = 3f;//巡逻范围
        public float ChaseRange = 6f;//发现范围
    }
}