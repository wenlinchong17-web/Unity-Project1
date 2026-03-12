using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementSystem
{
    private IMovementStrategy strategy;

    public MovementSystem(IMovementStrategy initialStrategy)
    {
        strategy = initialStrategy;
    }

    public void SetStrategy(IMovementStrategy newStrategy)
    {
        strategy = newStrategy;
    }

    public void Update(Player player, Rigidbody2D rb, Vector2 input, bool jumpHeld, bool jumpPressed, float deltaTime)
    {
        strategy.Update(player, rb, input, jumpHeld, jumpPressed, deltaTime);
    }
}
