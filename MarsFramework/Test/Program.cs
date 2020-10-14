using MarsFramework.Global;
using MarsFramework.Pages;
using NUnit.Framework;
using static MarsFramework.Global.GlobalDefinitions;

namespace MarsFramework
{
    public class Program
    {
        [TestFixture]
        [Category("Sprint1")]
        class User : Global.Base
        {
            [Test, Order(1), Description ("Check if user is able to Enter a Skill on Share Skill page")]
            public void ShareSkillEntry()
            {
                test = extent.StartTest("Start ShareSkillEntry");

                //Created object to interact with ShareSkill and ManageListings classes and their methods
                ShareSkill ShareSkillObj = new ShareSkill();
                ManageListings ManageListingsObj = new ManageListings(ShareSkillObj);

                //Called object to run EnterShareSkill method
                ShareSkillObj.EnterShareSkill();
                //Called object to run ValidateShareSkillEntry method
                ManageListingsObj.ValidateShareSkillEntry();
            }

            [Test, Order(2), Description("Check if user is able to Edit the Skill on Share Skill page")]

            public void EditShareSkill()
            {
                test = extent.StartTest("Start EditShareSkill");

                //Created object to interact with ShareSkill and ManageListings classes and their methods
                ShareSkill ShareSkillObj = new ShareSkill();
                ManageListings ManageListingsObj = new ManageListings(ShareSkillObj);

                //Called objects to run EditShareSkill method
                ManageListingsObj.EditShareSkill();
                //Called objects to run EditShareSkill method
                ShareSkillObj.EditShareSkill();
                //Called objects to run ValidateShareSkillEntry method
                ManageListingsObj.ValidateShareSkillEntry();
            }

            [Test, Order(3), Description("Check if user is able to Delete the Skill from Manage Listings page")]

            public void DeleteShareSkill()
            {
                test = extent.StartTest("Start DeleteShareSkill");

                //Created object to interact with ManageListings class and its methods
                ManageListings ManageListingsObj = new ManageListings();

                //Called object to run DeleteListing method
                ManageListingsObj.DeleteListing();
            }
        }
    }
}