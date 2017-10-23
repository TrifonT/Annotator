using Annotator;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;

namespace Annotator
{
    internal enum AnchorType
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

    internal class DragRectangle
    {
        private const int HandleSize = 7;

        private static AnchorType[] Ancors =  { AnchorType.TopLeft, AnchorType.TopCenter, AnchorType.TopRight, AnchorType.MiddleRight,
                                      AnchorType.BottomRight, AnchorType.BottomCenter, AnchorType.BottomLeft, AnchorType.MiddleLeft};

        private Rectangle GetRectangle(int x, int y)
        {
            return new Rectangle(x - HandleSize / 2, y - HandleSize / 2, HandleSize, HandleSize);
        }

        private Rectangle GetRectangle(AnchorType type)
        {
            switch (type)
            {
                case AnchorType.None:
                    return new Rectangle();

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
                    return new Rectangle();
            }
        }

        public int X { get; set; }
        public int Y { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }

        public DragRectangle(int x, int y, int width, int height, bool active)
        {
            this.X = x;
            this.Y = y;
            this.Width = width;
            this.Height = height;
            this.Active = false;
        }

        public DragRectangle(int x, int y, int width, int height) : this(x, y, width, height, false)
        { }

        public DragRectangle() : this(0, 0, 0, 0, false)
        { }

        public bool IsEmpty()
        {
            return (X == 0 && Y == 0 && Width == 0 && Height == 0);
        }

        public bool Active { get; set; }

        public Rectangle ToRectangle()
        {
            return new Rectangle(X, Y, Width, Height);
        }

        private bool Contains(Point p)
        {
            return (p.X >= X && p.X < X + Width && p.Y >= Y && p.Y < Y + Height);
        }

        private AnchorType GetHitAncor(Point p)
        {
            foreach (AnchorType ancor in Ancors)
            {
                Rectangle rec = GetRectangle(ancor);
                if (rec.Contains(p))
                    return ancor;
            }
            return AnchorType.None;
        }

        public void Draw(Graphics g, Color color)
        {
            Pen pen = new Pen(color);
            g.DrawRectangle(pen, ToRectangle());
            if (Active)
                DrawAllAncors(g, pen);
        }

        private void DrawAllAncors(Graphics g, Pen pen)
        {
            foreach (var ancor in Ancors)
            {
                Rectangle rect = GetRectangle(ancor);
                g.DrawRectangle(pen, rect);
            }
        }
    }
}