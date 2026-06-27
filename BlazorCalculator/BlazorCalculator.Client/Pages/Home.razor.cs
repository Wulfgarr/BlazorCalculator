namespace BlazorCalculator.Client.Pages
{
    public partial class Home
    {
        private string _displayValue = "0";
        private double? _accumulator = null;
        private string _pendingOperator = null;
        private bool _waitingForNext = false;
        private void AppendInput(string input)
        {
            if (_waitingForNext)
            {
                _displayValue = "0";
                _waitingForNext = false;
            }

            if (input == ",")
            {
                if (!_displayValue.Contains(","))
                {
                    _displayValue += ",";
                }
            }
            else
            {
                if (_displayValue == "0")
                {
                    _displayValue = input;
                }
                else
                {
                    _displayValue += input;
                }
            }
        }

        private void OnOperator(string op)
        {
            if (double.TryParse(_displayValue, out double currentValue))
            {
                if (_pendingOperator != null && !_waitingForNext)
                {
                    // obliczyc wynik
                    _accumulator = Math.Round(Calculate(_accumulator ?? 0,
                        currentValue, _pendingOperator), 2);
                    _displayValue = _accumulator.ToString();
                }
                else
                {
                    _accumulator = currentValue;
                }

                _pendingOperator = op;
                _waitingForNext = true;
            }
        }

        private void OnClear()
        {
            _displayValue = "0";
            _accumulator = null;
            _pendingOperator = null;
            _waitingForNext = false;
        }

        private void OnEquals()
        {
            if (_pendingOperator != null && double.TryParse(_displayValue,
                out double currentValue))
            {
                var result = Math.Round(Calculate(_accumulator ?? 0, currentValue,
                    _pendingOperator), 2);
                _displayValue = result.ToString();
                _pendingOperator = null;
                _accumulator = null;
                _waitingForNext = true;
            }
        }

        private double Calculate(double left, double right, string op)
        {
            return op switch
            {
                "+" => left + right,
                "-" => left - right,
                "*" => left * right,
                "/" => left / right != 0 ? left / right : 0,
                _ => right
            };
        }
    }
}
