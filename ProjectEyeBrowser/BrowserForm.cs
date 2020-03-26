using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;
using Gecko;

namespace ProjectEyeBrowser
{
    public partial class eyeBrowserForm : Form
    {
        private LinkSelector linkSelector;
        private ZoomHandler zoomHandler;
        private bool linkSelectorStatus;
        private bool linkNavigatorStatus;
        private bool progressiveZoomStatus;
        private bool immediateZoomStatus;
        private bool freePointingStatus;
        private List<PageElement> visibleLinks;
        private EyeTrackingHandler eyeTrackingHandler;
        private Timer circleTimer;
        private int tickCounter;
        private Point circleCenter;

        public eyeBrowserForm()
        {
            InitializeComponent();
            Xpcom.Initialize("Firefox");
            linkSelector = new LinkSelector();
            zoomHandler = new ZoomHandler(browserControl);
            keyboard.Favorites = favoritesPanel;
            favoritesPanel.Keyboard = keyboard;
            linkSelectorStatus = false;
            linkNavigatorStatus = false;
            progressiveZoomStatus = false;
            immediateZoomStatus = false;
            freePointingStatus = false;
            circleTimer = new Timer
            {
                Interval = 35
            };
            tickCounter = 0;
            circleCenter = new Point(1, 1);
            circleTimer.Tick += (sender, e) =>
            {
                CountTimerTicks();
            };
            eyeTrackingHandler = new EyeTrackingHandler(browserControl, scrollPanel, keyboard, favoritesPanel, clickButton, popupPanel);
            Cursor.Hide();
        }


        // Link Selection by Link Position and Distance
        private void ShowLinks(object sender, MouseEventArgs e)
        {
            eyeTrackingHandler.AcceptClick = false;
            if (!linkLabelsPanel.Visible)
            {
                int i = 0;
                Utilities.ResetLinkPanel(linkLabelsPanel);
                visibleLinks = linkSelector.FindLinks(browserControl, e.Location);
                while (i < 5 && i < visibleLinks.Count)
                {
                    Label label = (Label)linkLabelsPanel.Controls[i];
                    Image image = linkSelector.TakeElementScreenshot(browserControl, visibleLinks[i]);
                    if (image.Width > label.Width || image.Height > label.Height)
                    {
                        image = Utilities.FitImage(image, label.Width, label.Height);
                    }
                    label.Image = image;
                    if (visibleLinks[i].ElementType.Equals("A"))
                    {
                        linkLabelsPanel.Controls[i].BackColor = Color.LemonChiffon;
                    }
                    else
                    {
                        linkLabelsPanel.Controls[i].BackColor = Color.Moccasin;
                    }
                    i++;
                }
                linkLabelsPanel.Visible = true;
                linkLabelsPanel.BringToFront();
            }
            else
            {
                linkLabelsPanel.Visible = false;
            }
            eyeTrackingHandler.AcceptClick = true;
        }

        private void SelectLink(object sender, EventArgs e)
        {
            int position = linkLabelsPanel.Controls.IndexOf((Control)sender);
            if(position < visibleLinks.Count)
            {
                visibleLinks[position].HtmlElement.Click();
                ChangeLinkSelectorStatus(sender, e);
            }
        }

        private void ChangeLinkSelectorStatus(object sender, EventArgs e)
        {
            if (!linkSelectorStatus)
            {
                linkSelectorStatus = true;
                browserLinkSelectorPanel.Visible = true;
                scrollPanel.Visible = false;
                DisableOtherFunctions(1);
                DisableScrolling();
            }
            else
            {
                linkSelectorStatus = false;
                browserLinkSelectorPanel.Visible = false;
                linkLabelsPanel.Visible = false;
                if (sender != null)
                {
                    scrollPanel.Visible = true;
                }
                EnableScrolling();
            }
            Utilities.ButtonPaintUpdate(linkSelectorButton, linkSelectorStatus);
        }


        // Link Selection by Link Navigator
        private void ChangeLinkNavigatorStatus(object sender, EventArgs e)
        {
            if (!linkNavigatorStatus)
            {
                linkNavigatorStatus = true;
                browserLinkNavigatorPanel.Visible = true;
                scrollPanel.Visible = false;
                DisableOtherFunctions(2);
                DisableScrolling();
            }
            else
            {
                linkNavigatorStatus = false;
                browserLinkNavigatorPanel.Visible = false;
                pointedLinkPanel.Visible = false;
                upNavigatorButton.Visible = false;
                leftNavigatorButton.Visible = false;
                downNavigatorButton.Visible = false;
                rightNavigatorButton.Visible = false;
                if(linkSelector.PointedElement != null)
                {
                    linkSelector.PointedElement.HtmlElement.RemoveAttribute("style");
                }
                if (sender != null)
                {
                    scrollPanel.Visible = true;
                }
                EnableScrolling();
            }
            Utilities.ButtonPaintUpdate(linkNavigatorButton, linkNavigatorStatus);
        }

