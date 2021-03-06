﻿using System;
using System.Collections;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpSlugsEngine {
    public class SpriteList {
        //Leaving dictionary public so stuff can be done direclty in the code itself;
        public Dictionary<string, Sprite> sprites = new Dictionary<string, Sprite>();
        private GraphicsManager Graphics;
        private Physics.MovementManager movement = new Physics.MovementManager();

        public SpriteList(GraphicsManager Graphics) {
            this.Graphics = Graphics;
        }

        public void Update() {
            movement.updateSprites(ref sprites);
            foreach (KeyValuePair<string, Sprite> obj in sprites) {
                if (obj.Value.alive) {
                    obj.Value.Update();
                }
            }
        }

        public void Draw() {
            foreach (KeyValuePair<string, Sprite> obj in sprites) {
                if (obj.Value.disp && obj.Value.alive) {
                    obj.Value.Draw(Graphics);
                }
            }
        }

        public void add(string key, Sprite sprite) {
            sprites.Add(key, sprite);
        }

        //Each of these simply links to the corresponding function in the Sprite class, where they are located to
        //allow a sprite to use the functions on itself, and for possible future use in a possible, but very
        //unlikely implementation.

        /// <summary>
        /// Change whether or not to display the sprite
        /// </summary>
        /// <param name="key">The name of the sprite to edit</param>
        /// <param name="disp">true to display, false to not display.</param>
        public void display(string key, bool disp) {
            sprites[key].display(disp);
        }

        /// <summary>
        /// Move the sprite x and y pixels
        /// </summary>
        /// <param name="key">The name of the sprite to move</param>
        /// <param name="x">How much to change the x value by. A negative value moves the sprite to the left.</param>
        /// <param name="y">How much to change the y value by. A negative value moves the sprite up.</param>
        public void move(string key, int x, int y) {
            this.sprites[key].move(x, y);
        }

        public void moveto(string key, int x, int y)
        {
            this.sprites[key].moveto(x, y);
        }

        public void moveX(string key, int x) {
            this.sprites[key].moveX(x);
        }

        public void moveY(string key, int y) {
            this.sprites[key].moveY(y);
        }

        /// <summary>
        /// Sets the sprite rotation to r
        /// </summary>
        /// <param name="key">Sprite to edit</param>
        /// <param name="r">How many degrees to rotate the sprite by.</param>
        public void setRotation(string key, float r) {
            this.sprites[key].setRotation(r);
        }

        /// <summary>
        /// Rotate the sprite by r (degrees or radians?)
        /// </summary>
        /// <param name="key">Sprite to edit</param>
        /// <param name="r">How many degrees to rotate the sprite by.</param>
        public void rotate(string key, float r) {
            this.sprites[key].rotate(r);
        }

        /// <summary>
        /// Scale the x value of the sprite
        /// </summary>
        /// <param name="key">Sprite to edit</param>
        /// <param name="scale">How much to scale it by(decimal to make it smaller)</param>
        public void scaleX(string key, double scale) {
            sprites[key].scaleX(scale);
        }

        /// <summary>
        /// Scale the Y value of the sprite
        /// </summary>
        /// <param name="key">Sprite to edit</param>
        /// <param name="scale">How much to scale it by(decimal to make it smaller)</param>
        public void scaleY(string key, double scale) {
            sprites[key].scaleY(scale);
        }

        public Vector2 getSize(string key) {
            return new Vector2(sprites[key].w, sprites[key].h);
        }

        /// <summary>
        /// Scale entire sprite
        /// </summary>
        /// <param name="key">Sprite to edit</param>
        /// <param name="scale">How much to scale it by(decimal to make it smaller)</param>
        public void scale(string key, double scale) {
            sprites[key].scale(scale);
        }

        public void setAnchor(string key, double anchor) {
            sprites[key].setAnchor(anchor);
        }

        public void setAnchorX(string key, double anchor) {
            sprites[key].setAnchorX(anchor);
        }

        public void setAnchorY(string key, double anchor) {
            sprites[key].setAnchorY(anchor);
        }

        public void kill(string key) {
            sprites[key].kill();
        }

        public void reincarnate(string key) {
            sprites[key].reincarnate();
        }

        public void setVelocityX(string key, int x) {
            sprites[key].setVelocityX(x);
        }
        
        public void setVelocityY(string key, int y) {
            sprites[key].setVelocityY(y);
        }

        public void setGravityX(string key, int x) {
            sprites[key].setGravityX(x);
        }

        public void setGravityY(string key, int y) {
            sprites[key].setGravityY(y);
        }

        public void setCollider(string key, Physics.Collider collider) {
            sprites[key].setCollider(collider);
        }

        public void addCollision(string key, string other) {
            sprites[key].addCollision(other);
        }
    }
}
