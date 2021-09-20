using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;
using System.Collections.Generic;
using System.Collections;

namespace E2Etest
{
    public class SetUP
    {
       
            IWebDriver driver;

            [SetUp]
            public void startBrowser()
            {
                driver = new ChromeDriver(@"C:\Users\Kiruthiga.Ganesan\source\repos\qa-tech-test");
                driver.Url = "http://localhost:3000/";
        }

            [Test]
            public void Test()
            {

            //Click the Render the Challenge button
           driver.FindElement(By.XPath("//button[@data-test-id='render-challenge']")).Click();


            //Get the list of values
            IList<IWebElement> tdelement = driver.FindElements(By.XPath("//td[contains(@data-test-id, 'array-item-1')]"));
            IList<IWebElement> tdelement2 = driver.FindElements(By.XPath("//td[contains(@data-test-id, 'array-item-2')]"));
            IList<IWebElement> tdelement3 = driver.FindElements(By.XPath("//td[contains(@data-test-id, 'array-item-3')]"));

            ArrayList rowelement = new ArrayList();
            ArrayList rowelement2 = new ArrayList();
            ArrayList rowelement3 = new ArrayList();

            foreach (var item in tdelement)
            {
                rowelement.Add(item.GetAttribute("innerHTML"));
            }
            foreach (var item in tdelement2)
            {
                rowelement2.Add(item.GetAttribute("innerHTML"));
            }
            foreach (var item in tdelement3)
            {
                rowelement3.Add(item.GetAttribute("innerHTML"));
            }

            for (int i = 0; i < rowelement.Count; i++)
            {

                int lhs, lhs1, lhs2;
                lhs = lhs1 = lhs2 = 0;
                int rhs, rhs1, rhs2;
                rhs = rhs1 = rhs2 = 0;
                int arrayvalue,arrayvalue1,arrayvalue2 = 0;
                for (int j = 0; j < i; j++)
                {
                    arrayvalue = int.Parse((string)rowelement[j]);
                    arrayvalue1 = int.Parse((string)rowelement2[j]);
                    arrayvalue2 = int.Parse((string)rowelement3[j]);
                    lhs += arrayvalue;
                    lhs1 += arrayvalue1;
                    lhs2 += arrayvalue2;
                }
                for (int k = (i + 1); k < rowelement.Count; k++)
                {
                    arrayvalue = int.Parse((string)rowelement[k]);
                    arrayvalue1 = int.Parse((string)rowelement2[k]);
                    arrayvalue2 = int.Parse((string)rowelement3[k]);
                    rhs += arrayvalue;
                    rhs1 += arrayvalue1;
                    rhs2 += arrayvalue2;
                }
                if (lhs == rhs)
                {
                    Console.WriteLine("The index value is:" + i);
                    string indexvalue =i.ToString();

                    driver.FindElement(By.XPath("//input[@data-test-id='submit-1']")).SendKeys(indexvalue);
                }
                if (lhs1 == rhs1)
                {
                    Console.WriteLine("The index value is:" + i);
                    string indexvalue = i.ToString();

                    driver.FindElement(By.XPath("//input[@data-test-id='submit-2']")).SendKeys(indexvalue);
                }

                if (lhs2 == rhs2)
                {

                    string indexvalue = i.ToString();

                    driver.FindElement(By.XPath("//input[@data-test-id='submit-3']")).SendKeys(indexvalue);
                }

            }
            //Enter my name
            driver.FindElement(By.XPath("//input[@data-test-id='submit-4']")).SendKeys("Kiruthiga Ganesan");
            //Click on Submit button
            driver.FindElement(By.XPath("//button[@tabindex='0']/div/div/span[contains(text(),'Submit')]")).Click();



        }
        [TearDown]
        public void closeBrowser()
        {
            driver.Close();
        }


    }
    }



