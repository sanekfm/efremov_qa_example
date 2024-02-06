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
        By expectedUserAfterAutorizationMasterWebAgency = By.XPath("//a[contains (text(),'Ваш логин test2')]");
        By expectedUserAfterAutorizationMasterWebPersonal = By.XPath("//a[contains (text(),'Ваш логин aefremov@megatec.ru')]");
        By expectedMasterWebAdminusername = By.XPath("//a[contains (text(),'Ваш логин MT15')]");
        string loginMasterWebPersonal = "aefremov@megatec.ru";
        string passwordMasterWebPersonal = "Pilot410192";
        string loginTourPrograms = "MT15";
        string passwordTourPrograms = "1";
        string loginMWAdmin = "MT15";
        string passwordMWAdmin = "1";
        By expectedTourProgramsusername = By.XPath("//ul[@class='nav navbar-nav navbar-right']/li/span"); //Test 1.//
        string loginCanaryAgency = "test2";
        string passwordCanaryAgency = "1";
        string expectedUserAfterAutorizationCanaryAgency = "Агентство";
        string expectedRegisterLoginCanary = "Тестовый+партнер";
        string loginCanaryPersonal = "aefremov@megatec.ru";
        string passwordCanaryPersonal = "Pilot410192";
        string loginTSCAgency = "test2";
        string passwordTSCAgency = "1";
        string expectedUserAfterAutorizationTSCAgency = "Агентство";
        string loginTSCPersonal = "aefremov@megatec.ru";
        string passwordTSCPersonal = "Pilot410192";
        string expectedUserAfterAutorizationTSCPersonal = "aefremov@megatec.ru";
        string expectedUserAfterAutorizationCanaryPersonal = "aefremov@megatec.ru";
        //для мастерфинанса базы
        string loginTSCAgencyMF = "test2";
        string passwordTSCAgencyMF = "1";
        string expectedUserAfterAutorizationTSCAgencyMF = "Партнер-покупатель122";
        string loginTSCPersonalMF = "aefremov@megatec.ru";
        string passwordTSCPersonalMF = "Pilot410192";
        string expectedUserAfterAutorizationTSCPersonalMF = "aefremov@megatec.ru";
        string expectedcomissionAgencyTinkoffFullPayment = "100692,00 рб";
        string expectedcomissionPersonalTinkoffFullPayment = "123120,00 рб";
        string expectedcomissionAgencyUnitellerFullPayment = "102892,42 рб";
        string expectedcomissionPersonalUnitellerFullPayment = "152532,03 рб";
        string expectedcomissionAgencySberbankFullPayment = "101277,00 рб";
        string expectedcomissionPersonalSberbankFullPayment = "134440,00 рб";
        string expectedcomissionAgencyAssistFullPayment = "101898,00 рб";
        string expectedcomissionPersonalAssistFullPayment = "146430,00 рб";
        string expectedcomissionAgencyPayOnlineFullPayment = "104940,00 рб";
        string expectedcomissionPersonalPayOnlineFullPayment = "141600,00 рб";
        string expectedcomissionAgencyWebPayFullPayment = "101277,00 рб";
        string expectedcomissionPersonalWebPayFullPayment = "134440,00 рб";
        string expectedOrderSummAgencyWithoutComissionService = "90000,00 рб";
        string expectedOrderSummPersonalWithoutComissionService = "100000,00 рб";
        string editSumPersonalPart1 = "99000 рб (99000,00 рб)";
        string editSumPersonalPart2 = "98000 рб (98000,00 рб)";
        string editSumAgencyPart1 = "89000 рб (89000,00 рб)";
        string editSumAgencyPart2 = "88000 рб (88000,00 рб)";
        string ifFullPaySucces = "0 рб (0,00 рб)";
        string orderNumber;

        [SetUp]
        public void Setup()
        {
            Console.WriteLine("Инициализация драйвера.");
            //проверка версии браузера
            new DriverManager().SetUpDriver(new ChromeConfig(), VersionResolveStrategy.MatchingBrowser);
            driver = new ChromeDriver();
            
        }


        //****************************

        //авторизация в турпрограммах
        [Test, Order(1), Timeout(800000), Retry(5)]
        [AllureSuite("Cian")]
        [AllureFeature("CianTest")]
        public void AutorizationTourPrograms()
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            int times = 0;
            Console.WriteLine("Запуск теста проверки сайта Cian.");
            Console.WriteLine("Инициализация переменных");
            string login = "efremov_test@rambler.ru";
            string password = "HiCian123";
            string expectedCianusername = "//a[contains (text(),'ID 113000074')]";
            By AddBtn = By.XPath("//input[@class='btn btn-primary']");
            By AddFormName = By.XPath("//*[contains(text(), 'Создание тарифа')]");
            By CopyFormName = By.XPath("//*[contains(text(), 'Копирование тарифа')]");
            By ButtonDeleteXPath = By.XPath("//button[@class='btn btn-primary btn-sm btn-danger btn-xs']");
            By ButtonCopyXPath = By.XPath("//button[@class='btn btn-primary btn-xs icon_small']");
            By confirmDeleted = By.XPath("//button[@class='btn btn-primary']/span[contains(text(),'Да')]");
            Console.WriteLine("Авторизация в Cian");
            try
            {
                AutorizationPageObject.AutorizationCianPageObject(login, password, expectedCianusername, driver);
            }
            catch (Exception)
            {
                Console.WriteLine("Не удалось авторизоваться. Тест прерван.");
                //если на этом этапе падает ошибка, то тест запустится еще раз
                times++;
                Assert.Fail(times + " times");
                System.Threading.Thread.CurrentThread.Abort();
            }
            Console.WriteLine("Переход в справочник тарифы авиаперелетов по ссылке http://supp-08.megatec.ru/TourPrograms_MT15.8/AirService");
            try
            {
                driver.Navigate().GoToUrl("http://supp-08.megatec.ru/TourPrograms_MT15.8/AirService");
            }
            catch (Exception)
            {
                Console.WriteLine("Запрашиваемая страница не существует. Тест прерван.");
                //если на этом этапе падает ошибка, то тест запустится еще раз
                times++;
                Assert.Fail(times + " times");
                System.Threading.Thread.CurrentThread.Abort();
            }
            System.Threading.Thread.Sleep(2000);
            Console.WriteLine("Переход к проверке создания тарифов авиаперелетов.");
            try
            {
                DictionaryOperations.AddObjectButtonandCheck(TestDictionaryName, AddBtn, AddFormName, driver);
            }
            catch (Exception)
            {
                Console.WriteLine("Не удалось создать тариф авиаперелетов. Тест прерван.");
                //если на этом этапе падает ошибка, то тест запустится еще раз
                times++;
                Assert.Fail(times + " times");
                System.Threading.Thread.CurrentThread.Abort();
            }
            Console.WriteLine("Заполнение формы.");
            try
            {
                driver.FindElement(By.Id("roomCategoriesName")).SendKeys("Тариф Авиа");
                System.Threading.Thread.Sleep(1000);
                driver.FindElement(By.Id("roomCategoriesCode")).SendKeys("PIU");
                System.Threading.Thread.Sleep(1000);
            }
            catch (Exception)
            {
                Console.WriteLine("Не удалось заполнить форму. Тест прерван.");
                //если на этом этапе падает ошибка, то тест запустится еще раз
                times++;
                Assert.Fail(times + " times");
                System.Threading.Thread.CurrentThread.Abort();
            }
            Console.WriteLine("Нажатие на кнопку создать тариф авиаперелета.");
            try
            {
                driver.FindElement(By.XPath("//div[@id='CreateEditAirServiceDialog']/div/div/button/span[contains(text(),'Сохранить')]")).Click();
                System.Threading.Thread.Sleep(1000);
            }
            catch (Exception)
            {
                Console.WriteLine("Сохранение не удалось. Тест прерван.");
                //если на этом этапе падает ошибка, то тест запустится еще раз
                times++;
                Assert.Fail(times + " times");
                System.Threading.Thread.CurrentThread.Abort();
            }
            //ждем Change Tracking и обновляем страницу
            System.Threading.Thread.Sleep(30000);
            driver.Navigate().Refresh();
            Console.WriteLine("Проверка, что тариф авиаперелетов создан успешно.");
            driver.FindElement(By.Id("airServiceSearch")).SendKeys("Тариф Авиа");
            System.Threading.Thread.Sleep(1000);
            try
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//button[contains(text(), 'Тариф Авиа')]")));
                Console.WriteLine("Тариф авиаперелета успешно создан.");
            }
            //Если падает исключение
            catch (Exception)
            {
                Console.WriteLine("Тариф авиаперелета отсутствует в списке. Тест прерван.");
                //если на этом этапе падает ошибка, то тест запустится еще раз
                times++;
                Assert.Fail(times + " times");
                System.Threading.Thread.CurrentThread.Abort();

            }
            Console.WriteLine("Переход к проверке копирования тарифов авиаперелетов.");
            try
            {
                DictionaryOperations.CopyObjectButtonandCheck(TestDictionaryName, ButtonCopyXPath, CopyFormName, driver);
            }
            catch (Exception)
            {
                Console.WriteLine("Не удалось скопировать тариф авиаперелетов. Тест прерван.");
                //если на этом этапе падает ошибка, то тест запустится еще раз
                times++;
                Assert.Fail(times + " times");
                System.Threading.Thread.CurrentThread.Abort();
            }
            Console.WriteLine("Нажатие на кнопку создать тариф авиаперелетов.");
            try
            {
                driver.FindElement(By.XPath("//div[@id='CreateEditAirServiceDialog']/div/div/button/span[contains(text(),'Сохранить')]")).Click();
                System.Threading.Thread.Sleep(1000);
            }
            catch (Exception)
            {
                Console.WriteLine("Не удалось выполнить сохранение. Тест прерван.");
                //если на этом этапе падает ошибка, то тест запустится еще раз
                times++;
                Assert.Fail(times + " times");
                System.Threading.Thread.CurrentThread.Abort();

            }
            //ждем Change Tracking и обновляем страницу
            System.Threading.Thread.Sleep(30000);
            driver.Navigate().Refresh();
            Console.WriteLine("Проверка, что тариф авиаперелетов скопирован успешно.");
            try
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//button[contains(text(),'Копия Тариф Авиа')]")));
                Console.WriteLine("Тариф авиаперелетов успешно скопирован.");
            }
            //Если падает исключение
            catch (Exception)
            {
                Console.WriteLine("Тариф авиаперелетов отсутствует. Тест прерван.");
                //если на этом этапе падает ошибка, то тест запустится еще раз
                times++;
                Assert.Fail(times + " times");
                System.Threading.Thread.CurrentThread.Abort();
            }

            Console.WriteLine("Удаляем созданные тарифы авиаперелетов.");
            try
            {
                DeleteCreatedElementAfterTest.DeleteTourProgramsElementPageObject(ButtonDeleteXPath, ButtonCopyXPath, expectedDeleteElementName, confirmDeleted, driver);
            }
            //Если падает исключение
            catch (Exception)
            {
                Console.WriteLine("Не удалось удалить тарифы авиаперелетов. Тест прерван.");
                //если на этом этапе падает ошибка, то тест запустится еще раз
                times++;
                Assert.Fail(times + " times");
                System.Threading.Thread.CurrentThread.Abort();
            }
            Console.WriteLine("Тест справочника тарифы авиаперелетов успешно пройден.");

        }

        [TearDown]
        public void TearDown()
        {
            Console.WriteLine("TearDown");
        }
    }

}