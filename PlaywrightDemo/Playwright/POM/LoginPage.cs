using Microsoft.Playwright;
using System.Threading.Tasks;

namespace PlaywrightDemo.POM
{
    public class LoginPage
    {
        private IPage _page;
        private readonly ILocator _loginLink;
        private readonly ILocator _usernameField;
        private readonly ILocator _passwordField;
        private readonly ILocator _loginButton;
        private readonly ILocator _employeeDetailsLink;

        public LoginPage(IPage page)
        {
            _page = page;
            _loginLink = _page.Locator("text=Login");
            _usernameField = _page.Locator("#UserName");
            _passwordField = _page.Locator("#Password");
            _loginButton = _page.Locator("text=Log in");
            _employeeDetailsLink = _page.Locator("text='Employee Details'");
        }

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
