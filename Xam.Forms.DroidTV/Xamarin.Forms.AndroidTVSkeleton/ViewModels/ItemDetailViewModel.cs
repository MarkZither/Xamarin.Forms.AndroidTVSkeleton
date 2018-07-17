using System;

using Xamarin.Forms.AndroidTVSkeleton.Models;

namespace Xamarin.Forms.AndroidTVSkeleton.ViewModels
{
    public class ItemDetailViewModel : BaseViewModel
    {
        public Item Item { get; set; }
        public ItemDetailViewModel(Item item = null)
        {
            Title = item?.Text;
            Item = item;
        }
    }
}
