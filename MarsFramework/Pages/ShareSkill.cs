using AutoIt;
using MarsFramework.Global;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Policy;
using System.Threading;

namespace MarsFramework.Pages
{
    class ShareSkill
    {
        public ShareSkill()
        {
            PageFactory.InitElements(Global.GlobalDefinitions.driver, this);
        }

        //static String Path = System.Reflection.Assembly.GetCallingAssembly().CodeBase;
        //static String ActualPath = Path.Substring(0, Path.LastIndexOf("bin"));
        //String ProjectPath = new Url(ActualPath).;

        //Click on ShareSkill Button
        [FindsBy(How = How.LinkText, Using = "Share Skill")]
        private IWebElement ShareSkillButton { get; set; }

        //Enter the Title in textbox
        [FindsBy(How = How.Name, Using = "title")]
        private IWebElement Title { get; set; }

        //Generate unique description using current timestamp
        internal String TimeStamp = (DateTime.Now.ToString("yyyyMMddHHmmssfff"));

        //Enter the Description in textbox
        [FindsBy(How = How.Name, Using = "description")]
        private IWebElement Description { get; set; }

        //Click on Category Dropdown
        [FindsBy(How = How.Name, Using = "categoryId")]
        private IWebElement CategoryDropDown { get; set; }

        //Click on SubCategory Dropdown
        [FindsBy(How = How.Name, Using = "subcategoryId")]
        private IWebElement SubCategoryDropDown { get; set; }

        //Enter Tag names in textbox
        [FindsBy(How = How.XPath, Using = "//body/div/div/div[@id='service-listing-section']/div[contains(@class,'ui container')]/div[contains(@class,'listing')]/form[contains(@class,'ui form')]/div[contains(@class,'tooltip-target ui grid')]/div[contains(@class,'twelve wide column')]/div[contains(@class,'')]/div[contains(@class,'ReactTags__tags')]/div[contains(@class,'ReactTags__selected')]/div[contains(@class,'ReactTags__tagInput')]/input[1]")]
        private IWebElement Tags { get; set; }

        //Select the Service type
        [FindsBy(How = How.XPath, Using = "//form/div[5]/div[@class='twelve wide column']/div/div/div/input")]
        private IList<IWebElement> ServiceTypeOptions { get; set; }

        //Select the Location Type
        [FindsBy(How = How.XPath, Using = "//form/div[6]/div[@class='twelve wide column']/div/div/div/input")]
        private IList<IWebElement> LocationTypeOption { get; set; }

        //Click on Start Date dropdown
        [FindsBy(How = How.Name, Using = "startDate")]
        private IWebElement StartDateDropDown { get; set; }

        //Click on End Date dropdown
        [FindsBy(How = How.Name, Using = "endDate")]
        private IWebElement EndDateDropDown { get; set; }

        //Storing the table of available days
        [FindsBy(How = How.XPath, Using = "//body/div/div/div[@id='service-listing-section']/div[@class='ui container']/div[@class='listing']/form[@class='ui form']/div[7]/div[2]/div[1]/div/div/div/input")]
        private IList<IWebElement> Days { get; set; }

        //Storing the starttime
        [FindsBy(How = How.XPath, Using = "//*[@id='service-listing-section']/div[2]/div/form/div[7]/div[2]/div/div/div[2]/input")]
        private IList<IWebElement> StartTime { get; set; }

        //Click on StartTime dropdown
        [FindsBy(How = How.XPath, Using = "//*[@id='service-listing-section']/div[2]/div/form/div[7]/div[2]/div/div/div[2]/input")]
        private IList<IWebElement> StartTimeDropDown { get; set; }

        //Click on EndTime dropdown
        [FindsBy(How = How.XPath, Using = "//*[@id='service-listing-section']/div[2]/div/form/div[7]/div[2]/div/div/div[3]/input")]
        private IList<IWebElement> EndTimeDropDown { get; set; }

