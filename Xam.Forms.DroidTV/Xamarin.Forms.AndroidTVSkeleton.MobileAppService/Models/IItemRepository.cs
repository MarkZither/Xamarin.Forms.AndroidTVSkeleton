﻿using System;
using System.Collections.Generic;

namespace Xamarin.Forms.AndroidTVSkeleton.Models
{
	public interface IItemRepository
	{
		void Add(Item item);
		void Update(Item item);
		Item Remove(string key);
		Item Get(string id);
		IEnumerable<Item> GetAll();
	}
}
