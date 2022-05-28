using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Windows;
using OpenQA.Selenium.Interactions;
using System;

namespace WinAppDriverSampleTest
{
    [TestClass]
    public class UnitTest1
    {
        protected static WindowsDriver<WindowsElement> _session;

        /// <summary>
        /// クラス初期化処理です。
        /// </summary>
        /// <param name="context"></param>
        [ClassInitialize]
        public static void ClassInitialize(TestContext context)
        {
            // クラス内の最初のテストが実行される前に、実行される

            var options = new AppiumOptions();
            // テスト対象のアプリを設定
            options.AddAdditionalCapability("app", @"C:\Users\testuser\source\repos\temp\WinAppDriverSample\bin\Debug\WinAppDriverSample.exe");

            _session = new WindowsDriver<WindowsElement>(new Uri("http://127.0.0.1:4723"), options);
        }

        /// <summary>
        /// クラス終了処理です。
        /// </summary>
        [ClassCleanup]
        public static void ClassCleanup()
        {
            // クラス内のテストがすべて実行された後、実行される

            if (_session != null)
            {
                _session.Quit();
                _session = null;
            }
        }

        [TestMethod]
        public void T001_左クリックする()
        {
            var button = _session.FindElementByAccessibilityId("button1");
            var actions = new Actions(_session);

            actions.Click(button);      // Buttonを左クリック
            actions.Perform();          // 実行

            System.Threading.Thread.Sleep(1000);
        }

        [TestMethod]
        public void T002_右クリックする()
        {
            var form = _session.FindElementByAccessibilityId("Form1");
            var actions = new Actions(_session);

            actions.ContextClick(form);     // Formを右クリック
            actions.Perform();              // 実行

            var item = _session.FindElementByName("click");
            actions.Click(item);            // メニュー項目をクリック
            actions.Perform();              // 実行

            System.Threading.Thread.Sleep(1000);
        }

        [TestMethod]
        public void T003_マウスを操作する()
        {
            var button = _session.FindElementByAccessibilityId("button1");
            var actions = new Actions(_session);

            actions.MoveToElement(button);      // マウスポインターをButtonに移動
            actions.Perform();                  // 実行

            actions.Click(button);              // Buttonを左クリック
            actions.Perform();                  // 実行

            System.Threading.Thread.Sleep(1000);
        }

        [TestMethod]
        public void T004_キーボードを操作する()
        {
            var form = _session.FindElementByAccessibilityId("Form1");
            var actions = new Actions(_session);

            actions.SendKeys(Keys.Command + Keys.ArrowUp);      // [Windows]キー+[↑]キーを入力
            actions.Perform();                                  // 実行

            System.Threading.Thread.Sleep(1000);
        }

        [TestMethod]
        public void T005_スクリーンショットを取得する()
        {
            var form = _session.FindElementByAccessibilityId("Form1");

            System.Threading.Thread.Sleep(1000);    // 起動するまで待つ

            var shot = form.GetScreenshot();                            // スクリーンショットを取得
            shot.SaveAsFile("form.png", ScreenshotImageFormat.Png);     // 保存
        }
    }
}
