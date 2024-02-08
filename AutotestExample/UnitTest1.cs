using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Chrome;
using System;
using System.IO;
using System.Text.RegularExpressions;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;
using SeleniumExtras.WaitHelpers;
using WebDriverManager.Helpers;
using AutotestExample.PageObject;
using static System.Net.Mime.MediaTypeNames;
using System.Drawing;
using System.Threading;
using System.Xml.Linq;
using Microsoft.Win32;
using System.ComponentModel;
using AngleSharp.Dom;
using OpenQA.Selenium.DevTools;
using AngleSharp.Html.Dom;
using System.Diagnostics;
using NUnit.Allure.Core;
using Allure.Commons;
using NUnit.Allure.Attributes;
using System.Collections.Generic;
using AngleSharp.Css;
using OpenQA.Selenium.Interactions;
using RestSharp;
using RestSharp.Serializers.SystemTextJson;
using System.Net;
using System.Text.Json;
using static System.Text.Json.JsonSerializer;
using System.Text.Encodings.Web;



namespace AutotestExample
{
    [NUnit.Framework.Category("CianTest")]
    [NUnit.Framework.Category("Cian")]
    [AllureNUnit]
    public class Tests
    {
        private IWebDriver driver;
        string login = "efremov_test@rambler.ru";
        string password = "HiCian123";
        string expectedCianusername = "ID 113000074";

        [SetUp]
        public void Setup()
        {
            Console.WriteLine("������������� ��������.");
            //�������� ������ ��������
            new DriverManager().SetUpDriver(new ChromeConfig(), VersionResolveStrategy.MatchingBrowser);
            driver = new ChromeDriver();
            
        }


        [Test, Order(1), Timeout(800000), Retry(2)]
        [AllureSuite("Cian")]
        [AllureFeature("CianAutorization")]
        public void CianAutorization()
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            int times = 0;
            Console.WriteLine("������ ����� �������� ����������� ����� Cian.");
            Console.WriteLine("������������� ����������");
            Console.WriteLine("����������� � Cian");
            try
            {
                AutorizationPageObject.AutorizationCianPageObject(login, password, expectedCianusername, driver);
            }
            catch (Exception)
            {
                Console.WriteLine("�� ������� ��������������. ���� �������.");
                //���� �� ���� ����� ������ ������, �� ���� ���������� ��� ���
                times++;
                Assert.Fail(times + " times");
                System.Threading.Thread.CurrentThread.Abort();
            }
            Console.WriteLine("���� �������� ����������� � Cian ������� �������.");

        }

    

        [Test, Order(2), Timeout(800000), Retry(2)]
        [AllureSuite("Cian")]
        [AllureFeature("CianPage")]
        public void CianRentPage ()
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            int times = 0;
            Console.WriteLine("������ ����� �������� �������� ������ ����� Cian.");
            Console.WriteLine("������������� ����������");
            string login = "efremov_test@rambler.ru";
            string password = "HiCian123";
            string expectedCianusername = "ID 113000074";
            Console.WriteLine("����������� � Cian");
            try
            {
                AutorizationPageObject.AutorizationCianPageObject(login, password, expectedCianusername, driver);
            }
            catch (Exception)
            {
                Console.WriteLine("�� ������� ��������������. ���� �������.");
                //���� �� ���� ����� ������ ������, �� ���� ���������� ��� ���
                times++;
                Assert.Fail(times + " times");
                System.Threading.Thread.CurrentThread.Abort();
            }
            Console.WriteLine("����������� � Cian ������� ��������.");
            Console.WriteLine("�������� ������ �������� �� ������� ������.");
            try
            {
                driver.FindElement(By.XPath("//li/a[contains(text(), '������')]")).Click();

                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
                wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//h1[contains(text(), '������ ������������ � ���������')]")));
            }
            catch (Exception)
            {
                Console.WriteLine("�������� �������� �� �����������.���� �������.");
                //���� �� ���� ����� ������ ������, �� ���� ���������� ��� ���
                times++;
                Assert.Fail(times + " times");
                System.Threading.Thread.CurrentThread.Abort();
            }
            Console.WriteLine("���� �������� �������� �������� ������.");

        }


        [Test, Order(2), Timeout(800000), Retry(3)]
        [AllureSuite("Cian")]
        [AllureFeature("CianPage")]
        public void CianIpoCalcPage()
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            int times = 0;
            Console.WriteLine("������ ����� �������� �������� ��������� ����������� ����� Cian.");
            Console.WriteLine("������������� ����������");
            string login = "efremov_test@rambler.ru";
            string password = "HiCian123";
            string expectedCianusername = "ID 113000074";
            Console.WriteLine("����������� � Cian");
            try
            {
                AutorizationPageObject.AutorizationCianPageObject(login, password, expectedCianusername, driver);
            }
            catch (Exception)
            {
                Console.WriteLine("�� ������� ��������������. ���� �������.");
                //���� �� ���� ����� ������ ������, �� ���� ���������� ��� ���
                times++;
                Assert.Fail(times + " times");
                System.Threading.Thread.CurrentThread.Abort();
            }
            Console.WriteLine("����������� � Cian ������� ��������.");
            Console.WriteLine("����� JS ������� ��� ��������� � ������ �����.");
            //�������� JavaScript
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("document.querySelector(\"#frontend-footer li:nth-child(12) > a\").scrollIntoView(true)");
            try
            {
                driver.FindElement(By.XPath("//a[contains(text(), '��������� �����������')]")).Click();

                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
                wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//h1[contains(text(), '��������� �����������')]")));
            }
            catch (Exception)
            {
                Console.WriteLine("�������� �������� �� �����������.���� �������.");
                //���� �� ���� ����� ������ ������, �� ���� ���������� ��� ���
                times++;
                Assert.Fail(times + " times");
                System.Threading.Thread.CurrentThread.Abort();
            }
            Console.WriteLine("���� �������� �������� �������� ��������� ����������� �������.");

        }


        


        [TearDown]
        public void TearDown()
        {
            Console.WriteLine("TearDown");
            driver.Quit();
        }
    }

}