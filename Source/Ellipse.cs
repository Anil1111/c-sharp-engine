﻿using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpSlugsEngine {
    class Ellipse : Sprite {
        public Color color;
        public bool fill;

        public Ellipse(int x, int y, int w, int h, Color color, bool fill = true) {
            this.x = x;
            this.y = y;
            this.w = w;
            this.h = h;
            this.color = color;
            this.fill = fill;
            display = false;
            alive = true;
            angle = 0;
            xAnchor = yAnchor = 0;
        }

        public override void Draw(GraphicsManager graphics) {
            graphics.DrawEllipse(x, y, w, h, color, fill, angle, xAnchor, yAnchor);
        }
    }
}
