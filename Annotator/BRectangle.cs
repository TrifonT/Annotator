using System;
using System.Drawing;
using System.Windows.Forms;

namespace Annotator
{
    public enum AnchorType
    {
        None,
        TopLeft,
        TopCenter,
        TopRight,
        MiddleLeft,
        MiddleRight,
        BottomLeft,
        BottomCenter,
        BottomRight
    }

    public class BRectangle
    {
        private const float HandleSize = 7;

        private static AnchorType[] Anchors =  { AnchorType.TopLeft, AnchorType.TopCenter, AnchorType.TopRight, AnchorType.MiddleRight,
                                      AnchorType.BottomRight, AnchorType.BottomCenter, AnchorType.BottomLeft, AnchorType.MiddleLeft};

        private BRectangle GetRectangle(float x, float y)
        {
            return new BRectangle(x - HandleSize / 2, y - HandleSize / 2, HandleSize, HandleSize);
        }

        private BRectangle GetRectangle(AnchorType type)
        {
            switch (type)
            {
                case AnchorType.None:
                    return new BRectangle();

                case AnchorType.TopLeft:
                    return GetRectangle(X, Y);

                case AnchorType.TopCenter:
                    return GetRectangle(X + Width / 2, Y);

                case AnchorType.TopRight:
                    return GetRectangle(X + Width, Y);

                case AnchorType.MiddleRight:
                    return GetRectangle(X + Width, Y + Height / 2);

                case AnchorType.BottomRight:
                    return GetRectangle(X + Width, Y + Height);

                case AnchorType.BottomCenter:
                    return GetRectangle(X + Width / 2, Y + Height);

                case AnchorType.BottomLeft:
                    return GetRectangle(X, Y + Height);

                case AnchorType.MiddleLeft:
                    return GetRectangle(X, Y + Height / 2);

                default:
                    return new BRectangle();
            }
        }

        public static Cursor GetCursor(AnchorType anchor)
        {
            switch (anchor)
            {
                case AnchorType.TopLeft:
                    return Cursors.SizeNWSE;

                case AnchorType.MiddleLeft:
                    return Cursors.SizeWE;

                case AnchorType.BottomLeft:
                    return Cursors.SizeNESW;

                case AnchorType.BottomCenter:
                    return Cursors.SizeNS;

                case AnchorType.TopRight:
                    return Cursors.SizeNESW;

                case AnchorType.BottomRight:
                    return Cursors.SizeNWSE;

                case AnchorType.MiddleRight:
                    return Cursors.SizeWE;

                case AnchorType.TopCenter:
                    return Cursors.SizeNS;

                default:
                    return Cursors.Default;
            }
        }

        public float X { get; set; }
        public float Y { get; set; }
        public float Width { get; set; }
        public float Height { get; set; }

        public BRectangle(float x, float y, float width, float height)
        {
            this.X = x;
            this.Y = y;
            this.Width = width;
            this.Height = height;
        }

        public BRectangle() : this(0f, 0f, 0f, 0f)
        { }

        public bool IsEmpty()
        {
            return (X == 0f && Y == 0f && Width == 0f && Height == 0f);
        }

        public RectangleF ToRectangleF()
        {
            return new RectangleF(X, Y, Width, Height);
        }

        public Rectangle ToRectangle()
        {
            return new Rectangle(Convert.ToInt32(X), Convert.ToInt32(Y), Convert.ToInt32(Width), Convert.ToInt32(Height));
        }

        public bool Contains(PointF p)
        {
            return (p.X >= X && p.X < X + Width && p.Y >= Y && p.Y < Y + Height);
        }

        public bool Contains(Point p)
        {
            return (p.X >= X && p.X < X + Width && p.Y >= Y && p.Y < Y + Height);
        }

        public bool Contains(int x, int y)
        {
            return (x >= X && x < X + Width && y >= Y && y < Y + Height);
        }

        public AnchorType GetHitAnchor(int x, int y)
        {
            foreach (AnchorType ancor in Anchors)
            {
                BRectangle rec = GetRectangle(ancor);
                if (rec.Contains(x, y))
                    return ancor;
            }
            return AnchorType.None;
        }

        public void Draw(Graphics g, Color color, bool active)
        {
            Pen pen = new Pen(color);
            g.DrawRectangle(pen, ToRectangle());
            if (active)
                DrawAllAnchors(g, pen);
        }

        private void DrawAllAnchors(Graphics g, Pen pen)
        {
            foreach (var ancor in Anchors)
            {
                BRectangle rect = GetRectangle(ancor);
                g.DrawRectangle(pen, rect.ToRectangle());
            }
        }
    }
}