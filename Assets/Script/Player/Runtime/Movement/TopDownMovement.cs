using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownMovement : IMovementStrategy
{
    public void Update(Player player, Rigidbody2D rb, Vector2 input, bool jumpHeld, bool jumpPressed, float deltaTime)
    {
       player.Velocity = input.normalized * player.MoveSpeed;
       player.Position += player.Velocity * deltaTime;
       rb.position = player.Position;
    }
}
