﻿using NUnit.Framework;

namespace SeleniumWD_OP
{
    public class TestBase
    {
        public Application? app;

        [SetUp]
        public void start()
        {
            app = new Application();
        }

        [TearDown]
        public void stop()
        {
            app.Quit();
            app = null;
        }
    }
}