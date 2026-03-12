using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformFacing : IFacingStrategy
{
    public void UpdateFacing(Player player, Vector2 input, float deltaTime)
    {
        if (!player.AllowFacingUpdate)
            return;

        if (input.x == 0)
            return;

        player.IsFacingRight = input.x > 0;
    }


    public void ForceFaceTarget(Player player, Vector2 targetPosition)
    {
        player.IsFacingRight = targetPosition.x > player.Position.x;
    }

}