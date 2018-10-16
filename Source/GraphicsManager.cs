﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
namespace SharpSlugsEngine
{
    public class GraphicsManager
    {
        SolidBrush myBrush;
        Pen myPen;
        Graphics formGraphics;

        Bitmap myMap;
        Graphics bitmapGraphics;

        private readonly Game game;
        private readonly Platform platform;

        internal GraphicsManager(Game game, Platform platform)
        {
            this.game = game;
            this.platform = platform;

            myBrush = new SolidBrush(Color.Red);
            myPen = new Pen(myBrush);

            formGraphics = platform.form.CreateGraphics();
        }

        internal void Begin()
        {
            myMap = new Bitmap(platform.form.Width, platform.form.Height, formGraphics);
            bitmapGraphics = Graphics.FromImage(myMap);
        }

        internal void End()
        {
            formGraphics.DrawImage(myMap, 0, 0);
            myMap.Dispose();
            bitmapGraphics.Dispose();
        }

        public void DrawRectangle(Rectangle rect, Color color, bool fill = true)
        {
            myBrush.Color = color;

            if (fill)
                bitmapGraphics.FillRectangle(myBrush, rect);
            else
                bitmapGraphics.DrawRectangle(myPen, rect);
        }

        public void DrawRectangle(int x, int y, int w, int h, Color color)
            => DrawRectangle(new Rectangle(x, y, w, h), color);

        public void DrawLine(int a, int b, int x, int y, Color color)
        {
            myBrush.Color = color;
            bitmapGraphics.DrawLine(myPen, a, b, x, y);
        }

        public void DrawLine(Vector2 p1, Vector2 p2, Color color)
            => DrawLine(p1.X, p1.Y, p2.X, p2.Y, color);

        public void DrawCircle(int x, int y, int r, Color color, bool fill = true)
        {
            myBrush.Color = color;
            if (fill)
                bitmapGraphics.FillEllipse(myBrush, x - r, y - r, 2 * r, 2 * r);
            else
                bitmapGraphics.DrawEllipse(myPen, x - r, y - r, 2 * r, 2 * r);
        }

        public void DrawCircle(Vector2 p, int r, Color color, bool fill = true)
            => DrawCircle(p.X, p.Y, r, color, fill);
    }
}
