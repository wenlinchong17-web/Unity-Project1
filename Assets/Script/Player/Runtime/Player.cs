using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player 
{
    public Vector2 Position;
    public Vector2 Velocity;

    public float MoveSpeed = 8f;
    public float JumpForce = 16f;

    public bool IsGrounded = true;
    //跳跃状态
    //土狼时间
    public float CoyoteTime = 0.1f;
    public float CoyoteTimer = 0f;
    //跳跃缓冲
    public float JumpBufferTime = 0.1f;
    public float JumpBufferTimer = 0f;
    //多段跳跃
    public int MaxJumpCount = 2;
    public int CurrentJumpCount = 0;


    // 当前真实朝向角度
    public float FacingAngle = 0f;

    // 目标朝向角度（用于平滑插值）
    public float TargetFacingAngle = 0f;

    // 旋转速度（越大越快）
    public float RotationSpeed = 720f; // 每秒旋转720度
    //平台模式用
    public bool IsFacingRight = false;
    public bool AllowFacingUpdate = true;
}
