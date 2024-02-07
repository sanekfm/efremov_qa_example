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

            Console.WriteLine("Заполнение формы авторизации. Тест прерван.");
            try
            {
                driver.FindElement(By.XPath("//button[@data-name='SwitchToEmailAuthBtn']")).Click();
                driver.FindElement(By.XPath("//input[@name='username']")).SendKeys(login);
                driver.FindElement(By.XPath("//button[@data-name='ContinueAuthBtn']")).Click();
                driver.FindElement(By.XPath("//input[@name='password']")).SendKeys(password);
                driver.FindElement(By.XPath("//button[@data-name='ContinueAuthBtn']")).Click();
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


        class EditConfigPageObject
    {
        public static void PaymentSystem(string filePath, string searchText, string replaceText)
        {
            //Ниже редактируем конфиг
            //читаем конфиг
            StreamReader reader = new StreamReader(filePath);
            string content = reader.ReadToEnd();
            reader.Close();
            //меняем строку
            content = Regex.Replace(content, searchText, replaceText);
            //перезаписываем конфиг
            StreamWriter writer = new StreamWriter(filePath);
            writer.Write(content);
            writer.Close();


        }


    }

   





        public static void AutorizationAdminMasterWebPageObject(string login, string password, By expectedMasterWebAdminusername, IWebDriver driver)
        {
            string name = TestContext.CurrentContext.Test.MethodName;
            try
            {
                Console.WriteLine("Переход на страницу авторизации AdminMasterWeb.");
                driver.Navigate().GoToUrl("http://supp-08.megatec.ru/MasterWeb_MT15.8/Admin");
            }
            catch
            {
                Console.WriteLine("Не удалось перейти на страницу авторизации.");
                System.Threading.Thread.CurrentThread.Abort();
            }
            try
            {
                WebDriverWait wait1 = new WebDriverWait(driver, TimeSpan.FromSeconds(300));
                wait1.Until(ExpectedConditions.ElementToBeClickable(By.Id("ctl00_generalContent_lbPageTitle")));
            }
            catch
            {
                Console.WriteLine("Окно авторизации не открылось. Тест прерван.");
                System.Threading.Thread.CurrentThread.Abort();
            }

            try
            {
                driver.FindElement(By.Id("ctl00_generalContent_LoginControl_txtUserName")).Click();
                System.Threading.Thread.Sleep(1000);
                driver.FindElement(By.Id("ctl00_generalContent_LoginControl_txtUserName")).SendKeys(login);
                System.Threading.Thread.Sleep(1000);
                driver.FindElement(By.Id("ctl00_generalContent_LoginControl_txtPassword")).Click();
                System.Threading.Thread.Sleep(1000);
                driver.FindElement(By.Id("ctl00_generalContent_LoginControl_txtPassword")).SendKeys(password);
                System.Threading.Thread.Sleep(1000);
                driver.FindElement(By.Id("ctl00_generalContent_LoginControl_btnLogin")).Click();
            }
            catch
            {
                Console.WriteLine("Авторизация не выполнена. Тест прерван.");
                System.Threading.Thread.CurrentThread.Abort();
            }

            try
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                wait.Until(ExpectedConditions.ElementToBeClickable(expectedMasterWebAdminusername));
                Console.WriteLine("Авторизация в AdminMasterWeb успешно пройдена.");
            }
            catch
            {
                Console.WriteLine("Авторизация в AdminMasterWeb не выполнена. Тест прерван.");
                System.Threading.Thread.CurrentThread.Abort();
            }
        }

        public static void AutorizationTourProgramsPageObject(string login, string password, By expectedTourProgramsusername, IWebDriver driver)
        {
            string name = TestContext.CurrentContext.Test.MethodName;
            Console.WriteLine("Переход по ссылке http://supp-08.megatec.ru/TourPrograms_MT15.8");
            try
            {
                driver.Navigate().GoToUrl("http://supp-08.megatec.ru/TourPrograms_MT15.8");
            }
            catch (Exception)
            {
                Console.WriteLine("Не удалось перейти по ссылке. Тест прерван.");
                System.Threading.Thread.CurrentThread.Abort();
            }

            driver.Manage().Window.Maximize();
            try
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(100));
                wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//button")));
            }
            catch (Exception)
            {
                Console.WriteLine("Не удалось дождаться загрузки страницы или кнопка войти не найдена. Тест прерван.");
                System.Threading.Thread.CurrentThread.Abort();
            }
            Console.WriteLine("Заполнение формы авторизации в TourPrograms.");
            try
            {
                driver.FindElement(By.Id("loginTextBox")).Click();
                driver.FindElement(By.Id("loginTextBox")).SendKeys(login);
                driver.FindElement(By.Id("passwordTextBox")).SendKeys(password);
                driver.FindElement(By.Id("RememberMe")).Click();
                driver.FindElement(By.XPath("//span[@data-bind='text: loginUpperTitle()']")).Click();
            }
            catch (Exception)
            {
                Console.WriteLine("Не удалось заполнить форму авторизации.Тест прерван.");
                System.Threading.Thread.CurrentThread.Abort();
            }
            try
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                wait.Until(ExpectedConditions.ElementToBeClickable(expectedTourProgramsusername));
                Console.WriteLine("Вход успешно выполнен.");
            }
            //Если падает исключение
            catch (Exception)
            {
                Console.WriteLine("Неверная пара логин/пароль или что-то сломалось.Тест прерван.");
                System.Threading.Thread.CurrentThread.Abort();
            }

        }

        public static void AutorizationTourProgramsMasterPageObject(string login, string password, By expectedTourProgramsusername, IWebDriver driver)
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            string name = TestContext.CurrentContext.Test.MethodName;
            Console.WriteLine("Переход по ссылке http://supp-08.megatec.ru/TourPrograms");
            try
            {
                driver.Navigate().GoToUrl("http://supp-08.megatec.ru/TourPrograms");
            }
            catch (Exception)
            {
                Console.WriteLine("Не удалось перейти по ссылке. Тест прерван.");
                System.Threading.Thread.CurrentThread.Abort();
            }

            driver.Manage().Window.Maximize();
            try
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(500));
                wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//span[@data-bind='text: loginUpperTitle()']")));
            }
            catch (Exception)
            {
                Console.WriteLine("Не удалось дождаться загрузки страницы или кнопка войти не найдена. Тест прерван.");
                System.Threading.Thread.CurrentThread.Abort();
            }
            Console.WriteLine("Заполнение формы авторизации в TourPrograms.");
            try
            {
                driver.FindElement(By.Id("loginTextBox")).Click();
                driver.FindElement(By.Id("loginTextBox")).SendKeys(login);
                driver.FindElement(By.Id("passwordTextBox")).SendKeys(password);
                driver.FindElement(By.Id("RememberMe")).Click();
                driver.FindElement(By.XPath("//span[@data-bind='text: loginUpperTitle()']")).Click();
            }
            catch (Exception)
            {
                Console.WriteLine("Не удалось заполнить форму авторизации.Тест прерван.");
                System.Threading.Thread.CurrentThread.Abort();
            }
            try
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                wait.Until(ExpectedConditions.ElementToBeClickable(expectedTourProgramsusername));
                Console.WriteLine("Вход успешно выполнен.");
            }
            //Если падает исключение
            catch (Exception)
            {
                Console.WriteLine("Неверная пара логин/пароль или что-то сломалось.Тест прерван.");
                System.Threading.Thread.CurrentThread.Abort();
            }

        }

        public static void AutorizationCanaryPageObject(string login, string password, string expectedCanaryusername, IWebDriver driver)
        {
            string name = TestContext.CurrentContext.Test.MethodName;
            Console.WriteLine("Переход по ссылке http://supp-08.megatec.ru/Canary_MT15.8");
            try
            {
                driver.Navigate().GoToUrl("http://supp-08.megatec.ru/Canary_MT15.8");
            }
            catch (Exception)
            {
                Console.WriteLine("Не удалось перейти по ссылке. Тест прерван.");
                System.Threading.Thread.CurrentThread.Abort();
            }

            driver.Manage().Window.Maximize();
            System.Threading.Thread.Sleep(1000);
            try
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(300));
                wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//div[@class='project-controller-item base-modal']")));
            }
            catch (Exception)
            {
                Console.WriteLine("Кнопка войти не найдена. Тест прерван.");
                System.Threading.Thread.CurrentThread.Abort();
            }
            Console.WriteLine("Нажатие на кнопку войти.");
            driver.FindElement(By.XPath("//div[@class='project-controller-item base-modal']")).Click();
            System.Threading.Thread.Sleep(1000);
            Console.WriteLine("Проверяем открылась ли форма авторизации.");
            //проверяем, что окно с подписью войти открылось
            try
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//h3[contains(text(),'Войти')]")));
            }
            catch (Exception)
            {
                Console.WriteLine("Не удалось открыть форму авторизации. Тест прерван.");
                System.Threading.Thread.CurrentThread.Abort();
            }
            Console.WriteLine("Заполнение формы авторизации в Canary.");
            System.Threading.Thread.Sleep(500);
            try
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//div[text()='Логин']/following-sibling::input")));
            }
            catch (Exception)
            {
                Console.WriteLine("Не удалось авторизоваться. Тест прерван.");
                System.Threading.Thread.CurrentThread.Abort();
            }
            try
            {
                driver.FindElement(By.XPath("//div[text()='Логин']/following-sibling::input")).Click();
                driver.FindElement(By.XPath("//div[text()='Логин']/following-sibling::input")).SendKeys(login);
                driver.FindElement(By.XPath("//input[@type='password']")).SendKeys(password);
                System.Threading.Thread.Sleep(1000);
            }
            catch (Exception)
            {
                System.Threading.Thread.CurrentThread.Abort();
            }
            try
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//span[contains(text(),'Войти')]")));
            }
            catch (Exception)
            {
                System.Threading.Thread.CurrentThread.Abort();
            }
            driver.FindElement(By.XPath("//span[contains(text(),'Войти')]/parent::div")).Click();
            System.Threading.Thread.Sleep(1000);
            var actualLoginCanary = driver.FindElement(By.XPath("//a[@class='project-controller-item pointer']")).Text;
            System.Threading.Thread.Sleep(1000);
            //Сравнение ожидаемого логина и актуального, в случае несоответствия выдает ошибку
            try
            {
                Assert.AreEqual(expectedCanaryusername, actualLoginCanary, "Login is wrong");
                Console.WriteLine("Авторизация прошла успешно.");
            }
            //Если падает исключение
            catch (Exception)
            {
                Console.WriteLine("Не удалось авторизоваться. Тест прерван.");
                System.Threading.Thread.CurrentThread.Abort();
            }
        }
        public static void AutorizationTourSearchClientPageObject(string login, string password, string expectedTSCusername, IWebDriver driver)
        {
            string name = TestContext.CurrentContext.Test.MethodName;
            Console.WriteLine("Переход по ссылке http://supp-08.megatec.ru/TourSearchClient_MT15.8");
            try
            {
                driver.Navigate().GoToUrl("http://supp-08.megatec.ru/TourSearchClient_MT15.8");
            }
            catch (Exception)
            {
                Console.WriteLine("Не удалось перейти по ссылке. Тест прерван.");
                System.Threading.Thread.CurrentThread.Abort();
            }

            driver.Manage().Window.Maximize();
            System.Threading.Thread.Sleep(2000);
            try
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(300));
                wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//a[@class='user-login']")));
            }
            catch (Exception)
            {
                Console.WriteLine("Кнопка войти не найдена. Тест прерван.");
                System.Threading.Thread.CurrentThread.Abort();
            }
            Console.WriteLine("Нажатие на кнопку войти.");
            driver.FindElement(By.XPath("//a[@class='user-login']")).Click();
            System.Threading.Thread.Sleep(500);
            Console.WriteLine("Проверяем открылась ли форма авторизации.");
            //проверяем, что окно с подписью войти открылось
            try
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("login")));
            }
            catch (Exception)
            {
                Console.WriteLine("Не удалось открыть форму авторизации. Тест прерван.");
                System.Threading.Thread.CurrentThread.Abort();
            }
            Console.WriteLine("Заполнение формы авторизации в TourSearchClient.");
            System.Threading.Thread.Sleep(500);
            try
            {
                driver.FindElement(By.Id("login")).Click();
                driver.FindElement(By.Id("login")).SendKeys(login);
                driver.FindElement(By.Id("password")).SendKeys(password);
                System.Threading.Thread.Sleep(1000);
            }
            catch (Exception)
            {
                System.Threading.Thread.CurrentThread.Abort();
            }
            try
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//button[@data-bind='click: login']")));
            }
            catch (Exception)
            {
                System.Threading.Thread.CurrentThread.Abort();
            }
            driver.FindElement(By.XPath("//button[@data-bind='click: login']")).Click();
            System.Threading.Thread.Sleep(1000);
            var actualLoginTSC = driver.FindElement(By.XPath("//span[@data-bind='text: summary()']")).Text;
            System.Threading.Thread.Sleep(2000);
            //Сравнение ожидаемого логина и актуального, в случае несоответствия выдает ошибку
            try
            {
                Assert.AreEqual(expectedTSCusername, actualLoginTSC, "Login is wrong");
                Console.WriteLine("Авторизация прошла успешно.");
            }
            //Если падает исключение
            catch (Exception)
            {
                Console.WriteLine("Не удалось авторизоваться. Тест прерван.");
                System.Threading.Thread.CurrentThread.Abort();
            }
        }
        public static void MF_AutorizationTourSearchClientPageObject(string login, string password, string expectedTSCusername, IWebDriver driver)
        {
            string name = TestContext.CurrentContext.Test.MethodName;
            Console.WriteLine("Переход по ссылке http://supp-08.megatec.ru/TourSearchClientMF");
            try
            {
                driver.Navigate().GoToUrl("http://supp-08.megatec.ru/TourSearchClientMF");
            }
            catch (Exception)
            {
                Console.WriteLine("Не удалось перейти по ссылке. Тест прерван.");
                System.Threading.Thread.CurrentThread.Abort();
            }

            driver.Manage().Window.Maximize();
            System.Threading.Thread.Sleep(2000);
            try
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(300));
                wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//a[@class='user-login']")));
            }
            catch (Exception)
            {
                Console.WriteLine("Кнопка войти не найдена. Тест прерван.");
                driver.Quit();
            }
            Console.WriteLine("Нажатие на кнопку войти.");
            driver.FindElement(By.XPath("//a[@class='user-login']")).Click();
            System.Threading.Thread.Sleep(500);
            Console.WriteLine("Проверяем открылась ли форма авторизации.");
            //проверяем, что окно с подписью войти открылось
            try
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("login")));
            }
            catch (Exception)
            {
                Console.WriteLine("Не удалось открыть форму авторизации. Тест прерван.");
                System.Threading.Thread.CurrentThread.Abort();
            }
            Console.WriteLine("Заполнение формы авторизации в TourSearchClient.");
            System.Threading.Thread.Sleep(500);
            try
            {
                driver.FindElement(By.Id("login")).Click();
                driver.FindElement(By.Id("login")).SendKeys(login);
                driver.FindElement(By.Id("password")).SendKeys(password);
                System.Threading.Thread.Sleep(1000);
            }
            catch (Exception)
            {
                System.Threading.Thread.CurrentThread.Abort();
            }
            try
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//button[@data-bind='click: login']")));
            }
            catch (Exception)
            {
                System.Threading.Thread.CurrentThread.Abort();
            }
            driver.FindElement(By.XPath("//button[@data-bind='click: login']")).Click();
            System.Threading.Thread.Sleep(1000);
            var actualLoginTSC = driver.FindElement(By.XPath("//span[@data-bind='text: summary()']")).Text;
            System.Threading.Thread.Sleep(2000);
            //Сравнение ожидаемого логина и актуального, в случае несоответствия выдает ошибку
            try
            {
                Assert.AreEqual(expectedTSCusername, actualLoginTSC, "Login is wrong");
                Console.WriteLine("Авторизация прошла успешно.");
            }
            //Если падает исключение
            catch (Exception)
            {
                Console.WriteLine("Не удалось авторизоваться. Тест прерван.");
                System.Threading.Thread.CurrentThread.Abort();
            }
        }
    }

    class DictionaryOperations
    {
        public static void AddObjectButtonandCheck(string TestDictionaryName, By AddBtn, By AddFormName, IWebDriver driver)
        {
            string name = TestContext.CurrentContext.Test.MethodName;
            Console.WriteLine($"Проверяем наличие кнопки добавления {TestDictionaryName}.");
            try
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                wait.Until(ExpectedConditions.ElementToBeClickable(AddBtn));
            }
            catch (Exception)
            {
                Console.WriteLine($"Кнопка добавления {TestDictionaryName} отсутствует. Тест прерван.");
                System.Threading.Thread.CurrentThread.Abort();
            }
            driver.FindElement(AddBtn).Click();
            System.Threading.Thread.Sleep(1000);
            Console.WriteLine($"Переход  на форму создания {TestDictionaryName}.");
            try
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                wait.Until(ExpectedConditions.ElementToBeClickable(AddFormName));
            }
            catch (Exception)
            {
                Console.WriteLine($"Форма создания {TestDictionaryName} не открылась. Тест прерван.");
                System.Threading.Thread.CurrentThread.Abort();

            }
            Console.WriteLine($"Форма создания {TestDictionaryName} открылась успешно.");
        }

        public static void CopyObjectButtonandCheck(string TestDictionaryName, By CopyBtn, By CopyFormName, IWebDriver driver)
        {
            string name = TestContext.CurrentContext.Test.MethodName;
            Console.WriteLine($"Проверяем наличие кнопки копирования {TestDictionaryName}.");
            //проверка наличия кнопки копирования типа тура
            try
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                wait.Until(ExpectedConditions.ElementToBeClickable(CopyBtn));
            }
            catch (Exception)
            {
                Console.WriteLine($"Кнопка копирования {TestDictionaryName} отсутствует. Тест прерван.");
                System.Threading.Thread.CurrentThread.Abort();
            }
            Console.WriteLine($"Нажатие на кнопку копирования {TestDictionaryName}.");
            driver.FindElement((CopyBtn)).Click();
            System.Threading.Thread.Sleep(500);
            //проверка что загрузилось окно копирования
            try
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                wait.Until(ExpectedConditions.ElementToBeClickable(CopyFormName));
            }
            catch (Exception)
            {
                Console.WriteLine($"Окно копирования {TestDictionaryName} не открылось. Тест прерван.");
                System.Threading.Thread.CurrentThread.Abort();
            }
            Console.WriteLine($"Окно копирования {TestDictionaryName} открылось успешно.");
        }
        public static void SaveObjectButtonandCheck(string TestDictionaryName, By SaveButton, IWebDriver driver)
        {
            Console.WriteLine($"Проверяем наличие кнопки сохранения {TestDictionaryName}.");
            //проверка наличия кнопки копирования типа тура
            try
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                wait.Until(ExpectedConditions.ElementToBeClickable(SaveButton));
            }
            catch (Exception)
            {
                Console.WriteLine($"Кнопка сохранения {TestDictionaryName} отсутствует. Тест прерван.");
                System.Threading.Thread.CurrentThread.Abort();
            }

            Console.WriteLine($"Нажатие на кнопку сохранить {TestDictionaryName}.");
            try
            {
                driver.FindElement(SaveButton).Click();
            }
            catch (Exception)
            {
                Console.WriteLine($"Не удалось выполнить сохранение {TestDictionaryName}.Тест прерван.");
            }
        }

    }
    class DeleteCreatedElementAfterTest
    {
        public static void DeleteTourProgramsElementPageObject(By ButtonDeleteXPath, By ButtonCopyXPath, By expectedDeleteElementName, By confirmDeleted, IWebDriver driver)
        {
            string name = TestContext.CurrentContext.Test.MethodName;
            Console.WriteLine("Удаляем созданные записи");

            //проверка наличия кнопки удалить 
            try
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                wait.Until(ExpectedConditions.ElementToBeClickable(ButtonDeleteXPath));
            }
            catch (Exception)
            {
                Console.WriteLine("Кнопка удалить отсутствует. Тест прерван.");
                System.Threading.Thread.CurrentThread.Abort();
            }
            Console.WriteLine("Запуск цикла удаления созданных записей.");


            int zapisy = 1;
            while (zapisy > 0)
            {
                try
                {
                    /*для хром
                    Console.WriteLine("Прокручиваем страницу до кнопки удаления.");
                    IWebElement element = driver.FindElement(ButtonDeleteXPath);
                    Console.WriteLine("Сделал IWebElement element = driver.FindElement(ButtonDeleteXPath);.");
                    Actions action = new Actions(driver);
                    Console.WriteLine("Сделал Actions action = new Actions(driver);");
                    IAction toelement = action.MoveToElement(element);
                    Console.WriteLine("Сделал IAction toelement = action.MoveToElement(element);");
                    toelement.Perform();
                    Console.WriteLine("Сделал toelement.Perform();");
                    IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
                    js.ExecuteScript("document.querySelector(\"button.btn.btn-primary.btn-sm.btn-danger.btn-xs\").scrollIntoView(true)");*/
                    System.Threading.Thread.Sleep(1000);
                    Console.WriteLine("Нажать кнопку удалить.");
                    driver.FindElement(ButtonDeleteXPath).Click();
                    System.Threading.Thread.Sleep(1000);
                    Console.WriteLine("Нажать кнопку подтвердить удаление.");
                    driver.FindElement(confirmDeleted).Click();
                    System.Threading.Thread.Sleep(1000);
                    driver.Navigate().Refresh();
                    System.Threading.Thread.Sleep(6000);
                }
                catch (Exception)
                {
                    Console.WriteLine("Удаление не удалось. Тест прерван.");
                    System.Threading.Thread.CurrentThread.Abort();
                }
                try
                {
                    bool peremennaya = driver.FindElement(ButtonCopyXPath).Displayed;

                    zapisy = 1;
                }
                catch
                {
                    zapisy = 0;
                }

            }
            System.Threading.Thread.Sleep(1000);
            Console.WriteLine("Проверяем, что созданные ранее записи успешно удалены.");
            //проверяем отсутствие авиакомпаний в списке
            try
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                wait.Until(ExpectedConditions.InvisibilityOfElementLocated(expectedDeleteElementName));
                Console.WriteLine("Все записи успешно удалены.");
            }
            catch (Exception)
            {
                Console.WriteLine("Не все созданные записи удалены из справочника. Тест прерван.");
                System.Threading.Thread.CurrentThread.Abort();

            }
        }
    }

    class MainEditPageObject
    {
        private IWebDriver driver;
        private readonly By EditButton = By.XPath("//a[contains (text(),'Изменить')]");

        public MainEditPageObject(IWebDriver webDriver)
        {
            driver = webDriver;

        }
        //класс для проверки наличия кнопки изменить
        public bool EditButtonIs()
        {
            try
            {
                driver.FindElement(EditButton);
                return true;
            }
            catch
            {
                return false;
            }
        }


    }

    class CreateDogovorforPaymentSystemTest
    {
        //15.8
        public static string CreateDogovorforPaymentSystemAgencyTestAfter10DaysFromCurrentDate(IWebDriver driver)
        {
            string name = TestContext.CurrentContext.Test.MethodName;
            Console.WriteLine("Сохраняем текущую дату +10 дней в переменную");
            string tendaysaftercurrentDate = DateTime.Now.AddDays(10).ToShortDateString();
            Console.WriteLine("Формируем ссылку для перехода в корзину TourSearchClient");
            string link = ("http://supp-08.megatec.ru/TourSearchClient_mt15.8/Basket?departureCities=-1&destination=1_7202&tour=100001852&date=" + tendaysaftercurrentDate + "&duration=11&hotelScheme=1_10_9559_344_10760_0_11&adultCount=2&hotelQuota=5&aviaQuota=5&busTransferQuota=5&trainTransferQuota=5&serviceDescriptions=1_0_0_3_9559_46404_1_7202_1588_344_10760_1_10&currency=RUB");
            System.Threading.Thread.Sleep(5000);
            driver.Navigate().GoToUrl(link);
            System.Threading.Thread.Sleep(5000);
            Console.WriteLine("Проверяем загружена ли корзина.");
            try
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
                wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//button[@class='btn btn-lg btn-primary create-reservation-button']")));
            }
            catch (Exception)
            {
                Console.WriteLine("Корзина не загружена. Тест прерван.");
                System.Threading.Thread.CurrentThread.Abort();
            }
            Console.WriteLine("Заполняем форму данными туристов.");
            try
            {
                driver.FindElement(By.XPath("//div[@id='tourists']/div/div/div[1]/table/tbody/tr/td[3]/input")).Click();
                driver.FindElement(By.XPath("//div[@id='tourists']/div/div/div[1]/table/tbody/tr/td[3]/input")).SendKeys("EFREMOV");
                System.Threading.Thread.Sleep(5000);
                driver.FindElement(By.XPath("//div[@id='tourists']/div/div/div[1]/table/tbody/tr/td[4]/input")).Click();
                driver.FindElement(By.XPath("//div[@id='tourists']/div/div/div[1]/table/tbody/tr/td[4]/input")).SendKeys("ALEXANDER");
                System.Threading.Thread.Sleep(5000);
                driver.FindElement(By.XPath("//div[@id='tourists']/div/div/div[2]/table/tbody/tr/td[3]/input")).Click();
                driver.FindElement(By.XPath("//div[@id='tourists']/div/div/div[2]/table/tbody/tr/td[3]/input")).SendKeys("EFREMOV");
                System.Threading.Thread.Sleep(5000);
                driver.FindElement(By.XPath("//div[@id='tourists']/div/div/div[2]/table/tbody/tr/td[4]/input")).Click();
                driver.FindElement(By.XPath("//div[@id='tourists']/div/div/div[2]/table/tbody/tr/td[4]/input")).SendKeys("ALEXANDER");
                System.Threading.Thread.Sleep(5000);

            }
            catch (Exception)
            {
                Console.WriteLine("Не удалось заполнить форму. Тест прерван.");
                System.Threading.Thread.CurrentThread.Abort();
            }
            Console.WriteLine("Нажимаем кнопку забронировать.");
            try
            {
                driver.FindElement(By.XPath("//button[@class='btn btn-lg btn-primary create-reservation-button']")).Click();
                System.Threading.Thread.Sleep(10000);
            }
            catch (Exception)
            {
                Console.WriteLine("Не удалось нажать кнопку забронировать. Тест прерван.");
                System.Threading.Thread.CurrentThread.Abort();
            }
            try
            {
                driver.SwitchTo().Alert().Accept();
            }
            catch
            { }
            Console.WriteLine("Проверяем загружена ли страница MasterWeb после бронирования.");
            try
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
                wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//td/span[@id='ctl00_generalContent_TabContainer1_TabPanel1_lbDogovorCode']")));
            }
            catch (Exception)
            {
                Console.WriteLine("Страница не загружена. Тест прерван.");
                System.Threading.Thread.CurrentThread.Abort();
            }
            Console.WriteLine("Копируем и передаем в ответе метода номер путевки забронированной.");
            string orderNumber = driver.FindElement(By.XPath("//td/span[@id='ctl00_generalContent_TabContainer1_TabPanel1_lbDogovorCode']")).Text;
            return orderNumber;
        }
        public static string CreateDogovorforPaymentSystemPersonalTestAfter10DaysFromCurrentDate(IWebDriver driver)
        {
            string name = TestContext.CurrentContext.Test.MethodName;
            Console.WriteLine("Сохраняем текущую дату +10 дней в переменную");
            string tendaysaftercurrentDate = DateTime.Now.AddDays(10).ToShortDateString();
            Console.WriteLine("Формируем ссылку для перехода в корзину TourSearchClient");
            string link = ("http://supp-08.megatec.ru/TourSearchClient_mt15.8/Basket?departureCities=-1&destination=1_7202&tour=100001852&date=" + tendaysaftercurrentDate + "&duration=11&hotelScheme=1_10_9559_344_10760_0_11&adultCount=2&hotelQuota=5&aviaQuota=5&busTransferQuota=5&trainTransferQuota=5&serviceDescriptions=1_0_0_3_9559_46404_1_7202_1588_344_10760_1_10&currency=RUB");
            System.Threading.Thread.Sleep(5000);
            driver.Navigate().GoToUrl(link);
            System.Threading.Thread.Sleep(5000);
            Console.WriteLine("Проверяем загружена ли корзина.");
            try
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
                wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//button[@class='btn btn-lg btn-primary create-reservation-button']")));
            }
            catch (Exception)
            {
                Console.WriteLine("Корзина не загружена. Тест прерван.");
                System.Threading.Thread.CurrentThread.Abort();
            }
            Console.WriteLine("Заполняем форму данными туристов.");
            try
            {
                driver.FindElement(By.XPath("//div[@id='tourists']/div/div/div[2]/table/tbody/tr/td[3]/input")).Click();
                driver.FindElement(By.XPath("//div[@id='tourists']/div/div/div[2]/table/tbody/tr/td[3]/input")).SendKeys("EFREMOV");
                System.Threading.Thread.Sleep(5000);
                driver.FindElement(By.XPath("//div[@id='tourists']/div/div/div[2]/table/tbody/tr/td[4]/input")).Click();
                driver.FindElement(By.XPath("//div[@id='tourists']/div/div/div[2]/table/tbody/tr/td[4]/input")).SendKeys("ALEXANDER");
                System.Threading.Thread.Sleep(5000);
                driver.FindElement(By.XPath("//tr[@data-bind='visible: isShowAcceptsConditions() && isUpdateFinished()']/td/a[@href='/TourSearchClient_MT15.8/AgreementAccord.html']/preceding-sibling::input")).Click();
                System.Threading.Thread.Sleep(5000);
            }
            catch (Exception)
            {
                Console.WriteLine("Не удалось заполнить форму. Тест прерван.");
                System.Threading.Thread.CurrentThread.Abort();
            }
            Console.WriteLine("Нажимаем кнопку забронировать.");
            try
            {
                driver.FindElement(By.XPath("//button[@class='btn btn-lg btn-primary create-reservation-button']")).Click();
                System.Threading.Thread.Sleep(10000);
            }
            catch (Exception)
            {
                Console.WriteLine("Не удалось нажать кнопку забронировать. Тест прерван.");
                System.Threading.Thread.CurrentThread.Abort();
            }
            try
            {
                driver.SwitchTo().Alert().Accept();
            }
            catch
            { }
            Console.WriteLine("Проверяем загружена ли страница MasterWeb после бронирования.");
            try
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
                wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//td/span[@id='ctl00_generalContent_TabContainer1_TabPanel1_lbDogovorCode']")));
            }
            catch (Exception)
            {
                Console.WriteLine("Страница не загружена. Тест прерван.");
                System.Threading.Thread.CurrentThread.Abort();
            }
            Console.WriteLine("Копируем и передаем в ответе метода номер путевки забронированной.");
            string orderNumber = driver.FindElement(By.XPath("//td/span[@id='ctl00_generalContent_TabContainer1_TabPanel1_lbDogovorCode']")).Text;
            return orderNumber;
        }
        //МАСТЕРФИНАНС
        public static string MF_CreateDogovorforPaymentSystemAgencyTestAfter10DaysFromCurrentDate(IWebDriver driver)
        {
            string name = TestContext.CurrentContext.Test.MethodName;
            Console.WriteLine("Сохраняем текущую дату +10 дней в переменную");
            string tendaysaftercurrentDate = DateTime.Now.AddDays(10).ToShortDateString();
            Console.WriteLine("Формируем ссылку для перехода в корзину TourSearchClient с Мастер Финанс");
            string link = ("http://supp-08.megatec.ru/TourSearchClientMF/Basket?departureCities=-1&destination=1_1&tour=100006764&date=" + tendaysaftercurrentDate + "&duration=11&hotelScheme=1_10_233_802_12667_0_11&adultCount=2&hotelQuota=5&aviaQuota=5&busTransferQuota=7&trainTransferQuota=7&serviceDescriptions=1_0_0_3_233_25707_1_1_62_802_12667_1_10&currency=RUB");
            System.Threading.Thread.Sleep(5000);
            driver.Navigate().GoToUrl(link);
            System.Threading.Thread.Sleep(5000);
            Console.WriteLine("Проверяем загружена ли корзина.");
            try
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
                wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//button[@class='btn btn-lg btn-primary create-reservation-button']")));
            }
            catch (Exception)
            {
                Console.WriteLine("Корзина не загружена. Тест прерван.");
                System.Threading.Thread.CurrentThread.Abort();
            }
            Console.WriteLine("Заполняем форму данными туристов.");
            try
            {
                driver.FindElement(By.XPath("//div[@id='tourists']/div/div/div[1]/table/tbody/tr/td[3]/input")).Click();
                driver.FindElement(By.XPath("//div[@id='tourists']/div/div/div[1]/table/tbody/tr/td[3]/input")).SendKeys("EFREMOV");
                System.Threading.Thread.Sleep(5000);
                driver.FindElement(By.XPath("//div[@id='tourists']/div/div/div[1]/table/tbody/tr/td[4]/input")).Click();
                driver.FindElement(By.XPath("//div[@id='tourists']/div/div/div[1]/table/tbody/tr/td[4]/input")).SendKeys("ALEXANDER");
                System.Threading.Thread.Sleep(5000);
                driver.FindElement(By.XPath("//div[@id='tourists']/div/div/div[2]/table/tbody/tr/td[3]/input")).Click();
                driver.FindElement(By.XPath("//div[@id='tourists']/div/div/div[2]/table/tbody/tr/td[3]/input")).SendKeys("EFREMOV");
                System.Threading.Thread.Sleep(5000);
                driver.FindElement(By.XPath("//div[@id='tourists']/div/div/div[2]/table/tbody/tr/td[4]/input")).Click();
                driver.FindElement(By.XPath("//div[@id='tourists']/div/div/div[2]/table/tbody/tr/td[4]/input")).SendKeys("ALEXANDER");
                System.Threading.Thread.Sleep(5000);

            }
            catch (Exception)
            {
                Console.WriteLine("Не удалось заполнить форму. Тест прерван.");
                System.Threading.Thread.CurrentThread.Abort();
            }
            Console.WriteLine("Нажимаем кнопку забронировать.");
            try
            {
                driver.FindElement(By.XPath("//button[@class='btn btn-lg btn-primary create-reservation-button']")).Click();
                System.Threading.Thread.Sleep(10000);
            }
            catch (Exception)
            {
                Console.WriteLine("Не удалось нажать кнопку забронировать. Тест прерван.");
                System.Threading.Thread.CurrentThread.Abort();
            }
            try
            {
                driver.SwitchTo().Alert().Accept();
            }
            catch
            { }
            Console.WriteLine("Проверяем загружена ли страница MasterWeb после бронирования.");
            try
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
                wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//td/span[@id='ctl00_generalContent_TabContainer1_TabPanel1_lbDogovorCode']")));
            }
            catch (Exception)
            {
                Console.WriteLine("Страница не загружена. Тест прерван.");
                System.Threading.Thread.CurrentThread.Abort();
            }
            Console.WriteLine("Копируем и передаем в ответе метода номер путевки забронированной.");
            string orderNumber = driver.FindElement(By.XPath("//td/span[@id='ctl00_generalContent_TabContainer1_TabPanel1_lbDogovorCode']")).Text;
            return orderNumber;
        }
        public static string MF_CreateDogovorforPaymentSystemPersonalTestAfter10DaysFromCurrentDate(IWebDriver driver)
        {
            string name = TestContext.CurrentContext.Test.MethodName;
            Console.WriteLine("Сохраняем текущую дату +10 дней в переменную");
            string tendaysaftercurrentDate = DateTime.Now.AddDays(10).ToShortDateString();
            Console.WriteLine("Формируем ссылку для перехода в корзину TourSearchClient");
            string link = ("http://supp-08.megatec.ru/TourSearchClientMF/Basket?departureCities=-1&destination=1_1&tour=100006764&date=" + tendaysaftercurrentDate + "&duration=11&hotelScheme=1_10_233_802_12667_0_11&adultCount=2&hotelQuota=5&aviaQuota=5&busTransferQuota=7&trainTransferQuota=7&serviceDescriptions=1_0_0_3_233_25707_1_1_62_802_12667_1_10&currency=RUB");
            System.Threading.Thread.Sleep(5000);
            driver.Navigate().GoToUrl(link);
            System.Threading.Thread.Sleep(5000);
            Console.WriteLine("Проверяем загружена ли корзина.");
            try
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
                wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//button[@class='btn btn-lg btn-primary create-reservation-button']")));
            }
            catch (Exception)
            {
                Console.WriteLine("Корзина не загружена. Тест прерван.");
                System.Threading.Thread.CurrentThread.Abort();
            }
            Console.WriteLine("Заполняем форму данными туристов.");
            try
            {
                driver.FindElement(By.XPath("//div[@id='tourists']/div/div/div[2]/table/tbody/tr/td[3]/input")).Click();
                driver.FindElement(By.XPath("//div[@id='tourists']/div/div/div[2]/table/tbody/tr/td[3]/input")).SendKeys("EFREMOV");
                System.Threading.Thread.Sleep(5000);
                driver.FindElement(By.XPath("//div[@id='tourists']/div/div/div[2]/table/tbody/tr/td[4]/input")).Click();
                driver.FindElement(By.XPath("//div[@id='tourists']/div/div/div[2]/table/tbody/tr/td[4]/input")).SendKeys("ALEXANDER");
                System.Threading.Thread.Sleep(5000);
                driver.FindElement(By.XPath("//tr[@data-bind='visible: isShowAcceptsConditions() && isUpdateFinished()']/td/a[@href='/TourSearchClientMF/AgreementAccord.html']/preceding-sibling::input")).Click();
                System.Threading.Thread.Sleep(5000);
            }
            catch (Exception)
            {
                Console.WriteLine("Не удалось заполнить форму. Тест прерван.");
                System.Threading.Thread.CurrentThread.Abort();
            }
            Console.WriteLine("Нажимаем кнопку забронировать.");
            try
            {
                driver.FindElement(By.XPath("//button[@class='btn btn-lg btn-primary create-reservation-button']")).Click();
                System.Threading.Thread.Sleep(10000);
            }
            catch (Exception)
            {
                Console.WriteLine("Не удалось нажать кнопку забронировать. Тест прерван.");
                System.Threading.Thread.CurrentThread.Abort();
            }
            try
            {
                driver.SwitchTo().Alert().Accept();
            }
            catch
            { }
            Console.WriteLine("Проверяем загружена ли страница MasterWeb после бронирования.");
            try
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
                wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//td/span[@id='ctl00_generalContent_TabContainer1_TabPanel1_lbDogovorCode']")));
            }
            catch (Exception)
            {
                Console.WriteLine("Страница не загружена. Тест прерван.");
                System.Threading.Thread.CurrentThread.Abort();
            }
            Console.WriteLine("Копируем и передаем в ответе метода номер путевки забронированной.");
            string orderNumber = driver.FindElement(By.XPath("//td/span[@id='ctl00_generalContent_TabContainer1_TabPanel1_lbDogovorCode']")).Text;
            return orderNumber;
        }


    }

    class PaymentsOnPaymentGateway
    {
        //редактируем сумму и проверяем комиссию
        public static void EditSummPayments(string PaymentsSum, string expectedComission, IWebDriver driver)
        {
            string name = TestContext.CurrentContext.Test.MethodName;
            Console.WriteLine("Редактируем сумму к оплате");
            driver.FindElement(By.XPath("//input[@class='text - box single - line right - align valid']")).Clear();
            System.Threading.Thread.Sleep(5000);
            driver.FindElement(By.XPath("//input[@class='text - box single - line right - align valid']")).SendKeys(PaymentsSum);
            System.Threading.Thread.Sleep(5000);
            Console.WriteLine("Проверяем, что сумма комиссии соответствует расчетной");
            if (driver.FindElement(By.Id("DogovorFeeSumm")).Text == expectedComission)
            {
                Console.WriteLine("Комиссия корректна");
            }
            else
            {
                Console.WriteLine("Комиссия рассчитана неверно. Тест прерван.");
                System.Threading.Thread.CurrentThread.Abort();
            }


        }

        public static void TinkoffPaymentsGateway(IWebDriver driver, string debt)
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            string name = TestContext.CurrentContext.Test.MethodName;
            Console.WriteLine("Открываем платежный шлюз Tinkoff.");
            try
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));
                wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//TUI-SVG[@automation-id='header__logo']")));
            }
            catch (Exception)
            {
                Console.WriteLine("Страница платежного шлюза не открылась. Тест прерван.");
                System.Threading.Thread.CurrentThread.Abort();
            }
            Console.WriteLine("Страница платежного шлюза загрузилась успешно.");
            try
            {
                Console.WriteLine("CardNumber");
                driver.FindElement(By.XPath("//input[@automation-id='tui-input-card-grouped__card']")).SendKeys("4300000000000777");
                System.Threading.Thread.Sleep(2000);
                Console.WriteLine("ExpireDate");
                driver.FindElement(By.XPath("//input[@automation-id='tui-input-card-grouped__expire']")).SendKeys("1122");
                System.Threading.Thread.Sleep(2000);
                Console.WriteLine("CVV");
                driver.FindElement(By.XPath("//input[@automation-id='tui-input-card-grouped__cvc']")).SendKeys("111");
                System.Threading.Thread.Sleep(2000);
                Console.WriteLine("Квитанция не нужна");
                driver.FindElement(By.XPath("//input[@automation-id='tui-checkbox__native']")).Click();
                System.Threading.Thread.Sleep(2000);
                Console.WriteLine("Оплатить");
                driver.FindElement(By.XPath("//span/span[contains (text(),'Оплатить')]")).Click();
            }
            catch (Exception)
            {
                Console.WriteLine("Не удалось заполнить данные карты. Тест прерван.");
                System.Threading.Thread.CurrentThread.Abort();
            }
            try
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));
                wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//tr/td[2]/span[@id='ctl00_generalContent_TabContainer1_TabPanel1_lbDeptSum']")));
            }
            catch (Exception)
            {
                Console.WriteLine("Страница MasterWeb не открылась. Тест прерван.");
                System.Threading.Thread.CurrentThread.Abort();
            }
            string zadolwennost = driver.FindElement(By.XPath("//tr/td[2]/span[@id='ctl00_generalContent_TabContainer1_TabPanel1_lbDeptSum']")).Text;
            if (zadolwennost == debt)
            {
                Console.WriteLine("Платеж успешно проведен.");
            }
            else
            {
                Console.WriteLine("Платеж не прошел. Тест прерван");
                System.Threading.Thread.CurrentThread.Abort();
            }

        }

        public static void UnitellerPaymentsGateway(IWebDriver driver, string debt)
        {

            string name = TestContext.CurrentContext.Test.MethodName;
            Console.WriteLine("Открываем платежный шлюз Uniteller.");
            try
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
                wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//img[@alt='Uniteller']")));
            }
            catch (Exception)
            {
                Console.WriteLine("Страница платежного шлюза не открылась. Тест прерван.");
                System.Threading.Thread.CurrentThread.Abort();
            }
            Console.WriteLine("Страница платежного шлюза загрузилась успешно.");
            try
            {
                driver.FindElement(By.Id("Pan")).SendKeys("4000000000002487");
                System.Threading.Thread.Sleep(1000);
                driver.FindElement(By.Id("ExpDate")).SendKeys("0123");
                System.Threading.Thread.Sleep(1000);
                driver.FindElement(By.Id("Cvc2")).SendKeys("123");
                System.Threading.Thread.Sleep(5000);
                driver.FindElement(By.Id("btnPay")).Click();
                System.Threading.Thread.Sleep(10000);
            }

            catch (Exception)
            {
                Console.WriteLine("Не удалось заполнить данные карты. Тест прерван.");
                System.Threading.Thread.CurrentThread.Abort();
            }
            try
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
                wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//button[contains (text(),'Вернуться в магазин')]")));
            }
            catch (Exception)
            {
                Console.WriteLine("Кнопка возврата после оплаты в личный кабинет отсутсвует. Тест прерван.");
                System.Threading.Thread.CurrentThread.Abort();
            }
            driver.FindElement(By.XPath("//button[contains (text(),'Вернуться в магазин')]")).Click();
            try
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));
                wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("ctl00_generalContent_TabContainer1_TabPanel1_lbDeptSum")));
            }
            catch (Exception)
            {
                Console.WriteLine("Страница MasterWeb не загружена. Тест прерван.");
                System.Threading.Thread.CurrentThread.Abort();
            }
            string zadolwennost = driver.FindElement(By.Id("ctl00_generalContent_TabContainer1_TabPanel1_lbDeptSum")).Text;
            System.Threading.Thread.Sleep(1000);
            if (zadolwennost == debt)
            {
                Console.WriteLine("Платеж успешно проведен.");
            }
            else
            {
                Console.WriteLine("Платеж не прошел. Тест прерван");
                System.Threading.Thread.CurrentThread.Abort();
            }

        }

        public static void AlfabankPaymentsGateway(IWebDriver driver, string debt)
        {
            string name = TestContext.CurrentContext.Test.MethodName;
            Console.WriteLine("Открываем платежный шлюз Alfabank.");
            try
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
                wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//span[@aria-label='Альфа-Банк']")));
            }
            catch (Exception)
            {
                Console.WriteLine("Страница платежного шлюза не открылась. Тест прерван.");
                System.Threading.Thread.CurrentThread.Abort();
            }
            Console.WriteLine("Страница платежного шлюза загрузилась успешно.");
            try
            {
                driver.FindElement(By.Id("cardccnumber")).SendKeys("0000000000000000");
                System.Threading.Thread.Sleep(1000);
                driver.FindElement(By.Id("expiredate")).SendKeys("0000");
                System.Threading.Thread.Sleep(1000);
                driver.FindElement(By.Id("cvv_label")).SendKeys("123");
                System.Threading.Thread.Sleep(1000);
                driver.FindElement(By.Id("cardholder")).SendKeys("alex ivanov");
                System.Threading.Thread.Sleep(1000);
                driver.FindElement(By.Id("go_purchase")).Click();
                System.Threading.Thread.Sleep(1000);
            }
            catch (Exception)
            {
                Console.WriteLine("Не удалось заполнить данные карты. Тест прерван.");
                System.Threading.Thread.CurrentThread.Abort();
            }
            string zadolwennost = driver.FindElement(By.Id("ctl00_generalContent_TabContainer1_TabPanel1_lbDeptSum")).Text;
            System.Threading.Thread.Sleep(10000);
            if (zadolwennost == debt)
            {
                Console.WriteLine("Платеж успешно проведен.");
            }
            else
            {
                Console.WriteLine("Платеж не прошел. Тест прерван");
                System.Threading.Thread.CurrentThread.Abort();
            }

        }

        public static void SberbankPaymentsGateway(IWebDriver driver, string debt)
        {
            string name = TestContext.CurrentContext.Test.MethodName;
            Console.WriteLine("Открываем платежный шлюз Sberbank.");
            try
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
                wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//div[@class='sberid-button-mount']")));
            }
            catch (Exception)
            {
                Console.WriteLine("Страница платежного шлюза не открылась. Тест прерван.");
                System.Threading.Thread.CurrentThread.Abort();
            }
            Console.WriteLine("Страница платежного шлюза загрузилась успешно.");
            try
            {
                driver.FindElement(By.Id("pan")).SendKeys("4111111111111111");
                System.Threading.Thread.Sleep(1000);
                driver.FindElement(By.Id("expiry")).SendKeys("1224");
                System.Threading.Thread.Sleep(1000);
                driver.FindElement(By.Id("cvc")).SendKeys("123");
                System.Threading.Thread.Sleep(1000);
                driver.FindElement(By.XPath("//*[@data-test-id='submit-payment']")).Click();
                System.Threading.Thread.Sleep(10000);
            }
            catch (Exception)
            {
                Console.WriteLine("Не удалось заполнить данные карты. Тест прерван.");
                System.Threading.Thread.CurrentThread.Abort();
            }
            driver.FindElement(By.Id("password")).SendKeys("12345678");
            try
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));
                wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("ctl00_generalContent_TabContainer1_TabPanel1_lbDeptSum")));
            }
            catch (Exception)
            {
                Console.WriteLine("Страница MasterWeb не открылась. Тест прерван.");
                System.Threading.Thread.CurrentThread.Abort();
            }
            string zadolwennost = driver.FindElement(By.Id("ctl00_generalContent_TabContainer1_TabPanel1_lbDeptSum")).Text;
            System.Threading.Thread.Sleep(1000);
            if (zadolwennost == debt)
            {
                Console.WriteLine("Платеж успешно проведен.");
            }
            else
            {
                Console.WriteLine("Платеж не прошел. Тест прерван");
                System.Threading.Thread.CurrentThread.Abort();
            }

        }

        public static void PayOnlinePaymentsGateway(IWebDriver driver, string debt)
        {
            string name = TestContext.CurrentContext.Test.MethodName;
            Console.WriteLine("Открываем платежный шлюз PayOnline.");
            try
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
                wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//img[@alt='Payonline']")));
            }
            catch (Exception)
            {
                Console.WriteLine("Страница платежного шлюза не открылась. Тест прерван.");
                System.Threading.Thread.CurrentThread.Abort();
            }
            Console.WriteLine("Страница платежного шлюза загрузилась успешно.");
            try
            {
                driver.FindElement(By.Id("ctl00_content_cardForm_cardTypeVisa")).Click();
                System.Threading.Thread.Sleep(1000);
                driver.FindElement(By.Id("ctl00_content_cardForm_cardNumberA")).SendKeys("4111");
                System.Threading.Thread.Sleep(1000);
                driver.FindElement(By.Id("ctl00_content_cardForm_cardNumberB")).SendKeys("1111");
                System.Threading.Thread.Sleep(1000);
                driver.FindElement(By.Id("ctl00_content_cardForm_cardNumberC")).SendKeys("1111");
                System.Threading.Thread.Sleep(1000);
                driver.FindElement(By.Id("ctl00_content_cardForm_cardNumberD")).SendKeys("1111");
                System.Threading.Thread.Sleep(1000);
                driver.FindElement(By.Id("ctl00_content_cardForm_expirationDateMonth")).Click();
                System.Threading.Thread.Sleep(1000);
                driver.FindElement(By.XPath("//select[@id='ctl00_content_cardForm_expirationDateMonth']/option[2]")).Click();
                System.Threading.Thread.Sleep(1000);
                driver.FindElement(By.Id("ctl00_content_cardForm_expirationDateYear")).Click();
                System.Threading.Thread.Sleep(1000);
                driver.FindElement(By.XPath("//select[@id='ctl00_content_cardForm_expirationDateYear']/option[5]")).Click();
                System.Threading.Thread.Sleep(1000);
                driver.FindElement(By.Id("ctl00_content_cardForm_cardHolderName")).SendKeys("alexander ivanov");
                System.Threading.Thread.Sleep(1000);
                driver.FindElement(By.Id("ctl00_content_cardForm_cardCVC")).SendKeys("999");
                System.Threading.Thread.Sleep(1000);
                driver.FindElement(By.Id("ctl00_content_cardForm_email")).SendKeys("example@example.com");
                System.Threading.Thread.Sleep(1000);
                driver.FindElement(By.Id("ctl00_content_cardForm_commandProcess")).Click();
                System.Threading.Thread.Sleep(10000);
            }
            catch (Exception)
            {
                Console.WriteLine("Не удалось заполнить данные карты. Тест прерван.");
                System.Threading.Thread.CurrentThread.Abort();
            }
            driver.FindElement(By.XPath("//input[@type='submit']")).Click();
            System.Threading.Thread.Sleep(5000);
            driver.FindElement(By.XPath("//p[@class='continue']/a")).Click();
            try
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
                wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("ctl00_generalContent_TabContainer1_TabPanel1_lbDeptSum")));
            }
            catch (Exception)
            {
                Console.WriteLine("Страница MasterWeb не открылась. Тест прерван.");
                System.Threading.Thread.CurrentThread.Abort();
            }
            string zadolwennost = driver.FindElement(By.Id("ctl00_generalContent_TabContainer1_TabPanel1_lbDeptSum")).Text;
            System.Threading.Thread.Sleep(1000);
            if (zadolwennost == debt)
            {
                Console.WriteLine("Платеж успешно проведен.");
            }
            else
            {
                Console.WriteLine("Платеж не прошел. Тест прерван");
                System.Threading.Thread.CurrentThread.Abort();
            }

        }

        public static void AssistPaymentsGateway(IWebDriver driver, string debt)
        {
            string name = TestContext.CurrentContext.Test.MethodName;
            Console.WriteLine("Открываем платежный шлюз Assist.");
            try
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
                wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("AssistLogo_right")));
            }
            catch (Exception)
            {
                Console.WriteLine("Страница платежного шлюза не открылась. Тест прерван.");
                System.Threading.Thread.CurrentThread.Abort();
            }
            Console.WriteLine("Страница платежного шлюза загрузилась успешно.");
            try
            {
                driver.FindElement(By.Id("Firstname")).SendKeys("Александр");
                System.Threading.Thread.Sleep(1000);
                driver.FindElement(By.Id("Lastname")).SendKeys("Иванов");
                System.Threading.Thread.Sleep(1000);
                driver.FindElement(By.Id("Email")).SendKeys("example@example.ru");
                System.Threading.Thread.Sleep(1000);
                driver.FindElement(By.XPath("//input[@name='Submit_Card_1']")).Click();
                System.Threading.Thread.Sleep(5000);
                driver.FindElement(By.Id("CardNumber")).SendKeys("4111 1111 1111 1111");
                System.Threading.Thread.Sleep(1000);
                driver.FindElement(By.Id("ExpireMonth")).SendKeys("12");
                System.Threading.Thread.Sleep(1000);
                driver.FindElement(By.Id("ExpireYear")).SendKeys("25");
                System.Threading.Thread.Sleep(1000);
                driver.FindElement(By.Id("Cardholder")).SendKeys("alexander ivanov");
                System.Threading.Thread.Sleep(1000);
                driver.FindElement(By.Id("CVC2")).SendKeys("123");
                System.Threading.Thread.Sleep(1000);
                driver.FindElement(By.Id("button_pay")).Click();
                System.Threading.Thread.Sleep(5000);
            }
            catch (Exception)
            {
                Console.WriteLine("Не удалось заполнить данные карты. Тест прерван.");
                System.Threading.Thread.CurrentThread.Abort();
            }
            driver.FindElement(By.XPath("//input[@value='Вернуться в магазин']")).Click();
            try
            {
                driver.SwitchTo().Alert().Accept();
            }
            catch
            { }
            System.Threading.Thread.Sleep(5000);
            //driver.FindElement(By.Id("proceed-button")).Click();
            try
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
                wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("ctl00_generalContent_TabContainer1_TabPanel1_lbDeptSum")));
            }
            catch (Exception)
            {
                Console.WriteLine("Страница MasterWeb не открылась. Тест прерван.");
                System.Threading.Thread.CurrentThread.Abort();
            }
            System.Threading.Thread.Sleep(5000);
            string zadolwennost = driver.FindElement(By.Id("ctl00_generalContent_TabContainer1_TabPanel1_lbDeptSum")).Text;
            System.Threading.Thread.Sleep(1000);
            if (zadolwennost == debt)
            {
                Console.WriteLine("Платеж успешно проведен.");
            }
            else
            {
                Console.WriteLine("Платеж не прошел. Тест прерван");
                System.Threading.Thread.CurrentThread.Abort();
            }

        }

        public static void WebPayPaymentsGateway(IWebDriver driver)
        {
            string name = TestContext.CurrentContext.Test.MethodName;
            Console.WriteLine("Открываем платежный шлюз WebPay.");
            Console.WriteLine("Нажимаем кнопку оплатить на шлюзе WebPay.");
            try
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
                wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//input[@value='Оплатить']")));
                driver.FindElement(By.XPath("//input[@value='Оплатить']")).Click();
                System.Threading.Thread.Sleep(2000);
            }
            catch (Exception)
            {
                Console.WriteLine("Кнопка оплатить не прогрузилась. Тест прерван.");
                System.Threading.Thread.CurrentThread.Abort();
            }
            try
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
                wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//img[@alt='logo']")));
            }
            catch (Exception)
            {
                Console.WriteLine("Страница платежного шлюза не открылась. Тест прерван.");
                System.Threading.Thread.CurrentThread.Abort();
            }
            Console.WriteLine("Страница платежного шлюза загрузилась успешно.");
            try
            {
                driver.FindElement(By.Id("cc_month")).SendKeys("05");
                System.Threading.Thread.Sleep(1000);
                driver.FindElement(By.Id("cc_year")).SendKeys("25");
                System.Threading.Thread.Sleep(1000);
                driver.FindElement(By.Id("cc_name")).SendKeys("TEST TESTOV");
                System.Threading.Thread.Sleep(1000);
                driver.FindElement(By.Id("cc_cvv")).SendKeys("123");
                System.Threading.Thread.Sleep(1000);
                driver.FindElement(By.Id("cc_email")).SendKeys("example@example.ru");
                System.Threading.Thread.Sleep(1000);
                driver.FindElement(By.Id("payBtn")).Click();
            }
            catch (Exception)
            {
                Console.WriteLine("Не удалось заполнить данные карты. Тест прерван.");
                System.Threading.Thread.CurrentThread.Abort();
            }
            try
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));
                wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("showReturnButtonSuccess")));
            }
            catch (Exception)
            {
                Console.WriteLine("Не произошел переход на страницу возврата. Тест прерван.");
                System.Threading.Thread.CurrentThread.Abort();
            }
            driver.FindElement(By.Id("showReturnButtonSuccess")).Click();
            System.Threading.Thread.Sleep(5000);
            //string zadolwennost = driver.FindElement(By.Id("ctl00_generalContent_TabContainer1_TabPanel1_lbDeptSum")).Text;
            //System.Threading.Thread.Sleep(1000);
            //if (zadolwennost == "0 рб (0,00 рб)")
            // {
            //    Console.WriteLine("Платеж успешно проведен.");
            //}
            //else
            //{
            //    Console.WriteLine("Платеж не прошел. Тест прерван");
            //   System.Threading.Thread.CurrentThread.Abort();
            //}

        }

    }

    class MasterWeb
    {
        public static void OrderNumberToMasterWebToEntryPoint(IWebDriver driver, string orderNumber, string PaymentSystemName, By PaymentSystemLocationOnEntryPoint, int PartPay, string MasterWebURL)
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            Console.WriteLine("Ожидаем открытия страницы MasterWeb.");
            driver.Navigate().GoToUrl(MasterWebURL);
            try
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
                wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("ctl00_generalContent_TabContainer1_TabPanel1_orderListControl_orderListFilter_txtToSearch")));
            }
            catch (Exception)
            {

                Console.WriteLine("Не удалось открыть MasterWeb. Тест прерван.");

            }
            Console.WriteLine("Страница загружена.");
            try
            {
                Console.WriteLine($"Вводим номер {orderNumber} в форму поиска путевки.");
                driver.FindElement(By.Id("ctl00_generalContent_TabContainer1_TabPanel1_orderListControl_orderListFilter_txtToSearch")).SendKeys(orderNumber);
                Console.WriteLine("Нажимаем кнопку поиска путевки по номеру.");
                driver.FindElement(By.Id("ctl00_generalContent_TabContainer1_TabPanel1_orderListControl_orderListFilter_btnSearch")).Click();
                Console.WriteLine($"Нажимаем на кнопку путевки {orderNumber}."); ;
                driver.FindElement(By.Id("ctl00_generalContent_TabContainer1_TabPanel1_orderListControl_ordersTable_ctl02_lnkOrderCode")).Click();
            }
            catch (Exception)
            {
                Console.WriteLine("Тест прерван.");
            }

            Console.WriteLine("Нажимаем на кнопку Оплатить.");
            try
            {
                driver.FindElement(By.Id("ctl00_generalContent_TabContainer1_TabPanel1_btnPayment")).Click();
                Console.WriteLine("Ожидаем открытия страницы EntryPoint.");
            }
            catch (Exception)
            {
                Console.WriteLine("Тест прерван.");
            }
            try
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
                wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//legend[contains (text(),'Способ оплаты')]")));
            }
            catch (Exception)
            {
                Console.WriteLine("Страница выбора способа оплат не загружена. Тест прерван.");
                //если на этом этапе падает ошибка, то тест запустится еще раз

            }
            Console.WriteLine("Страница выбора способа оплат загружена.");
            Console.WriteLine($"Нажимаем на кнопку платежной системы {PaymentSystemName}.");
            try
            {
                driver.FindElement(PaymentSystemLocationOnEntryPoint).Click();
            }
            catch (Exception)
            {
                Console.WriteLine("Не удалось нажать на кнопку платежной системы. Тест прерван.");
            }
            if (PartPay != 0)
            {
                string PartPayForm = PartPay.ToString();
                Console.WriteLine("Редактируем сумму к оплате.");
                driver.FindElement(By.Id("DogovorPaySumm")).Clear();
                driver.FindElement(By.Id("DogovorPaySumm")).SendKeys(PartPayForm);
                Console.WriteLine("Нажимаем на кнопку Оплатить.");
                driver.FindElement(By.XPath("//input[@value='Оплатить']")).Click();
            }
            else
            {
                Console.WriteLine("Нажимаем на кнопку Оплатить.");
                driver.FindElement(By.XPath("//input[@value='Оплатить']")).Click();
            }
            Console.WriteLine("Переходим на платежный шлюз.");
        }

    }
}
