﻿using System;
using System.Windows.Input;

using Xamarin.Forms;

namespace Xamarin.Forms.AndroidTVSkeleton.ViewModels
{
    public class AboutViewModel : BaseViewModel
    {
        public AboutViewModel()
        {
            Title = "About";

            OpenWebCommand = new Command(() => Device.OpenUri(new Uri("https://xamarin.com/platform")));
        }

        public ICommand OpenWebCommand { get; }
    }
}