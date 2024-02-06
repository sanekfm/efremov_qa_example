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
    [NUnit.Framework.Category("MainTest")]
    [NUnit.Framework.Category("All")]
    [NUnit.Framework.Category("TourPrograms")]
    [AllureNUnit]
    public class Tests
    {
        private IWebDriver driver;
        string loginMasterWebAgency = "test2";
        string passwordMasterWebAgency = "1";
        By expectedUserAfterAutorizationMasterWebAgency = By.XPath("//a[contains (text(),'��� ����� test2')]");
        By expectedUserAfterAutorizationMasterWebPersonal = By.XPath("//a[contains (text(),'��� ����� aefremov@megatec.ru')]");
        By expectedMasterWebAdminusername = By.XPath("//a[contains (text(),'��� ����� MT15')]");
        string loginMasterWebPersonal = "aefremov@megatec.ru";
        string passwordMasterWebPersonal = "Pilot410192";
        string loginTourPrograms = "MT15";
        string passwordTourPrograms = "1";
        string loginMWAdmin = "MT15";
        string passwordMWAdmin = "1";
        By expectedTourProgramsusername = By.XPath("//ul[@class='nav navbar-nav navbar-right']/li/span"); //Test 1.//
        string loginCanaryAgency = "test2";
        string passwordCanaryAgency = "1";
        string expectedUserAfterAutorizationCanaryAgency = "���������";
        string expectedRegisterLoginCanary = "��������+�������";
        string loginCanaryPersonal = "aefremov@megatec.ru";
        string passwordCanaryPersonal = "Pilot410192";
        string loginTSCAgency = "test2";
        string passwordTSCAgency = "1";
        string expectedUserAfterAutorizationTSCAgency = "���������";
        string loginTSCPersonal = "aefremov@megatec.ru";
        string passwordTSCPersonal = "Pilot410192";
        string expectedUserAfterAutorizationTSCPersonal = "aefremov@megatec.ru";
        string expectedUserAfterAutorizationCanaryPersonal = "aefremov@megatec.ru";
        //��� ������������� ����
        string loginTSCAgencyMF = "test2";
        string passwordTSCAgencyMF = "1";
        string expectedUserAfterAutorizationTSCAgencyMF = "�������-����������122";
        string loginTSCPersonalMF = "aefremov@megatec.ru";
        string passwordTSCPersonalMF = "Pilot410192";
        string expectedUserAfterAutorizationTSCPersonalMF = "aefremov@megatec.ru";
        string expectedcomissionAgencyTinkoffFullPayment = "100692,00 ��";
        string expectedcomissionPersonalTinkoffFullPayment = "123120,00 ��";
        string expectedcomissionAgencyUnitellerFullPayment = "102892,42 ��";
        string expectedcomissionPersonalUnitellerFullPayment = "152532,03 ��";
        string expectedcomissionAgencySberbankFullPayment = "101277,00 ��";
        string expectedcomissionPersonalSberbankFullPayment = "134440,00 ��";
        string expectedcomissionAgencyAssistFullPayment = "101898,00 ��";
        string expectedcomissionPersonalAssistFullPayment = "146430,00 ��";
        string expectedcomissionAgencyPayOnlineFullPayment = "104940,00 ��";
        string expectedcomissionPersonalPayOnlineFullPayment = "141600,00 ��";
        string expectedcomissionAgencyWebPayFullPayment = "101277,00 ��";
        string expectedcomissionPersonalWebPayFullPayment = "134440,00 ��";
        string expectedOrderSummAgencyWithoutComissionService = "90000,00 ��";
        string expectedOrderSummPersonalWithoutComissionService = "100000,00 ��";
        string editSumPersonalPart1 = "99000 �� (99000,00 ��)";
        string editSumPersonalPart2 = "98000 �� (98000,00 ��)";
        string editSumAgencyPart1 = "89000 �� (89000,00 ��)";
        string editSumAgencyPart2 = "88000 �� (88000,00 ��)";
        string ifFullPaySucces = "0 �� (0,00 ��)";
        string orderNumber;

        [SetUp]
        public void Setup()
        {
            Console.WriteLine("������������� ��������.");
            //�������� ������ ��������
            new DriverManager().SetUpDriver(new ChromeConfig(), VersionResolveStrategy.MatchingBrowser);
            driver = new ChromeDriver();
            
        }


        //****************************

        //����������� � �������������
        [Test, Order(1), Timeout(800000), Retry(5)]
        [AllureSuite("Cian")]
        [AllureFeature("CianTest")]
        public void AutorizationTourPrograms()
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            int times = 0;
            Console.WriteLine("������ ����� �������� ����� Cian.");
            Console.WriteLine("������������� ����������");
            string login = "efremov_test@rambler.ru";
            string password = "HiCian123";
            string expectedCianusername = "//a[contains (text(),'ID 113000074')]";
            By AddBtn = By.XPath("//input[@class='btn btn-primary']");
            By AddFormName = By.XPath("//*[contains(text(), '�������� ������')]");
            By CopyFormName = By.XPath("//*[contains(text(), '����������� ������')]");
            By ButtonDeleteXPath = By.XPath("//button[@class='btn btn-primary btn-sm btn-danger btn-xs']");
            By ButtonCopyXPath = By.XPath("//button[@class='btn btn-primary btn-xs icon_small']");
            By confirmDeleted = By.XPath("//button[@class='btn btn-primary']/span[contains(text(),'��')]");
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
            Console.WriteLine("������� � ���������� ������ ������������� �� ������ http://supp-08.megatec.ru/TourPrograms_MT15.8/AirService");
            try
            {
                driver.Navigate().GoToUrl("http://supp-08.megatec.ru/TourPrograms_MT15.8/AirService");
            }
            catch (Exception)
            {
                Console.WriteLine("������������� �������� �� ����������. ���� �������.");
                //���� �� ���� ����� ������ ������, �� ���� ���������� ��� ���
                times++;
                Assert.Fail(times + " times");
                System.Threading.Thread.CurrentThread.Abort();
            }
            System.Threading.Thread.Sleep(2000);
            Console.WriteLine("������� � �������� �������� ������� �������������.");
            try
            {
                DictionaryOperations.AddObjectButtonandCheck(TestDictionaryName, AddBtn, AddFormName, driver);
            }
            catch (Exception)
            {
                Console.WriteLine("�� ������� ������� ����� �������������. ���� �������.");
                //���� �� ���� ����� ������ ������, �� ���� ���������� ��� ���
                times++;
                Assert.Fail(times + " times");
                System.Threading.Thread.CurrentThread.Abort();
            }
            Console.WriteLine("���������� �����.");
            try
            {
                driver.FindElement(By.Id("roomCategoriesName")).SendKeys("����� ����");
                System.Threading.Thread.Sleep(1000);
                driver.FindElement(By.Id("roomCategoriesCode")).SendKeys("PIU");
                System.Threading.Thread.Sleep(1000);
            }
            catch (Exception)
            {
                Console.WriteLine("�� ������� ��������� �����. ���� �������.");
                //���� �� ���� ����� ������ ������, �� ���� ���������� ��� ���
                times++;
                Assert.Fail(times + " times");
                System.Threading.Thread.CurrentThread.Abort();
            }
            Console.WriteLine("������� �� ������ ������� ����� ������������.");
            try
            {
                driver.FindElement(By.XPath("//div[@id='CreateEditAirServiceDialog']/div/div/button/span[contains(text(),'���������')]")).Click();
                System.Threading.Thread.Sleep(1000);
            }
            catch (Exception)
            {
                Console.WriteLine("���������� �� �������. ���� �������.");
                //���� �� ���� ����� ������ ������, �� ���� ���������� ��� ���
                times++;
                Assert.Fail(times + " times");
                System.Threading.Thread.CurrentThread.Abort();
            }
            //���� Change Tracking � ��������� ��������
            System.Threading.Thread.Sleep(30000);
            driver.Navigate().Refresh();
            Console.WriteLine("��������, ��� ����� ������������� ������ �������.");
            driver.FindElement(By.Id("airServiceSearch")).SendKeys("����� ����");
            System.Threading.Thread.Sleep(1000);
            try
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//button[contains(text(), '����� ����')]")));
                Console.WriteLine("����� ������������ ������� ������.");
            }
            //���� ������ ����������
            catch (Exception)
            {
                Console.WriteLine("����� ������������ ����������� � ������. ���� �������.");
                //���� �� ���� ����� ������ ������, �� ���� ���������� ��� ���
                times++;
                Assert.Fail(times + " times");
                System.Threading.Thread.CurrentThread.Abort();

            }
            Console.WriteLine("������� � �������� ����������� ������� �������������.");
            try
            {
                DictionaryOperations.CopyObjectButtonandCheck(TestDictionaryName, ButtonCopyXPath, CopyFormName, driver);
            }
            catch (Exception)
            {
                Console.WriteLine("�� ������� ����������� ����� �������������. ���� �������.");
                //���� �� ���� ����� ������ ������, �� ���� ���������� ��� ���
                times++;
                Assert.Fail(times + " times");
                System.Threading.Thread.CurrentThread.Abort();
            }
            Console.WriteLine("������� �� ������ ������� ����� �������������.");
            try
            {
                driver.FindElement(By.XPath("//div[@id='CreateEditAirServiceDialog']/div/div/button/span[contains(text(),'���������')]")).Click();
                System.Threading.Thread.Sleep(1000);
            }
            catch (Exception)
            {
                Console.WriteLine("�� ������� ��������� ����������. ���� �������.");
                //���� �� ���� ����� ������ ������, �� ���� ���������� ��� ���
                times++;
                Assert.Fail(times + " times");
                System.Threading.Thread.CurrentThread.Abort();

            }
            //���� Change Tracking � ��������� ��������
            System.Threading.Thread.Sleep(30000);
            driver.Navigate().Refresh();
            Console.WriteLine("��������, ��� ����� ������������� ���������� �������.");
            try
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//button[contains(text(),'����� ����� ����')]")));
                Console.WriteLine("����� ������������� ������� ����������.");
            }
            //���� ������ ����������
            catch (Exception)
            {
                Console.WriteLine("����� ������������� �����������. ���� �������.");
                //���� �� ���� ����� ������ ������, �� ���� ���������� ��� ���
                times++;
                Assert.Fail(times + " times");
                System.Threading.Thread.CurrentThread.Abort();
            }

            Console.WriteLine("������� ��������� ������ �������������.");
            try
            {
                DeleteCreatedElementAfterTest.DeleteTourProgramsElementPageObject(ButtonDeleteXPath, ButtonCopyXPath, expectedDeleteElementName, confirmDeleted, driver);
            }
            //���� ������ ����������
            catch (Exception)
            {
                Console.WriteLine("�� ������� ������� ������ �������������. ���� �������.");
                //���� �� ���� ����� ������ ������, �� ���� ���������� ��� ���
                times++;
                Assert.Fail(times + " times");
                System.Threading.Thread.CurrentThread.Abort();
            }
            Console.WriteLine("���� ����������� ������ ������������� ������� �������.");

        }

        [TearDown]
        public void TearDown()
        {
            Console.WriteLine("TearDown");
        }
    }

}