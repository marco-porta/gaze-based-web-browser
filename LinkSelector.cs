using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;
using Gecko;

namespace ProjectEyeBrowser
{
    public class LinkSelector
    {

        private List<PageElement> visibleLinks, elements;
        private PageElement actualElement;

        public LinkSelector()
        {
            visibleLinks = new List<PageElement>();
            elements = new List<PageElement>();
        }

        public List<PageElement> FindLinks(GeckoWebBrowser browser, Point clickPosition)
        {
            visibleLinks.Clear();
            elements.Clear();
            FindElements(browser, "A", clickPosition);
            FindElements(browser, "IMG", clickPosition);
            foreach(var image in elements)
            {
                foreach(var link in visibleLinks)
                {
                    if (image.HtmlElement.Equals(link.HtmlElement))
                    {
                        link.Distance = -1;
                        break;
                    }
                }
            }
            foreach(var image in elements)
            {
                visibleLinks.Add(image);
            }
            visibleLinks.RemoveAll(link => (link.ElementType.Equals("A") && string.IsNullOrWhiteSpace(link.ElementContent)) || (link.Distance == -1));
            visibleLinks.Sort((a, b) => a.Distance.CompareTo(b.Distance));
            return visibleLinks;
        }

        private void FindElements(GeckoWebBrowser browser, string tagName, Point clickPosition)
        {
            //double x, y;
            //GeckoHtmlElement offsetParentElement;
            GeckoHtmlElement parentElement;
            GeckoNode childNode = null;
            GeckoHtmlElement childElement = null;
            foreach (var element in browser.Document.GetElementsByTagName(tagName))
            {
                if ((element.ComputedStyle.GetPropertyValue("display").Equals("none")) || (element.ComputedStyle.GetPropertyValue("visibility").Equals("hidden"))) { continue; }
                parentElement = element;
                while (parentElement != null)
                {
                    if (parentElement.TagName.Equals("A"))
                    {
                        int x = 0, y = 0, width = 0, height = 0, extraHeight = 0;
                        if (tagName.Equals("A"))
                        {
                            if (parentElement.ClientRects.Length == 1)
                            {
                                x = parentElement.ClientRects[0].X + parentElement.ClientRects[0].Width / 2;
                                y = parentElement.ClientRects[0].Y + parentElement.ClientRects[0].Height / 2;
                                width = parentElement.ClientRects[0].Width;
                                height = parentElement.ClientRects[0].Height;
                                if (parentElement.HasChildNodes)
                                {
                                    try
                                    {
                                        childNode = parentElement.ChildNodes[0];
                                        while (true)
                                        {
                                            if (childNode.NodeType == NodeType.Element)
                                            {
                                                childElement = (GeckoHtmlElement)childNode;
                                                if (childElement.ClientRects[0].Height > parentElement.ClientRects[0].Height && childElement.ClientRects[0].Height > extraHeight)
                                                {
                                                    extraHeight = childElement.ClientRects[0].Height - parentElement.ClientRects[0].Height;
                                                }
                                                if (childElement.HasChildNodes)
                                                {
                                                    childNode = childElement.ChildNodes[0];
                                                }
                                                else break;
                                            }
                                            else break;
                                        }
                                    } catch (Exception e) { }
                                    if (extraHeight != 0)
                                    {
                                        y -= extraHeight / 2;
                                        height += extraHeight;
                                    }
                                }
                                if (x >= 0 && x < browser.Width && y >= 0 && y < browser.Height) visibleLinks.Add(new PageElement(tagName, element.TextContent, element, x - (width / 2), y - (height / 2), width, height, Math.Sqrt(Math.Pow((x - clickPosition.X), 2) + Math.Pow((y - clickPosition.Y), 2))));
                            }
                            else if (parentElement.ClientRects.Length > 1)
                            {
                                x = parentElement.ClientRects[0].X;
                                foreach (Rectangle rect in parentElement.ClientRects)
                                {
                                    if (rect.X < x)
                                    {
                                        x = rect.X;
                                    }
                                }
                                y = parentElement.ClientRects[0].Y;
                                int tempWidth = 0;
                                foreach (Rectangle rect in parentElement.ClientRects)
                                {
                                    if (rect.X + rect.Width > tempWidth)
                                    {
                                        tempWidth = rect.X + rect.Width;
                                        width = tempWidth - x;
                                    }
                                }
                                height = - parentElement.ClientRects[0].Y + parentElement.ClientRects[parentElement.ClientRects.Length - 1].Y + parentElement.ClientRects[parentElement.ClientRects.Length - 1].Height;
                                x += width / 2;
                                y += height / 2;
                                if (parentElement.HasChildNodes)
                                {
                                    try
                                    {
                                        childNode = parentElement.ChildNodes[0];
                                        while (true)
                                        {
                                            if (childNode.NodeType == NodeType.Element)
                                            {
                                                childElement = (GeckoHtmlElement)childNode;
                                                if (childElement.ClientRects[0].Height > parentElement.ClientRects[0].Height && childElement.ClientRects[0].Height > extraHeight)
                                                {
                                                    extraHeight = childElement.ClientRects[0].Height - parentElement.ClientRects[0].Height;
                                                }
                                                if (childElement.HasChildNodes)
                                                {
                                                    childNode = childElement.ChildNodes[0];
                                                }
                                                else break;
                                            }
                                            else break;
                                        }
                                    }
                                    catch (Exception e) { }
                                    if (extraHeight != 0)
                                    {
                                        y -= extraHeight / 2;
                                        height += extraHeight;
                                    }
                                }
                                if (x >= 0 && x < browser.Width && y >= 0 && y < browser.Height) visibleLinks.Add(new PageElement(tagName, element.TextContent, element, x - (width / 2), y - (height / 2), width, height, Math.Sqrt(Math.Pow((x - clickPosition.X), 2) + Math.Pow((y - clickPosition.Y), 2))));
                            }
                        }
                        else if (tagName.Equals("IMG"))
                        {
                            if (element.ClientRects.Length >= 1)
                            {
                                x = element.ClientRects[0].X + element.ClientWidth / 2;
                                y = element.ClientRects[0].Y + element.ClientHeight / 2;
                                width = element.ClientWidth;
                                height = element.ClientHeight;
                                if (x >= 0 && x < browser.Width && y >= 0 && y < browser.Height) elements.Add(new PageElement(tagName, parentElement.GetAttribute("HREF"), parentElement, x - (width / 2), y - (height / 2), width, height, Math.Sqrt(Math.Pow((x - clickPosition.X), 2) + Math.Pow((y - clickPosition.Y), 2))));
                            }
                        }
                        //x = element.OffsetLeft + (element.OffsetWidth / 2.0) - browser.Document.GetElementsByTagName("HTML")[0].ScrollLeft + Convert.ToDouble(browser.Document.GetElementsByTagName("BODY")[0].ComputedStyle.GetPropertyValue("margin-left").Replace("px",""));
                        //if (parentElement.ClientRects.Length > 1 && !tagName.Equals("IMG"))
                        //{
                        //    if (parentElement.ClientRects[0].X > parentElement.ClientRects[1].X)
                        //    {
                        //        x += parentElement.ClientRects[1].X - parentElement.ClientRects[0].X;
                        //    }
                        //}
                        //y = element.OffsetTop + (element.OffsetHeight / 2.0) - browser.Document.GetElementsByTagName("HTML")[0].ScrollTop + Convert.ToDouble(browser.Document.GetElementsByTagName("BODY")[0].ComputedStyle.GetPropertyValue("margin-top").Replace("px","")); 
                        //offsetParentElement = element.OffsetParent;
                        //x -= parentElement.ScrollLeft;
                        //y -= parentElement.ScrollTop;
                        //GeckoHtmlElement scrollElement = parentElement;
                        //while (scrollElement != null)
                        //{
                        //    scrollElement = scrollElement.Parent;
                        //    if (!scrollElement.TagName.Equals("BODY") && !scrollElement.TagName.Equals("HTML") && scrollElement != null)
                        //    {
                        //        x -= scrollElement.ScrollLeft;
                        //        y -= scrollElement.ScrollTop;
                        //    }
                        //    else break;
                        //}
                        //while (offsetParentElement != null)
                        //{
                        //    if (offsetParentElement.ComputedStyle.GetPropertyValue("position").Equals("fixed"))
                        //    {
                        //        x = x + browser.Document.GetElementsByTagName("HTML")[0].ScrollLeft - Convert.ToDouble(browser.Document.GetElementsByTagName("BODY")[0].ComputedStyle.GetPropertyValue("margin-left").Replace("px", "")) + Convert.ToDouble(offsetParentElement.ComputedStyle.GetPropertyValue("left").Replace("px", ""));
                        //        y = y + browser.Document.GetElementsByTagName("HTML")[0].ScrollTop - Convert.ToDouble(browser.Document.GetElementsByTagName("BODY")[0].ComputedStyle.GetPropertyValue("margin-top").Replace("px", "")) + Convert.ToDouble(offsetParentElement.ComputedStyle.GetPropertyValue("top").Replace("px", ""));
                        //        break;
                        //    }
                        //    x += offsetParentElement.OffsetLeft;
                        //    y += offsetParentElement.OffsetTop;
                        //    offsetParentElement = offsetParentElement.OffsetParent;
                        //}
                        //if (x >= 0.0 && x < browser.Width && y >= 0.0 && y < browser.Height)
                        //{
                        //    if (tagName.Equals("A"))
                        //    {
                        //        visibleLinks.Add(new PageElement(tagName, element.TextContent, element, x - (element.OffsetWidth / 2.0), y - (element.OffsetHeight / 2.0), element.OffsetWidth+1, element.OffsetHeight+1, Math.Sqrt(Math.Pow((x - clickPosition.X), 2) + Math.Pow((y - clickPosition.Y), 2))));
                        //    }
                        //    else
                        //    {
                        //        elements.Add(new PageElement(tagName, parentElement.GetAttribute("HREF"), parentElement, x - (element.OffsetWidth / 2.0), y - (element.OffsetHeight / 2.0), element.OffsetWidth, element.OffsetHeight, Math.Sqrt(Math.Pow((x - clickPosition.X), 2) + Math.Pow((y - clickPosition.Y), 2))));
                        //    }
                        //}
                        break;
                    }
                    parentElement = parentElement.Parent;
                }
            }
        }

