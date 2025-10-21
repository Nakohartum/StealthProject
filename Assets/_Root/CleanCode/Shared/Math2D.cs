using _Root.CleanCode.Shared.Ports;

namespace Shared._Root.CleanCode.Shared
{
    public static class Math2D
    {
        /// <summary>Returns true if target lies within a vision cone from origin along dir.</summary>
        public static bool InCone(in Vec2 origin, in Vec2 dir, in Vec2 target, float maxDistance, float halfAngleDeg)
        {
            var to = new Vec2(target.X - origin.X, target.Y - origin.Y);
            var d2 = to.SqrMagnitude;
            if (d2 > maxDistance * maxDistance) return false;

            var nDir = dir.Normalized;
            var nTo  = d2 > 1e-10f ? new Vec2(to.X, to.Y).Normalized : Vec2.Zero;

            var dot = Vec2.Dot(nDir, nTo);
            // Clamp to avoid NaN on acos
            if (dot > 1f) dot = 1f; else if (dot < -1f) dot = -1f;

            var angleRad = System.MathF.Acos(dot);
            var angleDeg = angleRad * (180f / System.MathF.PI);
            return angleDeg <= halfAngleDeg;
        }
    }
}