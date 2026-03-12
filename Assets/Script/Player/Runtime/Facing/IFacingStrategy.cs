using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IFacingStrategy
{
    void UpdateFacing(Player player, Vector2 input, float deltaTime);
    void ForceFaceTarget(Player player, Vector2 targetPosition);
}