using System;

namespace MenuItems.Features
{
    public class SubmenuItem : IVisible
    {
        private bool Visible;
        public string Description { get; set; }

        public SubmenuItem(Func<bool> methodVisibility)
        {
            Description = methodVisibility.Method.Name;
            Visible = methodVisibility.Invoke();
        }

        public bool IsVisible()
        {
            return Visible;
        }

        public bool Show(Func<bool> method)
        {
            return method.Method.Name == Description;
        }

        public bool Show(string methodName)
        {
            return methodName == Description;
        }
    }
}