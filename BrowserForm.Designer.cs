namespace ProjectEyeBrowser
{
    partial class eyeBrowserForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Designer Code

        private void InitializeComponent()
        {
            this.browserControl = new Gecko.GeckoWebBrowser();
            this.linkSelectorButton = new System.Windows.Forms.Button();
            this.forwardNavigationBrowserButton = new System.Windows.Forms.Button();
            this.backNavigationBrowserButton = new System.Windows.Forms.Button();
            this.linkLabelsPanel = new System.Windows.Forms.TableLayoutPanel();
            this.link1Label = new System.Windows.Forms.Label();
            this.link2Label = new System.Windows.Forms.Label();
            this.link3Label = new System.Windows.Forms.Label();
            this.link4Label = new System.Windows.Forms.Label();
            this.link5Label = new System.Windows.Forms.Label();
            this.urlPanel = new System.Windows.Forms.TableLayoutPanel();
            this.refreshButton = new System.Windows.Forms.Button();
            this.goHomepageButton = new System.Windows.Forms.Button();
            this.urlBoxPanel = new System.Windows.Forms.Panel();
            this.urlBox = new System.Windows.Forms.TextBox();
            this.openFavoritesButton = new System.Windows.Forms.Button();
            this.openPopupButton = new System.Windows.Forms.Button();
            this.titleBar = new System.Windows.Forms.TableLayoutPanel();
            this.titleLabel = new System.Windows.Forms.Label();
            this.minimizeButton = new System.Windows.Forms.Button();
            this.closeButton = new System.Windows.Forms.Button();
            this.leftButtonsPanel = new System.Windows.Forms.TableLayoutPanel();
            this.linkNavigatorButton = new System.Windows.Forms.Button();
            this.progressiveZoomButton = new System.Windows.Forms.Button();
            this.immediateZoomButton = new System.Windows.Forms.Button();
            this.freePointingButton = new System.Windows.Forms.Button();
            this.rightNavigatorButton = new System.Windows.Forms.Button();
            this.downNavigatorButton = new System.Windows.Forms.Button();
            this.leftNavigatorButton = new System.Windows.Forms.Button();
            this.upNavigatorButton = new System.Windows.Forms.Button();
            this.rightButtonsPanel = new System.Windows.Forms.TableLayoutPanel();
            this.keyboardButton = new System.Windows.Forms.Button();
            this.scrollUpButton = new System.Windows.Forms.Button();
            this.scrollDownButton = new System.Windows.Forms.Button();
            this.scrollLeftButton = new System.Windows.Forms.Button();
            this.scrollRightButton = new System.Windows.Forms.Button();
            this.clickCirclePanel = new System.Windows.Forms.Panel();
            this.clickButton = new System.Windows.Forms.Button();
            this.pointedLinkPanel = new ProjectEyeBrowser.TransparentPanel();
            this.browserLinkSelectorPanel = new ProjectEyeBrowser.TransparentPanel();
            this.browserLinkNavigatorPanel = new ProjectEyeBrowser.TransparentPanel();
            this.browserZoomPanel = new ProjectEyeBrowser.TransparentPanel();
            this.scrollPanel = new ProjectEyeBrowser.TransparentPanel();
            this.keyboard = new ProjectEyeBrowser.Keyboard();
            this.favoritesPanel = new ProjectEyeBrowser.FavoritesPanel();
            this.circleAnimationPanel = new ProjectEyeBrowser.TransparentPanel();
            this.blockingPanel = new ProjectEyeBrowser.TransparentPanel();
            this.popupPanel = new System.Windows.Forms.TableLayoutPanel();
            this.cancelPopupButton = new System.Windows.Forms.Button();
            this.minimizePopupButton = new System.Windows.Forms.Button();
            this.closePopupButton = new System.Windows.Forms.Button();
            this.linkLabelsPanel.SuspendLayout();
            this.urlPanel.SuspendLayout();
            this.urlBoxPanel.SuspendLayout();
            this.titleBar.SuspendLayout();
            this.leftButtonsPanel.SuspendLayout();
            this.rightButtonsPanel.SuspendLayout();
            this.popupPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // browserControl
            // 
            this.browserControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.browserControl.FrameEventsPropagateToMainWindow = false;
            this.browserControl.Location = new System.Drawing.Point(178, 175);
            this.browserControl.Name = "browserControl";
            this.browserControl.Size = new System.Drawing.Size(948, 411);
            this.browserControl.TabIndex = 0;
            this.browserControl.UseHttpActivityObserver = false;
            this.browserControl.Navigating += new System.EventHandler<Gecko.Events.GeckoNavigatingEventArgs>(this.NavigationColor);
            this.browserControl.Navigated += new System.EventHandler<Gecko.GeckoNavigatedEventArgs>(this.ShowURL);
            this.browserControl.DocumentCompleted += new System.EventHandler<Gecko.Events.GeckoDocumentCompletedEventArgs>(this.NavigationCompleted);
            this.browserControl.CanGoBackChanged += new System.EventHandler(this.CanGoBackChanged);
            this.browserControl.CanGoForwardChanged += new System.EventHandler(this.CanGoForwardChanged);
            this.browserControl.CreateWindow += new System.EventHandler<Gecko.GeckoCreateWindowEventArgs>(this.BlockNewWindow);
            // 
            // linkSelectorButton
            // 
            this.linkSelectorButton.BackColor = System.Drawing.Color.LightCyan;
            this.linkSelectorButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.linkSelectorButton.FlatAppearance.BorderColor = System.Drawing.Color.MidnightBlue;
            this.linkSelectorButton.FlatAppearance.BorderSize = 2;
            this.linkSelectorButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.linkSelectorButton.Font = new System.Drawing.Font("Segoe UI Semibold", 20F, System.Drawing.FontStyle.Bold);
            this.linkSelectorButton.ForeColor = System.Drawing.Color.MidnightBlue;
            this.linkSelectorButton.Location = new System.Drawing.Point(2, 0);
            this.linkSelectorButton.Margin = new System.Windows.Forms.Padding(2, 0, 0, 1);
            this.linkSelectorButton.Name = "linkSelectorButton";
            this.linkSelectorButton.Size = new System.Drawing.Size(173, 81);
            this.linkSelectorButton.TabIndex = 2;
            this.linkSelectorButton.Text = "Menu";
            this.linkSelectorButton.UseVisualStyleBackColor = false;
            this.linkSelectorButton.Click += new System.EventHandler(this.ChangeLinkSelectorStatus);
            // 
            // forwardNavigationBrowserButton
            // 
            this.forwardNavigationBrowserButton.BackColor = System.Drawing.Color.Gainsboro;
            this.forwardNavigationBrowserButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.forwardNavigationBrowserButton.FlatAppearance.BorderColor = System.Drawing.Color.MidnightBlue;
            this.forwardNavigationBrowserButton.FlatAppearance.BorderSize = 2;
            this.forwardNavigationBrowserButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.forwardNavigationBrowserButton.Font = new System.Drawing.Font("Segoe UI Black", 40F, System.Drawing.FontStyle.Bold);
            this.forwardNavigationBrowserButton.ForeColor = System.Drawing.Color.Gray;
            this.forwardNavigationBrowserButton.Location = new System.Drawing.Point(145, 0);
            this.forwardNavigationBrowserButton.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.forwardNavigationBrowserButton.Name = "forwardNavigationBrowserButton";
            this.forwardNavigationBrowserButton.Size = new System.Drawing.Size(139, 150);
            this.forwardNavigationBrowserButton.TabIndex = 1;
            this.forwardNavigationBrowserButton.Text = "→";
            this.forwardNavigationBrowserButton.UseVisualStyleBackColor = false;
            this.forwardNavigationBrowserButton.Click += new System.EventHandler(this.ForwardNavigate);
            // 
            // backNavigationBrowserButton
            // 
            this.backNavigationBrowserButton.BackColor = System.Drawing.Color.Gainsboro;
            this.backNavigationBrowserButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.backNavigationBrowserButton.FlatAppearance.BorderColor = System.Drawing.Color.MidnightBlue;
            this.backNavigationBrowserButton.FlatAppearance.BorderSize = 2;
            this.backNavigationBrowserButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.backNavigationBrowserButton.Font = new System.Drawing.Font("Segoe UI Black", 40F, System.Drawing.FontStyle.Bold);
            this.backNavigationBrowserButton.ForeColor = System.Drawing.Color.Gray;
            this.backNavigationBrowserButton.Location = new System.Drawing.Point(0, 0);
            this.backNavigationBrowserButton.Margin = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.backNavigationBrowserButton.Name = "backNavigationBrowserButton";
            this.backNavigationBrowserButton.Size = new System.Drawing.Size(141, 150);
            this.backNavigationBrowserButton.TabIndex = 0;
            this.backNavigationBrowserButton.Text = "←";
            this.backNavigationBrowserButton.UseVisualStyleBackColor = false;
            this.backNavigationBrowserButton.Click += new System.EventHandler(this.BackNavigate);
            // 
            // linkLabelsPanel
            // 
            this.linkLabelsPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.linkLabelsPanel.BackColor = System.Drawing.Color.Teal;
            this.linkLabelsPanel.ColumnCount = 1;
            this.linkLabelsPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.linkLabelsPanel.Controls.Add(this.link1Label, 0, 0);
            this.linkLabelsPanel.Controls.Add(this.link2Label, 0, 1);
            this.linkLabelsPanel.Controls.Add(this.link3Label, 0, 2);
            this.linkLabelsPanel.Controls.Add(this.link4Label, 0, 3);
            this.linkLabelsPanel.Controls.Add(this.link5Label, 0, 4);
            this.linkLabelsPanel.Location = new System.Drawing.Point(417, 178);
            this.linkLabelsPanel.Name = "linkLabelsPanel";
            this.linkLabelsPanel.RowCount = 5;
            this.linkLabelsPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.linkLabelsPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.linkLabelsPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.linkLabelsPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.linkLabelsPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.linkLabelsPanel.Size = new System.Drawing.Size(470, 405);
            this.linkLabelsPanel.TabIndex = 5;
            this.linkLabelsPanel.Visible = false;
            // 
            // link1Label
            // 
            this.link1Label.AutoEllipsis = true;
            this.link1Label.BackColor = System.Drawing.Color.LemonChiffon;
            this.link1Label.Dock = System.Windows.Forms.DockStyle.Fill;
            this.link1Label.Font = new System.Drawing.Font("Cambria", 14.25F);
            this.link1Label.ForeColor = System.Drawing.Color.Black;
            this.link1Label.Location = new System.Drawing.Point(4, 4);
            this.link1Label.Margin = new System.Windows.Forms.Padding(4, 4, 4, 2);
            this.link1Label.Name = "link1Label";
            this.link1Label.Size = new System.Drawing.Size(462, 75);
            this.link1Label.TabIndex = 0;
            this.link1Label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.link1Label.Click += new System.EventHandler(this.SelectLink);
            // 
            // link2Label
            // 
            this.link2Label.AutoEllipsis = true;
            this.link2Label.BackColor = System.Drawing.Color.LemonChiffon;
            this.link2Label.Dock = System.Windows.Forms.DockStyle.Fill;
            this.link2Label.Font = new System.Drawing.Font("Cambria", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.link2Label.ForeColor = System.Drawing.Color.Black;
            this.link2Label.Location = new System.Drawing.Point(4, 83);
            this.link2Label.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.link2Label.Name = "link2Label";
            this.link2Label.Size = new System.Drawing.Size(462, 77);
            this.link2Label.TabIndex = 1;
            this.link2Label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.link2Label.Click += new System.EventHandler(this.SelectLink);
            // 
            // link3Label
            // 
            this.link3Label.AutoEllipsis = true;
            this.link3Label.BackColor = System.Drawing.Color.LemonChiffon;
            this.link3Label.Dock = System.Windows.Forms.DockStyle.Fill;
            this.link3Label.Font = new System.Drawing.Font("Cambria", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.link3Label.ForeColor = System.Drawing.Color.Black;
            this.link3Label.Location = new System.Drawing.Point(4, 164);
            this.link3Label.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.link3Label.Name = "link3Label";
            this.link3Label.Size = new System.Drawing.Size(462, 77);
            this.link3Label.TabIndex = 2;
            this.link3Label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.link3Label.Click += new System.EventHandler(this.SelectLink);
            // 
            // link4Label
            // 
            this.link4Label.AutoEllipsis = true;
            this.link4Label.BackColor = System.Drawing.Color.LemonChiffon;
            this.link4Label.Dock = System.Windows.Forms.DockStyle.Fill;
            this.link4Label.Font = new System.Drawing.Font("Cambria", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.link4Label.ForeColor = System.Drawing.Color.Black;
            this.link4Label.Location = new System.Drawing.Point(4, 245);
            this.link4Label.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.link4Label.Name = "link4Label";
            this.link4Label.Size = new System.Drawing.Size(462, 77);
            this.link4Label.TabIndex = 3;
            this.link4Label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.link4Label.Click += new System.EventHandler(this.SelectLink);
            // 
            // link5Label
            // 
            this.link5Label.AutoEllipsis = true;
            this.link5Label.BackColor = System.Drawing.Color.LemonChiffon;
            this.link5Label.Dock = System.Windows.Forms.DockStyle.Fill;
            this.link5Label.Font = new System.Drawing.Font("Cambria", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.link5Label.ForeColor = System.Drawing.Color.Black;
            this.link5Label.Location = new System.Drawing.Point(4, 326);
            this.link5Label.Margin = new System.Windows.Forms.Padding(4, 2, 4, 4);
            this.link5Label.Name = "link5Label";
            this.link5Label.Size = new System.Drawing.Size(462, 75);
            this.link5Label.TabIndex = 4;
            this.link5Label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.link5Label.Click += new System.EventHandler(this.SelectLink);
            // 
            // urlPanel
            // 
            this.urlPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.urlPanel.ColumnCount = 7;
            this.urlPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11F));
            this.urlPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11F));
            this.urlPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11F));
            this.urlPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11F));
            this.urlPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 34F));
            this.urlPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11F));
            this.urlPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11F));
            this.urlPanel.Controls.Add(this.backNavigationBrowserButton, 0, 0);
            this.urlPanel.Controls.Add(this.forwardNavigationBrowserButton, 1, 0);
            this.urlPanel.Controls.Add(this.refreshButton, 2, 0);
            this.urlPanel.Controls.Add(this.goHomepageButton, 3, 0);
            this.urlPanel.Controls.Add(this.urlBoxPanel, 4, 0);
            this.urlPanel.Controls.Add(this.openFavoritesButton, 5, 0);
            this.urlPanel.Controls.Add(this.openPopupButton, 6, 0);
            this.urlPanel.Location = new System.Drawing.Point(2, 22);
            this.urlPanel.Name = "urlPanel";
            this.urlPanel.RowCount = 1;
            this.urlPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.urlPanel.Size = new System.Drawing.Size(1300, 150);
            this.urlPanel.TabIndex = 7;
            // 
            // refreshButton
            // 
            this.refreshButton.BackColor = System.Drawing.Color.LightCyan;
            this.refreshButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.refreshButton.FlatAppearance.BorderColor = System.Drawing.Color.MidnightBlue;
            this.refreshButton.FlatAppearance.BorderSize = 2;
            this.refreshButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.refreshButton.Font = new System.Drawing.Font("Segoe UI Black", 36F, System.Drawing.FontStyle.Bold);
            this.refreshButton.ForeColor = System.Drawing.Color.MidnightBlue;
            this.refreshButton.Location = new System.Drawing.Point(288, 0);
            this.refreshButton.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.refreshButton.Name = "refreshButton";
            this.refreshButton.Size = new System.Drawing.Size(139, 150);
            this.refreshButton.TabIndex = 0;
            this.refreshButton.Text = "⭮";
            this.refreshButton.UseVisualStyleBackColor = false;
            this.refreshButton.Click += new System.EventHandler(this.RefreshPage);
            // 
            // goHomepageButton
            // 
            this.goHomepageButton.BackColor = System.Drawing.Color.LightCyan;
            this.goHomepageButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.goHomepageButton.FlatAppearance.BorderColor = System.Drawing.Color.MidnightBlue;
            this.goHomepageButton.FlatAppearance.BorderSize = 2;
            this.goHomepageButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.goHomepageButton.Font = new System.Drawing.Font("Segoe UI Black", 30F, System.Drawing.FontStyle.Bold);
            this.goHomepageButton.ForeColor = System.Drawing.Color.MidnightBlue;
            this.goHomepageButton.Location = new System.Drawing.Point(431, 0);
            this.goHomepageButton.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.goHomepageButton.Name = "goHomepageButton";
            this.goHomepageButton.Size = new System.Drawing.Size(139, 150);
            this.goHomepageButton.TabIndex = 7;
            this.goHomepageButton.Text = "🏠";
            this.goHomepageButton.UseVisualStyleBackColor = false;
            this.goHomepageButton.Click += new System.EventHandler(this.GoToHomepage);
            // 
            // urlBoxPanel
            // 
            this.urlBoxPanel.Controls.Add(this.urlBox);
            this.urlBoxPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.urlBoxPanel.Location = new System.Drawing.Point(575, 0);
            this.urlBoxPanel.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.urlBoxPanel.Name = "urlBoxPanel";
            this.urlBoxPanel.Size = new System.Drawing.Size(436, 150);
            this.urlBoxPanel.TabIndex = 9;
            this.urlBoxPanel.Click += new System.EventHandler(this.OpenKeyboardForNavigation);
            // 
            // urlBox
            // 
            this.urlBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.urlBox.BackColor = System.Drawing.Color.Ivory;
            this.urlBox.Font = new System.Drawing.Font("Segoe UI", 16F);
            this.urlBox.Location = new System.Drawing.Point(0, 60);
            this.urlBox.Margin = new System.Windows.Forms.Padding(0);
            this.urlBox.Name = "urlBox";
            this.urlBox.Size = new System.Drawing.Size(436, 36);
            this.urlBox.TabIndex = 7;
            this.urlBox.Click += new System.EventHandler(this.OpenKeyboardForNavigation);
            // 
            // openFavoritesButton
            // 
            this.openFavoritesButton.BackColor = System.Drawing.Color.LightCyan;
            this.openFavoritesButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.openFavoritesButton.FlatAppearance.BorderColor = System.Drawing.Color.MidnightBlue;
            this.openFavoritesButton.FlatAppearance.BorderSize = 2;
            this.openFavoritesButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.openFavoritesButton.Font = new System.Drawing.Font("Segoe UI Black", 36F, System.Drawing.FontStyle.Bold);
            this.openFavoritesButton.ForeColor = System.Drawing.Color.MidnightBlue;
            this.openFavoritesButton.Location = new System.Drawing.Point(1016, 0);
            this.openFavoritesButton.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.openFavoritesButton.Name = "openFavoritesButton";
            this.openFavoritesButton.Size = new System.Drawing.Size(139, 150);
            this.openFavoritesButton.TabIndex = 8;
            this.openFavoritesButton.Text = "★";
            this.openFavoritesButton.UseVisualStyleBackColor = false;
            this.openFavoritesButton.Click += new System.EventHandler(this.OpenFavorites);
            // 
            // openPopupButton
            // 
            this.openPopupButton.BackColor = System.Drawing.Color.LightCyan;
            this.openPopupButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.openPopupButton.FlatAppearance.BorderColor = System.Drawing.Color.MidnightBlue;
            this.openPopupButton.FlatAppearance.BorderSize = 2;
            this.openPopupButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.openPopupButton.Font = new System.Drawing.Font("Segoe UI", 32F, System.Drawing.FontStyle.Bold);
            this.openPopupButton.ForeColor = System.Drawing.Color.MidnightBlue;
            this.openPopupButton.Location = new System.Drawing.Point(1159, 0);
            this.openPopupButton.Margin = new System.Windows.Forms.Padding(2, 0, 0, 0);
            this.openPopupButton.Name = "openPopupButton";
            this.openPopupButton.Size = new System.Drawing.Size(141, 150);
            this.openPopupButton.TabIndex = 10;
            this.openPopupButton.Text = "_ X";
            this.openPopupButton.UseVisualStyleBackColor = false;
            this.openPopupButton.Click += new System.EventHandler(this.OpenPopup);
            // 
            // titleBar
            // 
            this.titleBar.BackColor = System.Drawing.Color.Teal;
            this.titleBar.ColumnCount = 3;
            this.titleBar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.titleBar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.titleBar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.titleBar.Controls.Add(this.titleLabel, 0, 0);
            this.titleBar.Controls.Add(this.minimizeButton, 1, 0);
            this.titleBar.Controls.Add(this.closeButton, 2, 0);
            this.titleBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.titleBar.Location = new System.Drawing.Point(0, 0);
            this.titleBar.Name = "titleBar";
            this.titleBar.RowCount = 1;
            this.titleBar.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.titleBar.Size = new System.Drawing.Size(1304, 20);
            this.titleBar.TabIndex = 8;
            // 
            // titleLabel
            // 
            this.titleLabel.AutoSize = true;
            this.titleLabel.BackColor = System.Drawing.Color.Teal;
            this.titleLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.titleLabel.Font = new System.Drawing.Font("Candara", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.titleLabel.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.titleLabel.Location = new System.Drawing.Point(0, 0);
            this.titleLabel.Margin = new System.Windows.Forms.Padding(0);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.titleLabel.Size = new System.Drawing.Size(782, 20);
            this.titleLabel.TabIndex = 0;
            this.titleLabel.Text = "EyeBrowser";
            this.titleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // minimizeButton
            // 
            this.minimizeButton.BackColor = System.Drawing.Color.LightSeaGreen;
            this.minimizeButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.minimizeButton.FlatAppearance.BorderColor = System.Drawing.Color.WhiteSmoke;
            this.minimizeButton.FlatAppearance.BorderSize = 0;
            this.minimizeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.minimizeButton.Font = new System.Drawing.Font("Candara", 18F, System.Drawing.FontStyle.Bold);
            this.minimizeButton.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.minimizeButton.Location = new System.Drawing.Point(822, 0);
            this.minimizeButton.Margin = new System.Windows.Forms.Padding(40, 0, 0, 3);
            this.minimizeButton.Name = "minimizeButton";
            this.minimizeButton.Size = new System.Drawing.Size(220, 17);
            this.minimizeButton.TabIndex = 1;
            this.minimizeButton.Text = "_";
            this.minimizeButton.UseVisualStyleBackColor = false;
            this.minimizeButton.Visible = false;
            this.minimizeButton.Click += new System.EventHandler(this.MinimizeWindow);
            // 
            // closeButton
            // 
            this.closeButton.BackColor = System.Drawing.Color.LightSeaGreen;
            this.closeButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.closeButton.FlatAppearance.BorderColor = System.Drawing.Color.WhiteSmoke;
            this.closeButton.FlatAppearance.BorderSize = 0;
            this.closeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.closeButton.Font = new System.Drawing.Font("Candara", 18F, System.Drawing.FontStyle.Bold);
            this.closeButton.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.closeButton.Location = new System.Drawing.Point(1062, 0);
            this.closeButton.Margin = new System.Windows.Forms.Padding(20, 0, 20, 3);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(222, 17);
            this.closeButton.TabIndex = 9;
            this.closeButton.Text = "X";
            this.closeButton.UseVisualStyleBackColor = false;
            this.closeButton.Visible = false;
            this.closeButton.Click += new System.EventHandler(this.CloseWindow);
            // 
            // leftButtonsPanel
            // 
            this.leftButtonsPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.leftButtonsPanel.ColumnCount = 1;
            this.leftButtonsPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.leftButtonsPanel.Controls.Add(this.linkSelectorButton, 0, 0);
            this.leftButtonsPanel.Controls.Add(this.linkNavigatorButton, 0, 1);
            this.leftButtonsPanel.Controls.Add(this.progressiveZoomButton, 0, 2);
            this.leftButtonsPanel.Controls.Add(this.immediateZoomButton, 0, 3);
            this.leftButtonsPanel.Controls.Add(this.freePointingButton, 0, 4);
            this.leftButtonsPanel.Location = new System.Drawing.Point(0, 175);
            this.leftButtonsPanel.Margin = new System.Windows.Forms.Padding(0);
            this.leftButtonsPanel.Name = "leftButtonsPanel";
            this.leftButtonsPanel.RowCount = 5;
            this.leftButtonsPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.leftButtonsPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.leftButtonsPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.leftButtonsPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.leftButtonsPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.leftButtonsPanel.Size = new System.Drawing.Size(175, 411);
            this.leftButtonsPanel.TabIndex = 9;
            // 
            // linkNavigatorButton
            // 
            this.linkNavigatorButton.BackColor = System.Drawing.Color.LightCyan;
            this.linkNavigatorButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.linkNavigatorButton.FlatAppearance.BorderColor = System.Drawing.Color.MidnightBlue;
            this.linkNavigatorButton.FlatAppearance.BorderSize = 2;
            this.linkNavigatorButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.linkNavigatorButton.Font = new System.Drawing.Font("Segoe UI Semibold", 20F, System.Drawing.FontStyle.Bold);
            this.linkNavigatorButton.ForeColor = System.Drawing.Color.MidnightBlue;
            this.linkNavigatorButton.Location = new System.Drawing.Point(2, 83);
            this.linkNavigatorButton.Margin = new System.Windows.Forms.Padding(2, 1, 0, 1);
            this.linkNavigatorButton.Name = "linkNavigatorButton";
            this.linkNavigatorButton.Size = new System.Drawing.Size(173, 80);
            this.linkNavigatorButton.TabIndex = 3;
            this.linkNavigatorButton.Text = "Discrete\r\nCursor";
            this.linkNavigatorButton.UseVisualStyleBackColor = false;
            this.linkNavigatorButton.Click += new System.EventHandler(this.ChangeLinkNavigatorStatus);
            // 
            // progressiveZoomButton
            // 
            this.progressiveZoomButton.BackColor = System.Drawing.Color.LightCyan;
            this.progressiveZoomButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.progressiveZoomButton.FlatAppearance.BorderColor = System.Drawing.Color.MidnightBlue;
            this.progressiveZoomButton.FlatAppearance.BorderSize = 2;
            this.progressiveZoomButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.progressiveZoomButton.Font = new System.Drawing.Font("Segoe UI Semibold", 20F, System.Drawing.FontStyle.Bold);
            this.progressiveZoomButton.ForeColor = System.Drawing.Color.MidnightBlue;
            this.progressiveZoomButton.Location = new System.Drawing.Point(2, 165);
            this.progressiveZoomButton.Margin = new System.Windows.Forms.Padding(2, 1, 0, 1);
            this.progressiveZoomButton.Name = "progressiveZoomButton";
            this.progressiveZoomButton.Size = new System.Drawing.Size(173, 80);
            this.progressiveZoomButton.TabIndex = 4;
            this.progressiveZoomButton.Text = "Progressive\r\nZoom";
            this.progressiveZoomButton.UseVisualStyleBackColor = false;
            this.progressiveZoomButton.Click += new System.EventHandler(this.ChangeProgressiveZoomStatus);
            // 
            // immediateZoomButton
            // 
            this.immediateZoomButton.BackColor = System.Drawing.Color.LightCyan;
            this.immediateZoomButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.immediateZoomButton.FlatAppearance.BorderColor = System.Drawing.Color.MidnightBlue;
            this.immediateZoomButton.FlatAppearance.BorderSize = 2;
            this.immediateZoomButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.immediateZoomButton.Font = new System.Drawing.Font("Segoe UI Semibold", 20F, System.Drawing.FontStyle.Bold);
            this.immediateZoomButton.ForeColor = System.Drawing.Color.MidnightBlue;
            this.immediateZoomButton.Location = new System.Drawing.Point(2, 247);
            this.immediateZoomButton.Margin = new System.Windows.Forms.Padding(2, 1, 0, 1);
            this.immediateZoomButton.Name = "immediateZoomButton";
            this.immediateZoomButton.Size = new System.Drawing.Size(173, 80);
            this.immediateZoomButton.TabIndex = 5;
            this.immediateZoomButton.Text = "Quick\r\nZoom";
            this.immediateZoomButton.UseVisualStyleBackColor = false;
            this.immediateZoomButton.Click += new System.EventHandler(this.ChangeImmediateZoomStatus);
            // 
            // freePointingButton
            // 
            this.freePointingButton.BackColor = System.Drawing.Color.LightCyan;
            this.freePointingButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.freePointingButton.FlatAppearance.BorderColor = System.Drawing.Color.MidnightBlue;
            this.freePointingButton.FlatAppearance.BorderSize = 2;
            this.freePointingButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.freePointingButton.Font = new System.Drawing.Font("Segoe UI Semibold", 20F, System.Drawing.FontStyle.Bold);
            this.freePointingButton.ForeColor = System.Drawing.Color.MidnightBlue;
            this.freePointingButton.Location = new System.Drawing.Point(2, 329);
            this.freePointingButton.Margin = new System.Windows.Forms.Padding(2, 1, 0, 0);
            this.freePointingButton.Name = "freePointingButton";
            this.freePointingButton.Size = new System.Drawing.Size(173, 82);
            this.freePointingButton.TabIndex = 6;
            this.freePointingButton.Text = "Free\r\nPointing";
            this.freePointingButton.UseVisualStyleBackColor = false;
            this.freePointingButton.Click += new System.EventHandler(this.ChangeFreePointingStatus);
            // 
            // rightNavigatorButton
            // 
            this.rightNavigatorButton.BackColor = System.Drawing.Color.LemonChiffon;
            this.rightNavigatorButton.FlatAppearance.BorderColor = System.Drawing.Color.Teal;
            this.rightNavigatorButton.FlatAppearance.BorderSize = 2;
            this.rightNavigatorButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rightNavigatorButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Bold);
            this.rightNavigatorButton.ForeColor = System.Drawing.Color.Teal;
            this.rightNavigatorButton.Location = new System.Drawing.Point(543, 223);
            this.rightNavigatorButton.Margin = new System.Windows.Forms.Padding(0);
            this.rightNavigatorButton.Name = "rightNavigatorButton";
            this.rightNavigatorButton.Size = new System.Drawing.Size(180, 180);
            this.rightNavigatorButton.TabIndex = 11;
            this.rightNavigatorButton.Text = "⮞";
            this.rightNavigatorButton.UseVisualStyleBackColor = false;
            this.rightNavigatorButton.Visible = false;
            this.rightNavigatorButton.Click += new System.EventHandler(this.RightNavigatorButtonClick);
            // 
            // downNavigatorButton
            // 
            this.downNavigatorButton.BackColor = System.Drawing.Color.LemonChiffon;
            this.downNavigatorButton.FlatAppearance.BorderColor = System.Drawing.Color.Teal;
            this.downNavigatorButton.FlatAppearance.BorderSize = 2;
            this.downNavigatorButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.downNavigatorButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Bold);
            this.downNavigatorButton.ForeColor = System.Drawing.Color.Teal;
            this.downNavigatorButton.Location = new System.Drawing.Point(362, 404);
            this.downNavigatorButton.Margin = new System.Windows.Forms.Padding(0);
            this.downNavigatorButton.Name = "downNavigatorButton";
            this.downNavigatorButton.Size = new System.Drawing.Size(180, 180);
            this.downNavigatorButton.TabIndex = 14;
            this.downNavigatorButton.Text = "⮟";
            this.downNavigatorButton.UseVisualStyleBackColor = false;
            this.downNavigatorButton.Visible = false;
            this.downNavigatorButton.Click += new System.EventHandler(this.DownNavigatorButtonClick);
            // 
            // leftNavigatorButton
            // 
            this.leftNavigatorButton.BackColor = System.Drawing.Color.LemonChiffon;
            this.leftNavigatorButton.FlatAppearance.BorderColor = System.Drawing.Color.Teal;
            this.leftNavigatorButton.FlatAppearance.BorderSize = 2;
            this.leftNavigatorButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.leftNavigatorButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Bold);
            this.leftNavigatorButton.ForeColor = System.Drawing.Color.Teal;
            this.leftNavigatorButton.Location = new System.Drawing.Point(181, 223);
            this.leftNavigatorButton.Margin = new System.Windows.Forms.Padding(0);
            this.leftNavigatorButton.Name = "leftNavigatorButton";
            this.leftNavigatorButton.Size = new System.Drawing.Size(180, 180);
            this.leftNavigatorButton.TabIndex = 12;
            this.leftNavigatorButton.Text = "⮜";
            this.leftNavigatorButton.UseVisualStyleBackColor = false;
            this.leftNavigatorButton.Visible = false;
            this.leftNavigatorButton.Click += new System.EventHandler(this.LeftNavigatorButtonClick);
            // 
            // upNavigatorButton
            // 
            this.upNavigatorButton.BackColor = System.Drawing.Color.LemonChiffon;
            this.upNavigatorButton.FlatAppearance.BorderColor = System.Drawing.Color.Teal;
            this.upNavigatorButton.FlatAppearance.BorderSize = 2;
            this.upNavigatorButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.upNavigatorButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Bold);
            this.upNavigatorButton.ForeColor = System.Drawing.Color.Teal;
            this.upNavigatorButton.Location = new System.Drawing.Point(362, 42);
            this.upNavigatorButton.Margin = new System.Windows.Forms.Padding(0);
            this.upNavigatorButton.Name = "upNavigatorButton";
            this.upNavigatorButton.Size = new System.Drawing.Size(180, 180);
            this.upNavigatorButton.TabIndex = 13;
            this.upNavigatorButton.Text = "⮝";
            this.upNavigatorButton.UseVisualStyleBackColor = false;
            this.upNavigatorButton.Visible = false;
            this.upNavigatorButton.Click += new System.EventHandler(this.UpNavigatorButtonClick);
            // 
            // rightButtonsPanel
            // 
            this.rightButtonsPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rightButtonsPanel.ColumnCount = 1;
            this.rightButtonsPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.rightButtonsPanel.Controls.Add(this.keyboardButton, 0, 0);
            this.rightButtonsPanel.Controls.Add(this.scrollUpButton, 0, 1);
            this.rightButtonsPanel.Controls.Add(this.scrollDownButton, 0, 2);
            this.rightButtonsPanel.Controls.Add(this.scrollLeftButton, 0, 3);
            this.rightButtonsPanel.Controls.Add(this.scrollRightButton, 0, 4);
            this.rightButtonsPanel.Location = new System.Drawing.Point(1129, 175);
            this.rightButtonsPanel.Margin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.rightButtonsPanel.Name = "rightButtonsPanel";
            this.rightButtonsPanel.RowCount = 5;
            this.rightButtonsPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.rightButtonsPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.rightButtonsPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.rightButtonsPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.rightButtonsPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.rightButtonsPanel.Size = new System.Drawing.Size(175, 411);
            this.rightButtonsPanel.TabIndex = 18;
            // 
            // keyboardButton
            // 
            this.keyboardButton.BackColor = System.Drawing.Color.LightCyan;
            this.keyboardButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.keyboardButton.FlatAppearance.BorderColor = System.Drawing.Color.MidnightBlue;
            this.keyboardButton.FlatAppearance.BorderSize = 2;
            this.keyboardButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.keyboardButton.Font = new System.Drawing.Font("Segoe UI Black", 32F, System.Drawing.FontStyle.Bold);
            this.keyboardButton.ForeColor = System.Drawing.Color.MidnightBlue;
            this.keyboardButton.Location = new System.Drawing.Point(0, 0);
            this.keyboardButton.Margin = new System.Windows.Forms.Padding(0, 0, 2, 1);
            this.keyboardButton.Name = "keyboardButton";
            this.keyboardButton.Size = new System.Drawing.Size(173, 101);
            this.keyboardButton.TabIndex = 2;
            this.keyboardButton.Text = "⌨";
            this.keyboardButton.UseVisualStyleBackColor = false;
            this.keyboardButton.Click += new System.EventHandler(this.OpenKeyboard);
            // 
            // scrollUpButton
            // 
            this.scrollUpButton.BackColor = System.Drawing.Color.LightCyan;
            this.scrollUpButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scrollUpButton.FlatAppearance.BorderColor = System.Drawing.Color.MidnightBlue;
            this.scrollUpButton.FlatAppearance.BorderSize = 2;
            this.scrollUpButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.scrollUpButton.Font = new System.Drawing.Font("Segoe UI Semibold", 36F, System.Drawing.FontStyle.Bold);
            this.scrollUpButton.ForeColor = System.Drawing.Color.MidnightBlue;
            this.scrollUpButton.Location = new System.Drawing.Point(0, 103);
            this.scrollUpButton.Margin = new System.Windows.Forms.Padding(0, 1, 2, 1);
            this.scrollUpButton.Name = "scrollUpButton";
            this.scrollUpButton.Size = new System.Drawing.Size(173, 100);
            this.scrollUpButton.TabIndex = 3;
            this.scrollUpButton.Text = "⯅";
            this.scrollUpButton.UseVisualStyleBackColor = false;
            this.scrollUpButton.Click += new System.EventHandler(this.ScrollUp);
            // 
            // scrollDownButton
            // 
            this.scrollDownButton.BackColor = System.Drawing.Color.LightCyan;
            this.scrollDownButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scrollDownButton.FlatAppearance.BorderColor = System.Drawing.Color.MidnightBlue;
            this.scrollDownButton.FlatAppearance.BorderSize = 2;
            this.scrollDownButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.scrollDownButton.Font = new System.Drawing.Font("Segoe UI Semibold", 36F, System.Drawing.FontStyle.Bold);
            this.scrollDownButton.ForeColor = System.Drawing.Color.MidnightBlue;
            this.scrollDownButton.Location = new System.Drawing.Point(0, 205);
            this.scrollDownButton.Margin = new System.Windows.Forms.Padding(0, 1, 2, 1);
            this.scrollDownButton.Name = "scrollDownButton";
            this.scrollDownButton.Size = new System.Drawing.Size(173, 100);
            this.scrollDownButton.TabIndex = 4;
            this.scrollDownButton.Text = "⯆";
            this.scrollDownButton.UseVisualStyleBackColor = false;
            this.scrollDownButton.Click += new System.EventHandler(this.ScrollDown);
            // 
            // scrollLeftButton
            // 
            this.scrollLeftButton.BackColor = System.Drawing.Color.LightCyan;
            this.scrollLeftButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scrollLeftButton.FlatAppearance.BorderColor = System.Drawing.Color.MidnightBlue;
            this.scrollLeftButton.FlatAppearance.BorderSize = 2;
            this.scrollLeftButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.scrollLeftButton.Font = new System.Drawing.Font("Segoe UI Semibold", 36F, System.Drawing.FontStyle.Bold);
            this.scrollLeftButton.ForeColor = System.Drawing.Color.MidnightBlue;
            this.scrollLeftButton.Location = new System.Drawing.Point(0, 307);
            this.scrollLeftButton.Margin = new System.Windows.Forms.Padding(0, 1, 2, 1);
            this.scrollLeftButton.Name = "scrollLeftButton";
            this.scrollLeftButton.Size = new System.Drawing.Size(173, 49);
            this.scrollLeftButton.TabIndex = 5;
            this.scrollLeftButton.Text = "⯇";
            this.scrollLeftButton.UseVisualStyleBackColor = false;
            this.scrollLeftButton.Click += new System.EventHandler(this.ScrollLeft);
            // 
            // scrollRightButton
            // 
            this.scrollRightButton.BackColor = System.Drawing.Color.LightCyan;
            this.scrollRightButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scrollRightButton.FlatAppearance.BorderColor = System.Drawing.Color.MidnightBlue;
            this.scrollRightButton.FlatAppearance.BorderSize = 2;
            this.scrollRightButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.scrollRightButton.Font = new System.Drawing.Font("Segoe UI Semibold", 36F, System.Drawing.FontStyle.Bold);
            this.scrollRightButton.ForeColor = System.Drawing.Color.MidnightBlue;
            this.scrollRightButton.Location = new System.Drawing.Point(0, 358);
            this.scrollRightButton.Margin = new System.Windows.Forms.Padding(0, 1, 2, 0);
            this.scrollRightButton.Name = "scrollRightButton";
            this.scrollRightButton.Size = new System.Drawing.Size(173, 53);
            this.scrollRightButton.TabIndex = 6;
            this.scrollRightButton.Text = "⯈";
            this.scrollRightButton.UseVisualStyleBackColor = false;
            this.scrollRightButton.Click += new System.EventHandler(this.ScrollRight);
            // 
            // clickCirclePanel
            // 
            this.clickCirclePanel.BackColor = System.Drawing.Color.PaleTurquoise;
            this.clickCirclePanel.Location = new System.Drawing.Point(2, 2);
            this.clickCirclePanel.Name = "clickCirclePanel";
            this.clickCirclePanel.Size = new System.Drawing.Size(5, 5);
            this.clickCirclePanel.TabIndex = 22;
            this.clickCirclePanel.Visible = false;
            this.clickCirclePanel.Paint += new System.Windows.Forms.PaintEventHandler(this.PaintCircle);
            // 
            // clickButton
            // 
            this.clickButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.clickButton.BackColor = System.Drawing.Color.LemonChiffon;
            this.clickButton.FlatAppearance.BorderColor = System.Drawing.Color.Teal;
            this.clickButton.FlatAppearance.BorderSize = 2;
            this.clickButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.clickButton.Font = new System.Drawing.Font("Segoe UI Semibold", 20F, System.Drawing.FontStyle.Bold);
            this.clickButton.ForeColor = System.Drawing.Color.Teal;
            this.clickButton.Location = new System.Drawing.Point(953, 278);
            this.clickButton.Margin = new System.Windows.Forms.Padding(0);
            this.clickButton.Name = "clickButton";
            this.clickButton.Size = new System.Drawing.Size(173, 308);
            this.clickButton.TabIndex = 24;
            this.clickButton.Text = "Click!";
            this.clickButton.UseVisualStyleBackColor = false;
            this.clickButton.Visible = false;
            this.clickButton.Click += new System.EventHandler(this.ExecuteClick);
            // 
            // pointedLinkPanel
            // 
            this.pointedLinkPanel.BackColor = System.Drawing.Color.Transparent;
            this.pointedLinkPanel.Location = new System.Drawing.Point(362, 223);
            this.pointedLinkPanel.Margin = new System.Windows.Forms.Padding(0);
            this.pointedLinkPanel.Name = "pointedLinkPanel";
            this.pointedLinkPanel.Size = new System.Drawing.Size(180, 180);
            this.pointedLinkPanel.TabIndex = 16;
            this.pointedLinkPanel.Visible = false;
            this.pointedLinkPanel.Click += new System.EventHandler(this.SelectPointedLink);
            // 
            // browserLinkSelectorPanel
            // 
            this.browserLinkSelectorPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.browserLinkSelectorPanel.BackColor = System.Drawing.Color.Transparent;
            this.browserLinkSelectorPanel.Location = new System.Drawing.Point(178, 175);
            this.browserLinkSelectorPanel.Name = "browserLinkSelectorPanel";
            this.browserLinkSelectorPanel.Size = new System.Drawing.Size(948, 411);
            this.browserLinkSelectorPanel.TabIndex = 2;
            this.browserLinkSelectorPanel.Visible = false;
            this.browserLinkSelectorPanel.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ShowLinks);
            // 
            // browserLinkNavigatorPanel
            // 
            this.browserLinkNavigatorPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.browserLinkNavigatorPanel.BackColor = System.Drawing.Color.Transparent;
            this.browserLinkNavigatorPanel.Location = new System.Drawing.Point(178, 175);
            this.browserLinkNavigatorPanel.Name = "browserLinkNavigatorPanel";
            this.browserLinkNavigatorPanel.Size = new System.Drawing.Size(948, 411);
            this.browserLinkNavigatorPanel.TabIndex = 10;
            this.browserLinkNavigatorPanel.Visible = false;
            this.browserLinkNavigatorPanel.MouseClick += new System.Windows.Forms.MouseEventHandler(this.MarkFirstLink);
            // 
            // browserZoomPanel
            // 
            this.browserZoomPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.browserZoomPanel.BackColor = System.Drawing.Color.Transparent;
            this.browserZoomPanel.Location = new System.Drawing.Point(178, 175);
            this.browserZoomPanel.Name = "browserZoomPanel";
            this.browserZoomPanel.Size = new System.Drawing.Size(948, 411);
            this.browserZoomPanel.TabIndex = 17;
            this.browserZoomPanel.Visible = false;
            this.browserZoomPanel.MouseClick += new System.Windows.Forms.MouseEventHandler(this.IncreaseZoom);
            // 
            // scrollPanel
            // 
            this.scrollPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.scrollPanel.BackColor = System.Drawing.Color.Transparent;
            this.scrollPanel.Location = new System.Drawing.Point(178, 175);
            this.scrollPanel.Name = "scrollPanel";
            this.scrollPanel.Size = new System.Drawing.Size(948, 411);
            this.scrollPanel.TabIndex = 23;
            this.scrollPanel.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ScrollSoft);
            // 
            // keyboard
            // 
            this.keyboard.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.keyboard.BackColor = System.Drawing.Color.CadetBlue;
            this.keyboard.Location = new System.Drawing.Point(0, 20);
            this.keyboard.Margin = new System.Windows.Forms.Padding(0);
            this.keyboard.Name = "keyboard";
            this.keyboard.Size = new System.Drawing.Size(1304, 568);
            this.keyboard.TabIndex = 19;
            this.keyboard.Visible = false;
            // 
            // favoritesPanel
            // 
            this.favoritesPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.favoritesPanel.BackColor = System.Drawing.Color.CadetBlue;
            this.favoritesPanel.Location = new System.Drawing.Point(0, 20);
            this.favoritesPanel.Margin = new System.Windows.Forms.Padding(0);
            this.favoritesPanel.Name = "favoritesPanel";
            this.favoritesPanel.Size = new System.Drawing.Size(1304, 568);
            this.favoritesPanel.TabIndex = 20;
            this.favoritesPanel.Visible = false;
            // 
            // circleAnimationPanel
            // 
            this.circleAnimationPanel.Location = new System.Drawing.Point(0, 0);
            this.circleAnimationPanel.Name = "circleAnimationPanel";
            this.circleAnimationPanel.Size = new System.Drawing.Size(2, 2);
            this.circleAnimationPanel.TabIndex = 25;
            this.circleAnimationPanel.Click += new System.EventHandler(this.StartAnimation);
            this.circleAnimationPanel.MouseEnter += new System.EventHandler(this.StartAnimation);
            // 
            // blockingPanel
            // 
            this.blockingPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.blockingPanel.Location = new System.Drawing.Point(0, 0);
            this.blockingPanel.Margin = new System.Windows.Forms.Padding(0);
            this.blockingPanel.Name = "blockingPanel";
            this.blockingPanel.Size = new System.Drawing.Size(1304, 588);
            this.blockingPanel.TabIndex = 26;
            this.blockingPanel.Visible = false;
            // 
            // popupPanel
            // 
            this.popupPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.popupPanel.ColumnCount = 3;
            this.popupPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33F));
            this.popupPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33F));
            this.popupPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.34F));
            this.popupPanel.Controls.Add(this.cancelPopupButton, 0, 0);
            this.popupPanel.Controls.Add(this.minimizePopupButton, 1, 0);
            this.popupPanel.Controls.Add(this.closePopupButton, 2, 0);
            this.popupPanel.Location = new System.Drawing.Point(314, 220);
            this.popupPanel.Name = "popupPanel";
            this.popupPanel.RowCount = 1;
            this.popupPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.popupPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 225F));
            this.popupPanel.Size = new System.Drawing.Size(675, 225);
            this.popupPanel.TabIndex = 27;
            this.popupPanel.Visible = false;
            // 
            // cancelPopupButton
            // 
            this.cancelPopupButton.BackColor = System.Drawing.Color.LemonChiffon;
            this.cancelPopupButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cancelPopupButton.FlatAppearance.BorderColor = System.Drawing.Color.Teal;
            this.cancelPopupButton.FlatAppearance.BorderSize = 2;
            this.cancelPopupButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cancelPopupButton.Font = new System.Drawing.Font("Segoe UI Semibold", 20F, System.Drawing.FontStyle.Bold);
            this.cancelPopupButton.ForeColor = System.Drawing.Color.Teal;
            this.cancelPopupButton.Location = new System.Drawing.Point(3, 3);
            this.cancelPopupButton.Margin = new System.Windows.Forms.Padding(3, 3, 2, 3);
            this.cancelPopupButton.Name = "cancelPopupButton";
            this.cancelPopupButton.Size = new System.Drawing.Size(219, 219);
            this.cancelPopupButton.TabIndex = 25;
            this.cancelPopupButton.Text = "Cancel";
            this.cancelPopupButton.UseVisualStyleBackColor = false;
            this.cancelPopupButton.Click += new System.EventHandler(this.ClosePopup);
            // 
            // minimizePopupButton
            // 
            this.minimizePopupButton.BackColor = System.Drawing.Color.LemonChiffon;
            this.minimizePopupButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.minimizePopupButton.FlatAppearance.BorderColor = System.Drawing.Color.Teal;
            this.minimizePopupButton.FlatAppearance.BorderSize = 2;
            this.minimizePopupButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.minimizePopupButton.Font = new System.Drawing.Font("Segoe UI Semibold", 28F, System.Drawing.FontStyle.Bold);
            this.minimizePopupButton.ForeColor = System.Drawing.Color.Teal;
            this.minimizePopupButton.Location = new System.Drawing.Point(226, 3);
            this.minimizePopupButton.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.minimizePopupButton.Name = "minimizePopupButton";
            this.minimizePopupButton.Size = new System.Drawing.Size(220, 219);
            this.minimizePopupButton.TabIndex = 26;
            this.minimizePopupButton.Text = "_";
            this.minimizePopupButton.UseVisualStyleBackColor = false;
            this.minimizePopupButton.Click += new System.EventHandler(this.MinimizeWindow);
            // 
            // closePopupButton
            // 
            this.closePopupButton.BackColor = System.Drawing.Color.LemonChiffon;
            this.closePopupButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.closePopupButton.FlatAppearance.BorderColor = System.Drawing.Color.Teal;
            this.closePopupButton.FlatAppearance.BorderSize = 2;
            this.closePopupButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.closePopupButton.Font = new System.Drawing.Font("Segoe UI Semibold", 28F, System.Drawing.FontStyle.Bold);
            this.closePopupButton.ForeColor = System.Drawing.Color.Teal;
            this.closePopupButton.Location = new System.Drawing.Point(450, 3);
            this.closePopupButton.Margin = new System.Windows.Forms.Padding(2, 3, 3, 3);
            this.closePopupButton.Name = "closePopupButton";
            this.closePopupButton.Size = new System.Drawing.Size(222, 219);
            this.closePopupButton.TabIndex = 27;
            this.closePopupButton.Text = "X";
            this.closePopupButton.UseVisualStyleBackColor = false;
            this.closePopupButton.Click += new System.EventHandler(this.CloseWindow);
            // 
            // eyeBrowserForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.CadetBlue;
            this.ClientSize = new System.Drawing.Size(1304, 588);
            this.Controls.Add(this.circleAnimationPanel);
            this.Controls.Add(this.upNavigatorButton);
            this.Controls.Add(this.downNavigatorButton);
            this.Controls.Add(this.rightNavigatorButton);
            this.Controls.Add(this.leftNavigatorButton);
            this.Controls.Add(this.pointedLinkPanel);
            this.Controls.Add(this.clickButton);
            this.Controls.Add(this.titleBar);
            this.Controls.Add(this.leftButtonsPanel);
            this.Controls.Add(this.rightButtonsPanel);
            this.Controls.Add(this.urlPanel);
            this.Controls.Add(this.linkLabelsPanel);
            this.Controls.Add(this.browserLinkSelectorPanel);
            this.Controls.Add(this.browserLinkNavigatorPanel);
            this.Controls.Add(this.browserZoomPanel);
            this.Controls.Add(this.scrollPanel);
            this.Controls.Add(this.browserControl);
            this.Controls.Add(this.clickCirclePanel);
            this.Controls.Add(this.favoritesPanel);
            this.Controls.Add(this.keyboard);
            this.Controls.Add(this.popupPanel);
            this.Controls.Add(this.blockingPanel);
            this.ForeColor = System.Drawing.SystemColors.Desktop;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.Name = "eyeBrowserForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "EyeBrowser";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.LoadHomePage);
            this.linkLabelsPanel.ResumeLayout(false);
            this.urlPanel.ResumeLayout(false);
            this.urlBoxPanel.ResumeLayout(false);
            this.urlBoxPanel.PerformLayout();
            this.titleBar.ResumeLayout(false);
            this.titleBar.PerformLayout();
            this.leftButtonsPanel.ResumeLayout(false);
            this.rightButtonsPanel.ResumeLayout(false);
            this.popupPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Gecko.GeckoWebBrowser browserControl;
        private System.Windows.Forms.Button backNavigationBrowserButton;
        private System.Windows.Forms.Button forwardNavigationBrowserButton;
        private TransparentPanel browserLinkSelectorPanel;
        private System.Windows.Forms.Button linkSelectorButton;
        private System.Windows.Forms.Label link1Label;
        private System.Windows.Forms.Label link2Label;
        private System.Windows.Forms.Label link3Label;
        private System.Windows.Forms.Label link4Label;
        private System.Windows.Forms.TableLayoutPanel linkLabelsPanel;
        private System.Windows.Forms.Label link5Label;
        private System.Windows.Forms.TableLayoutPanel urlPanel;
        private System.Windows.Forms.Button refreshButton;
        private System.Windows.Forms.TableLayoutPanel titleBar;
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.Button minimizeButton;
        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.TableLayoutPanel leftButtonsPanel;
        private System.Windows.Forms.Button linkNavigatorButton;
        private TransparentPanel browserLinkNavigatorPanel;
        private System.Windows.Forms.Button rightNavigatorButton;
        private System.Windows.Forms.Button leftNavigatorButton;
        private System.Windows.Forms.Button upNavigatorButton;
        private System.Windows.Forms.Button downNavigatorButton;
        private TransparentPanel pointedLinkPanel;
        private TransparentPanel browserZoomPanel;
        private System.Windows.Forms.Button progressiveZoomButton;
        private System.Windows.Forms.Button immediateZoomButton;
        private System.Windows.Forms.TableLayoutPanel rightButtonsPanel;
        private Keyboard keyboard;
        private System.Windows.Forms.Button keyboardButton;
        private System.Windows.Forms.Button scrollRightButton;
        private System.Windows.Forms.Button scrollLeftButton;
        private System.Windows.Forms.Button scrollDownButton;
        private System.Windows.Forms.Button scrollUpButton;
        private FavoritesPanel favoritesPanel;
        private System.Windows.Forms.Button goHomepageButton;
        private System.Windows.Forms.Button openFavoritesButton;
        private System.Windows.Forms.Panel clickCirclePanel;
        private TransparentPanel scrollPanel;
        private System.Windows.Forms.Button freePointingButton;
        private System.Windows.Forms.Button clickButton;
        private System.Windows.Forms.Panel urlBoxPanel;
        private System.Windows.Forms.TextBox urlBox;
        private TransparentPanel circleAnimationPanel;
        private System.Windows.Forms.Button openPopupButton;
        private TransparentPanel blockingPanel;
        private System.Windows.Forms.TableLayoutPanel popupPanel;
        private System.Windows.Forms.Button cancelPopupButton;
        private System.Windows.Forms.Button minimizePopupButton;
        private System.Windows.Forms.Button closePopupButton;
    }
}