        public Image TakeElementScreenshot(GeckoWebBrowser browser, PageElement element)
        {
            Rectangle rectangle = new Rectangle(0, 0, 0, 0);
            if (element.RelativeX < 0)
            {
                rectangle.X = browser.PointToScreen(Point.Empty).X;
                rectangle.Width = element.Width + element.RelativeX;
            }
            else
            {
                rectangle.X = browser.PointToScreen(Point.Empty).X + element.RelativeX;
            }

            if (element.RelativeY < 0)
            {
                rectangle.Y = browser.PointToScreen(Point.Empty).Y;
                rectangle.Height = element.Height + element.RelativeY;
            }
            else
            {
                rectangle.Y = browser.PointToScreen(Point.Empty).Y + element.RelativeY;
            }

            if (browser.PointToScreen(Point.Empty).X + browser.Width < rectangle.X + element.Width)
            {
                rectangle.Width = browser.PointToScreen(Point.Empty).X + browser.Width - rectangle.X;
            }
            else if (rectangle.Width == 0)
            {
                rectangle.Width = element.Width;
            }

            if (browser.PointToScreen(Point.Empty).Y + browser.Height < rectangle.Y + element.Height)
            {
                rectangle.Height = browser.PointToScreen(Point.Empty).Y + browser.Height - rectangle.Y;
            }
            else if (rectangle.Height == 0)
            {
                rectangle.Height = element.Height;
            }

            Bitmap bitmap = null;
            try
            {
                bitmap = new Bitmap(rectangle.Width, rectangle.Height, PixelFormat.Format32bppArgb);
            } catch (Exception e)
            {
                bitmap = new Bitmap(5, 5, PixelFormat.Format32bppArgb);
            }
            Graphics graphics = Graphics.FromImage(bitmap);
            graphics.CopyFromScreen(rectangle.X, rectangle.Y, 0, 0, bitmap.Size, CopyPixelOperation.SourceCopy);
            return bitmap;
        }