        //Click on Skill Trade option
        [FindsBy(How = How.XPath, Using = "//form/div[8]/div[@class='twelve wide column']/div/div/div/input")]
        private IList<IWebElement> SkillTradeOption { get; set; }

        //Enter Skill Exchange
        [FindsBy(How = How.XPath, Using = "//div[@class='form-wrapper']//input[@placeholder='Add new tag']")]
        private IWebElement SkillExchange { get; set; }

        //Enter the amount for Credit
        [FindsBy(How = How.XPath, Using = "//input[@placeholder='Amount']")]
        private IWebElement CreditAmount { get; set; }

        //Click on Active/Hidden option
        [FindsBy(How = How.XPath, Using = "//form/div[10]/div[@class='twelve wide column']/div/div/div/input")]
        private IList<IWebElement> ActiveOption { get; set; }

        //Add Work sample file option
        [FindsBy(How = How.XPath, Using = "//*[@id='service-listing-section']/div[2]/div/form/div[9]/div/div[2]/section/div/label/div/span/i")]
        private IWebElement FileAdd { get; set; }

        //Click on Save button
        [FindsBy(How = How.XPath, Using = "//input[@value='Save']")]
        private IWebElement Save { get; set; }

        internal void EnterShareSkill()
        {
            //Populate the excel data
            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPathShareSkill, "ShareSkill");

            //Waiting for Profile page to load
            GlobalDefinitions.WaitForElement(GlobalDefinitions.driver, By.LinkText("Share Skill"), 10);

            //Click on Share Skill button
            ShareSkillButton.Click();

            //Waiting for Share Skill page to load
            GlobalDefinitions.WaitForElement(GlobalDefinitions.driver, By.Name("title"), 10);

            //Enter Title
            Title.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Title") + TimeStamp);

            //Enter Description
            Description.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Description"));

            //Select Category from DropDown
            CategoryDropDown.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Category"));

