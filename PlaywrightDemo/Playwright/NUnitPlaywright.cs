using NUnit.Framework;
using System.Threading.Tasks;
using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;
using System.Threading;

namespace PlaywrightDemo
{
    public class NUnitPlaywright : PageTest
    {
        private string url = "http://www.eaapp.somee.com";
        private string loginButton = "text=Login";
        // https://support.google.com/a/answer/9204988?hl=en
        [SetUp]
        public async Task Setup()
        {
            await Page.GotoAsync(url);
  
        }

        [Test]
        public async Task Test1Async()
        {
           // Page.SetDefaultTimeout(10);
            // await Page.ClickAsync(loginButton);
            var clickLoginButton = Page.Locator(loginButton);
            await clickLoginButton.ClickAsync();
           
            await Page.FillAsync("#UserName", "admin");
            await Page.FillAsync("#Password", "password");

            var checkbox = Page.Locator("#RememberMe");
            await checkbox.CheckAsync();

            //await Page.ClickAsync("text=Log in");
            var secondLoginButton = Page.Locator("input", new PageLocatorOptions { HasTextString = "Log in"});
            await secondLoginButton.ClickAsync();

            //Assertion
            await Expect(Page.Locator("text='Employee Details'")).ToBeVisibleAsync();
            
        }
    }
}