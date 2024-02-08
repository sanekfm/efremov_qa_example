using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using NUnit.Allure.Core;
using OpenQA.Selenium.Interactions;
using NUnit.Framework.Internal;

namespace AutotestExample.PageObject

{
    [AllureNUnit]

    class AutorizationPageObject
    {
        public static void AutorizationCianPageObject(string login, string password, string expectedCianusername, IWebDriver driver)
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            Console.WriteLine("Переход на страницу Cian.");
            try
            {
                driver.Navigate().GoToUrl("https://astrahan.cian.ru/");
            }
            catch
            {
                Console.WriteLine("Не удалось перейти на страницу авторизации.");
                System.Threading.Thread.CurrentThread.Abort();
            }
            Console.WriteLine("Проверяем, что страница Cian загружена.");
            try
            {
                WebDriverWait wait1 = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                wait1.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//span[contains (text(),'Войти')]")));
            }
            catch
            {
                Console.WriteLine("Страница не загружена. Тест прерван.");
                System.Threading.Thread.CurrentThread.Abort();
            }
            driver.Manage().Window.Maximize();
            Console.WriteLine("Нажимаем на кнопку войти на главной странице.");
            try
            {
                driver.FindElement(By.XPath("//span[contains (text(),'Войти')]")).Click();

            }
            catch
            {
                Console.WriteLine("Окно авторизации не открылось. Тест прерван.");
                System.Threading.Thread.CurrentThread.Abort();
            }

            Console.WriteLine("Заполнение формы авторизации.");
            try
            {
                driver.FindElement(By.XPath("//button[@data-name='SwitchToEmailAuthBtn']")).Click();
                driver.FindElement(By.XPath("//input[@name='username']")).SendKeys(login);
                driver.FindElement(By.XPath("//button[@data-name='ContinueAuthBtn']")).Click();
                driver.FindElement(By.XPath("//input[@name='password']")).SendKeys(password);
                driver.FindElement(By.XPath("//button[@data-name='ContinueAuthBtn']")).Click();
                System.Threading.Thread.Sleep(5000);
            }
            catch (Exception)
            {
                Console.WriteLine("Не удалось заполнить форму авторизации. Тест прерван.");
                System.Threading.Thread.CurrentThread.Abort();
            }
            Console.WriteLine("Проверяем, что авторизовались с корректным логином.");
            Console.WriteLine("Нажимаем на кнопку с аватаром пользователя");
            try
            {
                driver.FindElement(By.XPath("//a[@data-name='UserAvatar']")).Click();

            }
            catch (Exception)
            {
                Console.WriteLine("Не удалось нажать кнопку. Тест прерван.");
                System.Threading.Thread.CurrentThread.Abort();
            }
            Console.WriteLine("Проверяем, что ID соответствует ожидаемому.");
            try
            {
                var actualLoginCian = driver.FindElement(By.XPath("//a[contains (text(),'ID 113000074')]")).Text;
                Assert.AreEqual(expectedCianusername, actualLoginCian, "Login is wrong");
                Console.WriteLine("ID соответствует ожидаемому.Авторизация прошла успешно.");
            }
            //Если падает исключение
            catch (Exception)
            {
                Console.WriteLine("ID не соответствует ожидаемому.Тест прерван.");
                System.Threading.Thread.CurrentThread.Abort();
            }
        }

    }
}