using NUnit.Framework;
using System.Threading.Tasks;
using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;
namespace PlaywrightDemo
{
    public class PlaywrigthDemo
    {
        private string url = "http://www.eaapp.somee.com";
        private string loginButton = "text=Login";
        // https://support.google.com/a/answer/9204988?hl=en
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public async Task Test1Async()
        {
            //Playwright
            using var playwright = await Playwright.CreateAsync();

            //Browser and make sure to run headed.
            await using var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
            { 
                Headless = false,
            });

            //Page
            var page = await browser.NewPageAsync();
            await page.GotoAsync(url);
            await page.ClickAsync(loginButton);
            //await page.ScreenshotAsync(new PageScreenshotOptions { Path = "Login.png" });

            await page.FillAsync("#UserName", "admin");
            await page.FillAsync("#Password", "password");
            await page.ClickAsync("text=Log in");

            var isExist = await page.Locator("text='Employee Details'").IsVisibleAsync();
            Assert.IsTrue(isExist);
        }
    }
}