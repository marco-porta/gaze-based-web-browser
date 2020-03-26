using System.Drawing;
using System.Windows.Forms;
using Gecko;

namespace ProjectEyeBrowser
{
    public class ZoomHandler
    {

        private GeckoWebBrowser browser;
        private int clickCounter;
        private readonly int clickLimit = 10;
        private double zoomLevel;
        private readonly double progressiveZoomIncrease = 0.90;
        private readonly double immediateZoomIncrease = 6.50;
        private int initialPositionX;
        private int initialPositionY;
        private int oldScrollX;
        private int oldScrollY;
        private double scrollIncreaseX;
        private double scrollIncreaseY;

        public ZoomHandler(GeckoWebBrowser browserControl)
        {
            browser = browserControl;
            clickCounter = 0;
            zoomLevel = 1.0;
            initialPositionX = 0;
            initialPositionY = 0;
        }

        public void ResetZoom()
        {
            if(clickCounter == 0)
            {
                initialPositionX = browser.Document.GetElementsByTagName("HTML")[0].ScrollLeft;
                initialPositionY = browser.Document.GetElementsByTagName("HTML")[0].ScrollTop;
            }
            clickCounter = 0;
            zoomLevel = 1.0;
            try
            {
                if (browser.Document != null)
                {
                    browser.Document.Body.SetAttribute("style", @"transform: scale(" + zoomLevel.ToString("F", System.Globalization.CultureInfo.InvariantCulture) + "); transform-origin: 0 0;");
                    browser.Window.ScrollTo(initialPositionX, initialPositionY);
                }
            }
            catch (System.Exception e) { }
            initialPositionX = 0;
            initialPositionY = 0;
        }

        public bool PerformProgressiveZoom(Point clickLocation, Panel zoomPanel)
        {
            if(clickCounter == 0)
            {
                initialPositionX = browser.Document.GetElementsByTagName("HTML")[0].ScrollLeft;
                initialPositionY = browser.Document.GetElementsByTagName("HTML")[0].ScrollTop;
                scrollIncreaseX = browser.Window.ScrollX * progressiveZoomIncrease;
                scrollIncreaseY = browser.Window.ScrollY * progressiveZoomIncrease;
            }
            if(clickCounter == clickLimit)
            {
                zoomPanel.Visible = false;
                while (zoomPanel.Visible) ;
                Utilities.SimulateClick(browser.PointToScreen(Point.Empty).X + clickLocation.X, browser.PointToScreen(Point.Empty).Y + clickLocation.Y);
                return true;
            }
            oldScrollX = browser.Window.ScrollX;
            oldScrollY = browser.Window.ScrollY;
            clickCounter++;
            zoomLevel += progressiveZoomIncrease;
            try
            {
                if (browser.Document != null)
                {
                    browser.Document.Body.SetAttribute("style", @"transform: scale(" + zoomLevel.ToString("F", System.Globalization.CultureInfo.InvariantCulture) + "); transform-origin: 0 0;");
                    browser.Window.ScrollTo((int)(oldScrollX + scrollIncreaseX + clickLocation.X * progressiveZoomIncrease - System.Convert.ToDouble(browser.Document.GetElementsByTagName("BODY")[0].ComputedStyle.GetPropertyValue("margin-left").Replace("px", "")) * progressiveZoomIncrease), (int)(oldScrollY + scrollIncreaseY + clickLocation.Y * progressiveZoomIncrease - System.Convert.ToDouble(browser.Document.GetElementsByTagName("BODY")[0].ComputedStyle.GetPropertyValue("margin-top").Replace("px", "")) * progressiveZoomIncrease));
                }
            }
            catch (System.Exception e) { }
            return false;
        }

        public bool PerformImmediateZoom(Point clickLocation, Panel zoomPanel)
        {
            if (clickCounter == 0)
            {
                initialPositionX = browser.Document.GetElementsByTagName("HTML")[0].ScrollLeft;
                initialPositionY = browser.Document.GetElementsByTagName("HTML")[0].ScrollTop;
                scrollIncreaseX = browser.Window.ScrollX * immediateZoomIncrease;
                scrollIncreaseY = browser.Window.ScrollY * immediateZoomIncrease;
                oldScrollX = browser.Window.ScrollX;
                oldScrollY = browser.Window.ScrollY;
                clickCounter++;
                zoomLevel += immediateZoomIncrease;
                try
                {
                    if (browser.Document != null)
                    {
                        browser.Document.Body.SetAttribute("style", @"transform: scale(" + zoomLevel.ToString("F", System.Globalization.CultureInfo.InvariantCulture) + "); transform-origin: 0 0;");
                        browser.Window.ScrollTo((int)(oldScrollX + scrollIncreaseX + clickLocation.X * immediateZoomIncrease + clickLocation.X - browser.Width / 2 - System.Convert.ToDouble(browser.Document.GetElementsByTagName("BODY")[0].ComputedStyle.GetPropertyValue("margin-left").Replace("px", "")) * immediateZoomIncrease), (int)(oldScrollY + scrollIncreaseY + clickLocation.Y * immediateZoomIncrease + clickLocation.Y - browser.Height / 2 - System.Convert.ToDouble(browser.Document.GetElementsByTagName("BODY")[0].ComputedStyle.GetPropertyValue("margin-top").Replace("px", "")) * immediateZoomIncrease));
                    }
                }
                catch (System.Exception e) { }
                return false;
            }
            else
            {
                zoomPanel.Visible = false;
                while (zoomPanel.Visible) ;
                Utilities.SimulateClick(browser.PointToScreen(Point.Empty).X + clickLocation.X, browser.PointToScreen(Point.Empty).Y + clickLocation.Y);
                return true;
            }
        }

    }
}