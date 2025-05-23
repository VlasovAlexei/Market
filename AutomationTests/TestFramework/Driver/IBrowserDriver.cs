﻿using OpenQA.Selenium;

namespace TestFramework.Driver;

public interface IBrowserDriver
{
    IWebDriver GetChromeDriver();
    IWebDriver GetEdgeDriver();
    IWebDriver GetFirefoxDriver();
}
