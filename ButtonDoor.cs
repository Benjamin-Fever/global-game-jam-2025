using Godot;
using System;


// ButtonDoor.cs - The door that's controlled by a button
public partial class ButtonDoor : Door
{
    [Export]
    public bool StartsLocked { get; set; } = true;
    
    private StaticBody2D staticBody;
    private Sprite2D sprite;

    public override void _Ready()
    {
        sprite = GetNode<Sprite2D>("Sprite2D");
        staticBody = GetNode<StaticBody2D>("StaticBody2D");
        SetDoorState(StartsLocked);
    }

    public void SetDoorState(bool locked)
    {
        staticBody.GetNode<CollisionShape2D>("CollisionShape2D").SetDeferred("disabled", !locked);
        sprite.Visible = locked;
    }
}