using Microsoft.Playwright;
using System.Threading.Tasks;

namespace PlaywrightDemo.POM
{
    public class LoginPageUpgrade
    {
        private IPage _page;
        public LoginPageUpgrade(IPage page) => _page = page;

        //private readonly ILocator _loginLink;
        //private readonly ILocator _usernameField;
        //private readonly ILocator _passwordField;
        //private readonly ILocator _loginButton;
        //private readonly ILocator _employeeDetailsLink;

        private ILocator _loginLink => _page.Locator("text=Login");
        private ILocator _usernameField => _page.Locator("#UserName");
        private ILocator _passwordField => _page.Locator("#Password");
        private ILocator _loginButton => _page.Locator("text=Log in");
        private ILocator _employeeDetailsLink => _page.Locator("text='Employee Details'");

        public async Task ClickLogin() => await _loginLink.ClickAsync();

        public async Task Login(string username, string password)
        {
            await _usernameField.FillAsync(username);
            await _passwordField.FillAsync(password);
            await _loginButton.ClickAsync();
        }

        public async Task<bool> IsEmployeeDetailsExist() => await _employeeDetailsLink.IsVisibleAsync(); 
    }
}
