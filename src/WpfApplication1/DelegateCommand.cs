using System;
using System.Windows.Input;
using WpfApplication1.Annotations;

namespace WpfApplication1
{
    public class DelegateCommand<T> : ICommand
    {
        private readonly Action<T> _executeFunc;
        private readonly Func<T, bool> _canExecuteFunc;

        public DelegateCommand([NotNull] Action<T> executeFunc, Func<T, bool> canExecuteFunc = null)
        {
            if (executeFunc == null) throw new ArgumentNullException("executeFunc");
            _executeFunc = executeFunc;
            _canExecuteFunc = canExecuteFunc;
        }

        public bool CanExecute(object parameter)
        {
            return _canExecuteFunc == null || _canExecuteFunc((T) parameter);
        }

        public void Execute(object parameter)
        {
            _executeFunc((T) parameter);
        }

        public event EventHandler CanExecuteChanged;

        public virtual void OnCanExecuteChanged()
        {
            var handler = CanExecuteChanged;
            if (handler != null) handler(this, EventArgs.Empty);
        }
    }
}