        public List<PageElement> FindAllLinks(GeckoWebBrowser browser, Point clickPosition)
        {
            visibleLinks.Clear();
            elements.Clear();
            FindElements(browser, "A", clickPosition);
            FindElements(browser, "IMG", clickPosition);
            foreach (var image in elements)
            {
                foreach (var link in visibleLinks)
                {
                    if (image.HtmlElement.Equals(link.HtmlElement))
                    {
                        link.Distance = -1;
                        break;
                    }
                }
            }
            foreach (var image in elements)
            {
                visibleLinks.Add(image);
            }
            visibleLinks.RemoveAll(link => link.Distance == -1);
            visibleLinks.Sort((a, b) => a.Distance.CompareTo(b.Distance));
            if(visibleLinks.Count != 0)
            {
                actualElement = visibleLinks[0];
            }
            return visibleLinks;
        }

        private PageElement FindNextLink(GeckoWebBrowser browser, int direction)
        {
            Point p1 = new Point(), p2 = new Point(), p3 = new Point();
            if(direction == 1)
            {
                p1.X = actualElement.RelativeX;
                p2.X = p1.X + actualElement.Width / 2;
                p3.X = p1.X + actualElement.Width;
                p1.Y = actualElement.RelativeY;
                p2.Y = p1.Y;
                p3.Y = p1.Y;
            }
            else if (direction == 2)
            {
                p1.X = actualElement.RelativeX;
                p2.X = p1.X;
                p3.X = p1.X;
                p1.Y = actualElement.RelativeY;
                p2.Y = p1.Y + actualElement.Height / 2;
                p3.Y = p1.Y + actualElement.Height;
            }
            else if (direction == 3)
            {
                p1.X = actualElement.RelativeX;
                p2.X = p1.X + actualElement.Width / 2;
                p3.X = p1.X + actualElement.Width;
                p1.Y = actualElement.RelativeY + actualElement.Height;
                p2.Y = p1.Y;
                p3.Y = p1.Y;
            }
            else if (direction == 4)
            {
                p1.X = actualElement.RelativeX + actualElement.Width;
                p2.X = p1.X;
                p3.X = p1.X;
                p1.Y = actualElement.RelativeY;
                p2.Y = p1.Y + actualElement.Height / 2;
                p3.Y = p1.Y + actualElement.Height;
            }

            if(direction == 1)
            {
                while(p1.Y > 0)
                {
                    p1.Y -= 3;
                    foreach(var link in visibleLinks)
                    {
                        if (p1.Y >= link.RelativeY && p1.Y <= link.RelativeY + link.Height &&
                            ((p1.X >= link.RelativeX && p1.X <= link.RelativeX + link.Width) ||
                            (p2.X >= link.RelativeX && p2.X <= link.RelativeX + link.Width) ||
                            (p3.X >= link.RelativeX && p3.X <= link.RelativeX + link.Width)))
                        {
                            actualElement = link;
                            return link;
                        }
                    }
                }
            }
            else if (direction == 2)
            {
                while (p1.X > 0)
                {
                    p1.X -= 3;
                    foreach (var link in visibleLinks)
                    {
                        if (p1.X >= link.RelativeX && p1.X <= link.RelativeX + link.Width &&
                            ((p1.Y >= link.RelativeY && p1.Y <= link.RelativeY + link.Height) ||
                            (p2.Y >= link.RelativeY && p2.Y <= link.RelativeY + link.Height) ||
                            (p3.Y >= link.RelativeY && p3.Y <= link.RelativeY + link.Height)))
                        {
                            actualElement = link;
                            return link;
                        }
                    }
                }
            }
            else if (direction == 3)
            {
                while (p1.Y < browser.Height)
                {
                    p1.Y += 3;
                    foreach (var link in visibleLinks)
                    {
                        if (p1.Y >= link.RelativeY && p1.Y <= link.RelativeY + link.Height &&
                            ((p1.X >= link.RelativeX && p1.X <= link.RelativeX + link.Width) ||
                            (p2.X >= link.RelativeX && p2.X <= link.RelativeX + link.Width) ||
                            (p3.X >= link.RelativeX && p3.X <= link.RelativeX + link.Width)))
                        {
                            actualElement = link;
                            return link;
                        }
                    }
                }
            }
            else if (direction == 4)
            {
                while (p1.X < browser.Width)
                {
                    p1.X += 3;
                    foreach (var link in visibleLinks)
                    {
                        if (p1.X >= link.RelativeX && p1.X <= link.RelativeX + link.Width &&
                            ((p1.Y >= link.RelativeY && p1.Y <= link.RelativeY + link.Height) ||
                            (p2.Y >= link.RelativeY && p2.Y <= link.RelativeY + link.Height) ||
                            (p3.Y >= link.RelativeY && p3.Y <= link.RelativeY + link.Height)))
                        {
                            actualElement = link;
                            return link;
                        }
                    }
                }
            }

            return actualElement;
        }

