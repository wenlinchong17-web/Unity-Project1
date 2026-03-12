using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMovement : IMovementStrategy
{
    
    public void Update(Player player, Rigidbody2D rb, Vector2 input, bool jumpHeld, bool jumpPressed, float deltaTime)
    {
        // 水平输入
       rb.velocity = new Vector2(input.x * player.MoveSpeed, rb.velocity.y);
        //土狼时间
        if (player.IsGrounded)
        {
            player.CoyoteTimer = player.CoyoteTime;
            player.CurrentJumpCount = 0;
        }else
        {
            player.CoyoteTimer -= deltaTime;
        }

        /*if (jumpPressed && player.IsGrounded)
        {
            player.Velocity.y = player.JumpForce;
            player.IsGrounded = false;
        }*/
        //跳跃缓冲
        if (jumpPressed)
        {
            player.JumpBufferTimer = player.JumpBufferTime;
        }
        else
        {
            player.JumpBufferTimer -= deltaTime;
        }

        //多段跳跃
        bool canJumpFromGround = player.CoyoteTimer > 0;
        bool canMultiJump = player.CurrentJumpCount < player.MaxJumpCount - 1;
        if (player.JumpBufferTimer > 0 && (canJumpFromGround || canMultiJump))
        {
           rb.velocity = new Vector2(rb.velocity.x, player.JumpForce);

            player.IsGrounded = false;
            player.JumpBufferTimer = 0;

            if (!canJumpFromGround)
                player.CurrentJumpCount++;
        }
        // 更新位置
        player.Position = rb.position;
        
    }
}