            //Select SubCategory from DropDown
            SubCategoryDropDown.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "SubCategory"));

            //Enter Tags
            Tags.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Tags") + Keys.Enter);

            //Select ServiceType from Option
            switch ((GlobalDefinitions.ExcelLib.ReadData(2, "ServiceType")))
            {
                case "Hourly basis service":
                    //Select Hourly basis service from options
                    ServiceTypeOptions[0].Click();
                    break;

                case "One-off service":
                    //Select One-off service from options
                    ServiceTypeOptions[1].Click();
                    break;
            }

            //Select LocationType from Option
            switch ((GlobalDefinitions.ExcelLib.ReadData(2, "LocationType")))
            {
                case "On-site":
                    //Select On-site from location options
                    LocationTypeOption[0].Click();
                    break;

                case "Online":
                    //Select Online from location options
                    LocationTypeOption[1].Click();
                    break;
            }

            //Enter StartDate from DropDown
            StartDateDropDown.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Startdate"));

            //Enter EndDate from DropDown
            EndDateDropDown.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Enddate"));

            //Select Days and enter Start and End time
            if ((GlobalDefinitions.ExcelLib.ReadData(2, "Selectday")) == "Sun")
            {
                //Select Sunday
                Days[0].Click();
                //Enter StartTime from DropDown
                StartTimeDropDown[1].SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Starttime"));
                //Enter EndTime from DropDown
                EndTimeDropDown[0].SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Endtime"));
            }
            else if ((GlobalDefinitions.ExcelLib.ReadData(2, "Selectday")) == "Mon")
            {
                //Select Monday
                Days[1].Click();
                //Enter StartTime from DropDown
                StartTimeDropDown[2].SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Starttime"));
                //Enter EndTime from DropDown
                EndTimeDropDown[1].SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Endtime"));
            }
            else if ((GlobalDefinitions.ExcelLib.ReadData(2, "Selectday")) == "Tue")
            {
                //Select Tuesday
                Days[2].Click();
                //Enter StartTime from DropDown
                StartTimeDropDown[3].SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Starttime"));
                //Enter EndTime from DropDown
                EndTimeDropDown[2].SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Endtime"));
            }
            else if ((GlobalDefinitions.ExcelLib.ReadData(2, "Selectday")) == "Wed")
            {
                //Select Wednesday
                Days[3].Click();
                //Enter StartTime from DropDown
                StartTimeDropDown[4].SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Starttime"));
                //Enter EndTime from DropDown
                EndTimeDropDown[3].SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Endtime"));
            }
            else if ((GlobalDefinitions.ExcelLib.ReadData(2, "Selectday")) == "Thu")
            {
                //Select Thursday
                Days[4].Click();
                //Enter StartTime from DropDown
                StartTimeDropDown[5].SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Starttime"));
                //Enter EndTime from DropDown
                EndTimeDropDown[4].SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Endtime"));
            }
            else if ((GlobalDefinitions.ExcelLib.ReadData(2, "Selectday")) == "Fri")
            {
                //Select Friday
                Days[5].Click();
                //Enter StartTime from DropDown
                StartTimeDropDown[6].SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Starttime"));
                //Enter EndTime from DropDown
                EndTimeDropDown[5].SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Endtime"));
            }
            else if ((GlobalDefinitions.ExcelLib.ReadData(2, "Selectday")) == "Sat")
            {
                //Select Saturday
                Days[6].Click();
                //Enter StartTime from DropDown
                StartTimeDropDown[7].SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Starttime"));
                //Enter EndTime from DropDown
                EndTimeDropDown[6].SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Endtime"));
            }

            //Select Skill Trade from options
            if ((GlobalDefinitions.ExcelLib.ReadData(2, "SkillTrade")) == "Skill-Exchange")
            {
                //Select Skill-exchange from available options
                SkillTradeOption[0].Click();
                //Enter SkillExchange
                SkillExchange.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Skill-Exchange") + Keys.Enter);
            }
            else if ((GlobalDefinitions.ExcelLib.ReadData(2, "SkillTrade")) == "Credit")
            {
                //Select Credit from available options
                SkillTradeOption[1].Click();
                //Enter Credit Amount
                CreditAmount.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Credit"));
            }

            //Select ActiveOption
            switch ((GlobalDefinitions.ExcelLib.ReadData(2, "Active")))
            {
                case "Active":
                    //Select Active status
                    ActiveOption[0].Click();
                    break;

                case "Hidden":
                    //Select Hidden status
                    ActiveOption[1].Click();
                    break;
            }

            //Click on work sample file add icon
            FileAdd.Click();

            //Add work sample file using AutoIT
            AutoItX.WinWait("[CLASS:#32770]", "", 30);
            Thread.Sleep(3000);
            AutoItX.WinWaitActive("Open");
            AutoItX.ControlFocus("Open", "", "Edit1");
            AutoItX.ControlSetText("Open", "", "Edit1", @"C:\Study\IndustryConnect\git\ProjectMarsTestAutomationHybridFramework\MarsFramework\testFile.txt");
            Thread.Sleep(3000);
            AutoItX.ControlClick("Open", "", "Button1");


            //Click on Save button
            Save.Click();
            //Waiting for Manage Listing page to load
            GlobalDefinitions.WaitForElement(GlobalDefinitions.driver, By.XPath("//table[1]/tbody[1]"), 10);         
        }

        internal void EditShareSkill()
        {
            //Populate the excel data
            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPathShareSkill, "EditShareSkill");

            //Clear the existing Title and Enter new Title
            Title.Clear();
            Title.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Title") + TimeStamp);

            //Enter Tags
            Tags.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Tags") + Keys.Enter);

            //Disselect already entered day and time
            for (int i = 0; i < Days.Count; i++)
            {
                if (Days[i].Selected)
                {
                    Days[i].Click();
                    StartTimeDropDown[i+1].Clear();
                    EndTimeDropDown[i].Clear();
                }
            }

            //Select Days and enter Start and End time
            if ((GlobalDefinitions.ExcelLib.ReadData(2, "Selectday")) == "Sun")
            {
                //Select Sunday
                Days[0].Click();
                //Enter StartTime from DropDown
                StartTimeDropDown[1].SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Starttime"));
                //Enter EndTime from DropDown
                EndTimeDropDown[0].SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Endtime"));
            }
            else if ((GlobalDefinitions.ExcelLib.ReadData(2, "Selectday")) == "Mon")
            {
                //Select Monday
                Days[1].Click();
                //Enter StartTime from DropDown
                StartTimeDropDown[2].SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Starttime"));
                //Enter EndTime from DropDown
                EndTimeDropDown[1].SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Endtime"));
            }
            else if ((GlobalDefinitions.ExcelLib.ReadData(2, "Selectday")) == "Tue")
            {
                //Select Tuesday
                Days[2].Click();
                //Enter StartTime from DropDown
                StartTimeDropDown[3].SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Starttime"));
                //Enter EndTime from DropDown
                EndTimeDropDown[2].SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Endtime"));
            }
            else if ((GlobalDefinitions.ExcelLib.ReadData(2, "Selectday")) == "Wed")
            {
                //Select Wednesday
                Days[3].Click();
                //Enter StartTime from DropDown
                StartTimeDropDown[4].SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Starttime"));
                //Enter EndTime from DropDown
                EndTimeDropDown[3].SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Endtime"));
            }
            else if ((GlobalDefinitions.ExcelLib.ReadData(2, "Selectday")) == "Thu")
            {
                //Select Thursday
                Days[4].Click();
                //Enter StartTime from DropDown
                StartTimeDropDown[5].SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Starttime"));
                //Enter EndTime from DropDown
                EndTimeDropDown[4].SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Endtime"));
            }
            else if ((GlobalDefinitions.ExcelLib.ReadData(2, "Selectday")) == "Fri")
            {
                //Select Friday
                Days[5].Click();
                //Enter StartTime from DropDown
                StartTimeDropDown[6].SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Starttime"));
                //Enter EndTime from DropDown
                EndTimeDropDown[5].SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Endtime"));
            }
            else if ((GlobalDefinitions.ExcelLib.ReadData(2, "Selectday")) == "Sat")
            {
                //Select Saturday
                Days[6].Click();
                //Enter StartTime from DropDown
                StartTimeDropDown[7].SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Starttime"));
                //Enter EndTime from DropDown
                EndTimeDropDown[6].SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Endtime"));
            }

            //Select Skill Trade from options
            if ((GlobalDefinitions.ExcelLib.ReadData(2, "SkillTrade")) == "Skill-Exchange")
            {
                //Select Skill-exchange from available options
                SkillTradeOption[0].Click();
                //Enter SkillExchange
                SkillExchange.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Skill-Exchange") + Keys.Enter);
            }
            else if ((GlobalDefinitions.ExcelLib.ReadData(2, "SkillTrade")) == "Credit")
            {
                //Select Credit from available options
                SkillTradeOption[1].Click();
                //Enter Credit Amount
                CreditAmount.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Credit"));
            }
            
            //Select ActiveOption
            switch ((GlobalDefinitions.ExcelLib.ReadData(2, "Active")))
            {
                case "Active":
                    //Select Active status
                    ActiveOption[0].Click();
                    break;

                case "Hidden":
                    //Select Hidden status
                    ActiveOption[1].Click();
                    break;
            }

            //Click on Save button
            Save.Click();

            //Waiting for Manage Listing page to load
            GlobalDefinitions.WaitForElement(GlobalDefinitions.driver, By.XPath("//table[1]/tbody[1]"), 10);
        }
    }
}
