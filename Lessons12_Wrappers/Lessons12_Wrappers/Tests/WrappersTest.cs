using Lessons12_Wrappers.BaseEntities;
using Lessons12_Wrappers.Constants.DropdownOptions;
using Lessons12_Wrappers.Constants.RadioButtonOptions;
using Lessons12_Wrappers.Pages;
using Lessons12_Wrappers.Steps;
using NUnit.Framework;

namespace Lessons12_Wrappers.Tests
{
    public class WrappersTest : BaseTest
    {
        [Test]
        [Description("Select 'Use multiple test suites to manage cases' radio button on 'Add project' page")]
        public void SelectSuiteModelTest()
        {
            var loginSteps = new LoginSteps(Driver);
            loginSteps.Login();

            var addProjectPage = new AddProjectPage(Driver);
            var radioButton = addProjectPage.SuiteModel();

            radioButton.Click(SuiteModel.SuiteModeMulti);
        }

        [Test]
        [Description("Select 'MySql Export' radio button on 'Data Management' page in the 'export' tab")]
        public void SelectSqlVersionTest()
        {
            var loginSteps = new LoginSteps(Driver);
            loginSteps.Login();

            var dataManagementPage = new DataManagementPage(Driver);
            dataManagementPage.Exports().Click();

            var radioButton = dataManagementPage.SqlVersion();
            radioButton.Click(SqlVersion.MySqlExport);
        }

        [Test]
        [Description("Select 'My settings' option into 'User name' dropdown on 'Dashboard' page")]
        public void SelectValueInDropdownMenuTest()
        {
            var loginSteps = new LoginSteps(Driver);
            loginSteps.Login();

            var dashboardPage = new DashboardPage(Driver);
            var dropDownMenu = dashboardPage.Header.UserName();

            dropDownMenu.SelectByText(UserName.MySettings);
        }

        [Test]
        [Description("Check checkbox 'Show the announcement on the overview page' on 'Add project' page")]
        public void SetCheckBoxTest()
        {
            var loginSteps = new LoginSteps(Driver);
            loginSteps.Login();

            var addProjectPage = new AddProjectPage(Driver);

            addProjectPage.ShowAnnouncement().CheckCheckBox();
        }
    }
}