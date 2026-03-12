using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownFacing : IFacingStrategy
{
    public void UpdateFacing(Player player, Vector2 input, float deltaTime)
    {
        if (!player.AllowFacingUpdate) return;
        if(input==Vector2.zero) return;
       
        // 计算目标角度
        float targetAngle = Mathf.Atan2(input.y, input.x) * Mathf.Rad2Deg;

        player.TargetFacingAngle = targetAngle;

        // 平滑旋转
        player.FacingAngle = Mathf.MoveTowardsAngle(
            player.FacingAngle,
            player.TargetFacingAngle,
            player.RotationSpeed * deltaTime
        );
    }

    public void ForceFaceTarget(Player player, Vector2 targetPosition)
    {
        Vector2 dir = targetPosition - player.Position;

        float targetAngle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;

        player.TargetFacingAngle = targetAngle;
    }
}

