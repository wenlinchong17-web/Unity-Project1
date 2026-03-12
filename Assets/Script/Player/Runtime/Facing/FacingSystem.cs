using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FacingSystem 
{
    private IFacingStrategy strategy;

    public FacingSystem(IFacingStrategy initialStrategy)
    {
        strategy = initialStrategy;
    }

    public void SetStrategy(IFacingStrategy newStrategy)
    {
        strategy = newStrategy;
    }

    public void UpdateFacing(Player player, Vector2 input, float deltaTime)
    {
        strategy.UpdateFacing(player, input, deltaTime);
    }

    public void ForceFaceTarget(Player player, Vector2 targetPosition)
    {
        strategy.ForceFaceTarget(player, targetPosition);
    }
}
