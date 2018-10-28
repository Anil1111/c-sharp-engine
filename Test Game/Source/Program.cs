﻿using System;
using System.IO;
using SharpSlugsEngine;
using System.Drawing;

namespace Test_Game
{
    static class Program
    {
        static void Main()
        {
            TestGame test =  new TestGame();
            test.Resolution = new Vector2(1920, 1080);
            test.Run();
        }
    }

    class TestGame : Game
    {
        int i;
        
        protected override void Initialize()
        {
            TargetFramerate = 1;
            
            Controllers.ControllerAdded += (newController) =>
            {
                Console.WriteLine("New 360 controller added");

                newController.Disconnected += () => Console.WriteLine("Controller Disconnected");
                newController.Connected += () => Console.WriteLine("Controller Connected");

                newController.APressed += () => Console.WriteLine("A Pressed");
                newController.BPressed += () => Console.WriteLine("B Pressed");
                newController.XPressed += () => Console.WriteLine("X Pressed");
                newController.YPressed += () => Console.WriteLine("Y Pressed");
                newController.LBPressed += () => Console.WriteLine("LB Pressed");
                newController.RBPressed += () => Console.WriteLine("RB Pressed");
                newController.BackPressed += () => Console.WriteLine("Back Pressed");
                newController.StartPressed += () => Console.WriteLine("Start Pressed");
                newController.DPadUpPressed += () => Console.WriteLine("DPadUp Pressed");
                newController.DPadDownPressed += () => Console.WriteLine("DPadDown Pressed");
                newController.DPadLeftPressed += () => Console.WriteLine("DPadLeft Pressed");
                newController.DPadRightPressed += () => Console.WriteLine("DPadRight Pressed");
            };
        }
        
        protected override void LoadContent() {
            ContentManager manager = new ContentManager();
            Bitmap [] bmp = manager.SplitImage(@"..\..\Content\test.bmp", 4, "test_bmp");
            Bitmap[] scaled = manager.ScaleImage(bmp, 4);
            manager.printNames();
            sprites.add("rect1", new Rect(400, 400, 100, 100, Color.Black));
            sprites.display("rect1", true);

            i = 0;
        }
        protected override void Update(GameTime gameTime)
        {
            Resolution = new Vector2(1280, 720);
            //Console.WriteLine("Update");
            
        }

        protected override void Draw(GameTime gameTime)
        {
            //Console.WriteLine("Draw");
            Graphics.DrawRectangle(50, 50, 100, 100, Color.Blue);
            Graphics.DrawLine(100, 100, 400, 400, Color.BlanchedAlmond);
            Graphics.DrawCircle(250, 250, 50, Color.FromArgb(69, 69, 69));
        }
    }
}
