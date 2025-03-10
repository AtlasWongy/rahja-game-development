using System;
using Godot;

namespace Rahja.Character.Player.Movement;

public partial class Movement: CharacterBody3D
{
    [Export] private Camera3D _camera;

    private Vector3 _rayOrigin = Vector3.Zero;
    private Vector3 _rayEnd = Vector3.Zero;

    public override void _PhysicsProcess(double delta)
    {
        var spaceState = GetWorld3D().DirectSpaceState;

        var mousePosition = GetViewport().GetMousePosition();

        _rayOrigin = _camera.ProjectRayOrigin(mousePosition);
        _rayEnd = _rayOrigin + _camera.ProjectRayNormal(mousePosition) * 2000;

        var query = PhysicsRayQueryParameters3D.Create(_rayOrigin, _rayEnd);
        var intersection = spaceState.IntersectRay(query);

        if (intersection == null) return;
        var pos = intersection["position"].AsVector3();
        LookAt(new Vector3(pos.X, Position.Y, pos.Z), Vector3.Up);
        RotateObjectLocal(Vector3.Up, (float) Math.PI);

        if (Input.IsActionPressed("movement"))
        {
            var targetPos = new Vector3(pos.X, 0, pos.Z);
            var currentPos = new Vector3(Position.X, 0, Position.Z);
            
            var direction = (targetPos - currentPos).Normalized();
            Velocity = Velocity.Lerp(direction * 1.0f, 0.5f);
            MoveAndSlide();
        }
    }
}