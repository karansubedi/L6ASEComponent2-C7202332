using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Drawing;

namespace UnitTesting
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod_drawTo()
        {
            Component2.Form1 form = new Component2.Form1();
            Component2.commandParser parse = new Component2.commandParser();
            Bitmap outBitmap = form.mybitmap;

            Component2.Drawing mydrawing = new Component2.Drawing(Graphics.FromImage(outBitmap));
            parse.Commands("drawto 20,30", "", mydrawing);
        }

        [TestMethod]
        public void TestMethod_moveTo()
        {
            Component2.Form1 form = new Component2.Form1();
            Component2.commandParser parse = new Component2.commandParser();
            Bitmap outBitmap = form.mybitmap;

            Component2.Drawing mydrawing = new Component2.Drawing(Graphics.FromImage(outBitmap));
            parse.Commands("moveto 40,50", "", mydrawing);
        }

        [TestMethod]
        public void TestMethod_DrawRectangle()
        {
            Component2.Form1 form = new Component2.Form1();
            Component2.commandParser parse = new Component2.commandParser();
            Bitmap outBitmap = form.mybitmap;

            Component2.Drawing mydrawing = new Component2.Drawing(Graphics.FromImage(outBitmap));
            parse.Commands("rectangle 60,50", "", mydrawing);
        }

        [TestMethod]
        public void TestMethod_DrawSquare()
        {
            Component2.Form1 form = new Component2.Form1();
            Component2.commandParser parse = new Component2.commandParser();
            Bitmap outBitmap = form.mybitmap;

            Component2.Drawing mydrawing = new Component2.Drawing(Graphics.FromImage(outBitmap));
            parse.Commands("square 60", "", mydrawing);
        }

        [TestMethod]
        public void TestMethod_DrawCircle()
        {
            Component2.Form1 form = new Component2.Form1();
            Component2.commandParser parse = new Component2.commandParser();
            Bitmap outBitmap = form.mybitmap;

            Component2.Drawing mydrawing = new Component2.Drawing(Graphics.FromImage(outBitmap));
            parse.Commands("circle 60", "", mydrawing);
        }

        [TestMethod]
        public void TestMethod_DrawTriangle()
        {
            Component2.Form1 form = new Component2.Form1();
            Component2.commandParser parse = new Component2.commandParser();
            Bitmap outBitmap = form.mybitmap;

            Component2.Drawing mydrawing = new Component2.Drawing(Graphics.FromImage(outBitmap));
            parse.Commands("triangle 30,40,60", "", mydrawing);
        }

        [TestMethod]
        public void TestMethod_pen()
        {
            Component2.Form1 form = new Component2.Form1();
            Component2.commandParser parse = new Component2.commandParser();
            Bitmap outBitmap = form.mybitmap;

            Component2.Drawing mydrawing = new Component2.Drawing(Graphics.FromImage(outBitmap));
            parse.Commands("pen green", "", mydrawing);
        }

        [TestMethod]
        public void TestMethod_fill()
        {
            Component2.Form1 form = new Component2.Form1();
            Component2.commandParser parse = new Component2.commandParser();
            Bitmap outBitmap = form.mybitmap;

            Component2.Drawing mydrawing = new Component2.Drawing(Graphics.FromImage(outBitmap));
            parse.Commands("fill on", "", mydrawing);
        }

        [TestMethod]
        public void TestMethod_Reset()
        {
            Component2.Form1 form = new Component2.Form1();
            Component2.commandParser parse = new Component2.commandParser();
            Bitmap outBitmap = form.mybitmap;

            Component2.Drawing mydrawing = new Component2.Drawing(Graphics.FromImage(outBitmap));
            parse.Commands("reset", "", mydrawing);
        }

        [TestMethod]
        public void TestMethod_clear()
        {
            Component2.Form1 form = new Component2.Form1();
            Component2.commandParser parse = new Component2.commandParser();
            Bitmap outBitmap = form.mybitmap;

            Component2.Drawing mydrawing = new Component2.Drawing(Graphics.FromImage(outBitmap));
            parse.Commands("clear", "", mydrawing);
        }

        [TestMethod]
        public void TestMethod_Variables()
        {
            Component2.Form1 form = new Component2.Form1();
            Component2.commandParser parse = new Component2.commandParser();
            Bitmap outBitmap = form.mybitmap;

            Component2.Drawing mydrawing = new Component2.Drawing(Graphics.FromImage(outBitmap));
            parse.Commands("radius = radius + 10", "", mydrawing);
        }

        [TestMethod]
        public void TestMethod_updateTest()
        {
            Component2.Form1 form = new Component2.Form1();
            Component2.commandParser parse = new Component2.commandParser();
            Bitmap outBitmap = form.mybitmap;

            Component2.Drawing mydrawing = new Component2.Drawing(Graphics.FromImage(outBitmap));
            parse.Commands("radius = radius + 10", "", mydrawing);
            parse.Commands("radius = radius - 10", "", mydrawing);
            parse.Commands("radius = radius / 10", "", mydrawing);
            parse.Commands("radius = radius * 10", "", mydrawing);
        }

    }
}
