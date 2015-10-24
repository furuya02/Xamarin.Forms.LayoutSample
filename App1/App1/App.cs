using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace App1 {
    ////////////////////////////////////////////////////
    //
    // StackLayoutのサンプル
    //
    ////////////////////////////////////////////////////
    public class App : Application {
        public App() {

            //ラベルを3つ配置したスタックレイヤを生成する
            var stackLayout = new StackLayout {
                Padding = new Thickness(10, Device.OnPlatform(20, 10, 10), 10, 10),
                Spacing = 5, //各要素間のスペース
                Children ={new Label{
                        FontSize=30,
                        Text = "First",
                        HeightRequest=100,// 高さ100
                        BackgroundColor = Color.FromHex("82DADA"),
                    },
                    new Label{
                        FontSize=30,
                        Text = "Second",
                        VerticalOptions = LayoutOptions.FillAndExpand,//縦方向に余白を最大限利用する
                        BackgroundColor = Color.FromHex("53CF9E"),
                    },
                    new Label{
                        FontSize=30,
                        Text = "Third",
                        HeightRequest=300,// 高さ300
                        BackgroundColor = Color.FromHex("EB6379"),
                    },
                }
            };
            MainPage = new ContentPage {
                Content = stackLayout
            };
        }
    }
    /*
    ////////////////////////////////////////////////////
    //
    // AbsoluteLayoutのサンプル
    //
    ////////////////////////////////////////////////////
    public class App : Application {
        public App() {

            //アブソレートレイアウトの生成
            var absoluteLayout = new AbsoluteLayout();

            //ラベルの生成とレイアウトへの追加(Rectangle指定)
            var label1 = new Label { Text = "First", BackgroundColor = Color.FromHex("82DADA"), FontSize = 20 };
            absoluteLayout.Children.Add(label1, new Rectangle(20, 20, 200, 200));

            //ラベルの生成とレイアウトへの追加(Point指定)
            var label2 = new Label { Text = "Second", BackgroundColor = Color.FromHex("53CF9E"), FontSize = 20 };
            absoluteLayout.Children.Add(label2, new Point(200, 300));

            //ラベルの生成とレイアウトへの追加(SetLayoutBounds指定)
            var label3 = new Label { Text = "Third", BackgroundColor = Color.FromHex("EB6379"), FontSize = 20 };
            absoluteLayout.Children.Add(label3);
            AbsoluteLayout.SetLayoutBounds(label3, new Rectangle(30, 400, 250, 100));

            MainPage = new ContentPage {
                Content = absoluteLayout
            };
        }
    }
    */
    /*
    ////////////////////////////////////////////////////
    //
    // Gridのサンプル
    //
    ////////////////////////////////////////////////////
    public class App : Application {
        public App() {
            //グリッドの生成
            var grid = new Grid {
                Padding = new Thickness(10, Device.OnPlatform(20, 0, 0), 10, 10),//パディング
                RowSpacing = 10, //縦のスペース
                ColumnSpacing = 5, //横のスペース

                RowDefinitions = {//縦に２列
                    new RowDefinition { Height = GridLength.Auto },//（高さ）自動調整
                    new RowDefinition { Height = new GridLength(100, GridUnitType.Star) }//（高さ）のこり全部
                },
                ColumnDefinitions = {//横に３カラム
                    new ColumnDefinition { Width = GridLength.Auto }, //(幅)自動調整
                    new ColumnDefinition { Width = new GridLength(100, GridUnitType.Absolute) },//(幅)絶対値
                    new ColumnDefinition { Width = new GridLength(10, GridUnitType.Star) }//(幅)のこり全部
                }
            };

            //１列目にラベルを追加
            grid.Children.Add(new Label { Text = "1-1", BackgroundColor = Color.Red, }, 0, 0);//１列目で左から１カラム目
            grid.Children.Add(new Label { Text = "1-2", BackgroundColor = Color.Blue }, 1, 0);//１列目で左から２カラム目
            grid.Children.Add(new Label { Text = "1-3", BackgroundColor = Color.Green }, 2, 0);//１列目で左から３カラム目
                                                                                               //２列目にラベルを追加
            grid.Children.Add(new Label { Text = "2-1", BackgroundColor = Color.Yellow }, 0, 2, 1, 2); //２列目で左から１~２カラム
            grid.Children.Add(new Label { Text = "2-2", BackgroundColor = Color.Purple }, 2, 1);//２列目で左から３カラム目


            MainPage = new ContentPage {
                Content = grid
            };

        }
    }
    */
    /*
    ////////////////////////////////////////////////////
    //
    // RelativeLayoutのサンプル
    //
    ////////////////////////////////////////////////////
    public class App : Application {
        public App() {
            //リラティブレイアウトの生成
            var relativeLayout = new RelativeLayout();
            //ラベルの追加
            var label1 = new Label { Text = "label1", BackgroundColor = Color.FromHex("82DADA") ,FontSize=60};
            relativeLayout.Children.Add(label1,
                //Ｘ座標は、30
                Constraint.Constant(30),
                // Y座標は中央 (親要素との相対位置で配置)                         
                Constraint.RelativeToParent(parent => parent.Height / 2)
            );

            //ラベルの追加
            var label2 = new Label { Text = "label2", BackgroundColor = Color.FromHex("53CF9E"),FontSize=40 };
            relativeLayout.Children.Add(label2,
                //Ｘ座標は、100
                Constraint.Constant(100), 
                // Y座標は、label1の20下（他の要素との相対位置で配置）
                Constraint.RelativeToView(label1, (parent, sibling) => sibling.Y + sibling.Height + 20)
             );



            MainPage = new ContentPage {
                Content = relativeLayout
            };

        }
    }
    */
    /*
    ////////////////////////////////////////////////////
    //
    // ContentView / Frame / ScrollView のサンプル
    //
    ////////////////////////////////////////////////////
    public class App : Application {
        public App() {
            //フレームの生成
            var frame = new Frame {
                //枠線の効果
                OutlineColor = Color.Accent,
                HasShadow = true,
                //ラベルを配置する
                Content = new Label { Text = "Frame" }
            };

            //コンテンツビューの生成
            var contentView = new ContentView {
                BackgroundColor = Color.FromHex("EB6379"),
                Padding = new Thickness(50), //ContentView内での余白
                //ラベルを配置する
                Content = new Label { Text = "ContentView" ,FontSize=20}
            };

            //スクロールビューの生成
            var sb = new StringBuilder(); //100行のテキストを作成
            for (var i = 0; i < 100; i++) {
                sb.Append(string.Format("ScrollView {0}行目\n", i+1));
            }
            var scrollView = new ScrollView {
                VerticalOptions = LayoutOptions.FillAndExpand,
                //ラベルを配置する
                Content = new Label {
                    Text = sb.ToString(),
                    FontSize = 20,
                    TextColor = Color.FromHex("82DADA")
                }
            };

            MainPage = new ContentPage {
                //スタックレイアウトをContentに設定
                Content = new StackLayout {
                    Spacing = 10, //要素間のスペース
                    Padding = new Thickness(10, Device.OnPlatform(20, 10, 10), 10, 10),
                    //作成した「フレーム」・「コンテンツビュー」・「スクロールビュー」を縦に配置する
                    Children = { frame, contentView, scrollView }
                }
            };

        }
    }
    */
}
