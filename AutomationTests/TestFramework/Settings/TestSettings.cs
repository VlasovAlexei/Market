﻿namespace TestFramework.Settings
{
    public class TestSettings
    {
        public BrowserType BrowserType { get; set; }

        public Uri ApplicationUrl { get; set; }

        public int TimeoutInterval { get; set; }

        public Uri SeleniumGridUrl { get; set; }

        public ExecutionType ExecutionType { get; set; }
    }
}
