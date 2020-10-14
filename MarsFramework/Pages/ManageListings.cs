using MarsFramework.Global;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System.Collections.Generic;
using System.Threading;

namespace MarsFramework.Pages
{
    internal class ManageListings
    {
        //Created class reference variable and constructor to interact with ShareSkill class
        ShareSkill ShareSkillRefObj; 

        public ManageListings(ShareSkill _ShareSkillRefObj)
        {
            PageFactory.InitElements(Global.GlobalDefinitions.driver, this);
            this.ShareSkillRefObj = _ShareSkillRefObj;
        }

        public ManageListings()
        {
            PageFactory.InitElements(Global.GlobalDefinitions.driver, this);
        }

        //Click on Manage Listings Link
        [FindsBy(How = How.LinkText, Using = "Manage Listings")]
        private IWebElement manageListingsLink { get; set; }

        [FindsBy(How = How.XPath, Using = "//table[1]/tbody[1]")]
        private IWebElement ListingsTable { get; set; }

        //View the listing
        [FindsBy(How = How.XPath, Using = "(//i[@class='eye icon'])[1]")]
        private IWebElement view { get; set; }

        //Delete the listing
        [FindsBy(How = How.XPath, Using = "(//i[@class='remove icon'])[1]")]
        private IWebElement delete { get; set; }

        //Edit the listing
        [FindsBy(How = How.XPath, Using = "(//i[@class='outline write icon'])[1]")]
        private IWebElement edit { get; set; }

        //Listing title
        [FindsBy(How = How.XPath, Using = "//table[1]/tbody[1]/tr[1]/td[3]")]
        private IWebElement listingTitle { get; set; }

        //Click on Yes or No
        [FindsBy(How = How.XPath, Using = "//div[@class='actions']/button")]
        private IList<IWebElement> clickActionsButton { get; set; }

        internal void ValidateShareSkillEntry()
        {
            //Validating Share Skill entry and edit
            Assert.IsTrue(ListingsTable.Text.Contains(ShareSkillRefObj.TimeStamp));
        }

        internal void EditShareSkill()
        {
            //Waiting for Profile page to load after signing in
            GlobalDefinitions.WaitForElement(GlobalDefinitions.driver, By.LinkText("Manage Listings"), 5);     
            //Click on Manage Listings tab
            manageListingsLink.Click();
            //Waiting for Manage Listing page to load
            GlobalDefinitions.WaitForElement(GlobalDefinitions.driver, By.XPath("(//i[@class='outline write icon'])[1]"), 5);
            //Click on edit button
            edit.Click();
        }

        internal void DeleteListing()
        {
            //Populate the Excel Sheet
            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPathManageListings, "ManageListings");
            manageListingsLink.Click();

            //Waiting for Manage Listing page to load
            GlobalDefinitions.WaitForElement(GlobalDefinitions.driver, By.XPath("(//i[@class='remove icon'])[1]"), 5);

            //Saving the Title of to be deleted listing for validation
            string beforedelete = listingTitle.Text;

            //Click on delete button
            delete.Click();

            //Confirm the action while reading the data from excel sheet
            switch ((GlobalDefinitions.ExcelLib.ReadData(2, "Deleteaction")))
            {
                case "Yes":
                    //Select Yes option
                    clickActionsButton[1].Click();
                    break;

                case "No":
                    //Select No option
                    clickActionsButton[0].Click();
                    break;
            }

            //Refreshing the page after listing deletion
            GlobalDefinitions.driver.Navigate().Refresh();
            //Waiting for Manage Listing page to load
            GlobalDefinitions.WaitForElement(GlobalDefinitions.driver, By.XPath("//table[1]/tbody[1]"), 10);
            //Validation of listing delete
            Assert.IsTrue(!ListingsTable.Text.Contains(beforedelete));
        }
    }
}
