using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Paxton2
{
	public partial class MainPage : ContentPage
	{
        Label inputDisplayLabel = new Label();
        Label calculatedDisplayLabel = new Label();

        public MainPage()
		{

            Label displayLabel;
            Button backspaceButton;
            Button clearEntryButton;
            Button clearButton;
            Button divideButton;
            Button multiplyButton;
            Button subtractButton;
            Button addButton;
            Button equalsButton;
            Button negateButton;
            Button decimalButton;
            StackLayout mainStack = new StackLayout
            {
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.Center
            };

            displayLabel = new Label
            {
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
                VerticalOptions = LayoutOptions.Center,
                HorizontalTextAlignment = TextAlignment.End
            };
            mainStack.Children.Add(displayLabel);

            Grid myGrid = new Grid();
            mainStack.Children.Add(myGrid);

            backspaceButton = new Button
            {
                Text = "\u21E6",
                FontSize = Device.GetNamedSize(NamedSize.Default, typeof(Button)),
                WidthRequest = 60,
                IsEnabled = false,
            };
            backspaceButton.Clicked += onBackspaceButtonClicked;
            myGrid.Children.Add(backspaceButton, 2, 0);

            clearEntryButton = new Button
            {
                Text = "CE",
                FontSize = Device.GetNamedSize(NamedSize.Default, typeof(Button)),
                WidthRequest = 60,
                IsEnabled = false,
            };
            clearEntryButton.Clicked += onClearEntryButtonClicked;
            myGrid.Children.Add(clearEntryButton, 0,0);

            clearButton = new Button
            {
                Text = "C",
                FontSize = Device.GetNamedSize(NamedSize.Default, typeof(Button)),
                WidthRequest = 60,
                IsEnabled = false,
            };
            clearButton.Clicked += onClearButtonClicked;
            myGrid.Children.Add(clearButton, 1, 0);

            divideButton = new Button
            {
                Text = "/",
                FontSize = Device.GetNamedSize(NamedSize.Default, typeof(Button)),
                WidthRequest = 60,
                IsEnabled = false,
            };
            divideButton.Clicked += onDivideButtonClicked;
            myGrid.Children.Add(divideButton, 3, 0);

            multiplyButton = new Button
            {
                Text = "*",
                FontSize = Device.GetNamedSize(NamedSize.Default, typeof(Button)),
                WidthRequest = 60,
                IsEnabled = false,
            };
            multiplyButton.Clicked += onMultiplyButtonClicked;
            myGrid.Children.Add(multiplyButton, 3, 1);

            subtractButton = new Button
            {
                Text = "-",
                FontSize = Device.GetNamedSize(NamedSize.Default, typeof(Button)),
                WidthRequest = 60,
                IsEnabled = false,
            };
            subtractButton.Clicked += onSubtractButtonClicked;
            myGrid.Children.Add(subtractButton, 3, 2);

            addButton = new Button
            {
                Text = "+",
                FontSize = Device.GetNamedSize(NamedSize.Default, typeof(Button)),
                WidthRequest = 60,
                IsEnabled = false,
            };
            addButton.Clicked += onAddButtonClicked;
            myGrid.Children.Add(addButton, 3, 3);

            equalsButton = new Button
            {
                Text = "=",
                FontSize = Device.GetNamedSize(NamedSize.Default, typeof(Button)),
                WidthRequest = 60,
                IsEnabled = false,
            };
            equalsButton.Clicked += onEqualsButtonClicked;
            myGrid.Children.Add(equalsButton, 3, 4);

            decimalButton = new Button
            {
                Text = ".",
                FontSize = Device.GetNamedSize(NamedSize.Default, typeof(Button)),
                WidthRequest = 60,
                IsEnabled = true,
            };
            decimalButton.Clicked += onDecimalButtonClicked;
            myGrid.Children.Add(decimalButton, 2, 4);

            negateButton = new Button
            {
                Text = "+/-",
                FontSize = Device.GetNamedSize(NamedSize.Default, typeof(Button)),
                WidthRequest = 60,
                IsEnabled = true,
            };
            negateButton.Clicked += onNegateButtonClicked;
            myGrid.Children.Add(negateButton, 1, 4);

            int rowCounter = 0;
            int colCounter = 0;
            for (int num = 1; num <= 10; num++)
            {       
                if ((num - 1) % 3 == 0)
                {
                    rowCounter++;
                    colCounter = 0;
                }
                Button digitButton = new Button
                {
                    Text = (num % 10).ToString(),
                    FontSize = Device.GetNamedSize(NamedSize.Default, typeof(Button)),
                    WidthRequest = 60,
                    StyleId = (num % 10).ToString(),
                };
                digitButton.Clicked += OnDigitButtonClicked;

                myGrid.Children.Add(digitButton, colCounter, rowCounter);
                colCounter++;
                this.Content = mainStack;
                //InitializeComponent ();
            }


            void OnDigitButtonClicked(object sender, EventArgs args)
            {
                Button button = (Button)sender;
                displayLabel.Text += (string)button.StyleId;
                backspaceButton.IsEnabled = true;
                clearEntryButton.IsEnabled = true;
                clearButton.IsEnabled = true;
                divideButton.IsEnabled = true;
                multiplyButton.IsEnabled = true;
                subtractButton.IsEnabled = true;
                addButton.IsEnabled = true;
                equalsButton.IsEnabled = true;
            }

            void onBackspaceButtonClicked(object sender, EventArgs args)
            {
                string text = displayLabel.Text;
                displayLabel.Text = text.Substring(0, text.Length - 1);
                backspaceButton.IsEnabled = displayLabel.Text.Length > 0;
            }

            void onClearEntryButtonClicked(object sender, EventArgs args)
            {
                string text = displayLabel.Text;
                displayLabel.Text = text.Substring(0, text.Length - 1);
                clearEntryButton.IsEnabled = displayLabel.Text.Length > 0;
            }

            void onClearButtonClicked(object sender, EventArgs args)
            {
                string text = displayLabel.Text;
                displayLabel.Text = text.Substring(0, text.Length - 1);
                clearButton.IsEnabled = displayLabel.Text.Length > 0;
            }

            void onDivideButtonClicked(object sender, EventArgs args)
            {
                string text = displayLabel.Text;
                displayLabel.Text = text.Substring(0, text.Length - 1);
                divideButton.IsEnabled = displayLabel.Text.Length > 0;
            }

            void onMultiplyButtonClicked(object sender, EventArgs args)
            {
                string text = displayLabel.Text;
                displayLabel.Text = text.Substring(0, text.Length - 1);
                multiplyButton.IsEnabled = displayLabel.Text.Length > 0;
            }

            void onSubtractButtonClicked(object sender, EventArgs args)
            {
                string text = displayLabel.Text;
                displayLabel.Text = text.Substring(0, text.Length - 1);
                subtractButton.IsEnabled = displayLabel.Text.Length > 0;
            }

            void onAddButtonClicked(object sender, EventArgs args)
            {
                string text = displayLabel.Text;
                displayLabel.Text = text.Substring(0, text.Length - 1);
                addButton.IsEnabled = displayLabel.Text.Length > 0;
            }

            void onEqualsButtonClicked(object sender, EventArgs args)
            {
                string text = displayLabel.Text;
                displayLabel.Text = text.Substring(0, text.Length - 1);
                equalsButton.IsEnabled = displayLabel.Text.Length > 0;
            }

            void onDecimalButtonClicked(object sender, EventArgs args)
            {
                string text = displayLabel.Text;
                Button button = (Button)sender;
                displayLabel.Text += (string)button.StyleId;
            }

            void onNegateButtonClicked(object sender, EventArgs args)
            {
                Button button = (Button)sender;
                //displayLabel.Text;
            }


        }
    }
}
