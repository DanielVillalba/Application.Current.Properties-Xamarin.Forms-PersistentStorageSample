using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace PropertiesDictionaryTest
{
    public class App : Application
    {

        Entry toStoreEntry;


        public App()
        {
            toStoreEntry = new Entry
            {
                Placeholder="Enter some text to persist..."
            };

            var button = new Button
            {
                Text = "Store data"
            };

            // The root page of your application
            var content = new ContentPage
            {
                Title = "PropertiesDictionaryTest",
                Content = new StackLayout
                {
                    VerticalOptions = LayoutOptions.Center,
                    Children = {
                        new Label {
                            HorizontalTextAlignment = TextAlignment.Center,
                            Text = "Enter some data to persist..."
                        },

                        toStoreEntry,

                        button
                    }
                }
            };

            button.Clicked += Button_Clicked;


            MainPage = new NavigationPage(content);
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            if (Application.Current.Properties.ContainsKey("toStoreEntry"))
            {
                Application.Current.Properties.Remove("toStoreEntry");
            }

            Application.Current.Properties.Add("toStoreEntry", toStoreEntry.Text);
        }

        protected override void OnStart()
        {
            // Handle when your app starts
            if (Application.Current.Properties.ContainsKey("toStoreEntry"))
            {
                toStoreEntry.Text = Application.Current.Properties["toStoreEntry"] as string;
            }
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
