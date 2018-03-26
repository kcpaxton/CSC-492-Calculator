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
        public MainPage()
        {
            Boolean operationAdded = false;
            Boolean equalClicked = false;
            List<string> equationEntries = new List<string>();
            List<string> latestCommand = new List<string>();
            latestCommand.Add(null);
            latestCommand.Add(null);

            Label courseNameLabel;
            Label myNameLabel;
            Label displayLabel;
            Label equationLabel;
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
            this.Content = mainStack;
            this.BackgroundImage = "background.jpg";

            courseNameLabel = new Label
            {
                Text = "CSC 492 Mobile Apps",
                TextColor = Color.White,
                FontSize = Device.GetNamedSize(NamedSize.Small, typeof(Label)),
                VerticalOptions = LayoutOptions.Center,
                HorizontalTextAlignment = TextAlignment.Start
            };
            mainStack.Children.Add(courseNameLabel);

            myNameLabel = new Label
            {
                Text = "Kyle Paxton",
                TextColor = Color.White,
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
                VerticalOptions = LayoutOptions.Center,
                HorizontalTextAlignment = TextAlignment.Start
            };
            mainStack.Children.Add(myNameLabel);

            equationLabel = new Label
            {
                TextColor = Color.White,
                FontSize = Device.GetNamedSize(NamedSize.Small, typeof(Label)),
                VerticalOptions = LayoutOptions.Center,
                HorizontalTextAlignment = TextAlignment.End
            };
            mainStack.Children.Add(equationLabel);

            displayLabel = new Label
            {
                Text = "0",
                TextColor = Color.White,
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
                VerticalOptions = LayoutOptions.Center,
                HorizontalTextAlignment = TextAlignment.End
            };
            mainStack.Children.Add(displayLabel);

            Grid myGrid = new Grid();
            mainStack.Children.Add(myGrid);

            equalsButton = new Button
            {
                Text = "=",
                FontSize = Device.GetNamedSize(NamedSize.Default, typeof(Button)),
                WidthRequest = 60,
                IsEnabled = equationEntries.Count > 2,
            };
            equalsButton.Clicked += onEqualsButtonClicked;
            myGrid.Children.Add(equalsButton, 3, 4);

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
                IsEnabled = true,
                StyleId = "/",
            };
            divideButton.Clicked += onDivideButtonClicked;
            myGrid.Children.Add(divideButton, 3, 0);

            multiplyButton = new Button
            {
                Text = "*",
                FontSize = Device.GetNamedSize(NamedSize.Default, typeof(Button)),
                WidthRequest = 60,
                IsEnabled = true,
                StyleId = "*",
            };
            multiplyButton.Clicked += onMultiplyButtonClicked;
            myGrid.Children.Add(multiplyButton, 3, 1);

            subtractButton = new Button
            {
                Text = "-",
                FontSize = Device.GetNamedSize(NamedSize.Default, typeof(Button)),
                WidthRequest = 60,
                IsEnabled = true,
                StyleId = "-",
            };
            subtractButton.Clicked += onSubtractButtonClicked;
            myGrid.Children.Add(subtractButton, 3, 2);

            addButton = new Button
            {
                Text = "+",
                FontSize = Device.GetNamedSize(NamedSize.Default, typeof(Button)),
                WidthRequest = 60,
                IsEnabled = true,
                StyleId = "+",
            };
            addButton.Clicked += onAddButtonClicked;
            myGrid.Children.Add(addButton, 3, 3);

            

            decimalButton = new Button
            {
                Text = ".",
                FontSize = Device.GetNamedSize(NamedSize.Default, typeof(Button)),
                WidthRequest = 60,
                IsEnabled = true,
                StyleId = ".",
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
                
            }


            void OnDigitButtonClicked(object sender, EventArgs args)
            {
                if (displayLabel.Text == "0" || operationAdded)
                {
                    displayLabel.Text = "";
                    operationAdded = false;
                }

                Button button = (Button)sender;
                displayLabel.Text += (string)button.StyleId;

                if (latestCommand.Count != 0)
                {
                    latestCommand.RemoveAt(latestCommand.Count - 1);
                    latestCommand.Add(displayLabel.Text);
                }
                backspaceButton.IsEnabled = true;
                clearEntryButton.IsEnabled = true;
                clearButton.IsEnabled = true;
            }

            void onBackspaceButtonClicked(object sender, EventArgs args)
            {
                clearPreviouslyCalculated();
                string text = displayLabel.Text;
                
                if (displayLabel.Text != "0")
                {
                    displayLabel.Text = text.Substring(0, text.Length - 1);
                    backspaceButton.IsEnabled = displayLabel.Text.Length > 0;
                    equalsButton.IsEnabled = equationEntries.Count > 1;
                    if (displayLabel.Text == "")
                    {
                        displayLabel.Text = "0";
                    }
                }
            }

            void onClearEntryButtonClicked(object sender, EventArgs args)
            {
                clearPreviouslyCalculated();
                displayLabel.Text = "0";
                backspaceButton.IsEnabled = false;
                equalsButton.IsEnabled = equationEntries.Count > 1;
            }

            void onClearButtonClicked(object sender, EventArgs args)
            {
                clearPreviouslyCalculated();
                displayLabel.Text = "0";
                equationEntries.Clear();
                updateEquationText();
                backspaceButton.IsEnabled = false;
                equalsButton.IsEnabled = false;
            }

            void onDivideButtonClicked(object sender, EventArgs args)
            {
                clearPreviouslyCalculated();
                checkFloatingDecimal();
                Button button = (Button)sender;
                updateEquationList((string)button.StyleId, displayLabel.Text);
                updateLatestCommandList((string)button.StyleId, displayLabel.Text);
                equalsButton.IsEnabled = equationEntries.Count > 1;
                operationAdded = true;

            }

            void onMultiplyButtonClicked(object sender, EventArgs args)
            {
                clearPreviouslyCalculated();
                checkFloatingDecimal();
                Button button = (Button)sender;
                updateEquationList((string)button.StyleId, displayLabel.Text);
                updateLatestCommandList((string)button.StyleId, displayLabel.Text);
                equalsButton.IsEnabled = equationEntries.Count > 1;
                operationAdded = true;
            }

            void onSubtractButtonClicked(object sender, EventArgs args)
            {
                clearPreviouslyCalculated();
                checkFloatingDecimal();
                Button button = (Button)sender;
                updateEquationList((string)button.StyleId, displayLabel.Text);
                updateLatestCommandList((string)button.StyleId, displayLabel.Text);
                equalsButton.IsEnabled = equationEntries.Count > 1;
                operationAdded = true;
            }

            void onAddButtonClicked(object sender, EventArgs args)
            {
                clearPreviouslyCalculated();
                checkFloatingDecimal();
                Button button = (Button)sender;
                updateEquationList((string)button.StyleId, displayLabel.Text);
                updateLatestCommandList((string)button.StyleId, displayLabel.Text);
                equalsButton.IsEnabled = equationEntries.Count > 1;
                operationAdded = true;
            }

            void onDecimalButtonClicked(object sender, EventArgs args)
            {
                clearPreviouslyCalculated();
                if (!displayLabel.Text.Contains("."))
                {
                    Button button = (Button)sender;
                    displayLabel.Text += (string)button.StyleId;
                }
            }

            void onNegateButtonClicked(object sender, EventArgs args)
            {
                Button button = (Button)sender;
                if(displayLabel.Text[0] == '-')
                {
                    displayLabel.Text = displayLabel.Text.Remove(0);
                }
                else
                {
                    displayLabel.Text = displayLabel.Text.Insert(0, "-");
                }
            }

            void onEqualsButtonClicked(object sender, EventArgs args)
            {
                checkFloatingDecimal();
                operationAdded = true;
                 
                if (equalClicked == false)
                {
                    if (equationEntries.Count == 0)
                    {
                        equationLabel.Text = "Cannot evaluate with no entries";
                    }
                    else
                    {
                        executeCalculation();   
                    }
                }
                else
                {
                    executeLatestCommand();
                }

            }

            void updateEquationList(string currentOperation, string currentTerm)
            {
                equationEntries.Add(currentTerm);
                equationEntries.Add(currentOperation);
                updateEquationText();
            }

            void updateLatestCommandList(string currentOperation, string currentTerm)
            {
                //adds operation first then term 
                // * 5
                latestCommand.Add(currentOperation);
                latestCommand.Add(currentTerm);
            }

            void updateEquationText()
            {
                equationLabel.Text = "";
                foreach(string item in equationEntries)
                {
                    equationLabel.Text += item;
                    equationLabel.Text += ' ';
                }
            }

            void checkFloatingDecimal()
            {
                if(displayLabel.Text[displayLabel.Text.Length - 1] == '.')
                {
                    displayLabel.Text = displayLabel.Text.Substring(0, displayLabel.Text.Length - 1);
                }
            }

            void clearPreviouslyCalculated()
            {
                equalClicked = false;
                latestCommand.Clear();
            }
            
            void executeCalculation()
            {
                int i = 0;
                double subtotal = 0;
                double term = 0;
                double.TryParse(equationEntries[i], out subtotal);
                while (i < equationEntries.Count)
                {
                    double.TryParse(equationEntries[i], out term);
                    i = i + 1;
                    if (equationEntries[i] == "*")
                    {

                        //check if there is another entry
                        if (i + 1 < equationEntries.Count)
                        {
                            i = i + 1;
                            subtotal = subtotal * double.Parse(equationEntries[i]);
                        }
                        else
                        {
                            i = i + 1;
                            subtotal = subtotal * double.Parse(displayLabel.Text);
                        }

                    }
                    else if (equationEntries[i] == "+")
                    {
                        //check if there is another entry
                        if (i + 1 < equationEntries.Count)
                        {
                            i = i + 1;
                            subtotal = subtotal + double.Parse(equationEntries[i]);
                        }
                        else
                        {
                            i = i + 1;
                            subtotal = subtotal + double.Parse(displayLabel.Text);
                        }
                    }
                    else if (equationEntries[i] == "-")
                    {
                        //check if there is another entry
                        if (i + 1 < equationEntries.Count)
                        {
                            i = i + 1;
                            subtotal = subtotal - double.Parse(equationEntries[i]);
                        }
                        else
                        {
                            i = i + 1;
                            subtotal = subtotal - double.Parse(displayLabel.Text);
                        }
                    }
                    else if (equationEntries[i] == "/")
                    {
                        //check if there is another entry
                        if (i + 1 < equationEntries.Count)
                        {
                            i = i + 1;
                            subtotal = subtotal / double.Parse(equationEntries[i]);
                        }
                        else
                        {
                            i = i + 1;
                            subtotal = subtotal / double.Parse(displayLabel.Text);
                        }
                    }

                }
                equationEntries.Clear();
                equationLabel.Text = "";
                equalClicked = true;
                displayLabel.Text = subtotal.ToString();
            }

            void executeLatestCommand()
            {
                double subtotal = 0;
                double term = 0;
                double.TryParse(displayLabel.Text, out subtotal);
                if (latestCommand.Count > 0)
                {
                    double.TryParse(latestCommand[1], out term);

                    if (latestCommand[0] == "*")
                    {
                        subtotal = subtotal * double.Parse(latestCommand[1]);
                    }
                    else if (latestCommand[0] == "+")
                    {
                        subtotal = subtotal + double.Parse(latestCommand[1]);
                    }
                    else if (latestCommand[0] == "-")
                    {
                        subtotal = subtotal - double.Parse(latestCommand[1]);
                    }
                    else if (latestCommand[0] == "/")
                    {
                        subtotal = subtotal / double.Parse(latestCommand[1]);
                    }

                    equationLabel.Text = "";
                    equalClicked = true;
                    displayLabel.Text = subtotal.ToString();
                }
            }
        }
    }
}
