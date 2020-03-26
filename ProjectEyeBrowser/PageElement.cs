namespace ProjectEyeBrowser
{

    public class PageElement
    {
        private string type;
        private string content;
        private Gecko.GeckoHtmlElement element;
        private int relativeX;
        private int relativeY;
        private int width;
        private int height;
        private double totalDistance;

        public PageElement(string elementType, string text, Gecko.GeckoHtmlElement HtmlElement, double xPosition, double yPosition, int w, int h, double distance)
        {
            type = elementType;
            content = text;
            element = HtmlElement;
            relativeX = System.Convert.ToInt32(xPosition);
            relativeY = System.Convert.ToInt32(yPosition);
            width = w;
            height = h;
            totalDistance = distance;
        }

        public string ElementType { get { return type; } set { type = value; } }
        public string ElementContent { get { return content; } set { content = value; } }
        public Gecko.GeckoHtmlElement HtmlElement { get { return element; } set { element = value; } }
        public int RelativeX { get { return relativeX; } set { relativeX = value; } }
        public int RelativeY { get { return relativeY; } set { relativeY = value; } }
        public int Width { get { return width; } set { width = value; } }
        public int Height { get { return height; } set { height = value; } }
        public double Distance { get { return totalDistance; } set { totalDistance = value; } }
    }

}