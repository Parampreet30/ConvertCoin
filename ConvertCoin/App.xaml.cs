﻿namespace ConvertCoin
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            // MainPage = new HomePage();
            MainPage = new AppShell();
        }
    }
}
