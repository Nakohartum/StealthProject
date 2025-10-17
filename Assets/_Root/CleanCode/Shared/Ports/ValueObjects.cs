namespace _Root.CleanCode.Shared.Ports
{
    public readonly struct Vec2
    {
        public readonly float X;
        public readonly float Y;

        public Vec2(float x, float y) { X = x; Y = y; }

        public static readonly Vec2 Zero = new Vec2(0f, 0f);

        public float SqrMagnitude => X * X + Y * Y;

        public Vec2 Normalized
        {
            get
            {
                var m2 = SqrMagnitude;
                if (m2 <= 1e-10f) return Zero;
                var inv = 1f / System.MathF.Sqrt(m2);
                return new Vec2(X * inv, Y * inv);
            }
        }

        public static Vec2 operator +(Vec2 a, Vec2 b) => new Vec2(a.X + b.X, a.Y + b.Y);
        public static Vec2 operator -(Vec2 a, Vec2 b) => new Vec2(a.X - b.X, a.Y - b.Y);
        public static Vec2 operator *(Vec2 a, float d) => new Vec2(a.X * d, a.Y * d);
        public static float Dot(in Vec2 a, in Vec2 b) => a.X * b.X + a.Y * b.Y;
    }
    
    public readonly struct Rect2
    {
        public readonly float X;
        public readonly float Y;
        public readonly float Width;
        public readonly float Height;

        public Rect2(float x, float y, float width, float height)
        {
            X = x; Y = y; Width = width; Height = height;
        }

        public float XMin => X;
        public float YMin => Y;
        public float XMax => X + Width;
        public float YMax => Y + Height;

        public bool Contains(in Vec2 p) =>
            p.X >= XMin && p.X <= XMax && p.Y >= YMin && p.Y <= YMax;
    }
    
}