using System.Windows.Forms;
using System.Drawing;
using System;
using System.IO;
using Tobii.Interaction;
using Tobii.Interaction.Framework;

namespace ProjectEyeBrowser
{
    public class EyeTrackingHandler
    {

        private Host host;
        private FixationDataStream fixationStream;
        private Point circleCenter;
        private bool acceptClick;
        private bool zooming;
        private bool zoomingExecution;
        private bool freePointingExecution;
        private Point pointedPosition;
        private Button clickButton;
        private Gecko.GeckoWebBrowser browser;
        private int browserX;
        private int width;
        private int browserY;
        private int height;
        private TransparentPanel scrollPanel;
        private Keyboard keyboardPanel;
        private FavoritesPanel favoritesPanel;
        private Panel closePanel;
        private int firstPointedX;
        private int firstPointedY;
        private int pointedX;
        private int pointedY;
        private int fixationCounter;
        private int requiredSamplings;
        private int radiusLimit;
        private int zoomingSamplings;
        private int scrollingSamplings;
        private string settingsPath;

        public EyeTrackingHandler(Gecko.GeckoWebBrowser b, TransparentPanel scroll, Keyboard keys, FavoritesPanel favorites, Button click, Panel close)
        {
            host = new Host();
            fixationStream = host.Streams.CreateFixationDataStream(FixationDataMode.Slow);
            HandleFixation();
            acceptClick = true;
            circleCenter = new Point(1, 1);
            zooming = false;
            zoomingExecution = false;
            freePointingExecution = false;
            pointedPosition = new Point(1, 1);
            browser = b;
            browserX = browser.Location.X;
            width = browserX + browser.Width;
            browserY = browser.Location.Y;
            height = browserY + browser.Height;
            clickButton = click;
            scrollPanel = scroll;
            keyboardPanel = keys;
            closePanel = close;
            favoritesPanel = favorites;
            firstPointedX = 0;
            firstPointedY = 0;
            pointedX = 0;
            pointedY = 0;
            fixationCounter = 0;
            requiredSamplings = 120;
            radiusLimit = 150;
            zoomingSamplings = 30;
            scrollingSamplings = 10;
            settingsPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "EyeBrowserTimingPreferences.txt");
            if (File.Exists(settingsPath))
            {
                using (StreamReader reader = new StreamReader(settingsPath))
                {
                    requiredSamplings = Int32.Parse(reader.ReadLine());
                    radiusLimit = Int32.Parse(reader.ReadLine());
                    zoomingSamplings = Int32.Parse(reader.ReadLine());
                    scrollingSamplings = Int32.Parse(reader.ReadLine());
                }
            }
            else
            {
                using (StreamWriter writer = new StreamWriter(settingsPath, false))
                {
                    writer.WriteLine(requiredSamplings);
                    writer.WriteLine(radiusLimit);
                    writer.WriteLine(zoomingSamplings);
                    writer.WriteLine(scrollingSamplings);
                }
            }
        }

        private void HandleFixation()
        {
            fixationStream.Next += (sender, fixation) =>
            {
                if (!freePointingExecution)
                {
                    if (fixationCounter == 40 || fixationCounter == 70)
                    {
                        Utilities.SetCursorPos(pointedX, pointedY);
                    }
                }
                if (ComputePosition((int)fixation.Data.X, (int)fixation.Data.Y))
                {
                    browserX = browser.Location.X;
                    width = browserX + browser.Width;
                    browserY = browser.Location.Y;
                    height = browserY + browser.Height;
                    if (freePointingExecution)
                    {
                        if (!(pointedX > browserX && pointedY > browserY && pointedX < width && pointedY < height))
                        {
                            pointedPosition = Cursor.Position;
                            if (pointedX >= clickButton.Location.X && pointedY >= clickButton.Location.Y && pointedX <= clickButton.Location.X + clickButton.Width && pointedY <= clickButton.Location.Y + clickButton.Height)
                            {
                                Utilities.PerformClick(Cursor.Position);
                                circleCenter = new Point(pointedX, pointedY);
                                Utilities.SetCursorPos(1, 1);
                            }
                            else
                            {
                                Utilities.SimulateSingleClick(pointedX, pointedY);
                                circleCenter = new Point(pointedX, pointedY);
                                Utilities.SetCursorPos(1, 1);
                            }
                        }
                        else
                        {
                            Utilities.SetCursorPos(pointedX, pointedY);
                        }
                    }
                    else if (!zooming)
                    {
                        if (keyboardPanel.Visible)
                        {
                            Utilities.SimulateSingleClick(pointedX, pointedY);
                            circleCenter = new Point(pointedX, pointedY);
                            Utilities.SetCursorPos(1, 1);
                        }
                        else if (favoritesPanel.Visible || (pointedX > browserX && pointedY > browserY && pointedX < width && pointedY < height))
                        {
                            Utilities.SimulateSingleClick(pointedX, pointedY);
                        }
                        else
                        {
                            Utilities.SimulateSingleClick(pointedX, pointedY);
                            circleCenter = new Point(pointedX, pointedY);
                            Utilities.SimulateSingleClick(1, 1);
                        }
                    }
                    else if (zooming && pointedX > browserX && pointedY > browserY && pointedX < width && pointedY < height)
                    {
                        zoomingExecution = true;
                        Utilities.SimulateSingleClick(pointedX, pointedY);
                    }
                    else if (zooming && !(pointedX > browserX && pointedY > browserY && pointedX < width && pointedY < height))
                    {
                        Utilities.SimulateSingleClick(pointedX, pointedY);
                        circleCenter = new Point(pointedX, pointedY);
                        Utilities.SimulateSingleClick(1, 1);
                    }
                }
            };
        }

        private bool ComputePosition(int x, int y)
        {
            if (!acceptClick || !keyboardPanel.Writing)
            {
                fixationCounter = 0;
                return false;
            }
            if (fixationCounter == 0)
            {
                firstPointedX = x;
                firstPointedY = y;
                pointedX = x;
                pointedY = y;
                fixationCounter++;
            }
            else
            {
                if (System.Math.Sqrt(System.Math.Pow(firstPointedX - x, 2) + System.Math.Pow(firstPointedY - y, 2)) < radiusLimit)
                {
                    pointedX = (pointedX + x) / 2;
                    pointedY = (pointedY + y) / 2;
                    fixationCounter++;
                }
                else
                {
                    fixationCounter = 0;
                }
            }
            if (fixationCounter >= requiredSamplings)
            {
                fixationCounter = 0;
                return true;
            }
            else if (zoomingExecution && fixationCounter >= zoomingSamplings)
            {
                fixationCounter = 0;
                return true;
            }
            else if (!closePanel.Visible && scrollPanel.Visible && !keyboardPanel.Visible && !favoritesPanel.Visible && fixationCounter >= scrollingSamplings && pointedX > browser.Location.X && pointedY > browser.Location.Y && pointedX < browser.Location.X + browser.Width && pointedY < browser.Location.Y + browser.Height)
            {
                fixationCounter = 0;
                Utilities.SimulateSingleClick(pointedX, pointedY);
                return false;
            }
            else
            {
                return false;
            }
        }

        public void StartZooming()
        {
            zooming = true;
        }

        public void StopZooming()
        {
            zoomingExecution = false;
            zooming = false;
        }

        public void CloseConnection()
        {
            host.DisableConnection();
        }

        public bool AcceptClick { set { acceptClick = value; } get { return acceptClick; } }
        public bool FreePointing { set { freePointingExecution = value; } }
        public Point PointedPosition { get { return pointedPosition; } }
        public Point ClickedPoint { get { return circleCenter; } }

    }
}