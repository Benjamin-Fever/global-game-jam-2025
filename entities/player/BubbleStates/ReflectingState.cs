using Godot;
using System;

public partial class ReflectingState : State {
    private Node2D reflectingBubble;
    private const float bubbleDuration = 1f;
    private const float CooldownDuration = 1f;
    private float elapsedTime = 0;
    public bool IsActive { get; private set; } = false;
    public bool IsOnCooldown { get; private set; } = false;

    public override void Enter() {

        var character = GetParent<StateMachine>().GetParent<CharacterBody2D>();
        reflectingBubble = character.GetNode<Node2D>("ReflectingBubble");

        if (IsOnCooldown) {
            ChangeState("DefaultState");
            return;
        }

        reflectingBubble.Visible = true;
        elapsedTime = 0;
        IsActive = true;
        IsOnCooldown = true;
    }

    public override void Update(double delta) {
        elapsedTime += (float)delta;

        //hide bubble
        if (elapsedTime >= bubbleDuration) {
            reflectingBubble.Visible = false;
            IsActive = false; // No longer active
        }

        if (elapsedTime >= bubbleDuration) {
            ChangeState("DefaultState");
        }
    }

    public override void Exit() {

        if (reflectingBubble != null) {
            reflectingBubble.Visible = false;
        }

        IsActive = false; //turn off active

        //cooldown timer
        GetTree().CreateTimer(CooldownDuration).Connect("timeout", Callable.From(ResetCooldown));
    }

    private void ResetCooldown() {
        IsOnCooldown = false;
    }
}