        public void ChangeNavigatorPosition(GeckoWebBrowser browser, int direction, Panel linkPanel, Button upButton, Button leftButton, Button downButton, Button rightButton)
        {
            if(direction != 0)
            {
                actualElement.HtmlElement.RemoveAttribute("style");
            }
            FindNextLink(browser, direction);
            actualElement.HtmlElement.SetAttribute("style", @"background-color: PaleGoldenrod; color: DarkRed;");

            Rectangle rectangle = new Rectangle(0, 0, 0, 0);
            if (actualElement.RelativeX < 0)
            {
                rectangle.X = browser.PointToScreen(Point.Empty).X;
                rectangle.Width = actualElement.Width + actualElement.RelativeX;
            }
            else
            {
                rectangle.X = browser.PointToScreen(Point.Empty).X + actualElement.RelativeX;
            }

            if (actualElement.RelativeY < 0)
            {
                rectangle.Y = browser.PointToScreen(Point.Empty).Y;
                rectangle.Height = actualElement.Height + actualElement.RelativeY;
            }
            else
            {
                rectangle.Y = browser.PointToScreen(Point.Empty).Y + actualElement.RelativeY;
            }

            if (browser.PointToScreen(Point.Empty).X + browser.Width < rectangle.X + actualElement.Width)
            {
                rectangle.Width = browser.PointToScreen(Point.Empty).X + browser.Width - rectangle.X;
            }
            else if (rectangle.Width == 0)
            {
                rectangle.Width = actualElement.Width;
            }

            if (browser.PointToScreen(Point.Empty).Y + browser.Height < rectangle.Y + actualElement.Height)
            {
                rectangle.Height = browser.PointToScreen(Point.Empty).Y + browser.Height - rectangle.Y;
            }
            else if (rectangle.Height == 0)
            {
                rectangle.Height = actualElement.Height;
            }
            linkPanel.Location = rectangle.Location;
            linkPanel.Size = rectangle.Size;

            if(linkPanel.Width < leftButton.Width)
            {
                linkPanel.Left += (linkPanel.Width / 2 - leftButton.Width / 2);
                linkPanel.Width = leftButton.Width;
            }
            if(linkPanel.Height < upButton.Height)
            {
                linkPanel.Top += (linkPanel.Height / 2 - upButton.Height / 2);
                linkPanel.Height = upButton.Height;
            }

            leftButton.Left = linkPanel.Left - leftButton.Width;
            leftButton.Top = linkPanel.Top;
            leftButton.Height = linkPanel.Height;

            upButton.Left = leftButton.Left + leftButton.Width;
            upButton.Top = leftButton.Top - upButton.Height;
            upButton.Width = linkPanel.Width;

            downButton.Left = upButton.Left;
            downButton.Top = leftButton.Top + leftButton.Height;
            downButton.Width = upButton.Width;

            rightButton.Left = linkPanel.Left + linkPanel.Width;
            rightButton.Top = leftButton.Top;
            rightButton.Height = leftButton.Height;
        }

        public void ClickActualLink()
        {
            actualElement.HtmlElement.RemoveAttribute("style");
            actualElement.HtmlElement.Click();
        }

        public PageElement PointedElement { get { return actualElement; } }


    }
}