        private void MarkFirstLink(object sender, MouseEventArgs e)
        {
            eyeTrackingHandler.AcceptClick = false;
            if (!pointedLinkPanel.Visible)
            {
                visibleLinks = linkSelector.FindAllLinks(browserControl, e.Location);
                if (visibleLinks.Count != 0)
                {
                    linkSelector.ChangeNavigatorPosition(browserControl, 0, pointedLinkPanel, upNavigatorButton, leftNavigatorButton, downNavigatorButton, rightNavigatorButton);
                    pointedLinkPanel.Visible = true;
                    pointedLinkPanel.BringToFront();
                    rightNavigatorButton.Visible = true;
                    rightNavigatorButton.BringToFront();
                    leftNavigatorButton.Visible = true;
                    leftNavigatorButton.BringToFront();
                    upNavigatorButton.Visible = true;
                    upNavigatorButton.BringToFront();
                    downNavigatorButton.Visible = true;
                    downNavigatorButton.BringToFront();
                }
            }
            else
            {
                if (linkSelector.PointedElement != null && visibleLinks.Count > 1)
                {
                    linkSelector.PointedElement.HtmlElement.RemoveAttribute("style");
                    visibleLinks = linkSelector.FindAllLinks(browserControl, e.Location);
                    linkSelector.ChangeNavigatorPosition(browserControl, 0, pointedLinkPanel, upNavigatorButton, leftNavigatorButton, downNavigatorButton, rightNavigatorButton);
                }
            }
            eyeTrackingHandler.AcceptClick = true;
        }

        private void SelectPointedLink(object sender, EventArgs e)
        {
            linkSelector.ClickActualLink();
            ChangeLinkNavigatorStatus(sender, e);
        }

        private void UpNavigatorButtonClick(object sender, EventArgs e)
        {
            linkSelector.ChangeNavigatorPosition(browserControl, 1, pointedLinkPanel, upNavigatorButton, leftNavigatorButton, downNavigatorButton, rightNavigatorButton);
        }

        private void LeftNavigatorButtonClick(object sender, EventArgs e)
        {
            linkSelector.ChangeNavigatorPosition(browserControl, 2, pointedLinkPanel, upNavigatorButton, leftNavigatorButton, downNavigatorButton, rightNavigatorButton);
        }

        private void DownNavigatorButtonClick(object sender, EventArgs e)
        {
            linkSelector.ChangeNavigatorPosition(browserControl, 3, pointedLinkPanel, upNavigatorButton, leftNavigatorButton, downNavigatorButton, rightNavigatorButton);
        }

        private void RightNavigatorButtonClick(object sender, EventArgs e)
        {
            linkSelector.ChangeNavigatorPosition(browserControl, 4, pointedLinkPanel, upNavigatorButton, leftNavigatorButton, downNavigatorButton, rightNavigatorButton);
        }


        //Progressive and Immediate Zoom
        private void ChangeProgressiveZoomStatus(object sender, EventArgs e)
        {
            if (!progressiveZoomStatus)
            {
                DisableOtherFunctions(3);
                progressiveZoomStatus = true;
                browserZoomPanel.Visible = true;
                scrollPanel.Visible = false;
                eyeTrackingHandler.StartZooming();
                DisableScrolling();
                browserControl.Document.Body.SetAttribute("style", @"transform: scale(1); transform-origin: 0 0;");
            }
            else
            {
                eyeTrackingHandler.StopZooming();
                progressiveZoomStatus = false;
                browserZoomPanel.Visible = false;
                zoomHandler.ResetZoom();
                if (sender != null)
                {
                    scrollPanel.Visible = true;
                }
                EnableScrolling();
            }
            Utilities.ButtonPaintUpdate(progressiveZoomButton, progressiveZoomStatus);
        }

        private void ChangeImmediateZoomStatus(object sender, EventArgs e)
        {
            if (!immediateZoomStatus)
            {
                DisableOtherFunctions(4);
                immediateZoomStatus = true;
                browserZoomPanel.Visible = true;
                scrollPanel.Visible = false;
                browserControl.Document.Body.SetAttribute("style", @"transform: scale(1); transform-origin: 0 0;");
            }
            else
            {
                immediateZoomStatus = false;
                browserZoomPanel.Visible = false;
                zoomHandler.ResetZoom();
                if (sender != null)
                {
                    scrollPanel.Visible = true;
                }
            }
            Utilities.ButtonPaintUpdate(immediateZoomButton, immediateZoomStatus);
        }

