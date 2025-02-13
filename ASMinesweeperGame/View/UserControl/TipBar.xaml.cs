﻿using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;

namespace ASMinesweeperGame.View {
    /// <summary>
    /// TipBar.xaml 的交互逻辑
    /// </summary>
    public partial class TipBar : UserControl {
        public static readonly DependencyProperty TipProperty =
            DependencyProperty.Register(nameof(Tip), typeof(object), typeof(TipBar), new PropertyMetadata(null));

        public object? Tip {
            get {
                return GetValue(TipProperty);
            }
            set {
                SetValue(TipProperty, value);
            }
        }

        public async void DisplayTip(object tip, TimeSpan displayTime) {
            Tip = tip;
            DoubleAnimation animation = new DoubleAnimation() {
                To = 40,
                AccelerationRatio = 0.2,
                DecelerationRatio = 0.8,
                Duration = TimeSpan.FromMilliseconds(150)
            };
            BeginAnimation(HeightProperty, animation);
            await Task.Delay(displayTime);
            DoubleAnimation animation2 = new DoubleAnimation() {
                To = 0,
                AccelerationRatio = 0.2,
                DecelerationRatio = 0.8,
                Duration = TimeSpan.FromMilliseconds(150)
            };
            BeginAnimation(HeightProperty, animation2);
            Tip = null;
        }

        public TipBar() {
            InitializeComponent();
        }
    }
}
