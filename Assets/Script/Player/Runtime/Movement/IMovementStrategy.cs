using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMovementStrategy
{
    void Update(Player player, Rigidbody2D rb, Vector2 input, bool jumpHeld, bool jumpPressed, float deltaTime);
}
