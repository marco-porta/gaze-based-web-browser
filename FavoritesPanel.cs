using System.Windows.Forms;
using System;
using System.IO;
using System.Collections.Generic;
using System.Drawing;

namespace ProjectEyeBrowser
{
    public partial class FavoritesPanel : UserControl
    {

        private string homepagePath;
        private string favoritesPath;
        private string homepage;
        private List<string> favorites;
        private List<string> names;
        private List<string> links;
        private int page;
        private Gecko.GeckoWebBrowser browser;
        private Color disabledColor;
        private Color enabledColor = Color.DeepSkyBlue;
        private Keyboard keyboard;

        public FavoritesPanel()
        {
            InitializeComponent();
            page = 0;
            disabledColor = removeFavoritesButton.BackColor;
            homepagePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "EyeBrowserHomepagePreferences.txt");
            favoritesPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "EyeBrowserFavoritesPreferences.txt");
            favorites = new List<string>();
            names = new List<string>();
            links = new List<string>();
            if (File.Exists(homepagePath))
            {
                using (StreamReader reader = new StreamReader(homepagePath))
                {
                    homepage = reader.ReadLine();
                }
            }
            else
            {
                homepage = "www.google.com";
                using (StreamWriter writer = new StreamWriter(homepagePath, false))
                {
                    writer.WriteLine(homepage);
                }
            }
            if (File.Exists(favoritesPath))
            {
                favorites = new List<string>(File.ReadAllLines(favoritesPath));
                foreach(string line in favorites)
                {
                    names.Add(line.Split("\t".ToCharArray())[0]);
                    links.Add(line.Split("\t".ToCharArray())[1]);
                }
            }
            else
            {
                using (StreamWriter writer = new StreamWriter(favoritesPath, false)) { }
            }
        }

        private void SetHomepage(object sender, EventArgs e)
        {
            setHomepageButton.Enabled = false;
            setHomepageButton.Text = "Home page set!";
            homepage = browser.Url.ToString();
            using (StreamWriter writer = new StreamWriter(homepagePath, false))
            {
                 writer.WriteLine(homepage);
            }
        }

        private void SetFavorite(object sender, EventArgs e)
        {
            keyboard.OpenKeyboardForFavorites();
            setFavoriteButton.Enabled = false;
            setFavoriteButton.Text = "Added to Favorites!";
            links.Add(browser.Url.ToString());
        }

        public void WriteFavoriteName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                names.Add(browser.Url.ToString());
            }
            else
            {
                names.Add(name);
            }
            UpdateFavoritesFile();
            page = 0;
            UpdateList();
            HideRemoveFavorites();
        }

        private void UpdateFavoritesFile()
        {
            using (StreamWriter writer = new StreamWriter(favoritesPath, false))
            {
                for (int i = 0; i < links.Count; i++)
                {
                    writer.WriteLine(names[i] + "\t" + links[i]);
                }
            }
        }

        private void UpdateList()
        {
            if (page * 5 + 1 <= names.Count)
            {
                favorite1Button.Text = names[page * 5];
                favorite1Button.Enabled = true;
                remove1Button.Enabled = true;
            }
            else
            {
                favorite1Button.Text = "";
                favorite1Button.Enabled = false;
                remove1Button.Enabled = false;
            }

            if (page * 5 + 2 <= names.Count)
            {
                favorite2Button.Text = names[page * 5 + 1];
                favorite2Button.Enabled = true;
                remove2Button.Enabled = true;
            }
            else
            {
                favorite2Button.Text = "";
                favorite2Button.Enabled = false;
                remove2Button.Enabled = false;
            }

            if (page * 5 + 3 <= names.Count)
            {
                favorite3Button.Text = names[page * 5 + 2];
                favorite3Button.Enabled = true;
                remove3Button.Enabled = true;
            }
            else
            {
                favorite3Button.Text = "";
                favorite3Button.Enabled = false;
                remove3Button.Enabled = false;
            }

            if (page * 5 + 4 <= names.Count)
            {
                favorite4Button.Text = names[page * 5 + 3];
                favorite4Button.Enabled = true;
                remove4Button.Enabled = true;
            }
            else
            {
                favorite4Button.Text = "";
                favorite4Button.Enabled = false;
                remove4Button.Enabled = false;
            }

            if (page * 5 + 5 <= names.Count)
            {
                favorite5Button.Text = names[page * 5 + 4];
                favorite5Button.Enabled = true;
                remove5Button.Enabled = true;
            }
            else
            {
                favorite5Button.Text = "";
                favorite5Button.Enabled = false;
                remove5Button.Enabled = false;
            }

            if(page == 0)
            {
                favoriteLeftButton.Enabled = false;
            }
            else
            {
                favoriteLeftButton.Enabled = true;
            }

            if((page + 1) * 5 < names.Count)
            {
                favoriteRightButton.Enabled = true;
            }
            else
            {
                favoriteRightButton.Enabled = false;
            }
        }

        private void OpenFavorite1(object sender, EventArgs e)
        {
            browser.Navigate(links[page * 5]);
            CloseFavorites(null, null);
        }

        private void OpenFavorite2(object sender, EventArgs e)
        {
            browser.Navigate(links[page * 5 + 1]);
            CloseFavorites(null, null);
        }

        private void OpenFavorite3(object sender, EventArgs e)
        {
            browser.Navigate(links[page * 5 + 2]);
            CloseFavorites(null, null);
        }

        private void OpenFavorite4(object sender, EventArgs e)
        {
            browser.Navigate(links[page * 5 + 3]);
            CloseFavorites(null, null);
        }

        private void OpenFavorite5(object sender, EventArgs e)
        {
            browser.Navigate(links[page * 5 + 4]);
            CloseFavorites(null, null);
        }

        private void HandleRemoveFavorites(object sender, EventArgs e)
        {
            if (!remove1Button.Visible)
            {
                remove1Button.Visible = true;
                remove2Button.Visible = true;
                remove3Button.Visible = true;
                remove4Button.Visible = true;
                remove5Button.Visible = true;
                favoriteLeftButton.Visible = false;
                favoriteRightButton.Visible = false;
                removeFavoritesButton.BackColor = enabledColor;
            }
            else
            {
                HideRemoveFavorites();
            }
        }

        private void HideRemoveFavorites()
        {
            remove1Button.Visible = false;
            remove2Button.Visible = false;
            remove3Button.Visible = false;
            remove4Button.Visible = false;
            remove5Button.Visible = false;
            favoriteLeftButton.Visible = true;
            favoriteRightButton.Visible = true;
            removeFavoritesButton.BackColor = disabledColor;
        }

        private void RemoveFavorite1(object sender, EventArgs e)
        {
            HideRemoveFavorites();
            names.RemoveAt(page * 5);
            links.RemoveAt(page * 5);
            UpdateFavoritesFile();
            page = 0;
            UpdateList();
        }

        private void RemoveFavorite2(object sender, EventArgs e)
        {
            HideRemoveFavorites();
            names.RemoveAt(page * 5 + 1);
            links.RemoveAt(page * 5 + 1);
            UpdateFavoritesFile();
            page = 0;
            UpdateList();
        }

        private void RemoveFavorite3(object sender, EventArgs e)
        {
            HideRemoveFavorites();
            names.RemoveAt(page * 5 + 2);
            links.RemoveAt(page * 5 + 2);
            UpdateFavoritesFile();
            page = 0;
            UpdateList();
        }

        private void RemoveFavorite4(object sender, EventArgs e)
        {
            HideRemoveFavorites();
            names.RemoveAt(page * 5 + 3);
            links.RemoveAt(page * 5 + 3);
            UpdateFavoritesFile();
            page = 0;
            UpdateList();
        }

        private void RemoveFavorite5(object sender, EventArgs e)
        {
            HideRemoveFavorites();
            names.RemoveAt(page * 5 + 4);
            links.RemoveAt(page * 5 + 4);
            UpdateFavoritesFile();
            page = 0;
            UpdateList();
        }

        private void PreviousPage(object sender, EventArgs e)
        {
            page--;
            UpdateList();
        }

        private void NextPage(object sender, EventArgs e)
        {
            page++;
            UpdateList();
        }

        public void OpenFavorites(Gecko.GeckoWebBrowser b)
        {
            favoriteRightButton.Location = new Point(favoritesLayoutPanel.Location.X + favorite1Button.Width + (favoritesLayoutPanel.Location.X - favoriteLeftButton.Location.X - favoriteLeftButton.Width) + 2, favoriteLeftButton.Location.Y);
            browser = b;
            page = 0;
            UpdateList();
            this.Visible = true;
            this.BringToFront();
        }

        private void CloseFavorites(object sender, EventArgs e)
        {
            this.Visible = false;
            setHomepageButton.Text = "Set this page as\nHome page";
            setHomepageButton.Enabled = true;
            setFavoriteButton.Text = "Add this page to\nFavorites";
            setFavoriteButton.Enabled = true;
            HideRemoveFavorites();
        }

        public string Homepage { get { return homepage; } }
        public Keyboard Keyboard { set { keyboard = value; } }

    }
}