using NUnit.Framework;
using System.Threading.Tasks;
using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;
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
            await Page.ClickAsync(loginButton);
            //await page.ScreenshotAsync(new PageScreenshotOptions { Path = "Login.png" });

            await Page.FillAsync("#UserName", "admin");
            await Page.FillAsync("#Password", "password");
            await Page.ClickAsync("text=Log in");

            //Assertion
            await Expect(Page.Locator("text='Employee Details'")).ToBeVisibleAsync();
        }
    }
}