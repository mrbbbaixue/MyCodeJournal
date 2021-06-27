﻿using System.Collections.ObjectModel;
using Ecliptae.Lib;
using HandyControl.Controls;
using Stylet;

namespace Ecliptae.Wpf.ViewModels
{
    public class MainViewModel : Screen
    {
        public string WindowTitleText { get; } = "Ecliptae 商城";
        public void ToggleDarkMode() => App.ToggleDarkMode();
        public bool IsSeller => (App.User.Level == 1);
        public OptimizedObservableCollection<Item> Items { get; set; }
        public OptimizedObservableCollection<OrderItem> Carts { get; set; }
        public Item ?SelectedItem { get; set; }
        public OrderItem ?SelectedCartItem { get; set; }
        public User User => App.User;

        public MainViewModel()
        {
            Items = new OptimizedObservableCollection<Item>();
            var item_A = new Item
            {
                Name = "Sandisk USB 3.0 Key (64GB)",
                Price = 99.99F,
                Description = "IT之家 6 月 27 日消息 微软本周发布了全新的 Windows 11 操作系统，将在圣诞节期间推出正式版，并表示用户可于 2022 年免费升级到 Win11。" +
                              " 当您从 Windows 10 升级到 Windows 11 时，某些用户可能会不太习惯，例如某些长期存在的 Windows 功能被砍，其中之一是 Windows 的任务栏停靠位置。" +
                              "众所周知，在现在的多个 Windows 版本中，用户不仅可以将任务栏放到底部，还可以任意将其停靠在屏幕顶部或侧边，方便竖屏小伙伴的日常使用。",
                Storage = 993
            };
            var item_B = new Item
            {
                Name = "Microsoft Windows 11 Pro",
                Price = 888.88F,
                Storage = 552
            };
            Items.Add(item_A);
            Items.Add(item_B);
            Carts = new OptimizedObservableCollection<OrderItem>();
            var orderItem_A = new OrderItem
            {
                Item = item_A,
                Count = 1
            };
            Carts.Add(orderItem_A);
        }

        // Item Operations
        public void ShowItemInfo()
        {
            // test method
            var comments = new OptimizedObservableCollection<Comment> { };
            var comment = new Comment
            {
                Content = "That is fucking bad.\n worst shop experience ever!",
                Star = 1
            };
            comments.Add(comment);

            var itemViewModel = new ItemViewModel
            {
                Item = SelectedItem,
                Comments = comments
            };
            App.WindowManager.ShowDialog(itemViewModel);
        }
        public void AddItemToCart()
        {
            foreach (var item in Carts)
            {
                if (item.Item.GUID == SelectedItem.GUID)
                    return;
            }
            // Add Item
            var orderItem = new OrderItem
            {
                Item = SelectedItem,
                Count = 1
            };
            Carts.Add(orderItem);
        }
        public void BuyItem()
        {

        }
        
        // Cart Item Operations
        public void OnCartItemNumericUpDownValueChanged()
        {
            if (SelectedCartItem != null && SelectedCartItem.Count <= 0)
                RemoveItemFromCart();
        }
        public void RemoveItemFromCart()
        => Carts.Remove(SelectedCartItem);

        public bool VerifyCart()
        {
            return true;
        }

        public void SubmitPayment()
        {
            if (VerifyCart())
            {

            }
        }

    }
}