        private void IncreaseZoom(object sender, MouseEventArgs e)
        {
            if (progressiveZoomStatus)
            {
                if(zoomHandler.PerformProgressiveZoom(e.Location, browserZoomPanel))
                {
                    Utilities.SimulateClick(progressiveZoomButton.PointToScreen(Point.Empty).X + (progressiveZoomButton.Width / 2), progressiveZoomButton.PointToScreen(Point.Empty).Y + (progressiveZoomButton.Height / 2));
                }
            }
            if (immediateZoomStatus)
            {
                if(zoomHandler.PerformImmediateZoom(e.Location, browserZoomPanel))
                {
                    Utilities.SimulateClick(immediateZoomButton.PointToScreen(Point.Empty).X + (immediateZoomButton.Width / 2), immediateZoomButton.PointToScreen(Point.Empty).Y + (immediateZoomButton.Height / 2));
                }
            }
        }


        // Handling
        private void OpenPopup(object sender, EventArgs e)
        {
            DisableOtherFunctions(0);
            blockingPanel.Visible = true;
            blockingPanel.BringToFront();
            popupPanel.Visible = true;
            popupPanel.BringToFront();
            Utilities.ButtonPaintUpdate(openPopupButton, true);
        }

        private void ClosePopup(object sender, EventArgs e)
        {
            blockingPanel.Visible = false;
            popupPanel.Visible = false;
            Utilities.ButtonPaintUpdate(openPopupButton, false);
        }

        private void MinimizeWindow(object sender, EventArgs e)
        {
            ClosePopup(null, null);
            WindowState = FormWindowState.Minimized;
        }

        private void CloseWindow(object sender, EventArgs e)
        {
            eyeTrackingHandler.CloseConnection();
            this.Close();
        }

        private void DisableOtherFunctions(int id)
        {
            if(id != 1 && linkSelectorStatus)
            {
                ChangeLinkSelectorStatus(null, null);
            }
            if(id != 2 && linkNavigatorStatus)
            {
                ChangeLinkNavigatorStatus(null, null);
            }
            if(id != 3 && progressiveZoomStatus)
            {
                ChangeProgressiveZoomStatus(null, null);
            }
            if(id != 4 && immediateZoomStatus)
            {
                ChangeImmediateZoomStatus(null, null);
            }
            if(id != 5 && freePointingStatus)
            {
                ChangeFreePointingStatus(null, null);
            }
            if(id != 1 && id != 2 && id != 3)
            {
                EnableScrolling();
            }
            if(id == 0)
            {
                scrollPanel.Visible = true;
            }
        }

        private void OpenKeyboard(object sender, EventArgs e)
        {
            keyboard.Browser = browserControl;
            keyboard.Navigation = false;
            DisableOtherFunctions(0);
            keyboard.Visible = true;
            keyboard.BringToFront();
        }

        private void OpenKeyboardForNavigation(object sender, EventArgs e)
        {
            keyboard.Browser = browserControl;
            keyboard.Navigation = true;
            DisableOtherFunctions(0);
            keyboard.Visible = true;
            keyboard.BringToFront();
        }

        private void ChangeFreePointingStatus(object sender, EventArgs e)
        {
            if (!freePointingStatus)
            {
                DisableOtherFunctions(5);
                clickButton.Location = new Point(rightButtonsPanel.Location.X + scrollUpButton.Location.X, rightButtonsPanel.Location.Y + scrollUpButton.Location.Y);
                clickButton.Width = scrollUpButton.Width;
                clickButton.Height = scrollRightButton.Location.Y - scrollUpButton.Location.Y + scrollRightButton.Height;
                clickButton.BackColor = Color.LemonChiffon;
                freePointingStatus = true;
                scrollPanel.Visible = false;
                eyeTrackingHandler.FreePointing = true;
                clickButton.Visible = true;
                Cursor.Show();
            }
            else
            {
                freePointingStatus = false;
                if (sender != null)
                {
                    scrollPanel.Visible = true;
                }
                eyeTrackingHandler.FreePointing = false;
                clickButton.Visible = false;
                Cursor.Hide();
            }
            Utilities.ButtonPaintUpdate(freePointingButton, freePointingStatus);
        }

        private void ExecuteClick(object sender, EventArgs e)
        {
            Utilities.PerformClick(Cursor.Position);
        }


        // Scrolling
        private void ScrollUp(object sender, EventArgs e)
        {
            browserControl.Window.ScrollBy(0, - browserControl.Height * 9 / 10);
        }

        private void ScrollDown(object sender, EventArgs e)
        {
            browserControl.Window.ScrollBy(0, browserControl.Height * 9 / 10);
        }

        private void ScrollLeft(object sender, EventArgs e)
        {
            browserControl.Window.ScrollBy(- browserControl.Width, 0);
        }

        private void ScrollRight(object sender, EventArgs e)
        {
            browserControl.Window.ScrollBy(browserControl.Width, 0);
        }

        private void EnableScrolling()
        {
            scrollUpButton.Enabled = true;
            scrollDownButton.Enabled = true;
            scrollLeftButton.Enabled = true;
            scrollRightButton.Enabled = true;
        }

        private void DisableScrolling()
        {
            scrollUpButton.Enabled = false;
            scrollDownButton.Enabled = false;
            scrollLeftButton.Enabled = false;
            scrollRightButton.Enabled = false;
        }

        private void ScrollSoft(object sender, MouseEventArgs e)
        {
            if(e.Location.Y < browserControl.Height / 8)
            {
                browserControl.Window.ScrollBy(0, - 10);
            }
            if(e.Location.Y > browserControl.Height - browserControl.Height / 8)
            {
                browserControl.Window.ScrollBy(0, 10);
            }
        }


        // Navigation
        private void LoadHomePage(object sender, EventArgs e)
        {
            browserControl.Navigate(favoritesPanel.Homepage);
        }

        private void BackNavigate(object sender, EventArgs e)
        {
            browserControl.GoBack();
            DisableOtherFunctions(0);
        }

        private void ForwardNavigate(object sender, EventArgs e)
        {
            browserControl.GoForward();
            DisableOtherFunctions(0);
        }

        private void ShowURL(object sender, GeckoNavigatedEventArgs e)
        {
            urlBox.Text = browserControl.Url.ToString();
            DisableOtherFunctions(0);
        }

        private void RefreshPage(object sender, EventArgs e)
        {
            browserControl.Navigate(urlBox.Text);
            DisableOtherFunctions(0);
        }

        private void GoToHomepage(object sender, EventArgs e)
        {
            browserControl.Navigate(favoritesPanel.Homepage);
            DisableOtherFunctions(0);
        }

        private void OpenFavorites(object sender, EventArgs e)
        {
            DisableOtherFunctions(0);
            favoritesPanel.OpenFavorites(browserControl);
        }

        private void NavigationColor(object sender, Gecko.Events.GeckoNavigatingEventArgs e)
        {
            urlBox.BackColor = Color.Lavender;
        }

        private void NavigationCompleted(object sender, Gecko.Events.GeckoDocumentCompletedEventArgs e)
        {
            urlBox.BackColor = Color.Ivory;
        }

        private void BlockNewWindow(object sender, GeckoCreateWindowEventArgs e)
        {
            browserControl.Navigate(e.Uri);
            e.Cancel = true;
        }

        private void CanGoBackChanged(object sender, EventArgs e)
        {
            Utilities.EnabledButtonPaint(backNavigationBrowserButton, browserControl.CanGoBack);
        }

        private void CanGoForwardChanged(object sender, EventArgs e)
        {
            Utilities.EnabledButtonPaint(forwardNavigationBrowserButton, browserControl.CanGoForward);
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape)
            {
                if (eyeTrackingHandler.AcceptClick)
                {
                    eyeTrackingHandler.AcceptClick = false;
                    Cursor.Show();
                }
                else
                {
                    eyeTrackingHandler.AcceptClick = true;
                    Cursor.Hide();
                }
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }


        // Click feedback
        private void StartAnimation(object sender, EventArgs e)
        {
            if (!freePointingStatus)
            {
                circleTimer.Start();
            }
            else
            {
                if (clickButton.BackColor == Color.LemonChiffon)
                {
                    clickButton.BackColor = Color.Orange;
                }
                else
                {
                    clickButton.BackColor = Color.LemonChiffon;
                }
                Utilities.SetCursorPos(eyeTrackingHandler.PointedPosition.X, eyeTrackingHandler.PointedPosition.Y);
            }
        }

        private void CountTimerTicks()
        {
            circleCenter = eyeTrackingHandler.ClickedPoint;
            if (tickCounter < 12)
            {
                tickCounter++;
                clickCirclePanel.Invalidate();
                clickCirclePanel.Visible = true;
                clickCirclePanel.BringToFront();
            }
            else
            {
                circleTimer.Stop();
                tickCounter = 1;
                circleCenter = new Point(1, 1);
                clickCirclePanel.Invalidate();
                clickCirclePanel.Visible = false;
            }
        }

        private void PaintCircle(object sender, PaintEventArgs e)
        {
            clickCirclePanel.Location = new Point(circleCenter.X - tickCounter, circleCenter.Y - tickCounter);
            clickCirclePanel.Width = tickCounter + tickCounter;
            clickCirclePanel.Height = tickCounter + tickCounter;
            using (GraphicsPath path = new GraphicsPath())
            {
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                path.AddEllipse(0, 0, clickCirclePanel.Width, clickCirclePanel.Height);
                clickCirclePanel.Region = new Region(path);
                using (Pen pen = new Pen(Color.DarkGreen, 5))
                {
                    pen.Alignment = PenAlignment.Outset;
                    e.Graphics.DrawPath(pen, path);
                }
            }
        }

    }
}